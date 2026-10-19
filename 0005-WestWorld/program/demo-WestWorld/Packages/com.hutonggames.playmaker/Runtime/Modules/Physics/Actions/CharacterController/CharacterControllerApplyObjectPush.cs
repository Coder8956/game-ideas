using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.CharacterController)]
    [ActionDescription("Applies motion from overlapping moving objects to a CharacterController move vector. " +
                       "Object motion is detected automatically from Rigidbody velocity or tracked Transform motion. " +
                       "<br/>Apply the final Move Vector using CharacterController Move or CharacterController Simple Move.")]
    public sealed class CharacterControllerApplyObjectPush : BaseAction
    {
        private const float MinDeltaTime = 0.0001f;
        private readonly Collider[] _overlapHits = new Collider[16];
        private readonly Dictionary<Transform, Vector3> _trackedPositions = new();

        private int PushLayerMask => _pushLayers?.Value ?? Physics.DefaultRaycastLayers;
        private bool UseLocalSpace => _localSpace != null && _localSpace.Value;
        private bool OnlyWhenGrounded => _onlyWhenGrounded != null && _onlyWhenGrounded.Value;
        private bool AffectX => _affectX == null || _affectX.Value;
        private bool AffectY => _affectY == null || _affectY.Value;
        private bool AffectZ => _affectZ == null || _affectZ.Value;
        private float MaxPushSpeed => _maxPushSpeed != null && !_maxPushSpeed.IsNone ? _maxPushSpeed.Value : 0f;

        public enum PushMode
        {
            Motion,
            AwayFromCenter,
            AwayFromCenterOrthogonal,
            AwayFromCenterXZ,
            AwayFromCenterXY
        }

        [ActionHeader("Inputs")]

        [Tooltip("The CharacterController to push.")]
        [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("Layers treated as push objects.")]
        [SerializeField, DefaultValue("Physics.DefaultRaycastLayers")]
        private LayerMaskVar _pushLayers;

        [OptionalField]
        [Tooltip("Optional tag filter for push objects.")]
        [SerializeField]
        private StringVar _requiredTag;

        [Tooltip("Only apply push while the CharacterController is grounded.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _onlyWhenGrounded;

        [Tooltip("How to derive the push direction from the pushing object's motion.")]
        [SerializeField]
        private PushMode _pushMode;

        [Tooltip("Return the push vector in CharacterController local space instead of world space.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _localSpace;

        [Tooltip("Apply push on the X axis.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _affectX;

        [Tooltip("Apply push on the Y axis.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _affectY;

        [Tooltip("Apply push on the Z axis.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _affectZ;

        [Tooltip("Maximum push speed to apply. Use 0 or a negative value to disable clamping.")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _maxPushSpeed;

        [Tooltip("Specifies whether overlap checks should hit Triggers.")]
        [SerializeField, DefaultValue(QueryTriggerInteraction.Ignore)]
        private QueryTriggerInteraction _hitTriggers;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("Move vector to update. The selected push vector is added to this value.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _moveVector;

        [OptionalField]
        [Tooltip("True when a pushing object was found and contributed motion this frame.")]
        [SerializeField, WriteOnly]
        private BoolRef _wasPushed;

        [OptionalField]
        [Tooltip("The push vector selected this frame.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _pushVector;

        [OptionalField]
        [Tooltip("The pushing object selected this frame.")]
        [SerializeField, WriteOnly]
        private GameObjectRef _pushingObject;

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        public override bool CanExecute() => CheckParameters(_characterController, _pushLayers);

        public override void OnStateEnter()
        {
            _trackedPositions.Clear();
            ClearOutputs();
        }

        public override void OnStateExit()
        {
            _trackedPositions.Clear();
        }

        public override void Execute()
        {
            ClearOutputs();

            var controller = _characterController.Value;
            if (!controller)
            {
                return;
            }

            if (OnlyWhenGrounded && !controller.isGrounded)
            {
                return;
            }

            var (point0, point1, radius) = GetCapsule(controller, controller.transform.position);
            var hitCount = Physics.OverlapCapsuleNonAlloc(point0,
                                                          point1,
                                                          radius,
                                                          _overlapHits,
                                                          PushLayerMask,
                                                          _hitTriggers);

            Collider bestCollider = null;
            var bestMotion = Vector3.zero;
            var bestMotionSqr = 0f;
            var bestPenetration = 0f;

            for (var i = 0; i < hitCount; ++i)
            {
                var hit = _overlapHits[i];
                if (!IsPushCandidate(hit, controller))
                {
                    continue;
                }

                var motion = GetObjectMotion(hit);
                motion = GetPushMotion(controller, hit, motion);

                var motionSqr = motion.sqrMagnitude;
                if (motionSqr <= Mathf.Epsilon)
                {
                    continue;
                }

                var penetration = 0f;
                if (Physics.ComputePenetration(hit,
                                               hit.transform.position,
                                               hit.transform.rotation,
                                               controller,
                                               controller.transform.position,
                                               controller.transform.rotation,
                                               out _,
                                               out var distance))
                {
                    penetration = distance;
                }

                if (motionSqr < bestMotionSqr - Mathf.Epsilon)
                {
                    continue;
                }

                if (Mathf.Abs(motionSqr - bestMotionSqr) <= Mathf.Epsilon && penetration <= bestPenetration)
                {
                    continue;
                }

                bestCollider = hit;
                bestMotion = motion;
                bestMotionSqr = motionSqr;
                bestPenetration = penetration;
            }

            if (!bestCollider)
            {
                return;
            }

            var push = bestMotion;
            if (UseLocalSpace)
            {
                push = controller.transform.InverseTransformDirection(push);
            }

            if (!AffectX) push.x = 0f;
            if (!AffectY) push.y = 0f;
            if (!AffectZ) push.z = 0f;

            var maxPushSpeed = MaxPushSpeed;
            if (maxPushSpeed > 0f)
            {
                push = Vector3.ClampMagnitude(push, maxPushSpeed);
            }

            if (push.sqrMagnitude <= Mathf.Epsilon)
            {
                return;
            }

            if (_moveVector != null && !_moveVector.IsNone)
            {
                _moveVector.Value += push;
            }

            if (_wasPushed != null && _wasPushed.IsAssigned)
            {
                _wasPushed.Value = true;
            }

            if (_pushVector != null && _pushVector.IsAssigned)
            {
                _pushVector.Value = push;
            }

            if (_pushingObject != null && _pushingObject.IsAssigned)
            {
                _pushingObject.Value = bestCollider.gameObject;
            }
        }

        public override string GetSummary()
        {
            return "Apply object push to {_characterController} {_moveVector:output} {_pushVector:output} {_pushingObject:output}";
        }

        private Vector3 GetObjectMotion(Collider collider)
        {
            var body = collider.attachedRigidbody;
            if (body && !body.isKinematic)
            {
#if UNITY_6000_0_OR_NEWER
                return body.linearVelocity;
#else
                return body.velocity;
#endif
            }

            var transformCache = body ? body.transform : collider.transform;
            var currentPosition = transformCache.position;

            if (!_trackedPositions.TryGetValue(transformCache, out var previousPosition))
            {
                _trackedPositions[transformCache] = currentPosition;
                return Vector3.zero;
            }

            _trackedPositions[transformCache] = currentPosition;
            if (DeltaTime < MinDeltaTime)
            {
                return Vector3.zero;
            }

            return (currentPosition - previousPosition) / DeltaTime;
        }

        private bool IsPushCandidate(Collider hit, CharacterController controller)
        {
            if (!hit)
            {
                return false;
            }

            var controllerTransform = controller.transform;
            var hitTransform = hit.transform;
            if (hit == controller
                || hitTransform == controllerTransform
                || hitTransform.IsChildOf(controllerTransform)
                || hitTransform.root == controllerTransform.root)
            {
                return false;
            }

            if (_requiredTag != null && !_requiredTag.IsNoneOrNull && !hit.CompareTag(_requiredTag.Value))
            {
                return false;
            }

            return true;
        }

        private Vector3 GetPushMotion(CharacterController controller, Collider collider, Vector3 motion)
        {
            return _pushMode switch
            {
                PushMode.AwayFromCenter => BiasAwayFromCenter(controller, collider, motion),
                PushMode.AwayFromCenterOrthogonal => BiasAwayFromCenterOrthogonal(controller, collider, motion),
                PushMode.AwayFromCenterXZ => BiasAwayFromCenterOnPlane(controller, collider, motion, Vector3.up),
                PushMode.AwayFromCenterXY => BiasAwayFromCenterOnPlane(controller, collider, motion, Vector3.forward),
                _ => motion
            };
        }

        private static Vector3 BiasAwayFromCenter(CharacterController controller, Collider collider, Vector3 motion)
        {
            var speed = motion.magnitude;
            if (speed <= Mathf.Epsilon)
            {
                return motion;
            }

            var away = GetControllerWorldCenter(controller) - collider.bounds.center;
            if (away.sqrMagnitude <= Mathf.Epsilon)
            {
                return motion;
            }

            return away.normalized * speed;
        }

        private static Vector3 BiasAwayFromCenterOnPlane(CharacterController controller, Collider collider, Vector3 motion, Vector3 planeNormal)
        {
            var speed = motion.magnitude;
            if (speed <= Mathf.Epsilon)
            {
                return motion;
            }

            var away = GetControllerWorldCenter(controller) - collider.bounds.center;
            away = Vector3.ProjectOnPlane(away, planeNormal);
            if (away.sqrMagnitude <= Mathf.Epsilon)
            {
                // Keep the result on the plane even when the center aligns directly above/below.
                var controllerTransform = controller.transform;
                var right = Vector3.ProjectOnPlane(controllerTransform.right, planeNormal);
                if (right.sqrMagnitude <= Mathf.Epsilon)
                {
                    right = Vector3.ProjectOnPlane(Vector3.right, planeNormal);
                }

                if (right.sqrMagnitude <= Mathf.Epsilon)
                {
                    return Vector3.zero;
                }

                return right.normalized * speed;
            }

            return away.normalized * speed;
        }

        private static Vector3 BiasAwayFromCenterOrthogonal(CharacterController controller, Collider collider, Vector3 motion)
        {
            if (motion.sqrMagnitude <= Mathf.Epsilon)
            {
                return motion;
            }

            return BiasAwayFromCenterOnPlane(controller, collider, motion, motion.normalized);
        }

        private static Vector3 GetControllerWorldCenter(CharacterController controller)
        {
            var transformCache = controller.transform;
            return transformCache.TransformPoint(controller.center);
        }

        private static (Vector3 point0, Vector3 point1, float radius) GetCapsule(CharacterController controller, Vector3 position)
        {
            var transformCache = controller.transform;
            var absScale = Abs(transformCache.lossyScale);
            var radius = controller.radius * Mathf.Max(absScale.x, absScale.z);
            var scaledHeight = Mathf.Max(controller.height * absScale.y, radius * 2f);
            var worldCenter = transformCache.TransformPoint(controller.center) + (position - transformCache.position);
            var pointOffset = Mathf.Max(0f, scaledHeight * 0.5f - radius);
            var up = transformCache.up;
            return (worldCenter + up * pointOffset, worldCenter - up * pointOffset, radius);
        }

        private static Vector3 Abs(Vector3 value)
        {
            return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
        }

        private void ClearOutputs()
        {
            if (_wasPushed != null && _wasPushed.IsAssigned)
            {
                _wasPushed.Value = false;
            }

            if (_pushVector != null && _pushVector.IsAssigned)
            {
                _pushVector.Value = Vector3.zero;
            }

            if (_pushingObject != null && _pushingObject.IsAssigned)
            {
                _pushingObject.Value = null;
            }
        }
    }
}

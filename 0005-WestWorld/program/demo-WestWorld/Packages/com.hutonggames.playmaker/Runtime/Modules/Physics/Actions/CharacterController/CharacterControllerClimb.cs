using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.CharacterController)]
    [ActionDescription("Moves a CharacterController while climbing. " +
                       "Requires a climb target that defines the climb axes and provides bounds used to constrain climb motion and detect top and bottom.")]
    public sealed class CharacterControllerClimb : BaseAction
    {
        private const float TopLimitEventEpsilon = 0.001f;
        private const float PathConstraintDeadZone = 0.01f;

        public enum ClimbMode
        {
            ExplicitInput,
            LookDirection
        }

        public enum HorizontalConstraintMode
        {
            FreeWithinBounds,
            CenterLine
        }

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The CharacterController to move.")]
        [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("The climb target transform." +
                 "<br/>Up defines climb direction, right defines left/right motion, " +
                 "and its bounds can define ladder top/bottom limits.")]
        [SerializeField]
        private TransformVar _climbTarget;

        [Tooltip("Climb input mode." +
                 "<br/><b>Explicit Input</b> uses Input.y for up/down." +
                 "<br/><b>Look Direction</b> uses Input.y as forward/back and derives up/down from the current look direction.")]
        [SerializeField, DefaultValue(ClimbMode.ExplicitInput)]
        private ClimbMode _climbMode;

        [Tooltip("Movement input.<br/>X controls left/right motion.\nY controls up/down in Explicit Input mode or forward/back intent in Look Direction mode.")]
        [SerializeField]
        private Vector2Var _input;

        [Tooltip("Climb speed along the climb up axis.")]
        [SerializeField, DefaultValue(3f)]
        private FloatVar _climbSpeed;

        [Tooltip("Sideways speed along the climb right axis.")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _horizontalSpeed;

        [ActionHeader("Constraints")]

        [Tooltip("How horizontal motion is constrained while climbing." +
                 "<br/><b>Free Within Bounds</b> allows lateral movement within the climb target bounds." +
                 "<br/><b>Center Line</b> pulls the controller toward the climb target center line, similar to a ladder that recenters the player.")]
        [SerializeField, DefaultValue(HorizontalConstraintMode.FreeWithinBounds)]
        private HorizontalConstraintMode _horizontalConstraintMode;
        
        [Tooltip("Optional offset from the climb target surface along its local forward/back axis." +
                 "<br/>Use this to maintain a fixed stand-off distance while climbing ladders or walls.")]
        [FormerlySerializedAs("_pathOffset")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _surfaceOffset;
        
        [Tooltip("Maximum correction speed used to keep the controller aligned to the climb target." +
                 "<br/>This enforces side-to-side centering in Center Line mode and forward/back surface stand-off in all modes." +
                 "<br/>Higher values snap onto the authored climb path faster. Lower values allow softer drift before recentering.")]
        [SerializeField, DefaultValue(2f)]
        [FormerlySerializedAs("_pathSnapSpeed")]
        private FloatVar _snapSpeed;

        [ActionHeader("Look Direction")]

        [Tooltip("Optional transform used to read look direction in Look Direction mode. " +
                 "If omitted, uses the CharacterController transform.")]
        [SerializeField, HideIf(nameof(HideLookDirectionSettings))]
        private TransformVar _lookTransform;

        [Tooltip("Ignore very small look-up/look-down values in Look Direction mode. " +
                 "Useful when the character is looking almost level.")]
        [SerializeField, DefaultValue(0.05f), HideIf(nameof(HideLookDirectionSettings))]
        private FloatVar _lookDeadZone;

        [Tooltip("Use a fixed climb speed in Look Direction mode. " +
                 "The look angle still decides up vs down, but no longer scales climb speed.")]
        [SerializeField, DefaultValue(true), HideIf(nameof(HideLookDirectionSettings))]
        private BoolVar _useFixedClimbSpeed;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("Event to send once when the top climb limit is reached.")]
        [SerializeField]
        private EventRef _reachedTopEvent;

        [OptionalField]
        [Tooltip("Event to send once when the bottom climb limit is reached.")]
        [SerializeField]
        private EventRef _reachedBottomEvent;

        [OptionalField]
        [Tooltip("Store whether the CharacterController is currently at the top climb limit.")]
        [SerializeField, WriteOnly]
        private BoolRef _isAtTop;

        [OptionalField]
        [Tooltip("Store whether the CharacterController is currently at the bottom climb limit.")]
        [SerializeField, WriteOnly]
        private BoolRef _isAtBottom;

        [OptionalField]
        [Tooltip("Indicates the direction of a collision: None, Sides, Above, and Below.")]
        [SerializeField, WriteOnly]
        private CollisionFlagsRef _collisionFlags;

        [OptionalField]
        [Tooltip("Optional world-space motion applied this frame before collision response.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _moveVector;

        private Transform _cachedTransform;
        private float _startBottomOffset;
        private float _leftOffset;
        private float _rightOffset;
        private bool _wasAtTop;
        private bool _wasAtBottom;
        private bool _topEventArmed;
        private bool _bottomEventArmed;

        public override bool CanUsePerSecond => false;

        public override bool CanExecute() =>
            CheckParameters(
                _characterController,
                _climbTarget,
                _input,
                _climbSpeed,
                _horizontalSpeed,
                _snapSpeed,
                _surfaceOffset,
                _useFixedClimbSpeed) && HasClimbTargetBounds();

        public override void OnStart()
        {
            var controller = _characterController.Value;
            if (!controller)
            {
                return;
            }

            _cachedTransform = controller.transform;
            UpdateLimitStates(0f);
        }

        public override void Execute()
        {
            var controller = _characterController.Value;
            if (!controller)
            {
                return;
            }

            if (_cachedTransform == null)
            {
                _cachedTransform = controller.transform;
                UpdateLimitStates(0f);
            }

            var upAxis = GetUpAxis();
            var rightAxis = GetRightAxis(upAxis);
            var input = _input.Value;
            var climbInput = GetClimbInput(upAxis, input.y);

            var move = upAxis * (climbInput * _climbSpeed.Value)
                       + rightAxis * (input.x * _horizontalSpeed.Value);
            move *= DeltaTime;
            move = ApplyVerticalLimits(move, upAxis);
            move = ApplyTrackConstraint(move);
            move = ApplyHorizontalLimits(move, rightAxis);

            if (_moveVector is { IsAssigned: true })
            {
                _moveVector.Value = move;
            }

            var collisionFlags = controller.Move(move);
            if (_collisionFlags is { IsAssigned: true })
            {
                _collisionFlags.Value = collisionFlags;
            }

            UpdateLimitStates(climbInput);
        }

        public override string GetSummary()
        {
            return "{_characterController} climb {_climbTarget} with {_input}";
        }

        private Vector3 ApplyVerticalLimits(Vector3 move, Vector3 upAxis)
        {
            if (!TryGetProjectedBoundsRange(upAxis, out var min, out var max))
            {
                return move;
            }

            CacheControllerLimitOffsets(upAxis);
            var deltaOffset = Vector3.Dot(move, upAxis);
            var currentTop = Vector3.Dot(_cachedTransform.position, upAxis);
            var currentBottom = currentTop + _startBottomOffset;
            var unclampedTargetBottom = currentBottom + deltaOffset;
            var unclampedTargetTop = currentTop + deltaOffset;

            var correction = 0f;

            if (unclampedTargetTop > max)
            {
                correction = max - unclampedTargetTop;
            }
            else if (unclampedTargetBottom < min)
            {
                correction = min - unclampedTargetBottom;
            }

            return move + upAxis * correction;
        }

        private Vector3 ApplyHorizontalLimits(Vector3 move, Vector3 rightAxis)
        {
            if (!TryGetProjectedBoundsRange(rightAxis, out var min, out var max))
            {
                return move;
            }

            CacheControllerHorizontalLimitOffsets(rightAxis);
            var controllerWidth = _rightOffset - _leftOffset;
            if (max - min <= controllerWidth + Mathf.Epsilon)
            {
                return move;
            }

            var deltaOffset = Vector3.Dot(move, rightAxis);
            var currentCenter = Vector3.Dot(_cachedTransform.position, rightAxis);
            var currentLeft = currentCenter + _leftOffset;
            var currentRight = currentCenter + _rightOffset;
            var unclampedTargetLeft = currentLeft + deltaOffset;
            var unclampedTargetRight = currentRight + deltaOffset;

            // When already outside the horizontal band, do not snap back inside in one frame.
            // Only block movement that would push farther out. Center-line/path snapping can bring
            // the controller back in over time.
            if (currentRight > max + Mathf.Epsilon)
            {
                if (deltaOffset > 0f)
                {
                    return move - rightAxis * deltaOffset;
                }

                return move;
            }

            if (currentLeft < min - Mathf.Epsilon)
            {
                if (deltaOffset < 0f)
                {
                    return move - rightAxis * deltaOffset;
                }

                return move;
            }

            var correction = 0f;
            if (unclampedTargetRight > max)
            {
                correction = max - unclampedTargetRight;
            }
            else if (unclampedTargetLeft < min)
            {
                correction = min - unclampedTargetLeft;
            }

            return move + rightAxis * correction;
        }

        private Vector3 ApplyTrackConstraint(Vector3 move)
        {
            if (_cachedTransform == null)
            {
                return move;
            }

            var reference = _climbTarget.Value;
            if (!reference)
            {
                return move;
            }

            var snapSpeed = Mathf.Max(0f, _snapSpeed.Value);
            if (snapSpeed <= Mathf.Epsilon)
            {
                return move;
            }

            var snapWorld = Vector3.zero;
            var depthError = GetPathConstraintAxisError(GetPathConstraintSurfaceLocalZ(reference), _surfaceOffset.Value);
            if (!Mathf.Approximately(depthError, 0f))
            {
                snapWorld += GetPathConstraintDepthAxis(reference) * depthError;
            }

            if (_horizontalConstraintMode == HorizontalConstraintMode.CenterLine)
            {
                var lateralAxis = GetPathConstraintLateralAxis(reference);
                var lateralError = GetPathConstraintLateralError(reference, lateralAxis);
                if (!Mathf.Approximately(lateralError, 0f))
                {
                    snapWorld += lateralAxis * lateralError;
                }
            }

            if (snapWorld.sqrMagnitude <= PathConstraintDeadZone * PathConstraintDeadZone)
            {
                return move;
            }

            var maxCorrection = snapSpeed * DeltaTime;
            var clampedSnapWorld = Vector3.ClampMagnitude(snapWorld, maxCorrection);
            return move + clampedSnapWorld;
        }

        private static float GetPathConstraintAxisError(float current, float target)
        {
            var offset = target - current;
            if (Mathf.Abs(offset) <= PathConstraintDeadZone)
            {
                return 0f;
            }

            return offset;
        }

        private Vector3 GetPathConstraintLateralAxis(Transform reference)
        {
            var upAxis = GetUpAxis();
            var lateralAxis = Vector3.ProjectOnPlane(reference.right, Vector3.up);
            if (lateralAxis.sqrMagnitude <= Mathf.Epsilon)
            {
                lateralAxis = Vector3.ProjectOnPlane(reference.right, upAxis);
            }

            if (lateralAxis.sqrMagnitude <= Mathf.Epsilon)
            {
                lateralAxis = Vector3.right;
            }

            return lateralAxis.normalized;
        }

        private float GetPathConstraintLateralError(Transform reference, Vector3 lateralAxis)
        {
            var anchor = GetPathConstraintAnchorWorldPosition();
            var current = Vector3.Dot(anchor, lateralAxis);
            var target = Vector3.Dot(reference.position, lateralAxis);
            return GetPathConstraintAxisError(current, target);
        }

        private Vector3 GetPathConstraintDepthAxis(Transform reference)
        {
            var depthAxis = Vector3.ProjectOnPlane(reference.forward, Vector3.up);
            if (depthAxis.sqrMagnitude <= Mathf.Epsilon)
            {
                depthAxis = reference.forward;
            }

            return depthAxis.sqrMagnitude <= Mathf.Epsilon ? Vector3.forward : depthAxis.normalized;
        }

        private Vector3 GetPathConstraintAnchorWorldPosition()
        {
            var controller = _characterController.Value;
            if (!controller || _cachedTransform == null)
            {
                return _cachedTransform ? _cachedTransform.position : Vector3.zero;
            }

            GetControllerCapsuleSphereCentersWorld(controller, out _, out var bottomSphereCenterWorld);
            return bottomSphereCenterWorld;
        }

        private float GetPathConstraintSurfaceLocalZ(Transform reference)
        {
            var controller = _characterController.Value;
            if (!controller || _cachedTransform == null || !reference)
            {
                return reference ? reference.InverseTransformPoint(GetPathConstraintAnchorWorldPosition()).z : 0f;
            }

            GetControllerCapsuleSphereCentersWorld(controller, out _, out var bottomSphereCenterWorld);
            var bottomLocal = reference.InverseTransformPoint(bottomSphereCenterWorld);
            return bottomLocal.z - controller.radius;
        }

        private void GetControllerCapsuleSphereCentersWorld(CharacterController controller,
                                                            out Vector3 topSphereCenterWorld,
                                                            out Vector3 bottomSphereCenterWorld)
        {
            var centerWorld = _cachedTransform.TransformPoint(controller.center);
            var controllerUp = _cachedTransform.up.sqrMagnitude <= Mathf.Epsilon
                ? Vector3.up
                : _cachedTransform.up.normalized;
            var sphereOffset = Mathf.Max(controller.height * 0.5f - controller.radius, 0f);

            topSphereCenterWorld = centerWorld + controllerUp * sphereOffset;
            bottomSphereCenterWorld = centerWorld - controllerUp * sphereOffset;
        }

        private float GetClimbInput(Vector3 upAxis, float forwardInput)
        {
            if (_climbMode == ClimbMode.ExplicitInput)
            {
                return forwardInput;
            }

            var lookAmount = GetLookAmount(upAxis);
            if (Mathf.Abs(lookAmount) <= Mathf.Abs(_lookDeadZone.Value))
            {
                return 0f;
            }

            if (_useFixedClimbSpeed.Value)
            {
                if (Mathf.Approximately(forwardInput, 0f))
                {
                    return 0f;
                }

                return Mathf.Sign(lookAmount) * Mathf.Sign(forwardInput);
            }

            return forwardInput * lookAmount;
        }

        private float GetLookAmount(Vector3 upAxis)
        {
            var lookForward = GetLookForward();
            return Vector3.Dot(lookForward, upAxis);
        }

        private Vector3 GetRightAxis(Vector3 upAxis)
        {
            var right = GetConstraintRightAxis(upAxis);

            // Keep positive horizontal input aligned with the character's current right side.
            if (_cachedTransform != null && Vector3.Dot(right, _cachedTransform.right) < 0f)
            {
                right = -right;
            }

            return right;
        }

        private Vector3 GetConstraintRightAxis(Vector3 upAxis)
        {
            var reference = _climbTarget.Value;
            var right = reference.right;
            right = Vector3.ProjectOnPlane(right, upAxis);

            if (right.sqrMagnitude <= Mathf.Epsilon)
            {
                right = Vector3.ProjectOnPlane(Vector3.right, upAxis);
            }

            if (right.sqrMagnitude <= Mathf.Epsilon)
            {
                right = Vector3.Cross(upAxis, _cachedTransform.forward);
            }

            if (right.sqrMagnitude <= Mathf.Epsilon)
            {
                right = Vector3.Cross(upAxis, Vector3.forward);
            }

            if (right.sqrMagnitude <= Mathf.Epsilon)
            {
                return Vector3.right;
            }

            right.Normalize();
            return right;
        }

        private Vector3 GetUpAxis()
        {
            var up = _climbTarget.Value.up;
            return up.sqrMagnitude <= Mathf.Epsilon ? Vector3.up : up.normalized;
        }

        private Vector3 GetLookForward()
        {
            var lookTransform = _lookTransform != null && !_lookTransform.IsNone
                ? _lookTransform.Value
                : _cachedTransform;

            if (!lookTransform)
            {
                return Vector3.forward;
            }

            var forward = lookTransform.forward;
            return forward.sqrMagnitude <= Mathf.Epsilon ? Vector3.forward : forward.normalized;
        }

        private void UpdateLimitStates(float climbInput)
        {
            if (_cachedTransform == null)
            {
                _wasAtTop = false;
                _wasAtBottom = false;
                _topEventArmed = false;
                _bottomEventArmed = false;
                if (_isAtTop is { IsAssigned: true }) _isAtTop.Value = false;
                if (_isAtBottom is { IsAssigned: true }) _isAtBottom.Value = false;
                return;
            }

            var upAxis = GetUpAxis();
            if (!TryGetProjectedBoundsRange(upAxis, out var min, out var max))
            {
                _wasAtTop = false;
                _wasAtBottom = false;
                if (_isAtTop is { IsAssigned: true }) _isAtTop.Value = false;
                if (_isAtBottom is { IsAssigned: true }) _isAtBottom.Value = false;
                return;
            }

            CacheControllerLimitOffsets(upAxis);
            var controller = _characterController.Value;
            var currentTop = Vector3.Dot(_cachedTransform.position, upAxis);
            var currentBottom = currentTop + _startBottomOffset;
            var bottomLimitEpsilon = controller ? Mathf.Max(controller.skinWidth, 0.001f) : 0.001f;
            var isAtTop = currentTop >= max - TopLimitEventEpsilon;
            var isAtBottom = currentBottom <= min + bottomLimitEpsilon;

            if (_isAtTop is { IsAssigned: true }) _isAtTop.Value = isAtTop;
            if (_isAtBottom is { IsAssigned: true }) _isAtBottom.Value = isAtBottom;

            if (!isAtTop)
            {
                _topEventArmed = true;
            }

            if (!isAtBottom)
            {
                _bottomEventArmed = true;
            }

            if (ShouldSendTopEvent(climbInput, isAtTop, _wasAtTop, _topEventArmed))
            {
                SendEvent(_reachedTopEvent);
            }

            if (ShouldSendBottomEvent(isAtBottom, _wasAtBottom, _bottomEventArmed))
            {
                SendEvent(_reachedBottomEvent);
            }

            _wasAtTop = isAtTop;
            _wasAtBottom = isAtBottom;
        }

        private bool HasClimbTargetBounds()
        {
            if (TryGetClimbTargetBounds(out _))
            {
                return true;
            }

            ErrorMessage = "Climb Target must have an enabled Collider or Renderer on itself or a child to define climb bounds.";
            return false;
        }

        private bool TryGetProjectedBoundsRange(Vector3 axis, out float min, out float max)
        {
            min = 0f;
            max = 0f;

            if (TryGetClimbTargetBounds(out var bounds))
            {
                var boundsMin = bounds.min;
                var boundsMax = bounds.max;

                min = ProjectBoundsCorner(boundsMin.x, boundsMin.y, boundsMin.z, axis);
                max = min;

                ExpandProjectedBounds(boundsMin.x, boundsMin.y, boundsMax.z, axis, ref min, ref max);
                ExpandProjectedBounds(boundsMin.x, boundsMax.y, boundsMin.z, axis, ref min, ref max);
                ExpandProjectedBounds(boundsMin.x, boundsMax.y, boundsMax.z, axis, ref min, ref max);
                ExpandProjectedBounds(boundsMax.x, boundsMin.y, boundsMin.z, axis, ref min, ref max);
                ExpandProjectedBounds(boundsMax.x, boundsMin.y, boundsMax.z, axis, ref min, ref max);
                ExpandProjectedBounds(boundsMax.x, boundsMax.y, boundsMin.z, axis, ref min, ref max);
                ExpandProjectedBounds(boundsMax.x, boundsMax.y, boundsMax.z, axis, ref min, ref max);
                return true;
            }

            return false;
        }

        private static bool ShouldSendTopEvent(float climbInput, bool isAtTop, bool wasAtTop, bool topEventArmed)
        {
            return climbInput > 0f && isAtTop && !wasAtTop && topEventArmed;
        }

        private static bool ShouldSendBottomEvent(bool isAtBottom, bool wasAtBottom, bool bottomEventArmed)
        {
            return isAtBottom && !wasAtBottom && bottomEventArmed;
        }

        private bool TryGetClimbTargetBounds(out Bounds bounds)
        {
            bounds = default;

            var reference = _climbTarget.Value;

            if (!reference)
            {
                return false;
            }

            if (TryGetBoundsFromRootOrChildren<Collider>(reference, out bounds))
            {
                return true;
            }

            return TryGetBoundsFromRootOrChildren<Renderer>(reference, out bounds);
        }

        private static bool TryGetBoundsFromRootOrChildren<T>(Transform reference, out Bounds bounds) where T : Component
        {
            bounds = default;

            var rootComponents = reference.GetComponents<T>();
            if (TryEncapsulateBounds(rootComponents, out bounds))
            {
                return true;
            }

            var childComponents = reference.GetComponentsInChildren<T>();
            return TryEncapsulateChildBounds(reference, childComponents, out bounds);
        }

        private void CacheControllerLimitOffsets(Vector3 upAxis)
        {
            var controller = _characterController.Value;
            if (!controller)
            {
                _startBottomOffset = 0f;
                return;
            }

            var centerWorld = _cachedTransform.TransformPoint(controller.center);
            var halfHeight = Mathf.Max(controller.height * 0.5f, 0f);
            var capsuleBottom = centerWorld - upAxis * halfHeight;

            _startBottomOffset = Vector3.Dot(capsuleBottom - _cachedTransform.position, upAxis);
        }

        private void CacheControllerHorizontalLimitOffsets(Vector3 rightAxis)
        {
            var controller = _characterController.Value;
            if (!controller)
            {
                _leftOffset = 0f;
                _rightOffset = 0f;
                return;
            }

            var centerWorld = _cachedTransform.TransformPoint(controller.center);
            var centerOffset = Vector3.Dot(centerWorld - _cachedTransform.position, rightAxis);

            _leftOffset = centerOffset - controller.radius;
            _rightOffset = centerOffset + controller.radius;
        }

        private static bool TryEncapsulateBounds<T>(T[] components, out Bounds bounds) where T : Component
        {
            bounds = default;
            var hasBounds = false;

            for (var i = 0; i < components.Length; i++)
            {
                var component = components[i];
                if (!component)
                {
                    continue;
                }

                var componentBounds = component switch
                {
                    Collider collider => collider.bounds,
                    Renderer renderer => renderer.bounds,
                    _ => default
                };

                if (!hasBounds)
                {
                    bounds = componentBounds;
                    hasBounds = true;
                    continue;
                }

                bounds.Encapsulate(componentBounds);
            }

            return hasBounds;
        }

        private static bool TryEncapsulateChildBounds<T>(Transform root, T[] components, out Bounds bounds) where T : Component
        {
            bounds = default;
            var hasBounds = false;

            for (var i = 0; i < components.Length; i++)
            {
                var component = components[i];
                if (!component || component.transform == root)
                {
                    continue;
                }

                var componentBounds = component switch
                {
                    Collider collider => collider.bounds,
                    Renderer renderer => renderer.bounds,
                    _ => default
                };

                if (!hasBounds)
                {
                    bounds = componentBounds;
                    hasBounds = true;
                    continue;
                }

                bounds.Encapsulate(componentBounds);
            }

            return hasBounds;
        }

        private static void ExpandProjectedBounds(
            float x,
            float y,
            float z,
            Vector3 upAxis,
            ref float min,
            ref float max)
        {
            var projection = ProjectBoundsCorner(x, y, z, upAxis);
            min = Mathf.Min(min, projection);
            max = Mathf.Max(max, projection);
        }

        private static float ProjectBoundsCorner(float x, float y, float z, Vector3 upAxis) =>
            x * upAxis.x + y * upAxis.y + z * upAxis.z;

        private bool HideLookDirectionSettings() => _climbMode != ClimbMode.LookDirection;
    }
}

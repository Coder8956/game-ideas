using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.CharacterController)]
    [ActionDescription("Makes a CharacterController crouch by adjusting its height and center. Handles transitions between standing and crouching and can optionally scale child offsets to match. Can also sync an attached CapsuleCollider. Does not resize visible meshes or rendered character models.")]
    public sealed class CharacterControllerCrouch : BaseAction
    {
        public enum CrouchMode
        {
            Hold,
            Toggle
        }

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [RequiredComponent(typeof(CharacterController))]
        [Tooltip("The CharacterController.")]
        [SerializeField, OwnerDefaultValue]
        private CharacterControllerVar _characterController;

        [Tooltip("Choose whether crouch uses a held input or a toggle input.")]
        [SerializeField, DefaultValue(CrouchMode.Hold)]
        private CrouchMode _crouchMode;

        [Tooltip("Crouch while this is true. Normally set by an input action.")]
        [SerializeField, HideIf(nameof(HideIsCrouching))]
        private BoolVar _isCrouching;

        [Tooltip("Request standing when true. Typically driven by a one-frame input such as Get Key Down. If Can Stand is false, the controller stays crouched.")]
        [SerializeField, HideIf(nameof(HideStandRequest))]
        private BoolRef _standRequest = new();

        [Tooltip("Height of the capsule while crouching.")]
        [SerializeField, DefaultValue(0.5f)]
        private FloatVar _crouchHeight;

        [Tooltip("Move direct children so their local Y offset scales with the capsule height.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _adjustChildren;

        [Tooltip("Also apply the crouch height and center to an attached CapsuleCollider on the same GameObject. " +
                 "<br/>Enable this if that collider is used for triggers, hit detection, overlap checks, or other physics queries that should match the crouched shape. Leave it off if movement only relies on the CharacterController." +
                 "<br/>Note: This does not resize visible meshes or rendered character models.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _syncCapsuleCollider;

        [Tooltip("How long it takes to crouch or stand in seconds.")]
        [SerializeField, DefaultValue(0.2f)]
        private FloatVar _transitionTime;

        [Tooltip("Always complete the full transition to crouching, even if crouch input is brief.")]
        [SerializeField, DefaultValue(false), HideIf(nameof(HideCompleteTransition))]
        private BoolVar _completeTransition;

        [Tooltip("Can the CharacterController stand if crouch input is released? Usually set by a headroom check.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _canStand;

        [OptionalField]
        [Tooltip("Event to send when the CharacterController finishes standing.")]
        [SerializeField]
        private EventRef _standEvent = new();

        [Tooltip("Reset the CharacterController height and center if the state exits before the transition has finished.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _resetHeightOnStop = new() { Value = true };

        private enum CrouchState
        {
            Stand,
            StandToCrouch,
            Crouch,
            CrouchToStand
        }

        private readonly Dictionary<Transform, float> _childOffsets = new();

        private CapsuleCollider _capsuleCollider;
        private Transform _cachedTransform;
        private Vector3 _originalCapsuleCenter;
        private Vector3 _originalCenter;
        private float _originalCapsuleHeight;
        private Vector3 _crouchCenter;
        private float _originalHeight;
        private float _resolvedCrouchHeight;
        private Vector3 _transitionStartCenter;
        private float _transitionStartHeight;
        private float _transitionTimeElapsed;
        private CrouchState _crouchState;
        private bool _wantsToCrouch;
        private bool _wasTogglePressed;

        public override bool CanExecute()
        {
            if (!CheckParameters(
                    _characterController,
                    _isCrouching,
                    _crouchHeight,
                    _adjustChildren,
                    _syncCapsuleCollider,
                    _transitionTime,
                    _completeTransition,
                    _canStand,
                    _resetHeightOnStop))
            {
                return false;
            }

            return _crouchMode != CrouchMode.Toggle || (_standRequest != null && !_standRequest.IsNone);
        }

        public override string ErrorCheck()
        {
            if (_crouchMode == CrouchMode.Toggle && (_standRequest == null || _standRequest.IsNone))
            {
                return "@_standRequest:Toggle mode requires a Bool variable reference for the stand request. Use InputGetKeyDown Store Result -> that Bool variable.";
            }

            return string.Empty;
        }

        public override void OnStart()
        {
            var controller = _characterController.Value;
            if (!controller) return;

            _cachedTransform = controller.transform;
            _capsuleCollider = _syncCapsuleCollider.Value ? controller.GetComponent<CapsuleCollider>() : null;
            _originalHeight = controller.height;
            _originalCenter = controller.center;
            _originalCapsuleHeight = _capsuleCollider ? _capsuleCollider.height : 0f;
            _originalCapsuleCenter = _capsuleCollider ? _capsuleCollider.center : Vector3.zero;
            _resolvedCrouchHeight = ResolveCrouchHeight(controller);
            _crouchCenter = GetCenterForHeight(_resolvedCrouchHeight);
            _transitionStartHeight = controller.height;
            _transitionStartCenter = controller.center;
            _transitionTimeElapsed = 0f;
            _crouchState = IsAtTarget(controller.height, _resolvedCrouchHeight) ? CrouchState.Crouch : CrouchState.Stand;
            _wantsToCrouch = _crouchMode == CrouchMode.Toggle || _isCrouching.Value;
            _wasTogglePressed = false;

            if (_crouchMode == CrouchMode.Toggle && !_standRequest.IsNone && _standRequest.Value)
            {
                _wasTogglePressed = true;
            }

            CacheChildOffsets();
        }

        public override void Execute()
        {
            var controller = _characterController.Value;
            if (!controller) return;

            UpdateDesiredCrouchState();

            switch (_crouchState)
            {
                case CrouchState.Stand:
                    if (_wantsToCrouch && !IsAtTarget(controller.height, _resolvedCrouchHeight))
                    {
                        BeginTransition(CrouchState.StandToCrouch, controller);
                        StepTransition(controller, _resolvedCrouchHeight, _crouchCenter, CrouchState.Crouch);
                    }

                    break;

                case CrouchState.StandToCrouch:
                    StepTransition(controller, _resolvedCrouchHeight, _crouchCenter, CrouchState.Crouch);

                    if (!_completeTransition.Value && !_wantsToCrouch && CanStandNow())
                    {
                        BeginTransition(CrouchState.CrouchToStand, controller);
                        StepTransition(controller, _originalHeight, _originalCenter, CrouchState.Stand);
                        SendStandEventIfNeeded();
                    }

                    break;

                case CrouchState.Crouch:
                    if (!_wantsToCrouch && CanStandNow() && !IsAtTarget(controller.height, _originalHeight))
                    {
                        BeginTransition(CrouchState.CrouchToStand, controller);
                        StepTransition(controller, _originalHeight, _originalCenter, CrouchState.Stand);
                        SendStandEventIfNeeded();
                    }

                    break;

                case CrouchState.CrouchToStand:
                    if (_wantsToCrouch)
                    {
                        BeginTransition(CrouchState.StandToCrouch, controller);
                        StepTransition(controller, _resolvedCrouchHeight, _crouchCenter, CrouchState.Crouch);
                        break;
                    }

                    if (!CanStandNow())
                    {
                        BeginTransition(CrouchState.StandToCrouch, controller);
                        StepTransition(controller, _resolvedCrouchHeight, _crouchCenter, CrouchState.Crouch);
                        break;
                    }

                    StepTransition(controller, _originalHeight, _originalCenter, CrouchState.Stand);
                    SendStandEventIfNeeded();

                    break;
            }
        }

        public override void OnStop()
        {
            var controller = _characterController.Value;
            if (controller && _resetHeightOnStop.Value)
            {
                SetControllerDimensions(controller, _originalHeight, _originalCenter);
                if (_capsuleCollider)
                {
                    _capsuleCollider.height = _originalCapsuleHeight;
                    _capsuleCollider.center = _originalCapsuleCenter;
                }

                RestoreChildOffsets();
            }

            _childOffsets.Clear();
        }

        public override string GetSummary()
        {
            return "{_characterController} crouch to {_crouchHeight}"
                   + (_transitionTime.IsNotDefault() ? " over {_transitionTime}s" : "")
                   + "{_standEvent}";
        }

        private void BeginTransition(CrouchState nextState, CharacterController controller)
        {
            _crouchState = nextState;
            _transitionStartHeight = controller.height;
            _transitionStartCenter = controller.center;
            _transitionTimeElapsed = 0f;
        }

        private void CacheChildOffsets()
        {
            _childOffsets.Clear();
            if (_cachedTransform == null) return;

            foreach (Transform child in _cachedTransform)
            {
                _childOffsets[child] = child.localPosition.y;
            }
        }

        private bool CanStandNow() => _canStand.Value;

        private Vector3 GetCenterForHeight(float height)
        {
            var center = _originalCenter;
            center.y -= (_originalHeight - height) * 0.5f;
            return center;
        }

        private bool IsAtTarget(float currentHeight, float targetHeight) =>
            Mathf.Approximately(currentHeight, targetHeight);

        private float ResolveCrouchHeight(CharacterController controller)
        {
            var minHeight = controller.radius * 2f;
            var clamped = Mathf.Max(_crouchHeight.Value, minHeight);
            return Mathf.Min(clamped, _originalHeight);
        }

        private void RestoreChildOffsets()
        {
            foreach (var kvp in _childOffsets)
            {
                if (kvp.Key == null) continue;

                var pos = kvp.Key.localPosition;
                kvp.Key.localPosition = new Vector3(pos.x, kvp.Value, pos.z);
            }
        }

        private void SendStandEventIfNeeded()
        {
            if (_crouchState == CrouchState.Stand && _standEvent != null && _standEvent.IsSet)
            {
                SendEvent(_standEvent);
            }
        }

        private void SetControllerDimensions(CharacterController controller, float height, Vector3 center)
        {
            controller.height = height;
            controller.center = center;
            SetCapsuleColliderDimensions(height, center);

            if (!_adjustChildren.Value || Mathf.Approximately(_originalHeight, 0f))
            {
                return;
            }

            var adjust = controller.height / _originalHeight;
            foreach (var kvp in _childOffsets)
            {
                if (kvp.Key == null) continue;

                var pos = kvp.Key.localPosition;
                kvp.Key.localPosition = new Vector3(pos.x, kvp.Value * adjust, pos.z);
            }
        }

        private void SetCapsuleColliderDimensions(float height, Vector3 center)
        {
            if (!_capsuleCollider)
            {
                return;
            }

            _capsuleCollider.height = height;
            _capsuleCollider.center = center;
        }

        private void StepTransition(
            CharacterController controller,
            float targetHeight,
            Vector3 targetCenter,
            CrouchState completedState)
        {
            var duration = Mathf.Max(0f, _transitionTime.Value);
            if (duration <= 0f)
            {
                SetControllerDimensions(controller, targetHeight, targetCenter);
                _crouchState = completedState;
                return;
            }

            _transitionTimeElapsed += Time.deltaTime;
            var t = Mathf.Clamp01(_transitionTimeElapsed / duration);
            var height = Mathf.Lerp(_transitionStartHeight, targetHeight, t);
            var center = Vector3.Lerp(_transitionStartCenter, targetCenter, t);

            SetControllerDimensions(controller, height, center);

            if (t >= 1f)
            {
                _crouchState = completedState;
            }
        }

        private void UpdateDesiredCrouchState()
        {
            if (_crouchMode == CrouchMode.Toggle)
            {
                if (_standRequest.IsNone)
                {
                    _wasTogglePressed = false;
                    return;
                }

                var togglePressed = _standRequest.Value;
                if (togglePressed && !_wasTogglePressed)
                {
                    _wantsToCrouch = !_wantsToCrouch;
                }

                _wasTogglePressed = togglePressed;
                return;
            }

            _wantsToCrouch = _isCrouching.Value;
        }

        private bool HideIsCrouching() => _crouchMode == CrouchMode.Toggle;

        private bool HideStandRequest() => _crouchMode != CrouchMode.Toggle;

        private bool HideCompleteTransition() => _crouchMode == CrouchMode.Toggle;
    }
}

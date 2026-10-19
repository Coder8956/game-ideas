using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Mouse)]
    [ActionDescription("Rotates a single pivot Transform using mouse movement for orbit-style cameras. " +
                       "Stores yaw and pitch internally, supports per-axis inversion, and clamps vertical rotation."
                       + Strings.SupportsBothInputSystems)]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Input-mousePosition.html")]
    public sealed class InputMouseOrbit : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [OwnerDefaultValue]
        [Tooltip("The pivot Transform to rotate. Typically a camera orbit pivot parented under the player.")]
        [SerializeField]
        private TransformVar _pivotTransform;

        [Tooltip("Sensitivity of mouse movement.")]
        [SerializeField, DefaultValue(3f)]
        private FloatVar _mouseSensitivity;

        [OptionalField]
        [Tooltip("Invert mouse X movement.")]
        [SerializeField]
        private BoolVar _invertX;

        [OptionalField]
        [Tooltip("Invert mouse Y movement.")]
        [SerializeField]
        private BoolVar _invertY;

        [Tooltip("Minimum angle for vertical rotation.")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _downLimit;

        [Tooltip("Maximum angle for vertical rotation.")]
        [SerializeField, DefaultValue(60f)]
        private FloatVar _upLimit;

        [Tooltip("Initialize yaw and pitch from the pivot's current local rotation when the state starts.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _useCurrentRotationOnStart;

        [OptionalField]
        [Tooltip("Store the current yaw angle in degrees.")]
        [SerializeField, WriteOnly]
        private FloatRef _storeYaw;

        [OptionalField]
        [Tooltip("Store the current pitch angle in degrees.")]
        [SerializeField, WriteOnly]
        private FloatRef _storePitch;

        [NonSerialized]
        private float _yaw;

        [NonSerialized]
        private float _pitch;

        public override bool CanExecute() =>
            CheckParameters(_pivotTransform, _mouseSensitivity, _downLimit, _upLimit);

        public override string ErrorCheck()
        {
            if (_downLimit.Value > _upLimit.Value)
                return "@_downLimit:Minimum angle must be less than or equal to Maximum angle.";

            return string.Empty;
        }

        public override void OnStart()
        {
            var pivot = _pivotTransform.Value;
            if (pivot == null)
                return;

            if (_useCurrentRotationOnStart.Value)
            {
                var euler = pivot.localEulerAngles;
                _yaw = NormalizeAngle(euler.y);
                _pitch = Mathf.Clamp(NormalizeAngle(euler.x), _downLimit.Value, _upLimit.Value);
            }
            else
            {
                _yaw = 0f;
                _pitch = 0f;
            }

            ApplyRotation(pivot);
        }

        public override void Execute()
        {
            var pivot = _pivotTransform.Value;
            if (pivot == null)
                return;

            var delta = InputShim.GetMouseDelta();
            var sensitivity = _mouseSensitivity.Value;

            var xSign = !_invertX.IsNone && _invertX.Value ? -1f : 1f;
            var ySign = !_invertY.IsNone && _invertY.Value ? -1f : 1f;

            _yaw += delta.x * sensitivity * xSign;
            _pitch -= delta.y * sensitivity * ySign;
            _pitch = Mathf.Clamp(_pitch, _downLimit.Value, _upLimit.Value);

            ApplyRotation(pivot);
        }

        private void ApplyRotation(Transform pivot)
        {
            pivot.localRotation = Quaternion.Euler(_pitch, _yaw, 0f);

            if (!_storeYaw.IsNone)
                _storeYaw.Value = _yaw;

            if (!_storePitch.IsNone)
                _storePitch.Value = _pitch;
        }

        private static float NormalizeAngle(float angle)
        {
            angle %= 360f;
            if (angle > 180f) angle -= 360f;
            return angle;
        }

        public override string GetSummary() =>
            "Mouse Orbit {_pivotTransform}: Sensitivity {_mouseSensitivity} {_invertX:option} {_invertY:option} Down {_downLimit} Up {_upLimit}";
    }
}

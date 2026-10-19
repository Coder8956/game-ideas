using System;
using UnityEngine;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Mouse)]
    [ActionDescription("Rotates a Transform using mouse movement. Typically used in a first or third person controller."
                      + Strings.SupportsBothInputSystems)]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Input-mousePosition.html")]
    public sealed class InputMouseLook : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [OwnerDefaultValue]
        [Tooltip("The Transform to rotate with mouse X movement. Typically a capsule with a CharacterController.")]
        [SerializeField]
        private TransformVar _bodyTransform;
        
        [Tooltip("The Transform to rotate with mouse Y movement. Typically a Camera child of the body transform.")]
        [SerializeField]
        private TransformVar _headTransform;

        [Tooltip("Sensitivity of mouse movement.")]
        [SerializeField, DefaultValue(3f)]
        private FloatVar _mouseSensitivity;

        [Tooltip("Invert mouse Y movement.")]
        [SerializeField]
        private BoolVar _invertY;

        [Tooltip("Minimum angle for vertical rotation.")]
        [SerializeField, DefaultValue(-80f)]
        private FloatVar _downLimit;
        
        [Tooltip("Maximum angle for vertical rotation.")]
        [SerializeField, DefaultValue(80f)]
        private FloatVar _upLimit;

        [NonSerialized]
        private float _verticalRotation;

        public override bool CanExecute() =>
            CheckParameters(_bodyTransform, _headTransform, _mouseSensitivity, _downLimit, _upLimit);

        public override string ErrorCheck()
        {
            if (_bodyTransform.Value != null && _bodyTransform.Value == _headTransform.Value)
                return "@_headTransform:Body Transform and Head Transform cannot be the same. Use separate yaw and pitch pivots.";

            return string.Empty;
        }

        public override void OnStart()
        {
            var head = _headTransform.Value;
            if (head == null)
                return;

            _verticalRotation = Mathf.Clamp(
                NormalizeAngle(head.localEulerAngles.x),
                _downLimit.Value,
                _upLimit.Value);
        }

        public override void Execute()
        {
            if (_bodyTransform.Value == null || _headTransform.Value == null)
                return;
            
            var delta = InputShim.GetMouseDelta();
            var sensitivity = _mouseSensitivity.Value;

            // Horizontal (yaw)
            _bodyTransform.Value.Rotate(0f, delta.x * sensitivity, 0f);

            // Vertical (pitch)
            var invert = _invertY.Value ? -1f : 1f;
            _verticalRotation -= delta.y * sensitivity * invert;
            _verticalRotation = Mathf.Clamp(_verticalRotation, _downLimit.Value, _upLimit.Value);
            _headTransform.Value.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        }

        private static float NormalizeAngle(float angle)
        {
            angle %= 360f;
            if (angle > 180f) angle -= 360f;
            return angle;
        }

        public override string GetSummary() =>
            "Mouse Look: Sensitivity: {_mouseSensitivity} {_invertY:option} Down: {_downLimit} Up: {_upLimit}";
    }
}

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [Serializable]
    [ActionCategory(Category.GameplayOrientationRigidbody2D)]
    [ConvertibleGroup("LookAt")]
    [ActionDescription("Rotate a Rigidbody2D in 2D (around Z) so a chosen local axis faces the mouse cursor. " +
                       "Includes SmoothTime and MaxSpeed.")]
    [HelpURL("actions/transform-actions/look-at-actions/")]
    public sealed class Rigidbody2DLookAtMouse : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [Tooltip("The Rigidbody2D to rotate.")]
        [SerializeField] private Rigidbody2DVar _rigidbody2D;

        [DefaultValue("~MainCamera")]
        [Tooltip("Camera used to project mouse position into world space.")]
        [SerializeField] private CameraVar _camera;

        [Tooltip("Which local axis should face the mouse (2D: X / Y / -X / -Y).")]
        [SerializeField] private AxisDirection2DVar _facingAxis;

        [VarSlider(0.0f, 1.0f)]
        [Tooltip("Smooth Time in seconds (roughly time to halve the remaining angle). 0 = no smoothing.")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 1080)]
        [Tooltip("Maximum turn speed in degrees per second. 0 = uncapped.")]
        [SerializeField] private FloatVar _maxSpeed;

        private Quaternion _desired;

        public override bool CanExecute() => CheckParameters(_rigidbody2D, _camera, _facingAxis);

        public override void Execute()
        {
            var rb = _rigidbody2D.Value;
            var cam = _camera.Value;
            if (rb == null || cam == null) return;

            var t = rb.transform;
            var mouse = (Vector3)InputShim.GetMousePosition();
            mouse.z = t.position.z - cam.transform.position.z;
            var worldMouse = cam.ScreenToWorldPoint(mouse);

            var dir = worldMouse - t.position;
            dir.z = 0f;

            _desired = LookAtCompute.ComputeTargetRotation(
                t,
                dir,
                RotationConstraint.Z,
                _facingAxis.Value.ToAxisDirection(),
                Vector3.up
            );

            rb.MoveRotation(SmoothLookAtHelper.Update(t.rotation, _desired, _smoothTime.Value, _maxSpeed.Value));
        }

        public override string GetSummary()
        {
            var s = "Rotate {_rigidbody2D} {_facingAxis} to look at mouse";
            if (_smoothTime.IsNotDefault()) s += " in {_smoothTime}s";
            if (_maxSpeed.IsNotDefault()) s += " max {_maxSpeed} deg/s";
            return s;
        }
    }
}

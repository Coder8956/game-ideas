using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [Serializable]
    [ActionCategory(Category.GameplayOrientationTransform)]
    [ConvertibleGroup("LookAt")]
    [ActionDescription("Rotate a Transform in 2D (around Z) so a chosen local axis faces the mouse cursor. " +
                       "Includes SmoothTime and MaxSpeed.")]
    [HelpURL("actions/transform-actions/look-at-actions/")]
    [MovedFrom(true, null, null,"TransformMouseLook2D")]
    public sealed class TransformLookAtMouse2D : BaseAction
    {
        public override UpdateMode DefaultUpdateMode  => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [OwnerDefaultValue, Tooltip("The Transform to rotate.")]
        [SerializeField] private TransformVar _transform;

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

        public override bool CanExecute() => CheckParameters(_transform, _camera, _facingAxis);

        public override void Execute()
        {
            var t = _transform.Value;
            var cam = _camera.Value;
            if (t == null || cam == null) return;

            // Mouse → world (XY plane at transform's Z)
            var mouse = (Vector3) InputShim.GetMousePosition();
            mouse.z = t.position.z - cam.transform.position.z;
            var worldMouse = cam.ScreenToWorldPoint(mouse);

            // Direction to mouse in XY only
            var dir = worldMouse - t.position;
            dir.z = 0f;

            _desired = LookAtCompute.ComputeTargetRotation(
                t,
                dir,
                RotationConstraint.Z,                   // 2D preset
                _facingAxis.Value.ToAxisDirection(),    // map 2D axis → AxisDirection
                Vector3.up                               // ignored when constrained
            );

            t.rotation = SmoothLookAtHelper.Update(t.rotation, _desired, _smoothTime.Value, _maxSpeed.Value);
        }

        public override string GetSummary()
        {
            var s = "Rotate {_transform} {_facingAxis} to look at mouse";
            if (_smoothTime.IsNotDefault()) s += " in {_smoothTime}s";
            if (_maxSpeed.IsNotDefault())   s += " max {_maxSpeed}°/s";
            return s;
        }
    }
}

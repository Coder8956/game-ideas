using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Scale one local axis and automatically scale the other axis in a 2D plane to preserve area.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
    public sealed class TransformSquashAndStretch2D : BaseAction
    {
        public enum Axis
        {
            X,
            Y,
            Z
        }

        public enum Plane
        {
            XY,
            XZ,
            YZ
        }

        [OwnerDefaultValue]
        [Tooltip("The Transform")]
        [SerializeField]
        private TransformVar _transform;

        [Tooltip("The base local scale. A scale multiplier of 1 returns this scale.")]
        [SerializeField, DefaultValue("Vector3.one")]
        private Vector3Var _baseScale;

        [Tooltip("The 2D plane used to preserve area.")]
        [SerializeField]
        private Plane _plane;

        [Tooltip("The local scale axis to stretch. This axis should be in the selected plane.")]
        [SerializeField]
        private Axis _axis;

        [Tooltip("The multiplier applied to the selected axis relative to the base scale.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _scaleMultiplier;

        public override bool CanExecute() => CheckParameters(_transform, _baseScale, _scaleMultiplier);

        public override void Execute()
        {
            var transform = _transform.Value;
            if (transform == null) return;

            var baseScale = _baseScale.Value;
            var localScale = baseScale;
            var multiplier = _scaleMultiplier.Value;

            SetAxisScale(ref localScale, _axis, GetAxisScale(baseScale, _axis) * multiplier);

            if (Mathf.Approximately(multiplier, 0f) ||
                !TryGetPairedAxis(out var pairedAxis))
            {
                transform.localScale = localScale;
                return;
            }

            var preserveAreaScale = Mathf.Abs(1f / multiplier);
            ScaleAxis(ref localScale, pairedAxis, preserveAreaScale);
            transform.localScale = localScale;
        }

        private bool TryGetPairedAxis(out Axis pairedAxis)
        {
            switch (_plane)
            {
                case Plane.XY:
                    switch (_axis)
                    {
                        case Axis.X:
                            pairedAxis = Axis.Y;
                            return true;
                        case Axis.Y:
                            pairedAxis = Axis.X;
                            return true;
                    }

                    break;

                case Plane.XZ:
                    switch (_axis)
                    {
                        case Axis.X:
                            pairedAxis = Axis.Z;
                            return true;
                        case Axis.Z:
                            pairedAxis = Axis.X;
                            return true;
                    }

                    break;

                case Plane.YZ:
                    switch (_axis)
                    {
                        case Axis.Y:
                            pairedAxis = Axis.Z;
                            return true;
                        case Axis.Z:
                            pairedAxis = Axis.Y;
                            return true;
                    }

                    break;
            }

            pairedAxis = _axis;
            return false;
        }

        private static float GetAxisScale(Vector3 scale, Axis axis) =>
            axis switch
            {
                Axis.X => scale.x,
                Axis.Y => scale.y,
                Axis.Z => scale.z,
                _ => scale.x
            };

        private static void SetAxisScale(ref Vector3 scale, Axis axis, float value)
        {
            switch (axis)
            {
                case Axis.X:
                    scale.x = value;
                    break;
                case Axis.Y:
                    scale.y = value;
                    break;
                case Axis.Z:
                    scale.z = value;
                    break;
            }
        }

        private static void ScaleAxis(ref Vector3 scale, Axis axis, float value)
        {
            switch (axis)
            {
                case Axis.X:
                    scale.x *= value;
                    break;
                case Axis.Y:
                    scale.y *= value;
                    break;
                case Axis.Z:
                    scale.z *= value;
                    break;
            }
        }

        public override string GetSummary() => "Stretch {_transform} on {_axis} x{_scaleMultiplier} in {_plane}";
    }
}

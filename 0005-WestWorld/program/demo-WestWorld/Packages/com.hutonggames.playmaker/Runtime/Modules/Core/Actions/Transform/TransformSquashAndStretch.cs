using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Scale one local axis and automatically scale the other two axes to preserve volume.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
    public sealed class TransformSquashAndStretch : BaseAction
    {
        public enum Axis
        {
            X,
            Y,
            Z
        }

        [OwnerDefaultValue]
        [Tooltip("The Transform")]
        [SerializeField]
        private TransformVar _transform;

        [Tooltip("The base local scale. A scale multiplier of 1 returns this scale.")]
        [SerializeField, DefaultValue("Vector3.one")]
        private Vector3Var _baseScale;

        [Tooltip("The local scale axis to stretch.")]
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

            SetAxisScale(ref localScale, GetAxisScale(baseScale) * multiplier);

            if (Mathf.Approximately(multiplier, 0f))
            {
                transform.localScale = localScale;
                return;
            }

            var preserveVolumeScale = Mathf.Sqrt(Mathf.Abs(1f / multiplier));
            ScaleOtherAxes(ref localScale, preserveVolumeScale);
            transform.localScale = localScale;
        }

        private float GetAxisScale(Vector3 scale) =>
            _axis switch
            {
                Axis.X => scale.x,
                Axis.Y => scale.y,
                Axis.Z => scale.z,
                _ => scale.x
            };

        private void SetAxisScale(ref Vector3 scale, float value)
        {
            switch (_axis)
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

        private void ScaleOtherAxes(ref Vector3 scale, float value)
        {
            switch (_axis)
            {
                case Axis.X:
                    scale.y *= value;
                    scale.z *= value;
                    break;
                case Axis.Y:
                    scale.x *= value;
                    scale.z *= value;
                    break;
                case Axis.Z:
                    scale.x *= value;
                    scale.y *= value;
                    break;
            }
        }

        public override string GetSummary() => "Stretch {_transform} on {_axis} x{_scaleMultiplier}";
    }
}

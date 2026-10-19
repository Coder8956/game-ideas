using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a Vector2 to a Vector3, with optional swizzle mapping.")]
    public sealed class ConvertVector2ToVector3 : BaseAction
    {
        [ActionTarget]
        [Tooltip("The Vector2 to convert.")]
        [SerializeField]
        private Vector2Ref _vector2;

        [Tooltip("How to map Vector2 components into Vector3 axes.")]
        [SerializeField]
        private Vector2ToVector3Mapping _mapping;

        [Tooltip("Value used for the axis not supplied by the Vector2. E.g. Z for XY")]
        [SerializeField]
        private FloatRef _fill;

        [Tooltip("Store the converted Vector3 value.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _vector3;

        public override bool CanExecute() => CheckParameters(_vector2, _fill, _vector3);

        public override void Execute()
        {
            var v2 = _vector2.Value;
            var r = _fill.Value;

            var v3 = _mapping switch
            {
                Vector2ToVector3Mapping.XY => new Vector3(v2.x, v2.y, r),
                Vector2ToVector3Mapping.XZ => new Vector3(v2.x, r, v2.y),
                Vector2ToVector3Mapping.YX => new Vector3(v2.y, v2.x, r),
                Vector2ToVector3Mapping.YZ => new Vector3(r, v2.x, v2.y),
                Vector2ToVector3Mapping.ZX => new Vector3(v2.y, r, v2.x),
                Vector2ToVector3Mapping.ZY => new Vector3(r, v2.y, v2.x),
                _ => new Vector3(v2.x, v2.y, r)
            };

            _vector3.Value = v3;
        }

        public override string GetSummary() => "Convert {_vector2} to Vector3 -> {_vector3}";
    }
}

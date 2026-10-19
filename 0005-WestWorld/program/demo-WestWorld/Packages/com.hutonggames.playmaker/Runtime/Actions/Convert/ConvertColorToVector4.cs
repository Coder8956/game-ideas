using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a Color to a Vector4 (r,g,b,a).")]
    public sealed class ConvertColorToVector4 : BaseAction
    {
        [ActionTarget]
        [Tooltip("The Color to convert.")]
        [SerializeField]
        private ColorRef _color;

        [Tooltip("Store the converted Vector4 value.")]
        [SerializeField, WriteOnly]
        private Vector4Ref _vector;

        public override bool CanExecute() => CheckParameters(_color, _vector);

        public override void Execute()
        {
            _vector.Value = (Vector4)_color.Value;
        }

        public override string GetSummary() => "Convert {_color} to Vector4 -> {_vector}";
    }
}
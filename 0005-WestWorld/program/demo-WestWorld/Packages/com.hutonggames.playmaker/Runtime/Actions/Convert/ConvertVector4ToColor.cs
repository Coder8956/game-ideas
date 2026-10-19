using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a Vector4 to a Color (x,y,z,w → r,g,b,a).")]
    public sealed class ConvertVector4ToColor : BaseAction
    {
        [ActionTarget]
        [Tooltip("The Vector4 to convert.")]
        [SerializeField]
        private Vector4Ref _vector;

        [Tooltip("Store the converted Color value.")]
        [SerializeField, WriteOnly]
        private ColorRef _color;

        public override bool CanExecute() => CheckParameters(_vector, _color);

        public override void Execute()
        {
            _color.Value = (Color)_vector.Value;
        }

        public override string GetSummary() => "Convert {_vector} to Color -> {_color}";
    }
}
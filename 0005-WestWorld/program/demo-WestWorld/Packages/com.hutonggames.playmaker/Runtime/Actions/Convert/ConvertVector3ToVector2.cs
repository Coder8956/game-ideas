using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a Vector3 to a Vector2 by selecting which axes to keep.")]
    public sealed class ConvertVector3ToVector2 : BaseAction
    {
        [ActionTarget]
        [Tooltip("The Vector3 to convert.")]
        [SerializeField]
        private Vector3Ref _vector3;

        [Tooltip("Which axes to keep in the Vector2.")]
        [SerializeField]
        private Vector3ToVector2Mapping _mapping;

        [Tooltip("Store the converted Vector2 value.")]
        [SerializeField, WriteOnly]
        private Vector2Ref _vector2;

        public override bool CanExecute() => CheckParameters(_vector3, _vector2);

        public override void Execute()
        {
            var v3 = _vector3.Value;

            Vector2 v2;
            switch (_mapping)
            {
                case Vector3ToVector2Mapping.XY: v2 = new Vector2(v3.x, v3.y); break;
                case Vector3ToVector2Mapping.XZ: v2 = new Vector2(v3.x, v3.z); break;
                case Vector3ToVector2Mapping.YZ: v2 = new Vector2(v3.y, v3.z); break;
                default:         v2 = new Vector2(v3.x, v3.y); break;
            }

            _vector2.Value = v2;
        }

        public override string GetSummary() => "Convert {_vector3} to Vector2 -> {_vector2}";
    }
}
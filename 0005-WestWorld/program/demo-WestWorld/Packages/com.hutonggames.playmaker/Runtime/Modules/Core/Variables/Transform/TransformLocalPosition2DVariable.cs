using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(TransformVariable), typeof(Vector2), "localPosition2D")]
    public class TransformLocalPosition2DVariable : BaseTransformProperty<Vector2>
    {
        public override string PropertyName => "localPosition2D";
        
#if UNITY_EDITOR
        public override string Description => "The Transform's local position as a Vector2.";
#endif
        
        public override Vector2 Value
        {
            get => Transform ? Transform.localPosition : Vector2.zero;
            set
            {
                if (Transform) Transform.localPosition = value;
            }
        }
    }
}

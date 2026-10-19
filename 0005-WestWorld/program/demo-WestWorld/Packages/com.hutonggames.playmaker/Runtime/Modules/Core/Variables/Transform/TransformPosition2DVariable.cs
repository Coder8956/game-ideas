using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(TransformVariable), typeof(Vector2), "position2D")]
    public class TransformPosition2DVariable : BaseTransformProperty<Vector2>
    {
        public override string PropertyName => "position2D";
        
#if UNITY_EDITOR
        public override string Description => "The Transform's position as a Vector2.";
#endif
        
        public override Vector2 Value
        {
            get =>  Transform ? Transform.position : Vector2.zero;
            set
            {
                if (Transform) Transform.position = value;
            }
        }
    }
}
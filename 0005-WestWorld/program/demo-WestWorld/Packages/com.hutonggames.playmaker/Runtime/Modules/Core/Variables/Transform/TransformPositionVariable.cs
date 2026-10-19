using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(TransformVariable), typeof(Vector3), "position")]
    public class TransformPositionVariable : BaseTransformProperty<Vector3>
    {
        public override string PropertyName => "position";
        
#if UNITY_EDITOR
        public override string Description => "The Transform's position.";
#endif
        
        public override Vector3 Value
        {
            get =>  Transform ? Transform.position : Vector3.zero;
            set
            {
                if (Transform) Transform.position = value;
            }
        }
    }
}
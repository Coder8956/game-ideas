using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(TransformVariable), typeof(Vector3), "localPosition")]
    public class TransformLocalPositionVariable : BaseTransformProperty<Vector3>
    {
        public override string PropertyName => "localPosition";
        
#if UNITY_EDITOR
        public override string Description => "The Transform's local position.";
#endif
        
        public override Vector3 Value
        {
            get => Transform ? Transform.localPosition : Vector3.zero;
            set
            {
                if (Transform) Transform.localPosition = value;
            }
        }
    }
}

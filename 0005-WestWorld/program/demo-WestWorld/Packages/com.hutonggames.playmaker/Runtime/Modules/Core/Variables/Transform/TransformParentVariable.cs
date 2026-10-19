using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(TransformVariable), typeof(Transform), "parent")]
    public class TransformParentVariable : BaseTransformProperty<Transform>
    {
        public override string PropertyName => "parent";
        
#if UNITY_EDITOR
        public override string Description => "The Transform's parent.";
#endif
        
        public override Transform Value
        {
            get => Transform ? Transform.parent : null;
            set
            {
                if (Transform) Transform.parent = value;
            }
        }
    }
}
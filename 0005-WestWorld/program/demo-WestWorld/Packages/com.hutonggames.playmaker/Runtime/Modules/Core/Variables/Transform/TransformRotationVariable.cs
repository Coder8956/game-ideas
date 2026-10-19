using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(TransformVariable), typeof(Quaternion), "rotation")]
    public class TransformRotationVariable : BaseTransformProperty<Quaternion>
    {
        public override string PropertyName => "rotation";
        
#if UNITY_EDITOR
        public override string Description => "The Transform's world rotation.";
#endif
        
        public override Quaternion Value
        {
            get => Transform ? Transform.rotation : Quaternion.identity;
            set
            {
                if (Transform) Transform.rotation = value;
            }
        }
    }
}

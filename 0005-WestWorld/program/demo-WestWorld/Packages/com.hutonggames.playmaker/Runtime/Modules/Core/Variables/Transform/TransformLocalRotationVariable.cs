using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(TransformVariable), typeof(Quaternion), "localRotation")]
    public class TransformLocalRotationVariable : BaseTransformProperty<Quaternion>
    {
        public override string PropertyName => "localRotation";
        
#if UNITY_EDITOR
        public override string Description => "The Transform's local rotation.";
#endif
        
        public override Quaternion Value
        {
            get => Transform ? Transform.localRotation : Quaternion.identity;
            set
            {
                if (Transform) Transform.localRotation = value;
            }
        }
    }
}

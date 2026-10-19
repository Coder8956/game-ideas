using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHit2DVariable), typeof(Transform), "transform", false)]
    public class RaycastHit2DTransformVariable : BaseVariableProperty<RaycastHit2D, Transform>
    {
        public override string PropertyName => "transform";
        
#if UNITY_EDITOR
        public override string Description => "The Transform of the object that was hit.";
#endif

        public override Transform Value
        {
            get => TargetAs<RaycastHit2DVariable>()?.Value.transform;
            set { }
        }
    }
}

using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(RaycastHit2DVariable), typeof(Rigidbody2D), "rigidbody", false)]
    public class RaycastHit2DRigidbodyVariable : BaseVariableProperty<RaycastHit2D, Rigidbody2D>
    {
        public override string PropertyName => "rigidbody";
        
#if UNITY_EDITOR
        public override string Description => "The Rigidbody2D attached to the object that was hit.";
#endif

        public override Rigidbody2D Value
        {
            get => TargetAs<RaycastHit2DVariable>()?.Value.rigidbody;
            set { }
        }
    }
}

using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(InteractableVariable), typeof(Transform), "undockingTransform", false)]
    public class InteractableUndockingTransformVariable : BaseVariableProperty<Interactable, Transform>
    {
        public override string PropertyName => "undockingTransform";
        
#if UNITY_EDITOR
        public override string Description => "The explicitly assigned undocking transform.";
#endif

        public override Transform Value
        {
            get => TargetAs<InteractableVariable>()?.Value ? TargetAs<InteractableVariable>().Value.UndockingTransform : null;
            set { }
        }
    }
}

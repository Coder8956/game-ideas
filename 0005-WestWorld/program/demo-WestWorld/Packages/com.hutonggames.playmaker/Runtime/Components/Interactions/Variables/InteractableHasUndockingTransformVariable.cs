using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(InteractableVariable), typeof(bool), "hasUndockingTransform", false)]
    public class InteractableHasUndockingTransformVariable : BaseVariableProperty<Interactable, bool>
    {
        public override string PropertyName => "hasUndockingTransform";
        
#if UNITY_EDITOR
        public override string Description => "True when an explicit undocking transform is assigned.";
#endif

        public override bool Value
        {
            get => TargetAs<InteractableVariable>()?.Value && TargetAs<InteractableVariable>().Value.HasUndockingTransform;
            set { }
        }
    }
}

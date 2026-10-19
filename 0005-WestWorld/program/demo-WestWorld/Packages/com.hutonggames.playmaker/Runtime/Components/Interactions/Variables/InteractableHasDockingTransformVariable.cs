using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(InteractableVariable), typeof(bool), "hasDockingTransform", false)]
    public class InteractableHasDockingTransformVariable : BaseVariableProperty<Interactable, bool>
    {
        public override string PropertyName => "hasDockingTransform";
        
#if UNITY_EDITOR
        public override string Description => "True when an explicit docking transform is assigned.";
#endif

        public override bool Value
        {
            get => TargetAs<InteractableVariable>()?.Value && TargetAs<InteractableVariable>().Value.HasDockingTransform;
            set { }
        }
    }
}

using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(InteractableVariable), typeof(Transform), "dockingTransform", false)]
    public class InteractableDockingTransformVariable : BaseVariableProperty<Interactable, Transform>
    {
        public override string PropertyName => "dockingTransform";
        
#if UNITY_EDITOR
        public override string Description => "The docking transform, falling back to the Interactable's transform when not explicitly assigned.";
#endif

        public override Transform Value
        {
            get => TargetAs<InteractableVariable>()?.Value ? TargetAs<InteractableVariable>().Value.DockingTransform : null;
            set { }
        }
    }
}

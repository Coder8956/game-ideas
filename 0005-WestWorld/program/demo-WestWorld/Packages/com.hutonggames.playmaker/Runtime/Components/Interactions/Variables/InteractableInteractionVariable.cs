using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(InteractableVariable), typeof(string), "interaction", false)]
    public class InteractableInteractionVariable : BaseVariableProperty<Interactable, string>
    {
        public override string PropertyName => "interaction";
        
#if UNITY_EDITOR
        public override string Description => "The interaction value.";
#endif

        public override string Value
        {
            get => TargetAs<InteractableVariable>()?.Value ? TargetAs<InteractableVariable>().Value.Interaction : string.Empty;
            set { }
        }
    }
}

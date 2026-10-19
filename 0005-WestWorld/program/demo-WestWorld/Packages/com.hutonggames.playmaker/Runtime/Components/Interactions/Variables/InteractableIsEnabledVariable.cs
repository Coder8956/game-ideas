using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(InteractableVariable), typeof(bool), "isEnabled", false)]
    public class InteractableIsEnabledVariable : BaseVariableProperty<Interactable, bool>
    {
        public override string PropertyName => "isEnabled";

#if UNITY_EDITOR
        public override string Description => "True when the interactable is enabled for interaction.";
#endif

        public override bool Value
        {
            get => TargetAs<InteractableVariable>()?.Value && TargetAs<InteractableVariable>().Value.IsEnabled;
            set { }
        }
    }
}

using System;

namespace HutongGames.PlayMaker
{
    [Serializable]
    [VariableProperty(typeof(InteractableVariable), typeof(string), "activationId", false)]
    public class InteractableActivationIdVariable : BaseVariableProperty<Interactable, string>
    {
        public override string PropertyName => "activationId";

#if UNITY_EDITOR
        public override string Description => "The activation identifier value.";
#endif

        public override string Value
        {
            get => TargetAs<InteractableVariable>()?.Value ? TargetAs<InteractableVariable>().Value.ActivationId : string.Empty;
            set { }
        }
    }
}

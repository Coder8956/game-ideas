using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Interactable)]
    [ConvertibleGroup("Interactable")]
    [ActionDescription("Enables or disables an Interactable so Interactors can or cannot select and activate it.")]
    public sealed class InteractableSetEnabled : BaseAction
    {
        [Tooltip("The Interactable to enable or disable.")]
        [SerializeField]
        private InteractableVar _interactable;

        [Tooltip("Set whether the Interactable is enabled for interaction.")]
        [SerializeField]
        private BoolVar _isEnabled;

        public override bool CanExecute() => CheckParameters(_interactable, _isEnabled);

        public override void Execute()
        {
            var interactable = _interactable.Value;
            if (!interactable)
            {
                return;
            }

            interactable.IsEnabled = _isEnabled.Value;
        }

        public override string GetSummary() => "Set {_interactable} enabled to {_isEnabled}";
    }
}

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [MovedFrom(true, null, null, "InteractionControllerSetRequiredTag")]
    [ActionCategory(Category.Interactor)]
    [ConvertibleGroup("Interactable")]
    [ActionDescription("Sets the optional required tag filter used by an Interactor when resolving nearby Interactables.")]
    public sealed class InteractorSetRequiredTag : BaseAction
    {
        [Tooltip("The Interactor to update.")]
        [SerializeField]
        private InteractorVar _interactionController;

        [TagValue, CanBeNullOrEmpty]
        [Tooltip("Optional tag filter applied to the resolved target GameObject. Leave empty to clear the filter.")]
        [SerializeField]
        private StringVar _requiredTag;

        public override bool CanExecute() => CheckParameters(_interactionController, _requiredTag);

        public override void Execute()
        {
            var controller = _interactionController.Value;
            if (!controller)
            {
                return;
            }

            controller.RequiredTag = _requiredTag.Value;
        }

        public override string GetSummary() =>
            "Set {_interactionController} Required Tag to {_requiredTag}";
    }
}

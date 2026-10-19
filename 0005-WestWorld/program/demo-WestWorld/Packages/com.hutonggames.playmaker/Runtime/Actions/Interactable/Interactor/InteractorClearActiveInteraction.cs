using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [MovedFrom(true, null, null, "InteractionControllerClearActiveInteraction")]
    [ActionCategory(Category.Interactor)]
    [ConvertibleGroup("Interactable")]
    [ActionDescription("Clears the active interaction on an Interactor.")]
    public sealed class InteractorClearActiveInteraction : BaseAction
    {
        [Tooltip("The Interactor whose active interaction should be cleared.")]
        [SerializeField]
        private InteractorVar _interactionController;

        public override bool CanExecute() => CheckParameters(_interactionController);

        public override void Execute()
        {
            var controller = _interactionController.Value;
            if (!controller)
            {
                return;
            }

            controller.ClearActiveInteraction();
        }

        public override string GetSummary() =>
            "Clear active interaction on {_interactionController}";
    }
}

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [MovedFrom(true, null, null, "InteractionControllerSuppressInteractable")]
    [ActionCategory(Category.Interactor)]
    [ConvertibleGroup("Interactable")]
    [ActionDescription("Temporarily suppresses an Interactable in the Interactor so it cannot be selected again immediately.")]
    public sealed class InteractorSuppressInteractable : BaseAction
    {
        [Tooltip("The Interactor that owns the suppression state.")]
        [SerializeField]
        private InteractorVar _interactionController;

        [Tooltip("The Interactable to suppress.")]
        [SerializeField]
        private InteractableVar _interactable;

        [Tooltip("Suppression duration in seconds.")]
        [SerializeField]
        private FloatVar _suppressDuration;

        public override bool CanExecute() => CheckParameters(_interactionController, _interactable, _suppressDuration);

        public override void Execute()
        {
            var controller = _interactionController.Value;
            var interactable = _interactable.Value;
            if (!controller || !interactable)
            {
                return;
            }

            controller.SuppressInteractable(interactable, _suppressDuration.Value);
        }

        public override string GetSummary() =>
            "Suppress {_interactable} on {_interactionController} for {_suppressDuration} seconds";
    }
}

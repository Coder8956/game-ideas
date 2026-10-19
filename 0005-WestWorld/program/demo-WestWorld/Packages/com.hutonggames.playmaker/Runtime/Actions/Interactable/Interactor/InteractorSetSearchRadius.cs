using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [MovedFrom(true, null, null, "InteractionControllerSetSearchRadius")]
    [ActionCategory(Category.Interactor)]
    [ConvertibleGroup("Interactable")]
    [ActionDescription("Sets the search radius used by an Interactor when resolving nearby Interactables.")]
    public sealed class InteractorSetSearchRadius : BaseAction
    {
        [Tooltip("The Interactor to update.")]
        [SerializeField]
        private InteractorVar _interactionController;

        [Tooltip("Search radius around the interaction origin.")]
        [SerializeField]
        private FloatVar _searchRadius;

        public override bool CanExecute() => CheckParameters(_interactionController, _searchRadius);

        public override void Execute()
        {
            var controller = _interactionController.Value;
            if (!controller)
            {
                return;
            }

            controller.SearchRadius = _searchRadius.Value;
        }

        public override string GetSummary() =>
            "Set {_interactionController} Search Radius to {_searchRadius}";
    }
}

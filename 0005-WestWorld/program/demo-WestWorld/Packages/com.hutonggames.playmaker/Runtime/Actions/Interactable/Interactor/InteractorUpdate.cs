using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [MovedFrom(true, null, null, "InteractionControllerActivationMode")]
    public enum InteractorActivationMode
    {
        None,
        Manual,
        MouseButtonDown,
        MouseButton
    }

    [Serializable]
    [PublicAPI]
    [MovedFrom(true, null, null, "InteractionControllerUpdate")]
    [ActionCategory(Category.Interactor)]
    [ConvertibleGroup("Interactable")]
    [ActionDescription("Updates an Interactor, evaluating all nearby Interactable components.")]
    public sealed class InteractorUpdate : BaseAction
    {
        private Interactor _controller;

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The Interactor to update.")]
        [SerializeField]
        private InteractorVar _interactionController;

        [Tooltip("How activation input is resolved for explicit interactions.")]
        [SerializeField, DefaultValue(InteractorActivationMode.None)]
        private InteractorActivationMode _activationMode;

        [OptionalField, HideIf(nameof(HideInteractPressed))]
        [Tooltip("Activation input state when Activation Mode is Manual.")]
        [SerializeField, DefaultValue(false)]
        private BoolRef _interactPressed;

        [HideIf(nameof(HideMouseButton))]
        [Tooltip("Mouse button index when Activation Mode uses mouse input. 0 = left, 1 = right, 2 = middle.")]
        [SerializeField, DefaultValue(0)]
        private IntegerVar _mouseButton;

        [OptionalField, HideIf(nameof(HideInteractionId))]
        [Tooltip("Optional activation identifier for the current activation input, such as Use or AltUse.")]
        [SerializeField]
        private StringVar _interactActivationId;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("True when the current selection can interact this update.")]
        [SerializeField, WriteOnly]
        private BoolRef _canInteract;

        [OptionalField]
        [Tooltip("The best Interactable component found.")]
        [SerializeField, WriteOnly]
        private InteractableRef _interactable;

        [OptionalField]
        [Tooltip("The resolved target GameObject for the best Interactable.")]
        [SerializeField, WriteOnly]
        private GameObjectRef _targetGameObject;

        [OptionalField]
        [Tooltip("Interaction name from the component.")]
        [SerializeField, WriteOnly]
        private StringRef _interaction;

        [OptionalField]
        [Tooltip("Activation identifier from the component.")]
        [SerializeField, WriteOnly]
        private StringRef _activationId;

        [OptionalField]
        [Tooltip("Approach normal of the best interactable target.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _normal;

        [OptionalField]
        [Tooltip("Distance from the interactor reference transform to the chosen interactable reference transform.")]
        [SerializeField, WriteOnly]
        private FloatRef _distance;

        [OptionalField]
        [Tooltip("Local event to send in this FSM when a new interaction is activated.")]
        [SerializeField]
        private EventRef _interactEvent;

        public override bool CanExecute() => CheckParameters(_interactionController);

        public override void OnStop()
        {
            if (_controller)
            {
                _controller.StopHoverTracking();
            }
        }

        public override void Execute()
        {
            _controller = _interactionController.Value;
            if (!_controller)
            {
                ClearOutputs();
                return;
            }

            _controller.BeginDeferredSystemEvents();
            try
            {
                _controller.EnsurePassiveStateUpdated();
                _controller.TryActivate(ResolveInteractPressed(),
                                        _interactActivationId != null && _interactActivationId.IsAssigned ? _interactActivationId.Value : string.Empty);

                if (_canInteract is { IsAssigned: true })
                {
                    _canInteract.Value = _controller.CanInteract;
                }

                if (_controller.CurrentSelectionInteractable)
                {
                    if (_interactable is { IsAssigned: true }) _interactable.Value = _controller.CurrentSelectionInteractable;
                    if (_targetGameObject is { IsAssigned: true }) _targetGameObject.Value = _controller.CurrentSelectionTarget;
                    if (_interaction is { IsAssigned: true }) _interaction.Value = _controller.CurrentInteraction;
                    if (_activationId is { IsAssigned: true }) _activationId.Value = _controller.CurrentActivationId;
                    if (_normal is { IsAssigned: true }) _normal.Value = _controller.CurrentNormal;
                    if (_distance is { IsAssigned: true }) _distance.Value = _controller.CurrentSelectionDistance;
                }
                else
                {
                    ClearSelectionOutputs();
                }

                if (_controller.DidActivateThisUpdate)
                {
                    _controller.FlushPendingSystemEvents();
                    SendEvent(_interactEvent);
                }
            }
            finally
            {
                _controller.FlushPendingSystemEvents();
            }
        }

        public override string GetSummary()
        {
            return "Update {_interactionController} interactions" +
                   _activationMode switch
                   {
                       InteractorActivationMode.Manual => " with {_interactPressed}",
                       InteractorActivationMode.MouseButtonDown => " with mouse {_mouseButton:mouseButton} button down",
                       InteractorActivationMode.MouseButton => " with mouse{_mouseButton:mouseButton} button",
                       _ => string.Empty
                   } +
                   " {_interactable:output} {_targetGameObject:output} {_interaction:output} {_interactEvent}";
        }

        private bool HideInteractPressed => _activationMode != InteractorActivationMode.Manual;
        private bool HideMouseButton => _activationMode is InteractorActivationMode.Manual or InteractorActivationMode.None;
        private bool HideInteractionId => _activationMode == InteractorActivationMode.None;

        private bool ResolveInteractPressed()
        {
            return _activationMode switch
            {
                InteractorActivationMode.Manual => _interactPressed is { Value: true },
                InteractorActivationMode.MouseButtonDown => InputShim.GetMouseButtonDown(_mouseButton.Value),
                InteractorActivationMode.MouseButton => InputShim.GetMouseButton(_mouseButton.Value),
                _ => false
            };
        }

        private void ClearOutputs()
        {
            if (_canInteract is { IsAssigned: true }) _canInteract.Value = false;
            ClearSelectionOutputs();
        }

        private void ClearSelectionOutputs()
        {
            if (_interactable is { IsAssigned: true }) _interactable.Value = null;
            if (_targetGameObject is { IsAssigned: true }) _targetGameObject.Value = null;
            if (_interaction is { IsAssigned: true }) _interaction.Value = string.Empty;
            if (_activationId is { IsAssigned: true }) _activationId.Value = string.Empty;
            if (_normal is { IsAssigned: true }) _normal.Value = Vector3.zero;
            if (_distance is { IsAssigned: true }) _distance.Value = 0f;
        }

#if UNITY_EDITOR
        public override bool HasDebugInfo => true;

        public override string GetDebugInfo()
        {
            return _controller ? _controller.GetDebugInfo() : string.Empty;
        }
#endif
    }
}

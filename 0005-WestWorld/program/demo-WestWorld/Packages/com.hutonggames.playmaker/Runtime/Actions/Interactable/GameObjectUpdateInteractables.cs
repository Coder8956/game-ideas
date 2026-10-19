using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Obsolete("Use InteractorUpdate instead")]
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.InteractionGameObject)]
    [ConvertibleGroup("Interactable")]
    [ActionDescription("Updates nearby Interactable targets for a GameObject using an Interactor. " +
                       "Sends Interactables system events for focus, lost focus, valid candidate enter and exit, and OnInteract when the selected Interactable is activated.")]
    public sealed class GameObjectUpdateInteractables : BaseAction
    {
        private Interactor _controller;

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The GameObject checking for interactable targets.")]
        [SerializeField, OwnerDefaultValue]
        private GameObjectVar _gameObject;

        [OptionalField]
        [Tooltip("Optional interaction origin transform. Uses the GameObject transform when not assigned.")]
        [SerializeField]
        private TransformVar _referenceTransform;

        [OptionalField]
        [Tooltip("Current activation input state for targets that need activation. Example: a button or ATM usually needs this pressed, while a ladder or climb volume may activate without it.")]
        [SerializeField, DefaultValue(false)]
        private BoolRef _interactPressed;

        [OptionalField]
        [Tooltip("Optional activation identifier for the current activation input, such as Use or AltUse. Interactables with a matching activation ID can activate when pressed.")]
        [SerializeField]
        private StringRef _interactActivationId;

        [OptionalField]
        [Tooltip("Keeps the current active interaction selected while true, even if temporary gating like facing, approach, raycast, or explicit input is no longer satisfied. The lock is released if the interactable is disabled, destroyed, out of range, or no longer passes the tag filter.")]
        [SerializeField, DefaultValue(false)]
        private BoolRef _lockActiveInteraction;

        [Tooltip("Layers that may contain Interactable colliders.")]
        [SerializeField, DefaultValue("Physics.DefaultRaycastLayers")]
        private LayerMaskVar _interactableLayers;

        [Tooltip("Layers that can block the Require Raycast Hit check.")]
        [SerializeField, DefaultValue("Physics.DefaultRaycastLayers")]
        private LayerMaskVar _blockingLayers;

        [Tooltip("Whether overlap checks should consider Trigger colliders.")]
        [SerializeField, DefaultValue(QueryTriggerInteraction.Collide)]
        private QueryTriggerInteraction _hitTriggers;

        [OptionalField]
        [Tooltip("Optional tag filter applied to the resolved target GameObject.")]
        [SerializeField]
        private StringVar _requiredTag;

        [Tooltip("Search radius around the Transform position.")]
        [SerializeField, DefaultValue(1.5f)]
        private FloatVar _searchRadius;

        [Tooltip("Deprecated. Visual validity is now exposed through system events.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _updateValidVisuals;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("True when a valid interactable target was found.")]
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
        [Tooltip("Interaction value from the component.")]
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
        [Tooltip("Distance from the Transform position to the chosen interactable reference transform.")]
        [SerializeField, WriteOnly]
        private FloatRef _distance;

        [OptionalField]
        [Tooltip("Local event to send in this FSM when a new interaction is activated.")]
        [SerializeField]
        private EventRef _interactEvent;

        public override bool CanExecute() => CheckParameters(_gameObject, _interactableLayers);

        public override void OnStop()
        {
            if (_controller)
            {
                _controller.StopHoverTracking();
            }
        }

        public override void Execute()
        {
            var controller = ResolveController();
            if (!controller)
            {
                ClearOutputs();
                return;
            }

            var blockingLayers = _blockingLayers != null
                ? _blockingLayers.Value
                : _interactableLayers.Value;

            controller.ReferenceTransform = _referenceTransform.Value;
            controller.InteractableLayers = _interactableLayers.Value;
            controller.BlockingLayers = blockingLayers;
            controller.HitTriggers = _hitTriggers;
            controller.RequiredTag = _requiredTag != null && _requiredTag.HasValue() ? _requiredTag.Value : string.Empty;
            controller.SearchRadius = _searchRadius.Value;
            controller.LockActiveInteraction = _lockActiveInteraction != null && _lockActiveInteraction.Value;
            controller.InvalidatePassiveState();
            controller.BeginDeferredSystemEvents();
            try
            {
                controller.EnsurePassiveStateUpdated();
                controller.TryActivate(_interactPressed != null && _interactPressed.Value,
                                       _interactActivationId != null && _interactActivationId.IsAssigned ? _interactActivationId.Value : string.Empty);

                if (_canInteract is { IsAssigned: true })
                {
                    _canInteract.Value = controller.CanInteract;
                }

                if (controller.CurrentSelectionInteractable)
                {
                    if (_interactable is { IsAssigned: true }) _interactable.Value = controller.CurrentSelectionInteractable;
                    if (_targetGameObject is { IsAssigned: true }) _targetGameObject.Value = controller.CurrentSelectionTarget;
                    if (_interaction is { IsAssigned: true }) _interaction.Value = controller.CurrentInteraction;
                    if (_activationId is { IsAssigned: true }) _activationId.Value = controller.CurrentActivationId;
                    if (_normal is { IsAssigned: true }) _normal.Value = controller.CurrentNormal;
                    if (_distance is { IsAssigned: true }) _distance.Value = controller.CurrentSelectionDistance;
                }
                else
                {
                    ClearSelectionOutputs();
                }

                if (controller.DidActivateThisUpdate)
                {
                    controller.FlushPendingSystemEvents();
                    SendEvent(_interactEvent);
                }
            }
            finally
            {
                controller.FlushPendingSystemEvents();
            }
        }

        public override string GetSummary()
        {
            return "Update {_gameObject} interactables " +
                   (_interactPressed.IsAssigned ? " {_interactPressed}" : "") +
                   (_interactActivationId is { IsAssigned: true } ? " {_interactActivationId}" : "") +
                   "{_interactable:output} {_targetGameObject:output} {_interaction:output} {_interactEvent}";
        }

        private Interactor ResolveController()
        {
            var owner = _gameObject.Value != null ? _gameObject.Value : _referenceTransform.Value != null ? _referenceTransform.Value.gameObject : null;
            if (!owner)
            {
                _controller = null;
                return null;
            }

            if (_controller && _controller.gameObject == owner)
            {
                return _controller;
            }

            _controller = owner.GetComponent<Interactor>();
            if (!_controller)
            {
                _controller = owner.AddComponent<Interactor>();
            }

            return _controller;
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

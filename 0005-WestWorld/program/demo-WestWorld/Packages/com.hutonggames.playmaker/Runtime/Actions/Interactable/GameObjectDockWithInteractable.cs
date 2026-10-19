using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.InteractionGameObject)]
    [ConvertibleGroup("Interactable")]
    [ActionDescription("Docks a GameObject to an Interactable. If the Interactable has no docking set up, then it just sends the Docked Event." +
                       "<br/>Uses Rigidbody, Rigidbody2D, or CharacterController handling when present, otherwise sets the Transform directly.")]
    public sealed class GameObjectDockWithInteractable : BaseAction
    {
        private Vector3 _startPosition;
        private Vector3 _startLocalPosition;
        private Quaternion _startRotation;
        private float _startTime;
        private bool _initialized;
        private bool _completed;

        public override bool CanFinish => true;
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The GameObject to dock.")]
        [SerializeField, OwnerDefaultValue]
        private GameObjectVar _gameObject;

        [Tooltip("The Interactable to dock with.")]
        [SerializeField]
        private InteractableVar _interactable;

        [Tooltip("Zero Rigidbody or Rigidbody2D velocity after docking.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _zeroVelocity;

        [Tooltip("Smooth docking duration in seconds. Set to 0 for an immediate snap.")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _smoothDuration;

        [Tooltip("Easing function used for smooth docking transitions.")]
        [SerializeField, DefaultValue(HutongGames.PlayMaker.EasingFunction.Ease.Linear)]
        private EasingFunctionVar _easing;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("The docking transform used.")]
        [SerializeField, WriteOnly]
        private TransformRef _dockingTransform;

        [OptionalField]
        [Tooltip("Event to send after docking.")]
        [SerializeField]
        private EventRef _dockedEvent;

        public override bool CanExecute() =>
            CheckParameters(_gameObject, _interactable, _zeroVelocity, _smoothDuration, _easing);

        public override void OnStart()
        {
            _initialized = false;
            _completed = false;
        }

        public override void Execute()
        {
            if (_completed)
            {
                Finish();
                return;
            }

            var actor = _gameObject.Value;
            var interactable = _interactable.Value;
            if (!actor || !interactable)
            {
                Finish();
                return;
            }

            if (!interactable.ShouldDock)
            {
                CompleteDock();
                return;
            }

            var dock = interactable.DockingTransform;
            if (!dock)
            {
                Finish();
                return;
            }

            if (_dockingTransform is { IsAssigned: true })
            {
                _dockingTransform.Value = dock;
            }

            var usePosition = interactable.DockPosition;
            var useRotation = interactable.DockRotation;
            if (!usePosition && !useRotation)
            {
                CompleteDock();
                return;
            }

            if (!_initialized)
            {
                _startPosition = actor.transform.position;
                _startLocalPosition = dock.InverseTransformPoint(_startPosition);
                _startRotation = actor.transform.rotation;
                _startTime = Time.time;
                _initialized = true;
            }

            var duration = Mathf.Max(0f, _smoothDuration.Value);
            if (duration <= Mathf.Epsilon)
            {
                ApplyImmediateDock(actor, dock, interactable.DockPositionAxis, usePosition, useRotation, _zeroVelocity.Value);
                CompleteDock();
                return;
            }

            var t = Mathf.Clamp01((Time.time - _startTime) / duration);
            var easedT = HutongGames.PlayMaker.EasingFunction.Evaluate(_easing.Value, t);
            Progress = t;
            ApplySmoothDock(actor, dock, interactable.DockPositionAxis, usePosition, useRotation, _zeroVelocity.Value, easedT);

            if (t < 1f)
            {
                return;
            }

            CompleteDock();
        }

        public override string GetSummary() =>
            "Dock {_gameObject} with {_interactable} {_dockingTransform:output} {_dockedEvent}";

        private void CompleteDock()
        {
            if (_completed)
            {
                return;
            }

            _completed = true;
            Progress = 1f;
            SendEvent(_dockedEvent);
            Finish();
        }

        private void ApplyImmediateDock(GameObject actor, Transform dock, MoveAxis positionAxis, bool setPosition, bool setRotation, bool zeroVelocity) =>
            GameObjectDockUtility.ApplyImmediateDock(actor, dock, _startLocalPosition, positionAxis, setPosition, setRotation, zeroVelocity);

        private void ApplySmoothDock(GameObject actor, Transform dock, MoveAxis positionAxis, bool setPosition, bool setRotation, bool zeroVelocity, float t) =>
            GameObjectDockUtility.ApplySmoothDock(actor,
                                                  dock,
                                                  _startPosition,
                                                  _startLocalPosition,
                                                  _startRotation,
                                                  positionAxis,
                                                  setPosition,
                                                  setRotation,
                                                  zeroVelocity,
                                                  t);
    }
}

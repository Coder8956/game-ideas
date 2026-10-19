using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameplayMovementGameObject)]
    [ActionDescription("Docks a GameObject to a Transform. Uses Rigidbody, Rigidbody2D, or CharacterController handling when present, otherwise sets the Transform directly.")]
    public sealed class GameObjectDockWithTransform : BaseAction
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

        [Tooltip("The Transform to dock with.")]
        [SerializeField]
        private TransformVar _target;

        [Tooltip("Match the docking position.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _setPosition;

        [Tooltip("Constrain position docking to a line or plane using the target transform axes. XYZ matches the full target position.")]
        [SerializeField, DefaultValue(MoveAxis.XYZ)]
        private MoveAxisVar _positionAxis;

        [Tooltip("Match the docking rotation.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _setRotation;

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
        [Tooltip("The target transform used.")]
        [SerializeField, WriteOnly]
        private TransformRef _dockingTransform;

        [OptionalField]
        [Tooltip("Event to send after docking.")]
        [SerializeField]
        private EventRef _dockedEvent;

        public override bool CanExecute() =>
            CheckParameters(_gameObject, _target, _setPosition, _positionAxis, _setRotation, _zeroVelocity, _smoothDuration, _easing);

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
            var dock = _target.Value;
            if (!actor || !dock)
            {
                Finish();
                return;
            }

            if (_dockingTransform is { IsAssigned: true })
            {
                _dockingTransform.Value = dock;
            }

            ExecuteDock(actor, dock);
        }

        public override string GetSummary() =>
            "Dock {_gameObject} with {_target} {_dockingTransform:output} {_dockedEvent}";

        internal void ExecuteDock(GameObject actor, Transform dock)
        {
            var usePosition = _setPosition.Value;
            var useRotation = _setRotation.Value;
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
                GameObjectDockUtility.ApplyImmediateDock(actor, dock, _startLocalPosition, _positionAxis.Value, usePosition, useRotation, _zeroVelocity.Value);
                CompleteDock();
                return;
            }

            var t = Mathf.Clamp01((Time.time - _startTime) / duration);
            var easedT = HutongGames.PlayMaker.EasingFunction.Evaluate(_easing.Value, t);
            Progress = t;
            GameObjectDockUtility.ApplySmoothDock(actor,
                                                  dock,
                                                  _startPosition,
                                                  _startLocalPosition,
                                                  _startRotation,
                                                  _positionAxis.Value,
                                                  usePosition,
                                                  useRotation,
                                                  _zeroVelocity.Value,
                                                  easedT);

            if (t < 1f)
            {
                return;
            }

            CompleteDock();
        }

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
    }
}

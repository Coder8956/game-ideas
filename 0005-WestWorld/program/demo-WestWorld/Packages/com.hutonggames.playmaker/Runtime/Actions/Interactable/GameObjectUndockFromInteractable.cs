using JetBrains.Annotations;
using HutongGames.PlayMaker.Internal;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.InteractionGameObject)]
    [ConvertibleGroup("Interactable")]
    [ActionDescription("Undocks a GameObject from an Interactable using its Undocking Transform when assigned, otherwise the Interactable's transform. Uses Rigidbody or Rigidbody2D APIs when present, otherwise sets the Transform directly.")]
    public sealed class GameObjectUndockFromInteractable : BaseAction
    {
        private Vector3 _startPosition;
        private Quaternion _startRotation;
        private float _startTime;
        private bool _initialized;
        private bool _completed;

        public override bool CanFinish => true;
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The GameObject to undock.")]
        [SerializeField, OwnerDefaultValue]
        private GameObjectVar _gameObject;

        [Tooltip("The Interactable to undock from.")]
        [SerializeField]
        private InteractableVar _interactable;

        [Tooltip("Match the undocking position.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _setPosition;

        [Tooltip("Match the undocking rotation.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _setRotation;

        [Tooltip("Zero Rigidbody or Rigidbody2D velocity after undocking.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _zeroVelocity;

        [Tooltip("Smooth undocking duration in seconds. Set to 0 for an immediate snap.")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _smoothDuration;

        [Tooltip("Easing function used for smooth undocking transitions.")]
        [SerializeField, DefaultValue(HutongGames.PlayMaker.EasingFunction.Ease.Linear)]
        private EasingFunctionVar _easing;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("The undocking transform used.")]
        [SerializeField, WriteOnly]
        private TransformRef _undockingTransform;

        [OptionalField]
        [Tooltip("Event to send after undocking.")]
        [SerializeField]
        private EventRef _undockedEvent;

        public override bool CanExecute() =>
            CheckParameters(_gameObject, _interactable, _setPosition, _setRotation, _zeroVelocity, _smoothDuration, _easing);

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

            var undock = interactable.HasUndockingTransform ? interactable.UndockingTransform : interactable.ReferenceTransform;
            if (!undock)
            {
                Finish();
                return;
            }

            if (_undockingTransform is { IsAssigned: true })
            {
                _undockingTransform.Value = undock;
            }

            var usePosition = _setPosition.Value;
            var useRotation = _setRotation.Value;
            if (!usePosition && !useRotation)
            {
                CompleteUndock();
                return;
            }

            if (!_initialized)
            {
                _startPosition = actor.transform.position;
                _startRotation = actor.transform.rotation;
                _startTime = Time.time;
                _initialized = true;
            }

            var duration = Mathf.Max(0f, _smoothDuration.Value);
            if (duration <= Mathf.Epsilon)
            {
                ApplyImmediateUndock(actor, undock, usePosition, useRotation, _zeroVelocity.Value);
                CompleteUndock();
                return;
            }

            var t = Mathf.Clamp01((Time.time - _startTime) / duration);
            var easedT = HutongGames.PlayMaker.EasingFunction.Evaluate(_easing.Value, t);
            Progress = t;
            ApplySmoothUndock(actor, undock, usePosition, useRotation, _zeroVelocity.Value, easedT);

            if (t < 1f)
            {
                return;
            }

            CompleteUndock();
        }

        public override string GetSummary() =>
            "Undock {_gameObject} from {_interactable} {_undockingTransform:output} {_undockedEvent}";

        private void CompleteUndock()
        {
            if (_completed)
            {
                return;
            }

            _completed = true;
            Progress = 1f;
            SendEvent(_undockedEvent);
            Finish();
        }

        private void ApplyImmediateUndock(GameObject actor, Transform undock, bool setPosition, bool setRotation, bool zeroVelocity)
        {
            if (actor.TryGetComponent<Rigidbody>(out var rb))
            {
                UndockRigidbody(rb, undock, setPosition, setRotation, zeroVelocity);
                return;
            }

            if (actor.TryGetComponent<Rigidbody2D>(out var rb2d))
            {
                UndockRigidbody2D(rb2d, undock, setPosition, setRotation, zeroVelocity);
                return;
            }

            var actorTransform = actor.transform;
            var position = setPosition ? undock.position : actorTransform.position;
            var rotation = setRotation ? undock.rotation : actorTransform.rotation;
            actorTransform.SetPositionAndRotation(position, rotation);
        }

        private void ApplySmoothUndock(GameObject actor, Transform undock, bool setPosition, bool setRotation, bool zeroVelocity, float t)
        {
            var position = setPosition ? Vector3.Lerp(_startPosition, undock.position, t) : actor.transform.position;
            var rotation = setRotation ? Quaternion.Slerp(_startRotation, undock.rotation, t) : actor.transform.rotation;

            if (actor.TryGetComponent<Rigidbody>(out var rb))
            {
                UndockRigidbodySmooth(rb, position, rotation, setPosition, setRotation, zeroVelocity);
                return;
            }

            if (actor.TryGetComponent<Rigidbody2D>(out var rb2d))
            {
                UndockRigidbody2DSmooth(rb2d, position, rotation, setPosition, setRotation, zeroVelocity);
                return;
            }

            actor.transform.SetPositionAndRotation(position, rotation);
        }

        private static void UndockRigidbody(Rigidbody rb, Transform undock, bool setPosition, bool setRotation, bool zeroVelocity)
        {
            if (setPosition)
            {
                rb.position = undock.position;
            }

            if (setRotation)
            {
                rb.rotation = undock.rotation;
            }

            if (!zeroVelocity)
            {
                return;
            }

            rb.SetVelocityShim(Vector3.zero);
            rb.angularVelocity = Vector3.zero;
        }

        private static void UndockRigidbodySmooth(Rigidbody rb, Vector3 position, Quaternion rotation, bool setPosition, bool setRotation, bool zeroVelocity)
        {
            if (setPosition)
            {
                rb.MovePosition(position);
            }

            if (setRotation)
            {
                rb.MoveRotation(rotation);
            }

            if (!zeroVelocity)
            {
                return;
            }

            rb.SetVelocityShim(Vector3.zero);
            rb.angularVelocity = Vector3.zero;
        }

        private static void UndockRigidbody2D(Rigidbody2D rb, Transform undock, bool setPosition, bool setRotation, bool zeroVelocity)
        {
            if (setPosition)
            {
                rb.position = undock.position;
            }

            if (setRotation)
            {
                rb.rotation = undock.eulerAngles.z;
            }

            if (!zeroVelocity)
            {
                return;
            }

            rb.SetVelocityShim(Vector2.zero);
            rb.angularVelocity = 0f;
        }

        private static void UndockRigidbody2DSmooth(Rigidbody2D rb, Vector3 position, Quaternion rotation, bool setPosition, bool setRotation, bool zeroVelocity)
        {
            if (setPosition)
            {
                rb.MovePosition(position);
            }

            if (setRotation)
            {
                rb.MoveRotation(rotation.eulerAngles.z);
            }

            if (!zeroVelocity)
            {
                return;
            }

            rb.SetVelocityShim(Vector2.zero);
            rb.angularVelocity = 0f;
        }
    }
}

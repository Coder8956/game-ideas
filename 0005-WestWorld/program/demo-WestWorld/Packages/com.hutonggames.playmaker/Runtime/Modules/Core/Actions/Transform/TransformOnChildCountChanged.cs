using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Sends an event when a Transform's child count changes.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-childCount.html")]
    public class TransformOnChildCountChanged : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;

        [OwnerDefaultValue]
        [Tooltip("The Transform to watch.")]
        public TransformVar Transform;

        [OptionalField]
        [Tooltip("Send this event when the child count changes.")]
        public EventRef ChildCountChangedEvent;

        [OptionalField]
        [Tooltip("Send this event when the child count increases.")]
        public EventRef ChildCountIncreasedEvent;

        [OptionalField]
        [Tooltip("Send this event when the child count decreases.")]
        public EventRef ChildCountDecreasedEvent;

        [OptionalField]
        [WriteOnly]
        [Tooltip("Store the previous child count before the change.")]
        public IntegerRef PreviousChildCount;

        [OptionalField]
        [WriteOnly]
        [Tooltip("Store the current child count after the change.")]
        public IntegerRef CurrentChildCount;

        private int _lastChildCount;
        private bool _initialized;

        public override bool CanExecute() => CheckParameters(Transform);

        public override void OnStateEnter()
        {
            var transform = Transform.Value;
            _lastChildCount = transform != null ? transform.childCount : 0;
            _initialized = transform != null;
        }

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null)
            {
                _initialized = false;
                return;
            }

            var childCount = transform.childCount;
            if (!_initialized)
            {
                _lastChildCount = childCount;
                _initialized = true;
                return;
            }

            if (childCount == _lastChildCount) return;

            if (PreviousChildCount.IsAssigned)
            {
                PreviousChildCount.Value = _lastChildCount;
            }

            if (CurrentChildCount.IsAssigned)
            {
                CurrentChildCount.Value = childCount;
            }

            var increased = childCount > _lastChildCount;

            _lastChildCount = childCount;
            SendEvent(ChildCountChangedEvent);
            SendEvent(increased ? ChildCountIncreasedEvent : ChildCountDecreasedEvent);
        }

        public override string ErrorCheck() =>
            !ChildCountChangedEvent.IsSet &&
            !ChildCountIncreasedEvent.IsSet &&
            !ChildCountDecreasedEvent.IsSet &&
            !PreviousChildCount.IsAssigned &&
            !CurrentChildCount.IsAssigned
                ? "Action does not send an event or store any values!"
                : null;

        public override string GetSummary()
        {
            var summary = "On {Transform} child count";

            if (ChildCountChangedEvent.IsSet)
            {
                summary += " changed {" + nameof(ChildCountChangedEvent) + "}";
            }

            if (ChildCountIncreasedEvent.IsSet)
            {
                summary += " increased {" + nameof(ChildCountIncreasedEvent) + "}";
            }

            if (ChildCountDecreasedEvent.IsSet)
            {
                summary += " decreased {" + nameof(ChildCountDecreasedEvent) + "}";
            }

            summary += " {PreviousChildCount:output} {CurrentChildCount:output}";

            return summary;
        }
    }
}

using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Gets the next sibling after the given transform in the hierarchy.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.GetChild.html")]
    public sealed class TransformGetNextSibling : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        [SerializeField]
        private TransformVar _transform;

        [Tooltip("Skip in-active GameObjects.")]
        [SerializeField]
        private BoolVar _skipInactive;
        
        [Tooltip("If true, loops back to the first sibling when no next sibling is found.")]
        [SerializeField]
        private BoolVar _loop;
        
        [Tooltip("Store the next sibling.")]
        [SerializeField]
        [WriteOnly]
        private TransformRef _result;

        [Tooltip("Event sent when there are no more siblings after this transform.")]
        [SerializeField]
        [OptionalField]
        private EventRef _noNextSibling;

        
        public override bool CanExecute()
        {
            return CheckParameters(_transform, _skipInactive, _loop, _result);
        }

        public override void Execute()
        {
            var transform = _transform.Value;
            if (transform == null) return;

            var parent = transform.parent;
            if (parent == null)
            {
                _result.Value = null;
                return;
            }

            var siblingIndex = transform.GetSiblingIndex();
            var nextIndex = siblingIndex + 1;

            // First try searching forward from current position
            while (nextIndex < parent.childCount)
            {
                var nextSibling = parent.GetChild(nextIndex);
                if (!_skipInactive.Value || nextSibling.gameObject.activeInHierarchy)
                {
                    _result.Value = nextSibling;
                    return;
                }
                nextIndex++;
            }

            // No next sibling found without looping
            SendEvent(_noNextSibling);

            // If loop is enabled, search from the beginning
            if (_loop.Value)
            {
                nextIndex = 0;
                while (nextIndex < siblingIndex)
                {
                    var nextSibling = parent.GetChild(nextIndex);
                    if (!_skipInactive.Value || nextSibling.gameObject.activeInHierarchy)
                    {
                        _result.Value = nextSibling;
                        return;
                    }
                    nextIndex++;
                }
            }

            _result.Value = null;
        }

        public override string GetSummary()
        {
            return "Get sibling after {_transform} -> {_result}";
        }
    }
}
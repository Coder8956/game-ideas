using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Gets the previous sibling before the given transform in the hierarchy.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.GetChild.html")]
    public sealed class TransformGetPreviousSibling : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        [SerializeField]
        private TransformVar _transform;

        [Tooltip("Skip in-active GameObjects.")]
        [SerializeField]
        private BoolVar _skipInactive;
        
        [Tooltip("If true, loops back to the last sibling when no previous sibling is found.")]
        [SerializeField]
        private BoolVar _loop;
        
        [Tooltip("Store the previous sibling.")]
        [SerializeField]
        [WriteOnly]
        private TransformRef _result;

        [Tooltip("Event sent when there are no more siblings before this transform.")]
        [SerializeField]
        [OptionalField]
        private EventRef _noPreviousSibling;

        
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
            var prevIndex = siblingIndex - 1;

            // First try searching backward from current position
            while (prevIndex >= 0)
            {
                var prevSibling = parent.GetChild(prevIndex);
                if (!_skipInactive.Value || prevSibling.gameObject.activeInHierarchy)
                {
                    _result.Value = prevSibling;
                    return;
                }
                prevIndex--;
            }

            // No previous sibling found without looping
            SendEvent(_noPreviousSibling);

            // If loop is enabled, search from the end
            if (_loop.Value)
            {
                prevIndex = parent.childCount - 1;
                while (prevIndex > siblingIndex)
                {
                    var prevSibling = parent.GetChild(prevIndex);
                    if (!_skipInactive.Value || prevSibling.gameObject.activeInHierarchy)
                    {
                        _result.Value = prevSibling;
                        return;
                    }
                    prevIndex--;
                }
            }

            _result.Value = null;
        }

        public override string GetSummary()
        {
            return "Get sibling before {_transform} -> {_result}";
        }
    }
}
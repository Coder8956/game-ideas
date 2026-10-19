using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get a child GameObject by index using the GameObject's Transform hierarchy.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.GetChild.html")]
    public sealed class GameObjectGetChild : BaseAction
    {
        [SerializeField, OwnerDefaultValue]
        [Tooltip("The parent GameObject.")]
        private GameObjectVar _gameObject;

        [SerializeField]
        [Tooltip("The index of the child.")]
        private IntegerVar _childIndex;

        [SerializeField, WriteOnly]
        [Tooltip("Store the child GameObject, or null if not found.")]
        private GameObjectRef _result;

        public override bool CanExecute()
        {
            return CheckParameters(_gameObject, _childIndex, _result);
        }

        public override void Execute()
        {
            var gameObject = _gameObject.Value;
            if (gameObject == null)
            {
                _result.Value = null;
                return;
            }

            var transform = gameObject.transform;
            var index = _childIndex.Value;
            _result.Value = index >= 0 && index < transform.childCount
                ? transform.GetChild(index).gameObject
                : null;
        }

        public override string GetSummary()
        {
            return "Get {_gameObject} child {_childIndex} -> {_result}";
        }
    }
}

using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get all GameObject ancestors, ordered from parent to root.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-parent.html")]
    public sealed class GameObjectGetAncestors : BaseAction
    {
        [SerializeField, OwnerDefaultValue]
        [Tooltip("The GameObject to start from.")]
        private GameObjectVar _gameObject;

        [SerializeField, WriteOnly]
        [Tooltip("Store the ancestor GameObjects, ordered from parent to root.")]
        private GameObjectListRef _result;

        public override bool CanExecute()
        {
            return CheckParameters(_gameObject, _result);
        }

        public override void Execute()
        {
            var ancestors = new List<GameObject>();
            var current = _gameObject.Value != null ? _gameObject.Value.transform.parent : null;
            while (current != null)
            {
                ancestors.Add(current.gameObject);
                current = current.parent;
            }

            _result.Value = ancestors;
        }

        public override string GetSummary()
        {
            return "Get {_gameObject} ancestors -> {_result}";
        }
    }
}

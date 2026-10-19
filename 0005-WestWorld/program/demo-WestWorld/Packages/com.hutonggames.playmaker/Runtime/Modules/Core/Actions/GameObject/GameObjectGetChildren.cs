using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get all child GameObjects using the GameObject's Transform hierarchy.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.html")]
    public sealed class GameObjectGetChildren : BaseAction
    {
        [SerializeField, OwnerDefaultValue]
        [Tooltip("The parent GameObject.")]
        private GameObjectVar _gameObject;

        [SerializeField, WriteOnly]
        [Tooltip("Store the child GameObjects.")]
        private GameObjectListRef _result;

        public override bool CanExecute()
        {
            return CheckParameters(_gameObject, _result);
        }

        public override void Execute()
        {
            var children = new List<GameObject>();
            var transform = _gameObject.Value != null ? _gameObject.Value.transform : null;
            if (transform != null)
            {
                foreach (Transform child in transform)
                {
                    children.Add(child.gameObject);
                }
            }

            _result.Value = children;
        }

        public override string GetSummary()
        {
            return "Get {_gameObject} children -> {_result}";
        }
    }
}

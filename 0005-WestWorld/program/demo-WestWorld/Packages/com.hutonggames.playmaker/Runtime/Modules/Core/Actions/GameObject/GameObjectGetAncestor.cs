using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get a GameObject ancestor by level. Level 0 returns the GameObject, 1 returns its parent, 2 returns its grandparent, and so on.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-parent.html")]
    public sealed class GameObjectGetAncestor : BaseAction
    {
        [SerializeField, OwnerDefaultValue]
        [Tooltip("The GameObject to start from.")]
        private GameObjectVar _gameObject;

        [SerializeField, DefaultValue(1)]
        [Tooltip("How many levels to move up the hierarchy. 0 returns the GameObject, 1 returns its parent, 2 returns its grandparent, and so on.")]
        private IntegerVar _ancestorLevel;

        [SerializeField, WriteOnly]
        [Tooltip("Store the ancestor GameObject, or null if no ancestor exists at the requested level.")]
        private GameObjectRef _result;

        public override bool CanExecute()
        {
            return CheckParameters(_gameObject, _ancestorLevel, _result);
        }

        public override void Execute()
        {
            var gameObject = _gameObject.Value;
            if (gameObject == null)
            {
                _result.Value = null;
                return;
            }

            var ancestorLevel = _ancestorLevel.Value;
            if (ancestorLevel < 0)
            {
                _result.Value = null;
                return;
            }

            var current = gameObject.transform;
            for (var i = 0; i < ancestorLevel && current != null; i++)
            {
                current = current.parent;
            }

            _result.Value = current != null ? current.gameObject : null;
        }

        public override string GetSummary()
        {
            return "Get {_gameObject} ancestor level {_ancestorLevel} -> {_result}";
        }
    }
}

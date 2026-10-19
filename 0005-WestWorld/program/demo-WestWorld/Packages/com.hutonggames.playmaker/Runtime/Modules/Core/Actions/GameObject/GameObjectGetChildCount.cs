using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get the number of child GameObjects using the GameObject's Transform hierarchy.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-childCount.html")]
    public sealed class GameObjectGetChildCount : BaseAction
    {
        [SerializeField, OwnerDefaultValue]
        [Tooltip("The parent GameObject.")]
        private GameObjectVar _gameObject;

        [SerializeField, WriteOnly]
        [Tooltip("Store the child count in a variable.")]
        private IntegerRef _result;

        public override bool CanExecute()
        {
            return CheckParameters(_gameObject, _result);
        }

        public override void Execute()
        {
            var gameObject = _gameObject.Value;
            _result.Value = gameObject != null ? gameObject.transform.childCount : 0;
        }

        public override string GetSummary()
        {
            return "Get {_gameObject} child count -> {_result}";
        }
    }
}

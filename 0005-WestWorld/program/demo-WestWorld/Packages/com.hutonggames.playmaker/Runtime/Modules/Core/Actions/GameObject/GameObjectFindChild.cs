using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Find a child GameObject by name using the GameObject's Transform hierarchy.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Find.html")]
    public sealed class GameObjectFindChild : BaseAction
    {
        [SerializeField, OwnerDefaultValue]
        [Tooltip("The parent GameObject.")]
        private GameObjectVar _gameObject;

        [SerializeField]
        [Tooltip("The name of the child to find.")]
        private StringVar _childName;

        [SerializeField, WriteOnly]
        [Tooltip("Store the child GameObject, or null if not found.")]
        private GameObjectRef _result;

        public override bool CanExecute()
        {
            return CheckParameters(_gameObject, _childName, _result);
        }

        public override void Execute()
        {
            var gameObject = _gameObject.Value;
            var child = gameObject != null ? gameObject.transform.Find(_childName.Value) : null;
            _result.Value = child != null ? child.gameObject : null;
        }

        public override string GetSummary()
        {
            return "Find {_gameObject} child {_childName} -> {_result}";
        }
    }
}

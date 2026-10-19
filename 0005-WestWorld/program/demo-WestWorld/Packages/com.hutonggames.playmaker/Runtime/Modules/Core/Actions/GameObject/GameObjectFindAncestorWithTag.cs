using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Find the first parent in a GameObject's hierarchy with the specified tag.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.CompareTag.html")]
    public sealed class GameObjectFindAncestorWithTag : BaseAction
    {
        [SerializeField, OwnerDefaultValue]
        [Tooltip("The GameObject to start from.")]
        private GameObjectVar _gameObject;

        [SerializeField, TagValue]
        [Tooltip("The tag to search for.")]
        private StringVar _tag;

        [SerializeField, WriteOnly]
        [Tooltip("Store the matching ancestor GameObject, or null if no ancestor with the specified tag exists.")]
        private GameObjectRef _result;

        public override bool CanExecute()
        {
            return CheckParameters(_gameObject, _tag, _result);
        }

        public override void Execute()
        {
            _result.Value = null;

            var tag = _tag.Value;
            if (_gameObject.Value == null || string.IsNullOrEmpty(tag))
            {
                return;
            }

            var current = _gameObject.Value.transform.parent;
            while (current != null)
            {
                if (current.gameObject.CompareTag(tag))
                {
                    _result.Value = current.gameObject;
                    return;
                }

                current = current.parent;
            }
        }

        public override string GetSummary()
        {
            return "Find {_gameObject} ancestor with tag {_tag} -> {_result}";
        }
    }
}

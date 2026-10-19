using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Find the first child in a GameObject's hierarchy with the specified tag.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.CompareTag.html")]
    public sealed class GameObjectFindChildWithTag : BaseAction
    {
        [SerializeField, OwnerDefaultValue]
        [Tooltip("The GameObject to start from.")]
        private GameObjectVar _gameObject;

        [SerializeField, TagValue]
        [Tooltip("The tag to search for.")]
        private StringVar _tag;

        [SerializeField, WriteOnly]
        [Tooltip("Store the matching child GameObject, or null if no child with the specified tag exists.")]
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

            _result.Value = FindChildWithTag(_gameObject.Value.transform, tag);
        }

        private static GameObject FindChildWithTag(Transform parent, string tag)
        {
            foreach (Transform child in parent)
            {
                if (child.gameObject.CompareTag(tag))
                {
                    return child.gameObject;
                }

                var result = FindChildWithTag(child, tag);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        public override string GetSummary()
        {
            return "Find {_gameObject} child with tag {_tag} -> {_result}";
        }
    }
}

using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameplayTargetingGameObject)]
    [ActionDescription("Finds the first child GameObject that matches a list of conditions.")]
    [HelpURL("actions/gameobject-actions/query/game-object-find-first-child-match/")]
    public sealed class GameObjectFindFirstChildMatch : BaseAction
    {
        [Tooltip("The parent GameObject to search under.")]
        [SerializeField, OwnerDefaultValue]
        private GameObjectVar _parent;

        [Tooltip(Strings.ConditionTest)]
        [BaseType(typeof(GameObject))]
        [SerializeField]
        private ConditionTest _findFirstChildWhere = new();

        [Tooltip("Also search descendants.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _recursive;

        [Tooltip("Store the result in a GameObject variable.")]
        [SerializeField, WriteOnly]
        private GameObjectRef _result;

        public override bool CanExecute()
        {
            return CheckParameters(_parent, _findFirstChildWhere, _recursive, _result);
        }

        public override void Execute()
        {
            _result.Value = null;

            var parent = _parent.Value;
            if (parent == null)
            {
                return;
            }

            _result.Value = FindFirstChildMatch(parent.transform, _findFirstChildWhere, _recursive.Value);
        }

        private static GameObject FindFirstChildMatch(Transform parent, ConditionTest conditionTest, bool recursive)
        {
            for (var i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                var childGameObject = child.gameObject;
                if (conditionTest.Evaluate(childGameObject))
                {
                    return childGameObject;
                }

                if (!recursive)
                {
                    continue;
                }

                var result = FindFirstChildMatch(child, conditionTest, true);
                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        public override string GetSummary()
        {
            return _recursive.Value
                ? "Find first child of {_parent} recursively where {_findFirstChildWhere} -> {_result}"
                : "Find first child of {_parent} where {_findFirstChildWhere} -> {_result}";
        }
    }
}

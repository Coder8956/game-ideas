using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameplayTargetingGameObject)]
    [ActionDescription("Finds child GameObjects that match a list of conditions.")]
    [HelpURL("actions/gameobject-actions/query/game-object-find-child-matches/")]
    public sealed class GameObjectFindChildMatches : BaseAction
    {
        [Tooltip("The parent GameObject to search under.")]
        [SerializeField, OwnerDefaultValue]
        private GameObjectVar _parent;

        [Tooltip(Strings.ConditionTest)]
        [BaseType(typeof(GameObject))]
        [SerializeField]
        private ConditionTest _findChildrenWhere = new();

        [Tooltip("Also search descendants.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _recursive;

        [Tooltip("Store the matching GameObjects in a GameObject list variable.")]
        [SerializeField, WriteOnly]
        private GameObjectListRef _result;

        public override bool CanExecute()
        {
            return CheckParameters(_parent, _findChildrenWhere, _recursive, _result);
        }

        public override void Execute()
        {
            var matches = new List<GameObject>();
            var parent = _parent.Value;
            if (parent != null)
            {
                AddChildMatches(parent.transform, _findChildrenWhere, _recursive.Value, matches);
            }

            _result.Value = matches;
        }

        private static void AddChildMatches(
            Transform parent,
            ConditionTest conditionTest,
            bool recursive,
            List<GameObject> matches)
        {
            for (var i = 0; i < parent.childCount; i++)
            {
                var child = parent.GetChild(i);
                var childGameObject = child.gameObject;
                if (conditionTest.Evaluate(childGameObject))
                {
                    matches.Add(childGameObject);
                }

                if (recursive)
                {
                    AddChildMatches(child, conditionTest, true, matches);
                }
            }
        }

        public override string GetSummary()
        {
            return _recursive.Value
                ? "Find children of {_parent} recursively where {_findChildrenWhere} -> {_result}"
                : "Find children of {_parent} where {_findChildrenWhere} -> {_result}";
        }
    }
}

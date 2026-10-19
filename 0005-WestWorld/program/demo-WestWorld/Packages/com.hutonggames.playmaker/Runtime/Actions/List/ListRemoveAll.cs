
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Removes all items from the List variable that match specified conditions.")]
    public class ListRemoveAll : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [MatchType(nameof(List))]
        [Tooltip(Strings.ConditionTest)]
        public ConditionTest RemoveItemsWhere = new ();
        
        public override bool CanExecute() => CheckParameters(List);

        public override void Execute() => List.ListVariable.RemoveAll(x => RemoveItemsWhere.Evaluate(x));

        public override string GetSummary() => "Remove all items in {List} where {RemoveItemsWhere}";
    }
}

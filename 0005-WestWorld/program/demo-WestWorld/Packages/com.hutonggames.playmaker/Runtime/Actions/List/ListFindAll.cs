
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Finds all items in a list that match the specified conditions.")]
    public class ListFindAll : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to search.")]
        [SerializeReference] public IListVariableRef List;

        [MatchType(nameof(List))]
        [Tooltip(Strings.ConditionTest)]
        public ConditionTest FindItemsWhere = new ();
        
        [MatchType(nameof(List))]
        [Tooltip("Store the result in a list.")]
        [WriteOnly, SerializeReference] public IListVariableRef StoreResult; 
        
        public override bool CanExecute() => CheckParameters(List, StoreResult);

        public override void Execute() => 
            StoreResult.SetValue(List.ListVariable.FindAll(x => FindItemsWhere.Evaluate(x)));

        public override string GetSummary() => "Find all items in {List} {FindItemsWhere} -> {StoreResult}";
    }
}

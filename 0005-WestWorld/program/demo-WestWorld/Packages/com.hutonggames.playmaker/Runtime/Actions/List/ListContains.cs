
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ConvertibleGroup("CheckList")]
    [ActionDescription("Check if a list contains an item. Stores result in a bool variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains")]
    public class ListContains : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to check for.")]
        [SerializeReference] public IVariableVar Item;

        [WriteOnly]
        [Tooltip("Store the result in a bool variable.")]
        public BoolRef Result;

        public override bool CanExecute() => CheckParameters(List, Item, Result);

        public override void Execute() => Result.Value = List.ListVariable.Contains(Item.GetValue());

        public override string GetSummary() => "Check {List} contains {Item} -> {Result}";
    }
}

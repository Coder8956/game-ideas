
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Get the zero-based index of the last occurrence of a value in a list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.lastindexof")]
    public class ListLastIndexOf : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to search.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to find.")]
        [SerializeReference] public IVariableVar Item;
        
        [WriteOnly]
        [Tooltip("The zero-based index of the item, or -1 if not found.")]
        public IntegerRef GetIndex;

        public override bool CanExecute() => CheckParameters(List, Item, GetIndex);

        public override void Execute() => GetIndex.Value = List.ListVariable.LastIndexOf(Item.GetValue());

        public override string GetSummary() => "Get {List} last index of {Item} -> {GetIndex}";
    }
}
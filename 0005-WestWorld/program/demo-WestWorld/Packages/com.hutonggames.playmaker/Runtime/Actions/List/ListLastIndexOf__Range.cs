
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Get the zero-based index of the last occurrence of a value in a list. " +
                       "Search in a range that extends from the specified index for the specified number of elements.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.lastindexof")]
    public class ListLastIndexOf__Range : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to search.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to find.")]
        [SerializeReference] public IVariableVar Item;

        [Tooltip("Search from this index.")]
        public IntegerVar StartIndex;
        
        [Tooltip("Search this number of elements.")]
        public IntegerVar Count;
        
        [WriteOnly]
        [Tooltip("The zero-based index of the item, or -1 if not found.")]
        public IntegerRef GetIndex;

        public override bool CanExecute() => CheckParameters(List, Item, StartIndex, Count, GetIndex);

        public override void Execute() => GetIndex.Value = List.ListVariable.LastIndexOf(Item.GetValue(), StartIndex.Value, Count.Value);

        public override string GetSummary() => "Get last index of {Item} in {List} from {StartIndex} count {Count} -> {GetIndex}";
    }
}

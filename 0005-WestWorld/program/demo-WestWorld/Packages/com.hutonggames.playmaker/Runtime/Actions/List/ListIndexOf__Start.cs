
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
    [ActionDescription("Get the zero-based index of the first occurrence of a value in a list. " +
                       "Search in a range that extends from the specified index to the last element.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.indexof")]
    public class ListIndexOf__Start : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to find.")]
        [SerializeReference] public IVariableVar Item;

        [Tooltip("Search from this index to the last element.")]
        public IntegerVar StartIndex;
        
        [WriteOnly]
        [Tooltip("The zero-based index of the item, or -1 if not found.")]
        public IntegerRef GetIndex;

        public override bool CanExecute() => CheckParameters(List, Item, StartIndex, GetIndex);

        public override void Execute() => GetIndex.Value = List.ListVariable.IndexOf(Item.GetValue(), StartIndex.Value);

        public override string GetSummary() => "Get index of {Item} in {List} (start:{StartIndex}) -> {GetIndex}";
    }
}
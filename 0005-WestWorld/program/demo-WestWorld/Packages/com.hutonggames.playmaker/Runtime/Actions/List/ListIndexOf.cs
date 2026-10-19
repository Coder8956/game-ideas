
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Get the zero-based index of the first occurrence of a value in a list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.indexof")]
    public class ListIndexOf : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to find.")]
        [SerializeReference] public IVariableVar Item;
        
        [WriteOnly]
        [Tooltip("The zero-based index of the item, or -1 if not found.")]
        public IntegerRef GetIndex;

        public override bool CanExecute() => CheckParameters(List, Item, GetIndex);

        public override void Execute() => GetIndex.Value = List.ListVariable.IndexOf(Item.GetValue());

        public override string GetSummary() => "Get index of {Item} in {List} -> {GetIndex}";
    }
}
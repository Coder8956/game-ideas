
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ConvertibleGroup("ListGetItem")]
    [ActionDescription("Get the item at the specified index.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item")]
    public class ListGetItem : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [Tooltip("The zero-based index of the item to set.")]
        public IntegerVar AtIndex;
        
        [MatchType(nameof(List))]
        [ConvertibleName("Item")]
        [Tooltip("Store the item in a variable.")]
        [WriteOnly, SerializeReference] public IVariableRef GetItem;

        public override bool CanExecute() => CheckParameters(List, AtIndex, GetItem);

        public override void Execute() => GetItem.SetValue(List.ListVariable[AtIndex.Value]);

        public override string GetSummary() => "Get {List} item at {AtIndex} -> {GetItem}";
    }
}
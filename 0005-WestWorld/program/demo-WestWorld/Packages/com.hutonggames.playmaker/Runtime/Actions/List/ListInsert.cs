
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Add an item to a List variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.insert")]
    public class ListInsert : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to insert.")]
        [SerializeReference] public IVariableVar InsertItem;
        
        [Tooltip("The zero-based list index at which to insert the item.")]
        public IntegerVar AtIndex;

        public override bool CanExecute() => CheckParameters(List, InsertItem, AtIndex);

        public override void Execute() => List.ListVariable.Insert( AtIndex.Value, InsertItem.GetValue());

        public override string GetSummary() => "Insert {InsertItem} into {List} at {AtIndex}";
    }
}

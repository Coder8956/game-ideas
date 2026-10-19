
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Replace an item at an index in a List variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.insert")]
    public class ListReplaceAt : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to insert.")]
        [SerializeReference] public IVariableVar Item;
        
        [Tooltip("The zero-based list index at which to insert the item, removing the current item.")]
        public IntegerVar AtIndex;

        public override bool CanExecute() => CheckParameters(List, Item, AtIndex);

        public override void Execute()
        {
            List.ListVariable.RemoveAt(AtIndex.Value);
            List.ListVariable.Insert(AtIndex.Value, Item.GetValue());
        }

        public override string GetSummary() => "Replace item at {AtIndex} in {List} with {Item}";
    }
}

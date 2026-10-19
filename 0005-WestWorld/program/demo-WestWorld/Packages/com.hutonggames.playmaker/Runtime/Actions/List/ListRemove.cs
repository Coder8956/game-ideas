
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Removes the first occurrence of an item from a list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.remove")]
    public class ListRemove : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to search.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to remove.")]
        [SerializeReference, CanBeNullOrEmpty] public IVariableVar RemoveItem;

        public override bool CanExecute() => CheckParameters(List, RemoveItem);

        public override void Execute() => List.ListVariable.Remove(RemoveItem.GetValue());

        public override string GetSummary() => "Remove {RemoveItem} from {List}";
    }
}

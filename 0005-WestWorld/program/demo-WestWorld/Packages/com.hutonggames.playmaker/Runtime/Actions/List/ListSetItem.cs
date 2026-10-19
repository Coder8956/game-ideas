
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Set the item at the specified index.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item")]
    public class ListSetItem : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [Tooltip("The zero-based index of the item to set.")]
        public IntegerVar AtIndex;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to set.")]
        [SerializeReference] public IVariableVar SetItem;

        public override bool CanExecute() => CheckParameters(List, AtIndex, SetItem);

        public override void Execute() => List.ListVariable[AtIndex.Value] = SetItem.GetValue();

        public override string GetSummary() => "Set {List} item at {AtIndex} to {SetItem}";
    }
}
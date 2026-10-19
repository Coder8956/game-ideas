
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
    [ActionDescription("Copy a range of elements in a source list to another list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.getrange")]
    public class ListGetRange : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The source list.")]
        [SerializeReference] public IListVariableRef SourceList;

        [Tooltip("The zero-based list index at which the range starts.")]
        public IntegerVar StartIndex;

        [Tooltip("The number of elements in the range.")]
        public IntegerVar Count;
        
        [MatchType(nameof(SourceList))]
        [Tooltip("The list to copy items to.")]
        [WriteOnly, SerializeReference] public IListVariableRef DestinationList;

        public override bool CanExecute() => CheckParameters(SourceList, StartIndex, Count, DestinationList);

        public override void Execute() => DestinationList.SetValue(SourceList.ListVariable.GetRange(StartIndex.Value, Count.Value));

        public override string GetSummary() => "Copy {Count} items from {SourceList} starting at {StartIndex} -> {DestinationList}";
    }
}

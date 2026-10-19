
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
    [ActionDescription("Reverses the order of the elements in a portion of a list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.reverse")]
    public class ListReverse__Range : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [Tooltip("Start from this index.")]
        public IntegerVar StartIndex;
        
        [Tooltip("Reverse this number of elements.")]
        public IntegerVar Count;
        
        public override bool CanExecute() => CheckParameters(List, StartIndex, Count);

        public override void Execute() => List.ListVariable.Reverse(StartIndex.Value, Count.Value);
        
        public override string GetSummary() => "Reverse {Count} items in {List} starting at {StartIndex}";
    }
}

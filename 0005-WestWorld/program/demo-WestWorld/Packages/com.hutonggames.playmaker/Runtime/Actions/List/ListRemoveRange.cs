
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Removes a range of elements from a list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removerange")]
    public class ListRemoveRange : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [Tooltip("Remove from this index.")]
        public IntegerVar StartIndex;
        
        [Tooltip("Remove this number of elements.")]
        public IntegerVar Count;

        public override bool CanExecute() => CheckParameters(List, StartIndex, Count);

        public override void Execute() => List.ListVariable.RemoveRange(StartIndex.Value, Count.Value);

        public override string GetSummary() => "Remove {Count} items from {List} starting at {StartIndex}";
    }
}

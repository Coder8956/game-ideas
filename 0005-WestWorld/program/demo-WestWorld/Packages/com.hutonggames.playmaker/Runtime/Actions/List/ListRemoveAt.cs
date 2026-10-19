
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Removes the item at the specified index.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.removeat")]
    public class ListRemoveAt : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [Tooltip("The zero-based index of the item to remove.")]
        public IntegerVar RemoveAtIndex;

        public override bool CanExecute() => CheckParameters(List, RemoveAtIndex);

        public override void Execute() => List.ListVariable.RemoveAt(RemoveAtIndex.Value);

        public override string GetSummary() => "Remove item at {RemoveAtIndex} from {List}";
    }
}

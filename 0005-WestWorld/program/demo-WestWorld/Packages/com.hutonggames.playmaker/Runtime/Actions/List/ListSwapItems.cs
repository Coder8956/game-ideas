using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Swap two items in a List.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item")]
    public class ListSwapItems : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [Tooltip("The zero-based index of the first item.")]
        public IntegerVar FirstIndex;

        [Tooltip("The zero-based index of the second item.")]
        public IntegerVar SecondIndex;

        public override bool CanExecute() => CheckParameters(List, FirstIndex, SecondIndex);

        public override void Execute()
        {
            var list = List.ListVariable;
            var firstIndex = FirstIndex.Value;
            var secondIndex = SecondIndex.Value;

            if (firstIndex == secondIndex)
            {
                return;
            }

            (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
        }

        public override string GetSummary() => "Swap items in {List} at {FirstIndex} and {SecondIndex}";
    }
}

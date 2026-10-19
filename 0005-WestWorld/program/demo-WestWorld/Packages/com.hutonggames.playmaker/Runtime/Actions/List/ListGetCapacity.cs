
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Get the capacity of a list variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.capacity")]
    public class ListGetCapacity : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [WriteOnly]
        [Tooltip("Store the capacity in a variable.")]
        public IntegerRef GetCapacity;

        public override bool CanExecute() => CheckParameters(List, GetCapacity);

        public override void Execute() => GetCapacity.Value = List.ListVariable.Capacity;

        public override string GetSummary() => "Get {List} capacity -> {GetCapacity}";
    }
}

using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Set the capacity of a list variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.capacity")]
    public class ListSetCapacity : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [Tooltip("Set the list capacity.")]
        public IntegerVar SetCapacity;

        public override bool CanExecute() => CheckParameters(List, SetCapacity);

        public override void Execute() => List.ListVariable.Capacity = SetCapacity.Value;

        public override string GetSummary() => "Set {List} capacity to {SetCapacity}";
    }
}
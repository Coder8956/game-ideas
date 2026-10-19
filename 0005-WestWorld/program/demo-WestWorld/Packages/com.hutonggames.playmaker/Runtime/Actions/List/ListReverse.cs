
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Reverses the order of the elements in a list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.reverse")]
    public class ListReverse : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        public override bool CanExecute() => CheckParameters(List);

        public override void Execute() => List.ListVariable.Reverse();
        
        public override string GetSummary() => "Reverse {List}";
    }
}
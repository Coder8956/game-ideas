
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Removes all items from the list.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.clear")]
    public class ListClear : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to clear.")]
        [SerializeReference] public IListVariableRef List;

        public override bool CanExecute() => CheckParameters(List);

        public override void Execute() => List.ListVariable.Clear();
        
        public override string GetSummary() => "Clear {List}";
    }
}

using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Get the number of items in a ListVariable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.count")]
    public class ListGetCount : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [WriteOnly]
        [Tooltip("Get the number of items in the list.")]
        public IntegerRef GetCount;

        public override bool CanExecute() => CheckParameters(List, GetCount);

        public override void Execute() => GetCount.Value = List.ListVariable.Count;
        
        public override string GetSummary() => "Get {List} count -> {GetCount}";
    }
}
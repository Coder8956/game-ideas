
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Sort items in a list using the default comparer." +
                       "\nNOTE: Unity Objects are sorted by name. " +
                       "If the type does not have a comparer, it is sorted by the string returned by ToString().")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort")]
    public class ListSort : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        public override bool CanExecute() => CheckParameters(List);

        public override void Execute() => List.ListVariable.Sort();
        
        public override string GetSummary() => "Sort {List}";
    }
}
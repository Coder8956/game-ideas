using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicCollection)]
    [ConvertibleGroup("CheckList")]
    [ActionDescription("Checks if a list is empty. Sends Events based on the result.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.count")]
    public class CheckListIsEmpty : BaseTrueFalseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to check.")]
        [SerializeReference] public IListVariableRef List;
        
        protected override bool Test() => List.ListVariable.Count == 0;

        protected override string TrueSummary => "{List} is empty";
        protected override string FalseSummary => "{List} is not empty";
    }
}
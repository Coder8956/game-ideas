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
    [ActionDescription("Checks if a list contains an item. Sends Events based on the result.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains")]
    public class CheckListContains : BaseTrueFalseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to check.")]
        [SerializeReference] public IListVariableRef List;

        [MatchType(nameof(List))]
        [Tooltip("The item to check for.")]
        [SerializeReference] public IVariableVar Item;
        
        protected override bool Test() => List.ListVariable.Contains(Item.GetValue());

        protected override string TrueSummary => "{List} contains {Item}";
        protected override string FalseSummary => "{List} does not contain {Item}";
    }
}
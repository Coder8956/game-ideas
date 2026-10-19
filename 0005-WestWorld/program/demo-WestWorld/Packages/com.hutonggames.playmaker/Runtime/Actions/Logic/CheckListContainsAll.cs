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
    [ActionDescription("Checks if a list contains all of the given items. Sends Events based on the result.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains")]
    public class CheckListContainsAll : BaseTrueFalseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to check.")]
        [SerializeReference] public IListVariableRef List;

        [MatchType(nameof(List))]
        [Tooltip("The items to check for.")]
        [SerializeReference] public IVariableVar[] Items;

        protected override bool Test()
        {
            foreach (var item in Items)
            {
                if (!List.ListVariable.Contains(item.GetValue()))
                {
                    return false;
                }
            }

            return true;
        }

        protected override string TrueSummary => "{List} contains all {Items}";
        protected override string FalseSummary => "{List} does not contain all {Items}";
    }
}
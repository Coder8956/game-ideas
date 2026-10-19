using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicCollection)]
    [ConvertibleGroup("CheckList")]
    [ActionDescription("Checks if a list contains only items in the given list of items. Sends Events based on the result.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains")]
    public class CheckListContainsOnly : BaseTrueFalseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to check.")]
        [SerializeReference] public IListVariableRef List;

        [MatchType(nameof(List))]
        [Tooltip("The list of items to check for.")]
        [SerializeReference] public IVariableVar[] Items;

        [Tooltip("The list must contain all of the given items (but only those items).")]
        [SerializeField] public BoolVar AllItems;
        
        protected override bool Test()
        {
            var items = new HashSet<object>();
            foreach (var item in Items)
            {
                var value = item.GetValue();
                items.Add(value);
                if (AllItems.Value && !List.ListVariable.Contains(value))
                    return false;
            }

            foreach (var value in List.ListVariable.List)
            {
                if (!items.Contains(value)) return false;
            }

            return true;
        }

        protected override string TrueSummary => "{List} contains only {Items}";
        protected override string FalseSummary => "{List} does not contain only {Items}";
    }
}
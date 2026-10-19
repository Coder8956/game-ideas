
using System;
using System.Collections;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Obsolete("Use CheckListContainsOnly instead.")]
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Check if a list contains only items in the given list of items. Stores result in a bool variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains")]
    public class ListContainsOnly : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The items to check for.")]
        [SerializeReference] public IVariableVar[] Items;

        [Tooltip("The list must contain all of the given items (but only those items).")]
        [SerializeField] public BoolVar AllItems;
        
        [WriteOnly]
        [Tooltip("Store the result in a bool variable.")]
        public BoolRef Result;

        public override bool CanExecute() => CheckParameters(List, Items, Result);

        public override void Execute() => 
            Result.Value = Test();
        
        private bool Test()
        {
            var items = Items.Select(x => x.GetValue()).ToList();
            if (AllItems.Value && !Items.All(item => List.ListVariable.Contains(item.GetValue()))) 
                return false;

            foreach (var value in List.ListVariable.List)
            {
                if (!items.Contains(value)) return false;
            }

            return true;
        }
        public override string GetSummary() => "{List} contains only {Items} -> {Result}";
    }
}
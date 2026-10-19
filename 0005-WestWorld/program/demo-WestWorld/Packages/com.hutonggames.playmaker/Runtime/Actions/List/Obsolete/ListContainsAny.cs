
using System;
using System.Collections;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Obsolete("Use CheckListContainsAny instead.")]
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Check if a list contains any of the given items. Stores result in a bool variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains")]
    public class ListContainsAny : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The items to check for.")]
        [SerializeReference] public IVariableVar[] Items;

        [WriteOnly]
        [Tooltip("Store the result in a bool variable.")]
        public BoolRef Result;

        public override bool CanExecute() => CheckParameters(List, Items, Result);

        public override void Execute() => 
            Result.Value = Items.Any(item => List.ListVariable.Contains(item.GetValue()));
        
        public override string GetSummary() => "{List} contains any {Items} -> {Result}";
    }
}
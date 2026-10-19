
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Insert multiple items into a List.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.addrange")]
    public class ListInsertRange : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The items to add. NOTE: This can be another List variable.")]
        [SerializeReference] public IListVariableVar InsertItems;

        [Tooltip("The zero-based list index at which to insert the items.")]
        public IntegerVar AtIndex;
        
        public override bool CanExecute() => CheckParameters(List, InsertItems, AtIndex);

        public override void Execute() => List.ListVariable.InsertRange(AtIndex.Value, InsertItems.GetValue());

        public override string GetSummary() => "Insert {InsertItems} into {List} at {AtIndex}";
    }
}

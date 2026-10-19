
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Add multiple items to a List variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.addrange")]
    public class ListAddRange : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The items to add. NOTE: This can be another List variable.")]
        [FormerlySerializedAs("Items")]
        [SerializeReference] public IListVariableVar AddItems;

        public override bool CanExecute() => CheckParameters(List, AddItems);

        public override void Execute() => List.ListVariable.AddRange(AddItems.GetValue());

        public override string GetSummary() => "Add {AddItems} to {List}";
    }
}
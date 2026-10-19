
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Add an item to a List variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.add")]
    [MovedFrom( true,null,null,"ListAddItem")]   
    public class ListAdd : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The item to add.")]
        [FormerlySerializedAs("Item")]
        [SerializeReference, CanBeNullOrEmpty] public IVariableVar AddItem;

        public override bool CanExecute() => CheckParameters(List);

        public override void Execute() => List.ListVariable.AddItem(AddItem.GetValue());

        public override string GetSummary() => "Add {AddItem} to {List}";
    }
}
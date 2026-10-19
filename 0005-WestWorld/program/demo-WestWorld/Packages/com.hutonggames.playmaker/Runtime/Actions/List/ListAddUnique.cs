using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Add an item to a List variable only if it doesn't already exist.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.contains")]
    public class ListAddUnique : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [MatchType(nameof(List))]
        [Tooltip("The item to add if it is not already in the list.")]
        [SerializeReference, CanBeNullOrEmpty] public IVariableVar AddItem;

        [OptionalField]
        [WriteOnly]
        [Tooltip("True if the item was added.")]
        public BoolRef Added;

        public override bool CanExecute() => CheckParameters(List);

        public override void Execute()
        {
            if (Added is { IsAssigned: true }) Added.Value = false;

            var item = AddItem.GetValue();
            if (List.ListVariable.Contains(item))
                return;

            List.ListVariable.AddItem(item);

            if (Added is { IsAssigned: true }) Added.Value = true;
        }

        public override string GetSummary() => "Add {AddItem} to {List} if missing {Added:output}";
    }
}

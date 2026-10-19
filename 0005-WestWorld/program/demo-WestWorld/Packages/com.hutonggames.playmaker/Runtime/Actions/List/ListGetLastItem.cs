using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ConvertibleGroup("ListGetItem")]
    [ActionDescription("Get the last item in a List.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.item")]
    public class ListGetLastItem : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [OptionalField, WriteOnly]
        [Tooltip("Store the zero-based index of the last item.")]
        public IntegerRef LastItemIndex;
        
        [MatchType(nameof(List))]
        [ConvertibleName("Item")]
        [Tooltip("Store the last item in a variable.")]
        [WriteOnly, SerializeReference] public IVariableRef GetLastItem;

        public override bool CanExecute() => CheckParameters(List, GetLastItem);

        public override void Execute()
        {
            var list = List.ListVariable;
            if (list == null || list.Count == 0)
            {
                return;
            }

            var lastItemIndex = list.Count - 1;
            LastItemIndex?.SetValue(lastItemIndex);
            GetLastItem.SetValue(list[lastItemIndex]);
        }

        public override string GetSummary() => "Get last item from {List} -> {GetLastItem}";
    }
}

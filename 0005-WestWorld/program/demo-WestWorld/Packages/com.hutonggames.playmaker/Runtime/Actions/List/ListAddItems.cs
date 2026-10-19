using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Add multiple items to a List variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.add")]
    public class ListAddItems : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [MatchType(nameof(List))]
        [Tooltip("The items to add.")]
        [SerializeReference] public IVariableVar[] Items = Array.Empty<IVariableVar>();

        public override bool CanExecute() => CheckParameters(List, Items);

        public override void Execute()
        {
            foreach (var item in Items)
            {
                List.ListVariable.AddItem(item.GetValue());
            }
        }

        public override string GetSummary() => "Add {Items} to {List}";
    }
}

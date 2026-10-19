
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
    [ActionDescription("Sets the items in a List variable.")]
    [HelpURL("https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.addrange")]
    public class ListSetValue : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("Set the items. NOTE: This can be another List variable.")]
        [SerializeReference] public IListVariableVar Items;

        public override bool CanExecute() => CheckParameters(List, Items);

        public override void Execute()
        {
            List.ListVariable.Clear();
            List.ListVariable.AddRange(Items.GetValue());
        }

        public override string GetSummary() => "Set {List} to {Items}";
    }
}
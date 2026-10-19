using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [ActionDescription("Run actions in this state on each item in a list." +
                       "\n\nIf the list is empty, no actions will be run.")]
    public class ForEachListItem : BaseForEachAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] 
        private IListVariableRef _list;
        
        [MatchType(nameof(_list))]
        [Tooltip("The current item retrieved from the list.")]
        [SerializeReference, WriteOnly] 
        private IVariableRef _item;
        
        protected override int ItemCount => _list.ListVariable?.Count ?? 0;
        
        public override bool CanExecute() => CheckParameters(_list, _item);

        public override void EachAction(int index) => _item.SetValue(_list.ListVariable[index]);

        public override string GetSummary() => "For each {_item} in {_list}";
    }
}
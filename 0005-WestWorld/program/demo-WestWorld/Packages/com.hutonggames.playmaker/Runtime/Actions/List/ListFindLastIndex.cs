
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Finds the index of the last item in a list that matches the specified conditions.")]
    public class ListFindLastIndex : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to search.")]
        [SerializeReference] public IListVariableRef List;
        
        [MatchType(nameof(List))]
        [Tooltip("The conditions to test each item in the list against.")]
        public ConditionTest IndexOfLastItemWhere = new ();

        [ActionHeader("Output")]
        
        [OptionalField, WriteOnly]
        [Tooltip("The zero-based index of the item, or -1 if not found.")]
        public IntegerRef StoreResult; 

        [OptionalField, WriteOnly]
        [Tooltip("Set to true if a matching item was found.")]
        public BoolRef Found;

        [OptionalField]
        [Tooltip("Event to send if a matching item was found.")]
        public EventRef FoundEvent;

        [OptionalField]
        [Tooltip("Event to send if no matching item was found.")]
        public EventRef NotFoundEvent;
        
        public override bool CanExecute() => CheckParameters(List);

        public override void Execute()
        {
            if (Found is { IsAssigned: true }) Found.Value = false;

            var index = List.ListVariable.FindLastIndex(x => IndexOfLastItemWhere.Evaluate(x));
            StoreResult?.SetValue(index);

            if (index >= 0)
            {
                if (Found is { IsAssigned: true }) Found.Value = true;
                SendEvent(FoundEvent);
                return;
            }

            SendEvent(NotFoundEvent);
        }

        public override string GetSummary() => 
            "Find {List} last index of item where {IndexOfLastItemWhere} -> {StoreResult} {Found:output}";

        public override string ErrorCheck()
        {
            var hasStoreResult = StoreResult is { IsAssigned: true };
            var hasFound = Found is { IsAssigned: true };
            var hasFoundEvent = FoundEvent is { IsSet: true };
            var hasNotFoundEvent = NotFoundEvent is { IsSet: true };

            return hasStoreResult || hasFound || hasFoundEvent || hasNotFoundEvent
                ? null
                : "Action has no outputs set.";
        }
    }
}

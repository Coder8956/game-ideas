
using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.List)]
    [ActionDescription("Finds the last item in a list that matches the specified conditions.")]
    public class ListFindLast : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable to search.")]
        [SerializeReference] public IListVariableRef List;

        [MatchType(nameof(List))]
        [Tooltip(Strings.ConditionTest)]
        public ConditionTest FindLastItemWhere = new ();

        [ActionHeader("Output")]
        
        [OptionalField]
        [MatchType(nameof(List))]
        [Tooltip("Store the result.")]
        [WriteOnly, SerializeReference] public IVariableRef StoreResult; 

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

            var list = List.ListVariable.List;
            for (var i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                if (!FindLastItemWhere.Evaluate(item))
                    continue;

                StoreResult?.SetValue(item);
                if (Found is { IsAssigned: true }) Found.Value = true;
                SendEvent(FoundEvent);
                return;
            }

            StoreResult?.SetValue(null);
            SendEvent(NotFoundEvent);
        }

        public override string GetSummary() => 
            "Find last item in {List} where {FindLastItemWhere} -> {StoreResult} {Found:output}";

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

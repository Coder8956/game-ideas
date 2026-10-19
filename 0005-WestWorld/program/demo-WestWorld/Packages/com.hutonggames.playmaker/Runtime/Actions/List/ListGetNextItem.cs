
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
    [ConvertibleGroup("ListGetItem")]
    [ActionDescription("Get the next item in a List each time this action is called. " +
                       "This lets you quickly loop through all the items of an array to perform actions on them.")]
    public class ListGetNextItem : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [Tooltip("The first index in the traversal range.")]
        public IntegerVar StartIndex = new();

        [Tooltip("The last index in the traversal range. Leave at 0 to use the last item in the list.")]
        public IntegerVar EndIndex = new();

        [Tooltip("Loop back to the start index after reaching the end index. A Finished Event takes precedence when set.")]
        public BoolVar Loop = new() { Value = true };

        [OptionalField]
        [Tooltip("Set to true to restart traversal from the start index on the next run. The action resets this to false.")]
        public BoolRef ResetFlag = new();

        [OptionalField]
        [Tooltip("Optional current position. Leave unset for simple iteration using the action's internal counter. " +
                 "Set this to navigate from a known position. Use -1 to start before the first item. " +
                 "When set, this increases by one before getting the item.")]
        public IntegerRef CurrentIndex;

        [ActionHeader("Output")]
        
        [MatchType(nameof(List))]
        [ConvertibleName("Item")]
        [Tooltip("Store the next item in a variable.")]
        [WriteOnly, SerializeReference]
        [FormerlySerializedAs("GetNextItem")]
        public IVariableRef GetItem;

        [OptionalField, WriteOnly]
        [Tooltip("Store the index of the item that was returned.")]
        public IntegerRef ItemIndex;

        [ActionHeader("Events")]

        [OptionalField]
        [Tooltip("Event sent after getting the next item.")]
        public EventRef LoopEvent;

        [OptionalField]
        [Tooltip("Event sent when there are no more items. If unset and Loop is true, loop back to the start index.")]
        public EventRef FinishedEvent;

        [NonSerialized]
        private int _nextItemIndex = -1;
        
        public override bool CanExecute() => CheckParameters(List, GetItem);

        public override void Execute()
        {
            var list = List.ListVariable;
            if (list == null || list.Count == 0)
            {
                if (FinishedEvent is { IsSet: true })
                {
                    SendEvent(FinishedEvent);
                }
                return;
            }

            GetTraversalRange(list.Count, out var startIndex, out var endIndex);

            if (HasCurrentIndex)
            {
                ExecuteFromCurrentIndex(list, startIndex, endIndex);
                return;
            }

            if (ConsumeResetFlag())
            {
                NextItemIndex = startIndex;
            }
            else if (NextItemIndex > endIndex)
            {
                if (FinishedEvent is { IsSet: true })
                {
                    StoreItemIndex(endIndex);
                    NextItemIndex = startIndex;
                    SendEvent(FinishedEvent);
                    return;
                }

                if (!ShouldLoop())
                {
                    StoreItemIndex(endIndex);
                    return;
                }

                NextItemIndex = startIndex;
            }
            else if (NextItemIndex < startIndex)
            {
                NextItemIndex = startIndex;
            }

            var itemIndex = NextItemIndex;
            StoreItemIndex(itemIndex);
            GetItem.SetValue(list[itemIndex]);
            NextItemIndex = itemIndex >= endIndex ? endIndex + 1 : itemIndex + 1;

            if (HasExplicitEndIndex() && itemIndex >= endIndex && FinishedEvent is { IsSet: true })
            {
                NextItemIndex = startIndex;
                SendEvent(FinishedEvent);
                return;
            }
            
            SendEvent(LoopEvent);
        }

        private void ExecuteFromCurrentIndex(IListVariable list, int startIndex, int endIndex)
        {
            if (ConsumeResetFlag())
            {
                GetItemAtIndex(list, startIndex);
                SendEvent(LoopEvent);
                return;
            }

            if (CurrentIndex.Value >= endIndex)
            {
                if (FinishedEvent is { IsSet: true })
                {
                    StoreItemIndex(endIndex);
                    CurrentIndex.Value = endIndex;
                    SendEvent(FinishedEvent);
                    return;
                }

                if (!ShouldLoop())
                {
                    StoreItemIndex(endIndex);
                    CurrentIndex.Value = endIndex;
                    return;
                }

                GetItemAtIndex(list, startIndex);
                SendEvent(LoopEvent);
                return;
            }

            var itemIndex = CurrentIndex.Value < startIndex ? startIndex : CurrentIndex.Value + 1;
            GetItemAtIndex(list, itemIndex);

            if (HasExplicitEndIndex() && itemIndex >= endIndex && FinishedEvent is { IsSet: true })
            {
                SendEvent(FinishedEvent);
                return;
            }

            SendEvent(LoopEvent);
        }

        private void GetItemAtIndex(IListVariable list, int itemIndex)
        {
            CurrentIndex.Value = itemIndex;
            StoreItemIndex(itemIndex);
            GetItem.SetValue(list[itemIndex]);
        }

        private bool ConsumeResetFlag()
        {
            if (ResetFlag is not { IsNone: false } || !ResetFlag.Value)
            {
                return false;
            }

            ResetFlag.Value = false;
            return true;
        }

        private int NextItemIndex
        {
            get => CurrentIndex is { IsNone: false } ? CurrentIndex.Value : _nextItemIndex;
            set
            {
                if (CurrentIndex is { IsNone: false })
                {
                    CurrentIndex.Value = value;
                }
                else
                {
                    _nextItemIndex = value;
                }
            }
        }

        private bool HasCurrentIndex => CurrentIndex is { IsNone: false };

        private void StoreItemIndex(int index)
        {
            if (ItemIndex is { IsNone: false })
            {
                ItemIndex.Value = index;
            }
        }

        private void GetTraversalRange(int listCount, out int startIndex, out int endIndex)
        {
            startIndex = Mathf.Clamp(StartIndex?.Value ?? 0, 0, listCount - 1);
            endIndex = !HasExplicitEndIndex() ? listCount - 1 : Mathf.Clamp(EndIndex.Value, 0, listCount - 1);

            if (startIndex > endIndex)
            {
                (startIndex, endIndex) = (endIndex, startIndex);
            }
        }

        private bool HasExplicitEndIndex() => (EndIndex?.Value ?? 0) > 0;

        private bool ShouldLoop() => Loop?.Value ?? true;

        public override string GetSummary() => 
            "Get next item from {List} -> {GetItem}"
            + (FinishedEvent is { IsSet: true } ? " Finished {FinishedEvent}" : "");
    }
}

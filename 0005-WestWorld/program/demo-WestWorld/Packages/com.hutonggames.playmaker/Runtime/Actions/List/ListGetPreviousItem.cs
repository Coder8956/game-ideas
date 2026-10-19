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
    [ActionDescription("Get the previous item in a List each time this action is called.")]
    public class ListGetPreviousItem : BaseAction
    {
        [BaseType(typeof(IList))]
        [Tooltip("The list variable.")]
        [SerializeReference] public IListVariableRef List;

        [Tooltip("The first index in the traversal range.")]
        public IntegerVar StartIndex = new();

        [Tooltip("The last index in the traversal range. Leave at 0 to use the last item in the list.")]
        public IntegerVar EndIndex = new();

        [Tooltip("Loop back to the end index after reaching the start index.")]
        public BoolVar Loop = new();

        [OptionalField]
        [Tooltip("Set to true to restart traversal from the end index on the next run. The action resets this to false.")]
        public BoolRef ResetFlag = new();

        [OptionalField]
        [Tooltip("Optional current position. Leave unset for simple iteration using the action's internal counter. " +
                 "Set this to navigate from a known position. Use List Count to start after the last item. " +
                 "When set, this decreases by one before getting the item.")]
        public IntegerRef CurrentIndex;

        [ActionHeader("Output")]
        
        [MatchType(nameof(List))]
        [ConvertibleName("Item")]
        [Tooltip("Store the previous item in a variable.")]
        [WriteOnly, SerializeReference]
        [FormerlySerializedAs("GetPreviousItem")]
        public IVariableRef GetItem;

        [OptionalField, WriteOnly]
        [Tooltip("Store the index of the item that was returned.")]
        public IntegerRef ItemIndex;

        [ActionHeader("Events")]

        [OptionalField]
        [Tooltip("Event sent after getting the previous item.")]
        public EventRef LoopEvent;

        [OptionalField]
        [Tooltip("Event sent when there are no more previous items. If unset and Loop is true, loop back to the end index.")]
        public EventRef FinishedEvent;

        [NonSerialized]
        private int _previousItemIndex = -1;
        [NonSerialized]
        private bool _hasPreviousItemIndex;

        public override bool CanExecute() => CheckParameters(List, GetItem);

        public override void Execute()
        {
            var list = List.ListVariable;
            if (list == null || list.Count == 0)
            {
                SendEvent(FinishedEvent);
                return;
            }

            GetTraversalRange(list.Count, out var startIndex, out var endIndex);

            if (HasSharedCurrentIndex)
            {
                ExecuteFromCurrentIndex(list, startIndex, endIndex);
                return;
            }

            if (ConsumeResetFlag())
            {
                PreviousItemIndex = endIndex;
            }
            else if (!HasSharedCurrentIndex && !_hasPreviousItemIndex)
            {
                PreviousItemIndex = endIndex;
            }
            else if (PreviousItemIndex < startIndex)
            {
                if (FinishedEvent is { IsSet: true })
                {
                    StoreItemIndex(startIndex);
                    PreviousItemIndex = endIndex;
                    SendEvent(FinishedEvent);
                    return;
                }

                if (!ShouldLoop())
                {
                    StoreItemIndex(startIndex);
                    return;
                }

                PreviousItemIndex = endIndex;
            }
            else if (PreviousItemIndex > endIndex)
            {
                PreviousItemIndex = endIndex;
            }

            var itemIndex = PreviousItemIndex;
            StoreItemIndex(itemIndex);
            GetItem.SetValue(list[itemIndex]);
            PreviousItemIndex = itemIndex <= startIndex ? startIndex - 1 : itemIndex - 1;
            SendEvent(LoopEvent);
        }

        private void ExecuteFromCurrentIndex(IListVariable list, int startIndex, int endIndex)
        {
            if (ConsumeResetFlag())
            {
                GetItemAtIndex(list, endIndex);
                SendEvent(LoopEvent);
                return;
            }

            if (CurrentIndex.Value <= startIndex)
            {
                if (FinishedEvent is { IsSet: true })
                {
                    StoreItemIndex(startIndex);
                    CurrentIndex.Value = startIndex;
                    SendEvent(FinishedEvent);
                    return;
                }

                if (!ShouldLoop())
                {
                    StoreItemIndex(startIndex);
                    CurrentIndex.Value = startIndex;
                    return;
                }

                GetItemAtIndex(list, endIndex);
                SendEvent(LoopEvent);
                return;
            }

            var itemIndex = CurrentIndex.Value > endIndex ? endIndex : CurrentIndex.Value - 1;
            GetItemAtIndex(list, itemIndex);
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

        private int PreviousItemIndex
        {
            get => HasSharedCurrentIndex ? CurrentIndex.Value : _previousItemIndex;
            set
            {
                if (HasSharedCurrentIndex)
                {
                    CurrentIndex.Value = value;
                }
                else
                {
                    _previousItemIndex = value;
                    _hasPreviousItemIndex = true;
                }
            }
        }

        private bool HasSharedCurrentIndex => CurrentIndex is { IsNone: false };

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
            endIndex = (EndIndex?.Value ?? 0) <= 0 ? listCount - 1 : Mathf.Clamp(EndIndex.Value, 0, listCount - 1);

            if (startIndex > endIndex)
            {
                (startIndex, endIndex) = (endIndex, startIndex);
            }
        }

        private bool ShouldLoop() => Loop?.Value ?? false;

        public override string GetSummary() =>
            "Get previous item from {List} -> {GetItem}"
            + (FinishedEvent is { IsSet: true } ? " Finished {FinishedEvent}" : "");
    }
}

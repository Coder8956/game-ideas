using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public abstract class BaseForEachAction : BaseAction
    {
        public override bool StartsLoop => true;
        
        [OptionalField]
        [Tooltip("Get the current index, incremented by one each loop.")]
        [SerializeField, WriteOnly]
        protected IntegerRef _currentIndex;

        /* Maybe we need this?
        [Tooltip("Event to send when the loop has finished.")]
        [SerializeField, OptionalField]
        protected EventRef _finishedEvent;
        */
        
        [Tooltip("Reset the loop when exiting the state. " +
                 "Set this to true to restart the loop every time the state is entered." +
                 "\n\nFor example, if you're using the loop to find the first match in a list, " +
                 "and you want to check the whole list every time.")]
        [SerializeField]
        protected bool _resetOnExitState;

        /// <summary>
        /// Subclasses must implement this to return the number of items to loop through.
        /// E.g., the number of items in a list.
        /// </summary>
        protected abstract int ItemCount { get; }
        
        [NonSerialized] private int _nextItemIndex;
        [NonSerialized] private bool _finishedInLastLoop;
        
        /// <summary>
        /// We need to get the next item in OnStart because other actions might need the value in OnStart.
        /// E.g., Tween actions setup their targets in OnStart.
        /// </summary>
        public override void OnStart()
        {
            // Cache item count in case it's expensive to calculate
            var itemCount = ItemCount;
            
            if (itemCount == 0 || _finishedInLastLoop)
            {
                //Progress = itemCount == 0 ? 0f : 1f;
                _finishedInLastLoop = false;
                CancelLoop();
                Finish();
                return;
            }
            
            _finishedInLastLoop = false;
            _currentIndex.Value = _nextItemIndex;
            
            if (_nextItemIndex < itemCount)
            {
                StartLoop();
                EachAction(_nextItemIndex);
                _nextItemIndex++;
                //Progress = itemCount > 0 ? (float)_nextItemIndex / itemCount : 0f;
            }
            
            if (_nextItemIndex >= itemCount)
            {
                //Progress = 1f;
                StopLoop();
                OnLoopFinished();
                _nextItemIndex = 0;
                _finishedInLastLoop = true;
            }
            
            Finish();
            
            if (_resetOnExitState)
            {
                State.Exited -= OnStateExited;
                State.Exited += OnStateExited;
            }
        }
        
        private void OnStateExited()
        {
            _nextItemIndex = 0;
            _finishedInLastLoop = false;
            //Progress = 0f;
            State.Exited -= OnStateExited;
        }

        public override void OnStateFinished()
        {
            _finishedInLastLoop = false;
            //Progress = 0f;
        }

        protected virtual void OnLoopFinished()
        {
            /* Do this if we include _finishedEvent
            if (_finishedEvent.IsSet)
            {
                SendEvent(_finishedEvent);
            }*/
        }

        public abstract void EachAction(int index);
        
        #if UNITY_EDITOR
        
        public override bool HasDebugInfo => true;
        
        public override string GetDebugInfo()
        {
            var itemCount = ItemCount;
            var currentIndex = _finishedInLastLoop ? itemCount : Mathf.Clamp(_nextItemIndex, 0, itemCount);
            return $"{currentIndex}/{itemCount}";
        }
        
        #endif
    }
}

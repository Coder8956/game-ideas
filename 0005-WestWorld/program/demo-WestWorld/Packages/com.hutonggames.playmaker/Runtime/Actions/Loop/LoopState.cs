using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [ActionDescription("Loop this state, running actions the specified number of times. " +
                       "Put it at the end of the action list to loop all actions.")]
    public class LoopState : BaseAction
    {
        public override bool EndsLoop => true;
        
        private bool HideCount => Forever.IsConstantValue && Forever.Value;
        
        [HideIf(nameof(HideCount))]
        [DefaultValue(3)]
        [Tooltip("How many times to loop through the state.")]
        public IntegerVar Count;

        [DefaultValue(false)]
        [Tooltip("Loops until an action in the list transitions to another state. " +
                 "\n\nNOTE: To loop over multiple frames use a Wait action in the loop E.g., Wait For Next Frame")]
        public BoolVar Forever;
        
        private int _loopedCount;

        public override UpdateMode AllowedUpdateModes => UpdateMode.None;

        public override bool CanExecute() => Forever.HasValue() && (HideCount || Count.HasValue());

        public override void OnStateEnter()
        {
            _loopedCount = 0;
        }

        public override void Execute()
        {
            if (Forever.Value)
            {
                RestartStateActions();
                return;
            }

            if (++_loopedCount < Count.Value)
            {
                //Progress = (float)_loopedCount / Count.Value;
                RestartStateActions();
            }
            else
            {
                _loopedCount = 0;
                Finish();
            }
        }

        public override string GetSummary() => Forever.Value 
            ? "Loop state forever" 
            : "Loop state {Count} times";
    }
}

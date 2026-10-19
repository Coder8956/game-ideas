using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the current state name of an FSM.")]
    public class GetFsmState : BaseAction
    {
        [Tooltip("The FSM to get the current state from.")]
        [SerializeField]
        private BaseFsmComponentVar _fsmComponent;

        [Tooltip("Store the FSM's current state in a string variable.")]
        [SerializeField, WriteOnly]
        private StringRef _storeResult;

        [Tooltip("Use the full state path for nested states (e.g., Walking/Slow). Otherwise use only the state name.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _useFullPath;

        [Tooltip("Get all active leaf states instead of only the primary active leaf state.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _allActiveStates;

        [Tooltip("Store all active leaf states.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringListRef _storeActiveStates;

        [Tooltip("Also concatenate all active leaf states into the string output when getting all active states.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _concatenateActiveStates;

        [Tooltip("Separator used when concatenating multiple active states into the string output.")]
        [SerializeField]
        private StringVar _separator;

        public override bool CanStart() => CheckParameters(_fsmComponent);

        public override bool CanExecute() => true;

        public override void Execute()
        {
            var fsm = _fsmComponent.Value ? _fsmComponent.Value.Fsm : null;
            if (fsm == null)
            {
                if (_storeResult != null)
                {
                    _storeResult.Value = string.Empty;
                }
                _storeActiveStates?.Value?.Clear();
                return;
            }

            if (_allActiveStates.Value)
            {
                var activeStates = GetActiveStateNames(fsm);

                if (_storeActiveStates != null)
                {
                    _storeActiveStates.Value.Clear();
                    _storeActiveStates.Value.AddRange(activeStates);
                }

                if (_concatenateActiveStates.Value)
                {
                    if (_storeResult != null)
                    {
                        _storeResult.Value = string.Join(GetSeparator(), activeStates);
                    }
                }
                else if (activeStates.Count > 0)
                {
                    if (_storeResult != null)
                    {
                        _storeResult.Value = activeStates[0];
                    }
                }
                else
                {
                    if (_storeResult != null)
                    {
                        _storeResult.Value = string.Empty;
                    }
                }

                return;
            }

            var state = fsm.GetPrimaryActiveLeafState();
            if (_storeResult != null)
            {
                _storeResult.Value = FormatStateName(state);
            }
        }

        public override string GetSummary() => "Get {_fsmComponent} state -> {_storeResult}";

        private List<string> GetActiveStateNames(HutongGames.PlayMaker.FSM.FsmNode fsm)
        {
            return fsm.GetActiveStateNames(_useFullPath.Value);
        }

        private string FormatStateName(HutongGames.PlayMaker.FSM.StateNode state)
        {
            if (state == null) return string.Empty;
            return _useFullPath.Value ? state.GetDisplayPath(true, "/") : state.Name;
        }

        private string GetSeparator() => string.IsNullOrEmpty(_separator.Value) ? ", " : _separator.Value;
    }
}

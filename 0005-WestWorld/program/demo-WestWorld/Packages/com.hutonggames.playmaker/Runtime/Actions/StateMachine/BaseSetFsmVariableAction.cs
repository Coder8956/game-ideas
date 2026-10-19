using System;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [HelpURL("actions/state-machine-actions/set-fsm-variable")]
    public abstract class BaseSetFsmVariableAction<T, TVariable, TVariableVar> : 
        BaseAction, ISerializationCallbackReceiver
        where TVariable : Variable<T>
        where TVariableVar : VariableVar<T>
    {
        // NEW FIELD: unified link (FSM + variable name + guid)
        [Tooltip("The FSM and variable to set.")]
        [SerializeField]
        protected FsmVariableLink<T, TVariable> _target;

        // OLD FIELDS: kept only for migration from pre-FsmVariableLink versions
        [SerializeField, Obsolete("Use _target instead"), HideInInspector]
        protected BaseFsmComponentVar _fsmComponent;
        
        [SerializeField, Obsolete("Use _target instead"), HideInInspector]
        protected StringVar _variableName;

        [Tooltip("Set the value of the variable.")]
        [SerializeField, Expandable]
        protected TVariableVar _setValue;
       
        [Tooltip("Send this event if the variable is not found.")]
        [SerializeField, OptionalField]
        protected EventRef _notFoundEvent;

        [Tooltip("Log an error if the variable is not found.")]
        [SerializeField]
        protected bool _logError;
        
        [SerializeField, HideInInspector]
        private int _serializationVersion = 0;
        
        public override bool CanStart() => CheckParameters(_target.FsmComponent, _target.VariableName) && _setValue.HasValue(true);

        public override bool CanExecute() => CheckParameters(_target.VariableName) && _setValue.HasValue(true);
        
        public override void Execute()
        {
            if (!_target.HasIdentifier) return;
            
            var variable = _target.Resolve();
            if (variable == null)
            {
                if (_logError)
                {
                    LogError("Variable not found: " + _target.VariableName.Value);
                }
                
                SendEvent(_notFoundEvent);
            }
            else
            {
                _target.LogAmbiguousShortNameWarning(this, variable);
                variable.Value = _setValue.Value;
            }
        }

        public override string GetSummary() => "Set {_target._fsmComponent} {_target._variableName} to {_setValue}";

        #region Migration (ISerializationCallbackReceiver)

#pragma warning disable CS0618 // Type or member is obsolete
        
        public void OnBeforeSerialize()
        {
            // Mark the data as up-to-date.
            if (_serializationVersion == 0)
                _serializationVersion = 1;
        }

        public void OnAfterDeserialize()
        {
            // If this is already version 1, do not migrate.
            // This covers:
            // - new components added via Inspector
            // - assets saved after migration
            if (_serializationVersion != 0)
                return;

#if PLAYMAKER_SOURCE_VERSION
            Debug.Log($"Migrating old action data: {GetType().Name} {_target.VariableName}");
#endif
            
            // NO evaluation here!
            // Just move raw serialized fields.
            if (_fsmComponent != null)
                _target.FsmComponent = _fsmComponent;

            if (_variableName != null)
                _target.VariableName = _variableName;

            // Leave guid empty — it will be healed in the editor later.

            // Mark migrated
            _serializationVersion = 1;
        }
        
#pragma warning restore CS0618 // Type or member is obsolete
        
        #endregion
    }
}

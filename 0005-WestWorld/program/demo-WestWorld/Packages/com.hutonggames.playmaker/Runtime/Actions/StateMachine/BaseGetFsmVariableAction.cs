using System;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for actions that get a variable from another FSM.
    /// New version uses FsmVariableLink for a robust (FSM + variable) reference.
    /// Old fields (_fsmComponent, _variableName) are kept for migration.
    /// </summary>
    [Serializable]
    [HelpURL("actions/state-machine-actions/get-fsm-variable")]
    public abstract class BaseGetFsmVariableAction<T, TVariable, TVariableRef, TVariableVar> :
        BaseAction,
        ISerializationCallbackReceiver
        where TVariable : Variable<T>
        where TVariableRef : VariableRef<T>
        where TVariableVar : VariableVar<T>
    {
        // NEW FIELD (PM2+): unified link to FSM + variable (name + guid).
        [Tooltip("The FSM and variable to get the value from.")]
        [SerializeField]
        protected FsmVariableLink<T, TVariable> _target;

        // OLD FIELDS (PM2 pre-migration): kept only so Unity can deserialize existing scenes/prefabs.
        // These are migrated into _target in OnAfterDeserialize and should no longer be used directly.

        [SerializeField, Obsolete("Use _target instead"), HideInInspector]
        protected BaseFsmComponentVar _fsmComponent;

        [SerializeField, Obsolete("Use _target instead"), HideInInspector]
        protected StringVar _variableName;

        [Tooltip("Use this value if the variable is not found. " +
                 "Set to None to leave to leave the store value untouched.")]
        [SerializeField, OptionalField]
        protected TVariableVar _defaultValue;

        [Tooltip("Store the value of the variable.")]
        [SerializeField, WriteOnly]
        protected TVariableRef _storeValue;

        [Tooltip("Send this event if the variable is not found.")]
        [SerializeField, OptionalField]
        protected EventRef _notFoundEvent;

        [Tooltip("Log an error if the variable is not found.")] 
        [SerializeField]
        protected bool _logError;
        
        [SerializeField, HideInInspector]
        private int _serializationVersion = 0;
        
        #region Execution

        public override bool CanStart() => CheckParameters(_target.FsmComponent, _target.VariableName, _storeValue);

        public override bool CanExecute() => CheckParameters(_target.VariableName, _storeValue);

        public override void Execute()
        {
            if (!_target.HasIdentifier) return;
            
            var variable = _target.Resolve();
            if (variable == null)
            {
                if (!_defaultValue.IsNone)
                {
                    _storeValue.Value = _defaultValue.Value;
                }
                
                if (_logError)
                {
                    LogError("Variable not found: " + _target.VariableName.Value);
                }

                SendEvent(_notFoundEvent);
            }
            else
            {
                _target.LogAmbiguousShortNameWarning(this, variable);
                _storeValue.Value = CopyValueForStore(variable.Value);
            }
        }

        private static T CopyValueForStore(T value)
        {
            if (value == null)
            {
                return default;
            }

            var valueType = value.GetType();
            if (!valueType.IsGenericType || valueType.GetGenericTypeDefinition() != typeof(System.Collections.Generic.List<>))
            {
                return value;
            }

            var copy = (System.Collections.IList)Activator.CreateInstance(valueType);
            foreach (var item in (System.Collections.IEnumerable)value)
            {
                copy.Add(item);
            }

            return (T)copy;
        }

        public override string GetSummary() => "Get {_target._fsmComponent} {_target._variableName} -> {_storeValue}";

        #endregion

        #region Migration
        
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

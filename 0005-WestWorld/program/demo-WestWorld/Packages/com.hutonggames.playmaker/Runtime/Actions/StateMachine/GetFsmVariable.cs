using System;
using JetBrains.Annotations;
using UnityEngine;
// ReSharper disable InconsistentNaming

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the value of a variable in another FSM.\n\nNOTE: Use type specific versions of this action if available for better performance.")]
    public class GetFsmVariable : BaseAction, ISerializationCallbackReceiver
    {
        // NEW FIELD (PM2+): unified link to FSM + variable (name + guid).
        //[Tooltip("The FSM and variable to get the value from (rename-safe).")]
        [SerializeField]
        private FsmVariableLink<object, Variable<object>> _target;
        
        [Tooltip("The FSM to get the variable from.")]
        [SerializeField, Obsolete("Use _target instead"), HideInInspector]
        private BaseFsmComponentVar _fsmComponent;
        
        [Tooltip("The name of the variable to get.")]
        [SerializeField, Obsolete("Use _target instead"), HideInInspector]
        private StringVar _variableName;
        
        [BaseType(typeof(object))]
        [Tooltip("Store the value of the variable.")]
        [SerializeReference, WriteOnly]
        private IVariableRef _storeValue;
        
        [SerializeField, HideInInspector]
        private int _serializationVersion = 0;
        
        public override bool CanStart() => CheckParameters(_target.FsmComponent, _target.VariableName, _storeValue);

        public override bool CanExecute() => CheckParameters(_target.VariableName, _storeValue);
        
        public override void Execute()
        {
            var variable = _target.ResolveAny();
            if (variable != null)
            {
                _target.LogAmbiguousShortNameWarning(this, variable);
                _storeValue.SetValue(variable.GetValue());
            }
            else
            {
                Debug.LogWarning("Variable not found: " + _target.VariableName);
            }
        }

        public override string GetSummary() => 
            "Get {_target._fsmComponent} {_target._variableName} -> {_storeValue}";
        
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

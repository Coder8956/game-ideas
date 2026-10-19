using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Get the value of an Enum variable in another FSM.")]
    [HelpURL("actions/state-machine-actions/set-fsm-variable")]
    public class GetFsmEnum : BaseAction
    {
        [Tooltip("The FSM to get the variable from.")]
        [SerializeField]
        private BaseFsmComponentVar _fsmComponent;
        
        [Tooltip("The name of the variable to get.")]
        [SerializeField]
        private StringVar _variableName;

        [BaseType(typeof(System.Enum))]
        [Tooltip("The type of enum to get.")]
        [SerializeField]
        private TypeReference _enumType;
        
        [MatchType(nameof(_enumType))]
        [Tooltip("Use this value if the variable is not found. Set this to None to require the variable to exist.")]
        [SerializeField, OptionalField]
        private EnumVar _defaultValue;
        
        [MatchType(nameof(_enumType))]
        [Tooltip("Store the value of the variable.")]
        [SerializeField, WriteOnly]
        private EnumRef _storeValue;
        
        public override bool CanStart() => CheckParameters(_fsmComponent, _variableName, _storeValue);

        public override bool CanExecute() => CheckParameters(_variableName, _storeValue);
        
        public override void Execute()
        {
            var value = _fsmComponent.Value;
            var variable = value ? value.Fsm.Variables.FindVariableByName<EnumVariable>(_variableName.Value) : null;
            if (variable == null)
            {
                if (_defaultValue.IsNone)
                {
                    LogError("Variable not found: " + _variableName.Value);
                    Finish();
                    return;
                }
                
                _storeValue.Value = _defaultValue.Value;
            }
            else
            {
                _storeValue.Value = variable.Value;
            }
        }

        public override string GetSummary() => "Get {_fsmComponent} {_variableName} -> {_storeValue}";
    }
}

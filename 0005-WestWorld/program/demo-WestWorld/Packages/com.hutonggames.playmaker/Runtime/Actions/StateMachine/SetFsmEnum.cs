using HutongGames.Reflection;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Set the value of an Enum variable in another FSM.")]
    [HelpURL("actions/state-machine-actions/set-fsm-variable")]
    public class SetFsmEnum : BaseAction
    {
        [Tooltip("The FSM to set the variable in.")]
        [SerializeField]
        private BaseFsmComponentVar _fsmComponent;
        
        [Tooltip("The name of the variable to set.")]
        [SerializeField]
        private StringVar _variableName;

        [BaseType(typeof(System.Enum))]
        [Tooltip("The type of enum to set.")]
        [SerializeField]
        private TypeReference _enumType;
        
        [MatchType(nameof(_enumType))]
        [Tooltip("Set the value of the variable.")]
        [SerializeField]
        private EnumVar _setValue;
        
        public override bool CanStart() => CheckParameters(_fsmComponent, _variableName) && _setValue.HasValue(true);

        public override bool CanExecute() => CheckParameters(_variableName) && _setValue.HasValue(true);
        
        public override void Execute()
        {
            var fsmComponent = _fsmComponent.Value;
            if (fsmComponent == null) return;

            var variable = fsmComponent.Fsm.Variables.FindVariableByName<EnumVariable>(_variableName.Value);
            if (variable == null)
            {
                LogError("Variable not found: " + _variableName.Value);
                Finish();
                return;
            }
            
            variable.Value = _setValue.Value;
        }

        public override string GetSummary() => "Set {_fsmComponent} {_variableName} to {_setValue}";
    }
}

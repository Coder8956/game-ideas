
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Set the value of a property in a Variable.")]
    public class SetVariableProperty : BaseAction
    {
        [Tooltip("The variable to set a property in.")]
        [SerializeReference]
        private AnyVariableRef _variable;
        
        [MatchType(nameof(_variable))]
        [SerializeField]
        private PropertySetter _setter;
        
        public override bool CanExecute() => CheckParameters(_variable) && _setter.CanExecute();

        public override void Execute() => _setter.Execute(_variable);
        
        public override string GetSummary() => _setter.GetSummary(nameof(_variable), nameof(_setter));
    }
}

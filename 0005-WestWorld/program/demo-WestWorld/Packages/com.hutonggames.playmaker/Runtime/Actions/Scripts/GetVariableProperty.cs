
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Get the value of a property in a Variable.")]
    public class GetVariableProperty : BaseAction
    {
        [Tooltip("The variable to get a property from.")]
        [SerializeReference]
        private AnyVariableRef _variable;
        
        [MatchType(nameof(_variable))]
        [SerializeField]
        private PropertyGetter _getter;
        
        public override bool CanExecute() => CheckParameters(_variable) && _getter.CanExecute();

        public override void Execute() => _getter.Execute(_variable.Value);
        
        public override string GetSummary() => _getter.GetSummary(nameof(_variable), nameof(_getter));

    }
}

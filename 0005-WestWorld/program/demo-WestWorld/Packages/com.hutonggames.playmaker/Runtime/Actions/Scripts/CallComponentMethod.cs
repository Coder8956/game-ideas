using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Call a method on a Component.")]
    public class CallComponentMethod : BaseAction
    {
        [Tooltip("The Component to call a method on.")]
        [SerializeField]
        private ComponentVar _component;

        [SerializeField, MatchType("_component")]
        private MethodCaller _method;

        public override bool CanExecute() => _component.HasValue() && _method.IsValid;
        
        public override void Execute() => _method.Execute(_component.Value);

        public override string GetSummary() => "Call {_method} on {_component}";
    }
}
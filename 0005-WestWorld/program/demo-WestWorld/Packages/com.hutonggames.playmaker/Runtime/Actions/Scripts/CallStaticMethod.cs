using System;
using UnityEngine;
using HutongGames.Reflection;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Script)]
    [ActionDescription("Call a static method.")]
    public class CallStaticMethod : BaseAction
    {
        [Tooltip("The type to call the method on.")]
        [SerializeField] 
        private TypeReference _type;
        
        [SerializeField, MatchType(nameof(_type)), StaticOnly]
        private MethodCaller _method;

        public override bool CanExecute() => _method.IsValid;

        public override void Execute() => _method.Execute(null);

        public override string GetSummary() => "Call {_method} in {_type}";
    }
}
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Object)]
    [ActionDescription("Compares two Object references to see if they refer to the same Object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-operator_eq.html")]
    public class ObjectEquals : BaseAction
    {
        [Tooltip("The Object to check.")]
        public ObjectRef Object;
        
        [Tooltip("The Object to compare with.")]
        public ObjectVar ObjectToCompare;
        
        [Tooltip("Store the result in Bool variable.")]
        [SerializeField]
        [WriteOnly]
        private BoolRef _result;
		
        public override bool CanExecute() => !Object.IsNone && !_result.IsNone;

        public override void Execute() => _result.Value = Object.Value == ObjectToCompare.Value;

        public override string GetSummary() => "{Object} equals {ObjectToCompare} -> {_result}";
    }
}
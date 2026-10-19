using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
    [ActionDescription("Compares two Object references to see if they refer to the same Object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-operator_eq.html")]
    public class ObjectCheckIsEqual : BaseTrueFalseAction
    {
        [Tooltip("The Object to check.")]
        public ObjectRef Object;
        
        [Tooltip("The Object to compare with.")]
        public ObjectVar ObjectToCompare;
        
        protected override bool Test() => Object.Value == ObjectToCompare.Value;
        protected override string TrueSummary => "{Object} equals {ObjectToCompare}";
        protected override string FalseSummary => "{Object} not equal to {ObjectToCompare}";
    }
}
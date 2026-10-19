using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Object)]
    [ActionDescription("Checks if an Object's name contains a given string.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-name.html")]
    public class ObjectCheckNameContains : BaseTrueFalseAction
    {
        [Tooltip("The Object to check.")]
        public ObjectRef Object;
        
        [Tooltip("The string to check."), CanBeNullOrEmpty]
        public StringVar Contains;
        
        [Tooltip("Ignore case when comparing strings.")]
        public bool IgnoreCase;
        
        protected override bool Test()
        {
            if (Object.Value == null) return false;

            var comparison = IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            return Object.Value.name.Contains(Contains.Value, comparison);
        }

        protected override string TrueSummary => 
            "{Object} name contains {Contains}" + (IgnoreCase ? " (Ignore Case)" : "");
        protected override string FalseSummary => 
            "{Object} name contains {Contains}" + (IgnoreCase ? " (Ignore Case)" : "");
    }
}
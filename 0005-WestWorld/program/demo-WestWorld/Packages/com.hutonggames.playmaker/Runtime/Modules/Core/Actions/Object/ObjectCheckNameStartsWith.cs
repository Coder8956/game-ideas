using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Object)]
    [ActionDescription("Checks if an Object's name starts with a given string.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-name.html")]
    public class ObjectCheckNameStartsWith : BaseTrueFalseAction
    {
        [Tooltip("The Object to check.")] public ObjectRef Object;

        [Tooltip("The string to check."), CanBeNullOrEmpty]
        public StringVar StartsWith;

        [Tooltip("Ignore case when comparing strings.")]
        public bool IgnoreCase;

        protected override bool Test()
        {
            if (Object.Value == null) return false;

            var comparison = IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            return Object.Value.name.StartsWith(StartsWith.Value, comparison);
        }

        protected override string TrueSummary => 
            "{Object} name starts with {StartsWith}" + (IgnoreCase ? " (Ignore Case)" : "");
        protected override string FalseSummary => 
            "{Object} name does not start with {StartsWith}" + (IgnoreCase ? " (Ignore Case)" : "");
    }
}
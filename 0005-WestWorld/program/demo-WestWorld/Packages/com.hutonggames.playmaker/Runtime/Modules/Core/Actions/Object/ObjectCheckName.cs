using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Object)]
    [ActionDescription("Checks an Object's name.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-name.html")]
    public class ObjectCheckName : BaseTrueFalseAction
    {
        [Tooltip("The Object to check.")]
        public ObjectRef Object;
        
        [Tooltip("The name to check for."), CanBeNullOrEmpty]
        public StringVar Name;
        
        [Tooltip("Ignore case when comparing strings.")]
        public bool IgnoreCase;
        
        protected override bool Test()
        {
            if (Object.Value == null) return false;

            var comparison = IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            return Object.Value.name.Equals(Name.Value, comparison);
        }
      
        protected override string TrueSummary => 
            "{Object} name is {Name}" + (IgnoreCase ? " (Ignore Case)" : "");
        protected override string FalseSummary => 
            "{Object} name is not {Name}" + (IgnoreCase ? " (Ignore Case)" : "");
     }
}
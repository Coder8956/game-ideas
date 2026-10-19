using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
    [ActionDescription("Checks if an Object is null.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-operator_Object.html")]
    public class ObjectCheckIsNull : BaseTrueFalseAction
    {
        [Tooltip("The Object to check.")]
        public ObjectRef Object;
        
        protected override bool Test() => Object.Value == null;
        protected override string TrueSummary => "{Object} is null";
        protected override string FalseSummary => "{Object} is not null";
    }
}
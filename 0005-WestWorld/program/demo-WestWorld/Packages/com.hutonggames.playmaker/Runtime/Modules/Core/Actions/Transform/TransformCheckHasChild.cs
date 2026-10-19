using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("GetChild")]
    [ActionDescription("Checks if a Transform has a child with a given name.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Find.html")]
    public class TransformCheckHasChild : BaseTrueFalseAction
    {
        [Tooltip("The Transform to check.")]
        public TransformVar Transform;
        
        [Tooltip("The child name to check for.")]
        public StringVar ChildName;
        
        protected override bool Test() => Transform.Value != null && 
                                          Transform.Value.Find(ChildName.Value) != null;
        protected override string TrueSummary => "{Transform} has child {ChildName}";
        protected override string FalseSummary => "{Transform} does not have child {ChildName}";
    }
}
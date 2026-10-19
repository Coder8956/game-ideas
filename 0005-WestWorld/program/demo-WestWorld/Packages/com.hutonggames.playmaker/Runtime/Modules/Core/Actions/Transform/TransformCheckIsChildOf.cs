using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Checks if a Transform is a child of another Transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.IsChildOf.html")]
    public class TransformCheckIsChildOf : BaseTrueFalseAction
    {
        [Tooltip("The Transform to check.")]
        public TransformVar Transform;
        
        [Tooltip("The parent Transform to check against.")]
        public TransformVar Parent;
        
        protected override bool Test() => Transform.Value != null && Transform.Value.IsChildOf(Parent.Value);
        protected override string TrueSummary => "{Transform} is child of {Parent}";
        protected override string FalseSummary => "{Transform} is not child of {Parent}";
    }
}
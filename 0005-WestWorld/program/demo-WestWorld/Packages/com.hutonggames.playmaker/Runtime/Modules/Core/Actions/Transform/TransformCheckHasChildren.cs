using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("GetChild")]
    [ActionDescription("Checks if a Transform has any children.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-childCount.html")]
    public class TransformCheckHasChildren : BaseTrueFalseAction
    {
        [Tooltip("The Transform to check.")]
        public TransformVar Transform;
        
        protected override bool Test() => Transform.Value != null && 
                                          Transform.Value.childCount > 0;
        protected override string TrueSummary => "{Transform} has children";
        protected override string FalseSummary => "{Transform} has no children";
    }
}
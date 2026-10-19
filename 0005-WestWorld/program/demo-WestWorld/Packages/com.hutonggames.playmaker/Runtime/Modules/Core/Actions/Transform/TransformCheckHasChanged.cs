using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Checks if a Transform has changed. " +
                       "NOTE: This action resets the hasChanged flag to false when finished.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-hasChanged.html")]
    public class TransformCheckHasChanged : BaseTrueFalseAction
    {
        [Tooltip("The Transform to check.")]
        public TransformVar Transform;
        
        protected override bool Test() => Transform.Value != null && Transform.Value.hasChanged;
        protected override string TrueSummary => "{Transform} has changed";
        protected override string FalseSummary => "{Transform} has not changed";

        public override void OnStop()
        {
            if (Transform.Value != null)
            {
                Transform.Value.hasChanged = false;
            }   
        }
    }
}
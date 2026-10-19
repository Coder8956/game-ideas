using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Set the parent of the transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.SetParent.html")]
    public class TransformSetParent : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("The new parent.")]
        [CanBeNullOrEmpty]
        public TransformVar SetParent;

        public override bool CanExecute() => CheckParameters(Transform); // Parent can be null

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            transform.SetParent(SetParent.Value);
        }
        
        public override string GetSummary() => "Set {Transform} parent to {SetParent}";
    }
}
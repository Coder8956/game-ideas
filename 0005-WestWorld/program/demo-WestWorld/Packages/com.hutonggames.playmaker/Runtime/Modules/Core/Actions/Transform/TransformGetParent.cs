using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Get the parent of the transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-parent.html")]
    public class TransformGetParent : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the parent.")]
        public TransformRef GetParent;

        public override bool CanExecute() => CheckParameters(Transform, GetParent);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null)
            {
                GetParent.Value = null;
                return;
            }
            GetParent.Value = transform.parent;
        }
        
        public override string GetSummary() => "Get {Transform} parent -> {GetParent}";
    }
}
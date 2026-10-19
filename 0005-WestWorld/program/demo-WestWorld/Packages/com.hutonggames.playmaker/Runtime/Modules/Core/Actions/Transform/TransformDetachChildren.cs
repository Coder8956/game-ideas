using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Detach all children of a Transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.DetachChildren.html")]
    public class TransformDetachChildren : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;

        public override bool CanExecute() => CheckParameters(Transform);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            transform.DetachChildren();
        }
        
        public override string GetSummary() => "Detach children from {Transform}";
    }
}

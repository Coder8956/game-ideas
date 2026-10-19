using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Get the topmost transform in the hierarchy.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-root.html")]
    public class TransformGetRoot : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the topmost transform in the hierarchy.")]
        public TransformRef GetRoot;

        public override bool CanExecute() => CheckParameters(Transform, GetRoot);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetRoot.Value = transform.root;
        }
        
        public override string GetSummary() => "Get {Transform} root -> {GetRoot}";
    }
}
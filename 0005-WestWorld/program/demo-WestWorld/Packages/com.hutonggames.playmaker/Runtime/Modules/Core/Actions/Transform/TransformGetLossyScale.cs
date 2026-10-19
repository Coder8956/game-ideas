using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformScale")]
    [ActionDescription("Get the global scale of the object (Read Only)")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-lossyScale.html")]
    public class TransformGetLossyScale : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the global scale in a Vector3 variable.")]
        public Vector3Ref GetLossyScale;

        public override bool CanExecute() => CheckParameters(Transform, GetLossyScale);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetLossyScale.Value = transform.lossyScale;
        }
        
        public override string GetSummary() => "Get {Transform} lossy scale -> {GetLossyScale}";
    }
}
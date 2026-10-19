using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetRotation")]
    [ActionDescription("Get the rotation of the transform relative to the transform rotation of the parent.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localRotation.html")]
    public class TransformGetLocalRotation : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the local rotation in a Quaternion variable.")]
        public QuaternionRef GetLocalRotation;

        public override bool CanExecute() => CheckParameters(Transform, GetLocalRotation);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetLocalRotation.Value = transform.localRotation;
        }
        
        public override string GetSummary() => "Get {Transform} local rotation -> {GetLocalRotation}";
    }
}
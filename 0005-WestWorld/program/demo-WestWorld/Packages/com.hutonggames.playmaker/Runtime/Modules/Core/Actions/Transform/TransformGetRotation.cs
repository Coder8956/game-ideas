using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetRotation")]
    [ActionDescription("Get the world rotation of the transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-rotation.html")]
    public class TransformGetRotation : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the world rotation in a Quaternion variable.")]
        public QuaternionRef GetRotation;

        public override bool CanExecute() => CheckParameters(Transform, GetRotation);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetRotation.Value = transform.rotation;
        }
        
        public override string GetSummary() => "Get {Transform} rotation -> {GetRotation}";
    }
}
using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetRotation")]
    [ActionDescription("Get the world rotation of the transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-rotation.html")]
    public class TransformGetRotation__XYZ : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [OptionalField]
        [WriteOnly, Tooltip("Store the world X rotation.")]
        public FloatRef GetXRotation;
        
        [OptionalField]
        [WriteOnly, Tooltip("Store the world Y rotation.")]
        public FloatRef GetYRotation;
        
        [OptionalField]
        [WriteOnly, Tooltip("Store the world Z rotation.")]
        public FloatRef GetZRotation;

        public override bool CanExecute() => CheckParameters(Transform);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            var rotation = transform.rotation.eulerAngles;
            if (GetXRotation.IsAssigned) GetXRotation.Value = rotation.x;
            if (GetYRotation.IsAssigned) GetYRotation.Value = rotation.y;
            if (GetZRotation.IsAssigned) GetZRotation.Value = rotation.z;
        }
        
        public override string GetSummary() => "Get {Transform} rotation {GetXRotation:output} {GetYRotation:output} {GetZRotation:output}";
    }
}
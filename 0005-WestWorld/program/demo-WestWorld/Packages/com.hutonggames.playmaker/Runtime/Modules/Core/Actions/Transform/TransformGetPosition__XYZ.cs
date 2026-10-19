using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetPosition")]
    [ActionDescription("Get the world position of the transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-position.html")]
    public class TransformGetPosition__XYZ : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [OptionalField]
        [WriteOnly, Tooltip("Store the world X position.")]
        public FloatRef GetXPosition;
        
        [OptionalField]
        [WriteOnly, Tooltip("Store the world Y position.")]
        public FloatRef GetYPosition;
        
        [OptionalField]
        [WriteOnly, Tooltip("Store the world Z position.")]
        public FloatRef GetZPosition;

        public override bool CanExecute() => CheckParameters(Transform);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            var position = transform.position;
            GetXPosition.Value = position.x;
            GetYPosition.Value = position.y;
            GetZPosition.Value = position.z;
        }
        
        public override string GetSummary() => "Get {Transform} position {GetXPosition:output} {GetYPosition:output} {GetZPosition:output}";
    }
}
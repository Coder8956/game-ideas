using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetPosition")]
    [ActionDescription("Get the position of the transform relative to the parent transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localPosition.html")]
    public class TransformGetLocalPosition__XYZ : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;

        [OptionalField]
        [WriteOnly, Tooltip("Store the local X position.")]
        public FloatRef GetXPosition;

        [OptionalField]
        [WriteOnly, Tooltip("Store the local Y position.")]
        public FloatRef GetYPosition;

        [OptionalField]
        [WriteOnly, Tooltip("Store the local Z position.")]
        public FloatRef GetZPosition;

        public override bool CanExecute() => CheckParameters(Transform);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            var localPosition = transform.localPosition;
            GetXPosition.Value = localPosition.x;
            GetYPosition.Value = localPosition.y;
            GetZPosition.Value = localPosition.z;
        }

        public override string GetSummary() => "Get {Transform} local position {GetXPosition:output} {GetYPosition:output} {GetZPosition:output}";
    }
}
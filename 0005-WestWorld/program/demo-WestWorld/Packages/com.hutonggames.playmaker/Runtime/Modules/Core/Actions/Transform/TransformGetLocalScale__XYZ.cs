using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformScale")]
    [ActionDescription("Get the scale of the transform relative to the transform's parent.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
    public class TransformGetLocalScale__XYZ : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [OptionalField]
        [WriteOnly, Tooltip("Store the local x scale.")]
        public FloatRef GetXScale;
        
        [OptionalField]
        [WriteOnly, Tooltip("Store the local y scale.")]
        public FloatRef GetYScale;

        [OptionalField] 
        [WriteOnly, Tooltip("Store the local z scale.")]
        public FloatRef GetZScale;

        public override bool CanExecute() => CheckParameters(Transform);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            
            if (GetXScale.IsAssigned) GetXScale.Value = transform.localScale.x;
            if (GetYScale.IsAssigned) GetYScale.Value = transform.localScale.y;
            if (GetZScale.IsAssigned) GetZScale.Value = transform.localScale.z;
        }
        
        public override string GetSummary() => "Get {Transform} scale {GetXScale:output} {GetYScale:output} {GetZScale:output}";
    }
}
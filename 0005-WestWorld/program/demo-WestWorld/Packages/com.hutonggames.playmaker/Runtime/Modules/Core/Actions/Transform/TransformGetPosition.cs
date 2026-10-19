using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetPosition")]
    [ActionDescription("Get the world position of the transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-position.html")]
    public class TransformGetPosition : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the world position.")]
        public Vector3Ref GetPosition;

        public override bool CanExecute() => CheckParameters(Transform, GetPosition);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetPosition.Value = transform.position;
        }
        
        public override string GetSummary() => "Get {Transform} position -> {GetPosition}";
    }
}
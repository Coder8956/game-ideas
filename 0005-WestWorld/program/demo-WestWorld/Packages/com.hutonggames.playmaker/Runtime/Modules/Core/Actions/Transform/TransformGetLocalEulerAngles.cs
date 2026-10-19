using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetRotation")]
    [ActionDescription("Get the local rotation of a Transform as euler angles.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localEulerAngles.html")]
    public class TransformGetLocalEulerAngles : BaseAction
    {
        [FormerlySerializedAs("ParentTransform")]
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the local euler angles in a Vector3 variable.")]
        public Vector3Ref GetLocalEulerAngles;

        public override bool CanExecute() => CheckParameters(Transform, GetLocalEulerAngles);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetLocalEulerAngles.Value = transform.localEulerAngles;
        }
        
        public override string GetSummary() => "Get {Transform} euler angles -> {GetLocalEulerAngles}";
    }
}
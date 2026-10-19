using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetRotation")]
    [ActionDescription("Get the world space rotation of a Transform as euler angles.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-eulerAngles.html")]
    public class TransformGetEulerAngles : BaseAction
    {
        [FormerlySerializedAs("ParentTransform")]
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the euler angles in a Vector3 variable.")]
        public Vector3Ref GetEulerAngles;

        public override bool CanExecute() => CheckParameters(Transform, GetEulerAngles);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetEulerAngles.Value = transform.eulerAngles;
        }
        
        public override string GetSummary() => "Get {Transform} euler angles -> {GetEulerAngles}";
    }
}
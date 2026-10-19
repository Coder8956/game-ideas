using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("GetChild")]
    [ActionDescription("Get a random child of a Transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.GetChild.html")]
    public class TransformGetRandomChild : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [ConvertibleName("Child")]
        [WriteOnly, Tooltip("Store the child (or null if not found).")]
        public TransformRef GetRandomChild;

        public override bool CanExecute() => CheckParameters(Transform, GetRandomChild);

        public override void Execute()
        {            
            var transform = Transform.Value;
            if (transform == null) return;

            var childCount = transform.childCount;
            GetRandomChild.Value = childCount > 0
                ? transform.GetChild(UnityEngine.Random.Range(0, childCount))
                : null;
        }
        
        public override string GetSummary() => "Get random child of {Transform} -> {GetRandomChild}";
    }
}

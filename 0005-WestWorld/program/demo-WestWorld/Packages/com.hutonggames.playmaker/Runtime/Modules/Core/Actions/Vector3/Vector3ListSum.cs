
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Vector3)]
    [ActionDescription("Get the sum total of a list of Vector3s.")]
    public class Vector3ListSum : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The Vector3 list")]
        public Vector3ListRef Vector3List;

        [WriteOnly]
        [Tooltip("Store the sum in a Vector3 variable.")]
        public Vector3Ref Sum;
        
        public override bool CanExecute() => CheckParameters(Vector3List, Sum);

        public override void Execute()
        {
            Sum.Value = Vector3.zero;
            foreach (var vector3 in Vector3List.Value)
            {
                Sum.Value += vector3;
            }
        }

        public override string GetSummary() => "Sum {Vector3List} -> {Sum}";
    }
}
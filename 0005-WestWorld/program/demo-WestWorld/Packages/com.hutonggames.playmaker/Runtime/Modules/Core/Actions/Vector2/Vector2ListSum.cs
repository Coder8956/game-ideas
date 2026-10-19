
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Vector2)]
    [ActionDescription("Get the sum total of a list of Vector2s.")]
    public class Vector2ListSum : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The Vector2 list")]
        public Vector2ListRef Vector2List;

        [WriteOnly]
        [Tooltip("Store the sum in a Vector2 variable.")]
        public Vector2Ref Sum;
        
        public override bool CanExecute() => CheckParameters(Vector2List, Sum);

        public override void Execute()
        {
            Sum.Value = Vector2.zero;
            foreach (var vector2 in Vector2List.Value)
            {
                Sum.Value += vector2;
            }
        }

        public override string GetSummary() => "Sum {Vector2List} -> {Sum}";
    }
}
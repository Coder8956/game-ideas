using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [HasSceneGUI]
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomVector2)]
    [ActionDescription("Get a random point on a rectangle perimeter.")]
    public class RandomGetPointOnRect : BaseAction
    {
        [Tooltip("The local-space rect whose perimeter will be sampled, relative to Offset.")]
        public RectVar Rect;

        [FormerlySerializedAs("Center")]
        [Tooltip("World-space offset applied to the sampled perimeter point. The Rect is evaluated in local space, then shifted by this Offset value.")]
        public Vector2Var Offset;
        
        [WriteOnly, DefaultName("RandomPoint")]
        [Tooltip("Store the random value in a Vector2 variable.")]
        public Vector2Ref StoreResult;

        public override void Reset() => Rect.Value = new Rect(0, 0, 1, 1);

        public override bool CanExecute() => CheckParameters(Offset, Rect, StoreResult);

        public override void Execute()
        {
            var rect = Rect.Value;
            
            // Calculate the perimeter of each side
            var width = rect.width;
            var height = rect.height;
            var perimeter = 2 * (width + height);
            
            // Choose a random position along the perimeter
            var randomPosition = Random.Range(0f, perimeter);
            
            Vector2 point;
            
            if (randomPosition <= width)
            {
                // Top edge
                point = new Vector2(rect.xMin + randomPosition, rect.yMax);
            }
            else if (randomPosition <= width + height)
            {
                // Right edge
                point = new Vector2(rect.xMax, rect.yMax - (randomPosition - width));
            }
            else if (randomPosition <= 2 * width + height)
            {
                // Bottom edge
                point = new Vector2(rect.xMax - (randomPosition - width - height), rect.yMin);
            }
            else
            {
                // Left edge
                point = new Vector2(rect.xMin, rect.yMin + (randomPosition - 2 * width - height));
            }
            
            StoreResult.Value = Offset.Value + point;

        }
        
        public override string GetSummary() => "Get random point on rect {Rect} -> {StoreResult}";
    }
}

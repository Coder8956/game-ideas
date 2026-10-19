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
    [ActionDescription("Get a random point inside a rectangle.")]
    public class RandomGetPointInRect : BaseAction
    {
        [Tooltip("The local-space rect bounds to sample from, relative to Offset.")]
        public RectVar Rect;

        [FormerlySerializedAs("Center")]
        [Tooltip("World-space offset applied to the sampled point. The Rect is sampled in local space, then shifted by this Offset value.")]
        public Vector2Var Offset;
        
        [WriteOnly, DefaultName("RandomPoint")]
        [Tooltip("Store the random value in a Vector2 variable.")]
        public Vector2Ref StoreResult;

        public override void Reset() => Rect.Value = new Rect(0, 0, 1, 1);

        public override bool CanExecute() => CheckParameters(Offset, Rect, StoreResult);

        public override void Execute()
        {
            var rect = Rect.Value;
            var x = Random.Range(rect.xMin, rect.xMax);
            var y = Random.Range(rect.yMin, rect.yMax);
            StoreResult.Value = Offset.Value + new Vector2(x, y);
        }
        
        public override string GetSummary() => "Get random point in rect {Rect} -> {StoreResult}";
    }
}

using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [HasSceneGUI]
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomVector2)]
    [ActionDescription("Get a random point on a circle of the given radius.")]
    public class RandomGetPointOnCircle : BaseAction
    {
        [Tooltip("The center of the circle.")]
        public Vector2Var Center;
        
        [DefaultValue(1f)]
        [Tooltip("Radius of the circle.")]
        public FloatVar Radius;

        [WriteOnly, DefaultName("RandomPoint")]
        [Tooltip("Store the random value in a Vector2 variable.")]
        public Vector2Ref StoreResult;

        public override bool CanExecute() => CheckParameters(Center, Radius, StoreResult);

        public override void Execute() => StoreResult.Value = GetRandomPointOnCircle(Radius.Value);
        
        private Vector2 GetRandomPointOnCircle(float radius)
        {
            var angle = Random.Range(0f, Mathf.PI * 2f);
            return Center.Value + new Vector2(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius);
        }
        
        public override string GetSummary()
        {
            return "Get random point on circle {Radius} -> {StoreResult}";
        }
    }
}
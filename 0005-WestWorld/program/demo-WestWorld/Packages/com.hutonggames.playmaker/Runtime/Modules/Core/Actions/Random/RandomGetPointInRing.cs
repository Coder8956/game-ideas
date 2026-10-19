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
    [ActionDescription("Get a random point in a ring specified by an inner and outer radius. Optionally bias distribution using a falloff curve (x:0=inner, x:1=outer).")]
    public class RandomGetPointInRing : BaseAction
    {
        [Tooltip("The center of the circle.")]
        public Vector2Var Center;

        [DefaultValue(1f)]
        [Tooltip("Inner radius of the ring.")]
        public FloatVar InnerRadius;

        [DefaultValue(1.5f)]
        [Tooltip("Outer radius of the ring.")]
        public FloatVar OuterRadius;

        [OptionalField]
        [Tooltip("Optional falloff controlling probability between inner and outer radius. " +
                 "x=0 represents the inner radius, x=1 the outer radius. " +
                 "\nHigher y near x=0 concentrates points near the inner radius; " +
                 "higher y near x=1 concentrates points near the outer radius. " +
                 "\nLeave unset for uniform distribution.")]
        public AnimationCurveVar Falloff;

        [WriteOnly, DefaultName("RandomPoint")]
        [Tooltip("Store the random value in a Vector2 variable.")]
        public Vector2Ref StoreResult;

        public override bool CanExecute() => CheckParameters(Center, InnerRadius, OuterRadius, StoreResult);

        public override void Execute()
        {
            var inner = Mathf.Max(0f, InnerRadius.Value);
            var outer = Mathf.Max(inner, OuterRadius.Value);

            StoreResult.Value = GetRandomPointInRing(inner, outer);
        }

        private Vector2 GetRandomPointInRing(float innerRadius, float outerRadius)
        {
            // Sample distance fraction [0,1] using optional falloff curve
            var t = CurveDistributionSampler.Sample01(Falloff);
            var radius = Mathf.Lerp(innerRadius, outerRadius, t);

            // Random direction
            var angle = Random.value * Mathf.PI * 2f;
            var sin = Mathf.Sin(angle);
            var cos = Mathf.Cos(angle);

            return Center.Value + new Vector2(cos * radius, sin * radius);
        }

        public override string GetSummary()
        {
            var summary = "Get random point in ring";
            summary += " r:{InnerRadius}-{OuterRadius}";
            if (Falloff.HasCurve()) summary += " ({Falloff})";
            summary += " -> {StoreResult}";
            return summary;
        }
    }
}

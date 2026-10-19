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
    [ActionDescription("Get a random point inside or on a circle of the given radius. Optionally bias the distribution using a falloff curve (x:0=center, 1=radius).")]
    public class RandomGetPointInCircle : BaseAction
    {
        [Tooltip("The center of the circle.")]
        public Vector2Var Center;

        [DefaultValue(1f)]
        [Tooltip("Radius of the circle.")]
        public FloatVar Radius;

        [OptionalField]
        [Tooltip("Optional falloff by distance from Center (x:0=center, 1=radius). " +
                 "Higher y near x=0 concentrates points near the center. " +
                 "Leave unset for uniform distance (area-biased toward the edges).")]
        public AnimationCurveVar Falloff;

        [DefaultName("RandomPoint")]
        [WriteOnly]
        [Tooltip("Store the random value in a Vector2 variable.")]
        public Vector2Ref StoreResult;

        public override bool CanExecute() => CheckParameters(Center, Radius, StoreResult);

        public override void Execute()
        {
            var r = Mathf.Max(0f, Radius.Value);
            if (r <= 0f)
            {
                StoreResult.Value = Center.Value;
                return;
            }

            if (Falloff.IsNone || Falloff.Value == null)
            {
                StoreResult.Value = Center.Value + Random.insideUnitCircle * r;
                return;
            }

            StoreResult.Value = CurveDistributionSampler.SampleRadial2D(Center.Value, r, Falloff);
        }

        public override string GetSummary()
        {
            var summary = "Get random point in circle r:{Radius}";
            if (Falloff.HasCurve()) summary += " ({Falloff})";
            summary += " -> {StoreResult}";
            return summary;
        }
    }
}

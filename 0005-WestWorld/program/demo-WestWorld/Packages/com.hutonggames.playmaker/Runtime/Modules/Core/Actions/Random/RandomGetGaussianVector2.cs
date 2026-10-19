using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomVector2)]
    [ActionDescription("Get a random Vector2 from a Gaussian (normal) distribution centered on Center.")]
    [HelpURL("https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform")]
    public class RandomGetGaussianVector2 : BaseAction
    {
        [Tooltip("The center of the distribution.")]
        public Vector2Var Center;

        [DefaultValue(1f)]
        [Tooltip("The standard deviation, or spread, for each axis. This is not a maximum radius; values are not clamped and can land outside this distance from Center.")]
        public FloatVar StandardDeviation;

        [WriteOnly, DefaultName("RandomPoint")]
        [Tooltip("Store the random value in a Vector2 variable.")]
        public Vector2Ref StoreResult;

        public override bool CanExecute() => CheckParameters(Center, StandardDeviation, StoreResult);

        public override void Execute()
        {
            var sd = Mathf.Abs(StandardDeviation.Value);
            StoreResult.Value = new Vector2(
                Center.Value.x + RandomGetGaussian.SampleStandardNormal() * sd,
                Center.Value.y + RandomGetGaussian.SampleStandardNormal() * sd);
        }

        public override string GetSummary()
        {
            return "Get Gaussian Vector2 center:{Center} sd:{StandardDeviation} -> {StoreResult}";
        }
    }
}

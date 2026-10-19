using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomFloat)]
    [ActionDescription("Get a random float from a Gaussian (normal) distribution.")]
    [HelpURL("https://en.wikipedia.org/wiki/Box%E2%80%93Muller_transform")]
    public class RandomGetGaussian : BaseAction
    {
        [Tooltip("The center of the distribution.")]
        public FloatVar Mean;

        [DefaultValue(1f)]
        [Tooltip("The standard deviation, or spread, of the distribution. About 68% of samples fall within Mean +/- 1 standard deviation, but values are not clamped.")]
        public FloatVar StandardDeviation;

        [WriteOnly]
        [Tooltip("Store the random value in a float variable.")]
        public FloatRef StoreResult;

        public override bool CanExecute() => CheckParameters(Mean, StandardDeviation, StoreResult);

        public override void Execute()
        {
            StoreResult.Value = Mean.Value + SampleStandardNormal() * Mathf.Abs(StandardDeviation.Value);
        }

        public override string GetSummary()
        {
            return "Get Gaussian mean:{Mean} sd:{StandardDeviation} -> {StoreResult}";
        }

        internal static float SampleStandardNormal()
        {
            var u1 = Mathf.Max(Random.value, float.Epsilon);
            var u2 = Random.value;
            var radius = Mathf.Sqrt(-2f * Mathf.Log(u1));
            var theta = 2f * Mathf.PI * u2;

            return radius * Mathf.Cos(theta);
        }
    }
}

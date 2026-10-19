using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomFloat)]
    [ActionDescription("Get a random float between Center - Magnitude and Center + Magnitude. Optionally bias the distribution with a falloff curve (0 = center, 1 = magnitude).")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Random.Range.html")]
    public class RandomGetFloatAroundCenter : BaseAction
    {
        [Tooltip("The center of the random value.")]
        public FloatVar Center;

        [Tooltip("The magnitude of the random value. The result will be within [Center - Magnitude, Center + Magnitude].")]
        public FloatVar Magnitude;

        [OptionalField]
        [Tooltip("Optional falloff by distance from Center (x: 0=center, 1=magnitude). "
               + "Higher y near x=0 concentrates values near Center. Leave unset for uniform.")]
        public AnimationCurveVar Falloff;

        [WriteOnly]
        [Tooltip("Store the random value in a float variable.")]
        public FloatRef StoreResult;

        public override bool CanExecute() => CheckParameters(Magnitude, StoreResult);

        public override void Execute()
        {
            var mag = Mathf.Max(0f, Magnitude.Value);
            if (mag <= 0f)
            {
                StoreResult.Value = Center.Value;
                return;
            }

            // Use the shared sampler (uniform if Falloff is unset/null)
            StoreResult.Value = CurveDistributionSampler.SampleSymmetric(
                Center.Value, mag, Falloff);
        }

        public override string GetSummary()
        {
            var summary = "Get float";
            if (Center.IsVariable || Center.Value != 0) summary += " around {Center}";
            summary += " +/- {Magnitude} ";
            if (Falloff.HasCurve()) summary += "({Falloff})";
            summary += " -> {StoreResult}";
            return summary;
        }
    }
}

using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Point In Ring")]
    [Tooltip("Generate a random point on the XZ plane inside a ring.")]
    public class RandomPointInRingGeneratorBlock : SpawnPositionGeneratorBlock
    {
        [Tooltip("Center of the ring.")]
        public Vector3Var Center;

        [DefaultValue(1f)]
        [Tooltip("Inner radius of the ring.")]
        public FloatVar InnerRadius;

        [DefaultValue(5f)]
        [Tooltip("Outer radius of the ring.")]
        public FloatVar OuterRadius;

        [OptionalField]
        [Tooltip("Optional falloff controlling probability between inner and outer radius.")]
        public AnimationCurveVar Falloff;

        public override bool IsValid => Center.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Center, InnerRadius, OuterRadius);

        public override void Generate(FindValidRandomPosition action)
        {
            var inner = Mathf.Max(0f, InnerRadius.Value);
            var outer = Mathf.Max(inner, OuterRadius.Value);

            var t = CurveDistributionSampler.Sample01(Falloff);
            var radius = Mathf.Lerp(inner, outer, t);
            var angle = Random.value * Mathf.PI * 2f;

            action.CandidatePosition = Center.Value + new Vector3(
                Mathf.Cos(angle) * radius,
                0f,
                Mathf.Sin(angle) * radius);
        }

        public override string GetSummary() => "Random point in ring";
    }
}

using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Position In Sphere")]
    [Tooltip("Generate a random position inside a sphere.")]
    public class RandomPositionInSphereGeneratorBlock : SpawnPositionGeneratorBlock
    {
        [Tooltip("Center of the sphere.")]
        public Vector3Var Center;

        [DefaultValue(5f)]
        [Tooltip("Radius of the sphere.")]
        public FloatVar Radius;

        public override bool IsValid => Center.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Center, Radius);

        public override void Generate(FindValidRandomPosition action)
        {
            action.CandidatePosition = Center.Value + Random.insideUnitSphere * Radius.Value;
        }

        public override string GetSummary() => "Random position in sphere";
    }
}

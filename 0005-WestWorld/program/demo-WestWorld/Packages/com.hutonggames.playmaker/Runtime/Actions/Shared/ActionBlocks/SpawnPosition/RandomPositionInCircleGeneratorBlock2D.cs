using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Position In Circle 2D")]
    [Tooltip("Generate a random 2D position inside a circle.")]
    public class RandomPositionInCircleGeneratorBlock2D : SpawnPositionGeneratorBlock2D
    {
        [Tooltip("Center of the circle.")]
        public Vector2Var Center;

        [DefaultValue(5f)]
        [Tooltip("Radius of the circle.")]
        public FloatVar Radius;

        public override bool IsValid => Center.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Center, Radius);

        public override void Generate(FindValidRandomPosition2D action)
        {
            action.CandidatePosition = Center.Value + Random.insideUnitCircle * Radius.Value;
        }

        public override string GetSummary() => "Random position in circle 2D";
    }
}

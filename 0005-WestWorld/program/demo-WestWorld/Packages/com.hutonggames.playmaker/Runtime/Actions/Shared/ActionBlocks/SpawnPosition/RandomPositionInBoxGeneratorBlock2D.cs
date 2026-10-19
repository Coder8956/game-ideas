using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Position In Box 2D")]
    [Tooltip("Generate a random 2D position inside a box.")]
    public class RandomPositionInBoxGeneratorBlock2D : SpawnPositionGeneratorBlock2D
    {
        [Tooltip("Center of the box.")]
        public Vector2Var Center;

        [Tooltip("Size of the box.")]
        public Vector2Var Size;

        public override bool IsValid => Center.HasValue() && Size.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Center, Size);

        public override void Generate(FindValidRandomPosition2D action)
        {
            var extents = Size.Value * 0.5f;
            action.CandidatePosition = Center.Value + new Vector2(
                Random.Range(-extents.x, extents.x),
                Random.Range(-extents.y, extents.y));
        }

        public override string GetSummary() => "Random position in box 2D";
    }
}

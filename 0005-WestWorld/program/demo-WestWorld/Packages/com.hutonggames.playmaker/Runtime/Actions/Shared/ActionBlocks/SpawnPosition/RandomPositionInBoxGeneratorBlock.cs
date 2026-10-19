using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Position In Box")]
    [Tooltip("Generate a random position inside a box.")]
    public class RandomPositionInBoxGeneratorBlock : SpawnPositionGeneratorBlock
    {
        [Tooltip("Center of the box.")]
        public Vector3Var Center;

        [Tooltip("Size of the box.")]
        public Vector3Var Size;

        public override bool IsValid => Center.HasValue() && Size.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Center, Size);

        public override void Generate(FindValidRandomPosition action)
        {
            var extents = Size.Value * 0.5f;
            action.CandidatePosition = Center.Value + new Vector3(
                Random.Range(-extents.x, extents.x),
                Random.Range(-extents.y, extents.y),
                Random.Range(-extents.z, extents.z));
        }

        public override string GetSummary() => "Random position in box";
    }
}

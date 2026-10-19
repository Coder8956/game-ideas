using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Transform From List")]
    [Tooltip("Generate a candidate position and rotation from a random Transform in a list.")]
    public class RandomTransformFromListGeneratorBlock : SpawnPositionGeneratorBlock
    {
        [Tooltip("List of transforms to pick from.")]
        public TransformListVar Transforms;

        [Tooltip("Don't get the same transform twice in a row." +
                 "\nNOTE: Does not apply across scene loading/unloading.")]
        public BoolVar NoRepeat;

        [NonSerialized] private RandomHelper _randomHelper;

        public override bool IsValid => Transforms?.Value != null && Transforms.Value.Count > 0;

        public override bool CanExecute() => Action.CheckParameters(Transforms, NoRepeat);

        public override void Generate(FindValidRandomPosition action)
        {
            var transforms = Transforms?.Value;
            if (transforms == null || transforms.Count == 0)
            {
                action.CandidatePosition = Vector3.zero;
                action.CandidateRotation = Quaternion.identity;
                return;
            }

            _randomHelper ??= new RandomHelper();

            var index = _randomHelper.Range(0, transforms.Count, NoRepeat.Value);
            var transform = transforms[index];

            if (transform == null)
            {
                action.CandidatePosition = Vector3.zero;
                action.CandidateRotation = Quaternion.identity;
                return;
            }

            action.CandidatePosition = transform.position;
            action.CandidateRotation = transform.rotation;
        }

        public override string GetSummary() => "Random transform from list";
    }
}

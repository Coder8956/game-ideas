using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Transform From List 2D")]
    [Tooltip("Generate a candidate 2D position and rotation from a random Transform in a list.")]
    public class RandomTransformFromListGeneratorBlock2D : SpawnPositionGeneratorBlock2D
    {
        [Tooltip("List of transforms to pick from.")]
        public TransformListVar Transforms;

        [Tooltip("Don't get the same transform twice in a row." +
                 "\nNOTE: Does not apply across scene loading/unloading.")]
        public BoolVar NoRepeat;

        [NonSerialized] private RandomHelper _randomHelper;

        public override bool IsValid => Transforms?.Value != null && Transforms.Value.Count > 0;

        public override bool CanExecute() => Action.CheckParameters(Transforms, NoRepeat);

        public override void Generate(FindValidRandomPosition2D action)
        {
            var transforms = Transforms?.Value;
            if (transforms == null || transforms.Count == 0)
            {
                action.CandidatePosition = Vector2.zero;
                action.CandidateRotation = 0f;
                return;
            }

            _randomHelper ??= new RandomHelper();

            var index = _randomHelper.Range(0, transforms.Count, NoRepeat.Value);
            var transform = transforms[index];

            if (transform == null)
            {
                action.CandidatePosition = Vector2.zero;
                action.CandidateRotation = 0f;
                return;
            }

            var position = transform.position;
            action.CandidatePosition = new Vector2(position.x, position.y);
            action.CandidateRotation = transform.eulerAngles.z;
        }

        public override string GetSummary() => "Random transform from list 2D";
    }
}

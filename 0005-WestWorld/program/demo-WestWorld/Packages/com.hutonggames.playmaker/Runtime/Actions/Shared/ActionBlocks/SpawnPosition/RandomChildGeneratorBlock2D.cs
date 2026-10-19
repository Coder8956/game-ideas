using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Child 2D")]
    [Tooltip("Generate a candidate 2D position and rotation from a random direct child of a Transform.")]
    public class RandomChildGeneratorBlock2D : SpawnPositionGeneratorBlock2D
    {
        [OwnerDefaultValue]
        [Tooltip("Parent transform to pick a child from.")]
        public TransformVar Parent;

        [Tooltip("Don't get the same child twice in a row." +
                 "\nNOTE: Does not apply across scene loading/unloading.")]
        public BoolVar NoRepeat;

        [NonSerialized] private RandomHelper _randomHelper;

        public override bool IsValid => Parent.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Parent, NoRepeat);

        public override void Generate(FindValidRandomPosition2D action)
        {
            var parent = Parent.Value;
            if (parent == null || parent.childCount == 0)
            {
                action.CandidatePosition = Vector2.zero;
                action.CandidateRotation = 0f;
                return;
            }

            _randomHelper ??= new RandomHelper();

            var index = _randomHelper.Range(0, parent.childCount, NoRepeat.Value);
            var child = parent.GetChild(index);

            if (child == null)
            {
                action.CandidatePosition = Vector2.zero;
                action.CandidateRotation = 0f;
                return;
            }

            var position = child.position;
            action.CandidatePosition = new Vector2(position.x, position.y);
            action.CandidateRotation = child.eulerAngles.z;
        }

        public override string GetSummary() => "Random child 2D";
    }
}

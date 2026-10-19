using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Snap To Grid 2D")]
    [Tooltip("Snap the candidate 2D position to grid points. Set grid size to 0 to disable snapping on an axis.")]
    public class SnapToGridModifierBlock2D : SpawnPositionModifierBlock2D
    {
        [DefaultValue(1f)]
        [Tooltip("X grid size.")]
        public FloatVar XGridSize;

        [DefaultValue(1f)]
        [Tooltip("Y grid size.")]
        public FloatVar YGridSize;

        public override bool CanExecute() => Action.CheckParameters(XGridSize, YGridSize);

        public override bool ModifyCandidate(FindValidRandomPosition2D action)
        {
            var position = action.CandidatePosition;
            position.Set(
                Snap.ToGrid(position.x, XGridSize.Value),
                Snap.ToGrid(position.y, YGridSize.Value));
            action.CandidatePosition = position;
            return true;
        }

        public override string GetSummary() => "Snap to grid 2D";
    }
}

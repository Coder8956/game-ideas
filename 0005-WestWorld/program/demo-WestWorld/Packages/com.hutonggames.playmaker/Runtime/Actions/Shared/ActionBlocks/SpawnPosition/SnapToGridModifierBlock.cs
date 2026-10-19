using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Snap To Grid")]
    [Tooltip("Snap the candidate position to grid points. Set grid size to 0 to disable snapping on an axis.")]
    public class SnapToGridModifierBlock : SpawnPositionModifierBlock
    {
        [DefaultValue(1f)]
        [Tooltip("X grid size.")]
        public FloatVar XGridSize;

        [DefaultValue(1f)]
        [Tooltip("Y grid size.")]
        public FloatVar YGridSize;

        [DefaultValue(1f)]
        [Tooltip("Z grid size.")]
        public FloatVar ZGridSize;

        public override bool CanExecute() => Action.CheckParameters(XGridSize, YGridSize, ZGridSize);

        public override bool ModifyCandidate(FindValidRandomPosition action)
        {
            var position = action.CandidatePosition;
            position.Set(
                Snap.ToGrid(position.x, XGridSize.Value),
                Snap.ToGrid(position.y, YGridSize.Value),
                Snap.ToGrid(position.z, ZGridSize.Value));
            action.CandidatePosition = position;
            return true;
        }

        public override string GetSummary() => "Snap to grid";
    }
}

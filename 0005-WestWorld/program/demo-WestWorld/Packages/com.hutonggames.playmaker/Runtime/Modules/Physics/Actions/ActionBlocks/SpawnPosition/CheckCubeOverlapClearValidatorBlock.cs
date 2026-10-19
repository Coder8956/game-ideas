using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Check Cube Clear")]
    [Tooltip("Require the candidate position to be clear of colliders within an axis-aligned box.")]
    public class CheckCubeOverlapClearValidatorBlock : SpawnPositionValidatorBlock
    {
        [Tooltip("Half the size of the box in each dimension.")]
        public Vector3Var HalfExtents;

        [Tooltip("A Layer mask that is used to selectively ignore colliders.")]
        [DefaultValue("Physics.DefaultRaycastLayers")]
        public LayerMaskVar LayerMask;

        [Tooltip("Specifies whether this query should hit Triggers.")]
        [DefaultValue(QueryTriggerInteraction.UseGlobal)]
        public QueryTriggerInteraction HitTriggers;

        public override bool CanExecute() => Action.CheckParameters(HalfExtents, LayerMask);

        public override bool IsValidPosition(FindValidRandomPosition action)
        {
            return !Physics.CheckBox(action.CandidatePosition, HalfExtents.Value, Quaternion.identity, LayerMask.Value, HitTriggers);
        }

        public override string GetSummary() => "Cube clear";
    }
}

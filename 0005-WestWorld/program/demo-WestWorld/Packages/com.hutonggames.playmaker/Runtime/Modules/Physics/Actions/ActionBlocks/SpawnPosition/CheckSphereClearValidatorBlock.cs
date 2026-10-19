using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Check Sphere Clear")]
    [Tooltip("Require the candidate position to be clear of colliders within a sphere.")]
    public class CheckSphereClearValidatorBlock : SpawnPositionValidatorBlock
    {
        [DefaultValue(0.5f)]
        [Tooltip("Radius used to test for blocking colliders.")]
        public FloatVar Radius;

        [Tooltip("A Layer mask that is used to selectively ignore colliders.")]
        [DefaultValue("Physics.DefaultRaycastLayers")]
        public LayerMaskVar LayerMask;

        [Tooltip("Specifies whether this query should hit Triggers.")]
        [DefaultValue(QueryTriggerInteraction.UseGlobal)]
        public QueryTriggerInteraction HitTriggers;

        public override bool CanExecute() => Action.CheckParameters(Radius, LayerMask);

        public override bool IsValidPosition(FindValidRandomPosition action)
        {
            return !Physics.CheckSphere(action.CandidatePosition, Radius.Value, LayerMask.Value, HitTriggers);
        }

        public override string GetSummary() => "Sphere clear";
    }
}

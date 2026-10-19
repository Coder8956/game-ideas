using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class RaycastFilterBlock : BaseActionBlock
    {
        [Tooltip("A Layer mask that is used to selectively ignore colliders when casting a ray.")]
        [DefaultValue("Physics.DefaultRaycastLayers")]
        public LayerMaskVar LayerMask;

        [Tooltip("Specifies whether this query should hit Triggers.")]
        [DefaultValue(QueryTriggerInteraction.UseGlobal)]
        public QueryTriggerInteraction UseTriggers;
        
        public override string GetSummary() => "mask: {LayerMask} triggers: {UseTriggers}";
    }
}
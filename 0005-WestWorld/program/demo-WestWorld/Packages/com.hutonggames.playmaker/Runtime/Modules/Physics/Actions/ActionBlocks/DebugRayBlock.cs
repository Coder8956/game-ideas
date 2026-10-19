using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Debug")]
    public class DebugRayBlock : BaseActionBlock
    {
        [DefaultValue("Color.yellow")]
        [Tooltip("The color of the debug ray.")]
        public ColorVar RayColor;

        [DefaultValue(1f)]
        [Tooltip("How long the ray should be visible for.")]
        public FloatVar Duration;
        
        public void DrawRay(Vector3 start, Vector3 direction)
        {
            var duration = Duration.Value;
            if (Action.UpdateMode.HasFlag(UpdateMode.EveryFrame))
            {
                duration = 0;
            }
            Debug.DrawRay(start, direction, RayColor.Value, duration);
        }
    }
}
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Debug)]
    [ActionDescription("Draws a gizmo representing a RaycastHit in the world.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit.html")]
    public sealed class DebugDrawRaycastHit : BaseAction
    {
        [Tooltip("The RaycastHit to draw.")]
        [SerializeField]
        private RaycastHitRef _raycastHit;

        [Tooltip("Color to use for the hit indicator.")]
        [SerializeField, DefaultValue("Color.red")]
        private ColorVar _hitColor;

        [Tooltip("Color to use for the normal line.")]
        [SerializeField, DefaultValue("Color.yellow")]
        private ColorVar _normalColor;
        
        [Tooltip("How long the gizmo should be visible for in seconds.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _duration;
        
        [DefaultValue(true)]
        [Tooltip("Should the gizmo be obscured by other objects in the scene?")]
        [SerializeField]
        private BoolVar _depthTest;
        
        public override void Execute()
        {
            // Duration should be zero if updated every frame
            var duration = UpdateMode.HasFlag(UpdateMode.EveryFrame) ? 0 : _duration.Value;
            DoDrawRaycastHit(duration);
        }
        
        public override void OnStop()
        {
            // Draw the ray one last time with the full duration
            DoDrawRaycastHit(_duration.Value);
        }

        private void DoDrawRaycastHit(float duration)
        {
            var raycastHit = _raycastHit.Value;
            if (raycastHit.collider == null) return;
            
            var settings = new DebugDraw.Settings(_hitColor.Value, duration, _depthTest.Value);
            DebugDraw.Circle(raycastHit.point, raycastHit.normal, .2f, settings, 16);
            var normalSettings = settings with {Color = _normalColor.Value};
            DebugDraw.Line(raycastHit.point, raycastHit.point + raycastHit.normal, normalSettings);
        }
        
        public override string GetSummary() => "Draw {_raycastHit}";
    }
}
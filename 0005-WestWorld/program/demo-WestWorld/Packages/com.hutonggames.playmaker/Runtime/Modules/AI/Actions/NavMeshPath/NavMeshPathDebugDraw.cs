using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.AI
{
    [Serializable]
    [PublicAPI]
    [HasSceneGUI]
    [ActionCategory(Category.AI.NavMeshPath)]
    [ActionDescription("Draw a NavMeshPath for debugging using Debug.DrawLine and Scene view gizmos.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshPath.html")]
    public sealed class NavMeshPathDebugDraw : BaseAction
    {
        [Tooltip("The NavMeshPath to draw.")]
        [SerializeField]
        private NavMeshPathRef _navMeshPath;

        [DefaultValue("Color.cyan")]
        [Tooltip("Color of the path lines.")]
        [SerializeField]
        private ColorVar _color;

        [DefaultValue(1f)]
        [Tooltip("How long the path should be visible for in seconds.")]
        [SerializeField]
        private FloatVar _duration;

        [DefaultValue(true)]
        [Tooltip("Should the path lines be obscured by other objects in the scene?")]
        [SerializeField]
        private BoolVar _depthTest;

        [DefaultValue(true)]
        [Tooltip("Draw start and end markers in the Scene view when the action is selected.")]
        [SerializeField]
        private BoolVar _drawEndpoints;

        [DefaultValue(0.2f)]
        [Tooltip("Radius of the Scene view endpoint markers.")]
        [SerializeField]
        private FloatVar _markerRadius;

        public override bool CanExecute() =>
            CheckParameters(_navMeshPath, _color, _duration, _depthTest, _drawEndpoints, _markerRadius);

        public override void Execute()
        {
            var duration = UpdateMode.HasFlag(UpdateMode.EveryFrame) ? 0 : _duration.Value;
            DrawDebugLines(duration);
        }

        public override void OnStop()
        {
            DrawDebugLines(_duration.Value);
        }

        public override string GetSummary() => "Draw {_navMeshPath} {_color}";

#if UNITY_EDITOR
        public override bool HasGizmos => true;

        public override void OnDrawGizmosSelected()
        {
            var corners = GetCorners();
            if (corners == null || corners.Length == 0)
            {
                return;
            }

            Gizmos.color = _color.Value;
            for (var i = 0; i < corners.Length - 1; i++)
            {
                Gizmos.DrawLine(corners[i], corners[i + 1]);
            }

            if (!_drawEndpoints.Value)
            {
                return;
            }

            var radius = Mathf.Max(0f, _markerRadius.Value);
            if (radius <= 0f)
            {
                return;
            }

            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(corners[0], radius);

            if (corners.Length > 1)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(corners[corners.Length - 1], radius);
            }
        }

        public override bool HasDebugInfo => true;

        public override string GetDebugInfo()
        {
            var path = _navMeshPath.Value;
            if (path == null)
            {
                return "Path: null";
            }

            var corners = path.corners;
            var length = 0f;
            if (corners != null)
            {
                for (var i = 1; i < corners.Length; i++)
                {
                    length += Vector3.Distance(corners[i - 1], corners[i]);
                }
            }

            return $"Corners: {corners?.Length ?? 0}  Status: {path.status}  Length: {length:0.##}";
        }
#endif

        private void DrawDebugLines(float duration)
        {
            var corners = GetCorners();
            if (corners == null || corners.Length < 2)
            {
                return;
            }

            for (var i = 0; i < corners.Length - 1; i++)
            {
                Debug.DrawLine(corners[i], corners[i + 1], _color.Value, duration, _depthTest.Value);
            }
        }

        private Vector3[] GetCorners() => _navMeshPath.Value?.corners;
    }
}

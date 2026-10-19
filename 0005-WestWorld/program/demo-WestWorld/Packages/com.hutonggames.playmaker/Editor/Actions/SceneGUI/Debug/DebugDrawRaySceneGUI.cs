using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(DebugDrawRay))]
    public class DebugDrawRaySceneGUI : SceneGUIDrawer
    {
        private DebugDrawRay _debugDrawRay;

        public DebugDrawRaySceneGUI(DebugDrawRay target) : base(target)
        {
            _debugDrawRay = target;
        }
        
        public override bool IsValid => _debugDrawRay.IsEnabled && _debugDrawRay.CanExecute();
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            if (!IsValid) return;

            var startPosition = _debugDrawRay.StartPosition;
            var endPosition = _debugDrawRay.EndPosition;

            var style = SceneGUIStyles.LabelStyle;
            var fromLabel = new GUIContent("From", "Debug Draw Ray");
            var toLabel = new GUIContent("Dir", "Debug Draw Ray");
            Handles.Label(startPosition, fromLabel, style);
            Handles.Label(endPosition, toLabel, style);
        }
        
        public override void OnDrawGizmos()
        {
            if (!IsValid) return;
            
            var startPosition = _debugDrawRay.StartPosition;
            var endPosition = _debugDrawRay.EndPosition;

            using (new Handles.DrawingScope(_debugDrawRay.Color))
            {
                Handles.DrawLine(startPosition, endPosition);
            }
        }
    }
}
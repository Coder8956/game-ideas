using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(PhysicsRaycast__Options))]
    public class PhysicsRaycast__OptionsSceneGUI : SceneGUIDrawer
    {
        private PhysicsRaycast__Options _raycast;

        public PhysicsRaycast__OptionsSceneGUI(PhysicsRaycast__Options target) : base(target)
        {
            _raycast = target;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            var startPosition = _raycast.StartPosition;
            var endPosition = _raycast.EndPosition;

            Handles.Label(startPosition, "From");
            Handles.Label(endPosition, "To");
        }

        public override void OnDrawGizmos()
        {
            var startPosition = _raycast.StartPosition;
            var endPosition = _raycast.EndPosition;

            var color = Color.yellow;
            if (_raycast.DebugRay != null)
            {
                color = _raycast.DebugRay.RayColor.Value;
            }
            
            using (new Handles.DrawingScope(color))
            {
                Handles.DrawLine(startPosition, endPosition);
            }
        }
    }
}
using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(PhysicsLinecast__Options))]
    public class PhysicsLineCastSceneGUI : SceneGUIDrawer
    {
        private PhysicsLinecast__Options _lineCast;

        public PhysicsLineCastSceneGUI(PhysicsLinecast__Options target) : base(target)
        {
            _lineCast = target;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            var startPosition = _lineCast.StartPosition.GetWorldPosition();
            var endPosition = _lineCast.EndPosition.GetWorldPosition();

            Handles.Label(startPosition, "From");
            Handles.Label(endPosition, "To");
        }

        public override void OnDrawGizmos()
        {
            var startPosition = _lineCast.StartPosition.GetWorldPosition();
            var endPosition = _lineCast.EndPosition.GetWorldPosition();

            var color = Color.yellow;
            if (_lineCast.DebugRay != null)
            {
                color = _lineCast.DebugRay.RayColor.Value;
            }
            
            using (new Handles.DrawingScope(color))
            {
                Handles.DrawLine(startPosition, endPosition);
            }
        }
    }
}
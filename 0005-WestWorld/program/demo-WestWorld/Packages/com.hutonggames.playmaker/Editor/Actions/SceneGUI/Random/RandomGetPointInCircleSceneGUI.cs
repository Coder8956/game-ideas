using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(RandomGetPointInCircle))]
    public class RandomGetPointInCircleSceneGUI : SceneGUIDrawer
    {
        private RandomGetPointInCircle _action;

        public RandomGetPointInCircleSceneGUI(RandomGetPointInCircle target) : base(target)
        {
            _action = target;
        }
        
        public override bool IsValid => _action.IsEnabled;

        public override void OnSceneGUI(SceneView sceneView)
        {
            if (!IsValid) return;

            EditorGUI.BeginChangeCheck();

            // Handle center position
            var center3D = new Vector3(_action.Center.Value.x, _action.Center.Value.y, 0f);
            var newCenter3D = Handles.PositionHandle(center3D, Quaternion.identity);

            // Handle radius with a radius handle
            var cameraForward = sceneView.camera.transform.forward;
            var newRadius =
                Handles.RadiusHandle(Quaternion.LookRotation(cameraForward), newCenter3D, _action.Radius.Value);

            // Draw the wire disc for visual feedback
            using (new Handles.DrawingScope(Color.yellow))
            {
                Handles.DrawWireDisc(newCenter3D, cameraForward, newRadius);
            }

            // Apply changes if any handles were modified
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(_action.Owner, "Modify Circle Parameters");

                if (!_action.Center.IsNone)
                {
                    _action.Center.Value = new Vector2(newCenter3D.x, newCenter3D.y);
                }

                if (!_action.Radius.IsNone)
                {
                    _action.Radius.Value = newRadius;
                }

                // Mark the action as dirty so changes are saved
                UndoHelper.RecordPrefabChanges(_action.Owner);
            }
        }

        
        public override void OnDrawGizmos()
        {
            using (new Handles.DrawingScope(Color.yellow))
            {
                var sceneView = SceneView.currentDrawingSceneView;
                if (!sceneView) return;
                
                // Get the scene view camera
                var sceneCamera = sceneView.camera;
                if (sceneCamera != null)
                {
                    // Use the camera's forward direction as the disc normal
                    var cameraForward = sceneCamera.transform.forward;
                    Handles.DrawWireDisc(_action.Center.Value, cameraForward, _action.Radius.Value);
                }
                else
                {
                    // Fallback to original behavior if no scene camera available
                    Handles.DrawWireDisc(_action.Center.Value, Vector3.up, _action.Radius.Value);
                }
            }
        }
    }
}
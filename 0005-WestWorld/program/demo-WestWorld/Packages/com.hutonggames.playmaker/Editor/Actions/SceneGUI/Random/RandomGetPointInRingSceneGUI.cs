using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(RandomGetPointInRing))]
    public class RandomGetPointInRingSceneGUI : SceneGUIDrawer
    {
        private RandomGetPointInRing _action;

        public RandomGetPointInRingSceneGUI(RandomGetPointInRing target) : base(target)
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
            
            // Handle inner and outer radius with radius handles
            var cameraForward = sceneView.camera.transform.forward;
            
            // Inner radius handle (red color)
            using (new Handles.DrawingScope(Color.red))
            {
                var newInnerRadius = Handles.RadiusHandle(Quaternion.LookRotation(cameraForward), newCenter3D, _action.InnerRadius.Value);
                if (EditorGUI.EndChangeCheck())
                {
                    EditorGUI.BeginChangeCheck();
                    _action.InnerRadius.Value = Mathf.Max(0f, Mathf.Min(newInnerRadius, _action.OuterRadius.Value - 0.01f));
                }
            }
            
            // Outer radius handle (yellow color)
            using (new Handles.DrawingScope(Color.yellow))
            {
                var newOuterRadius = Handles.RadiusHandle(Quaternion.LookRotation(cameraForward), newCenter3D, _action.OuterRadius.Value);
                if (EditorGUI.EndChangeCheck())
                {
                    EditorGUI.BeginChangeCheck();
                    _action.OuterRadius.Value = Mathf.Max(_action.InnerRadius.Value + 0.01f, newOuterRadius);
                }
            }
            
            // Apply center changes if position handle was modified
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(_action.Owner, "Modify Ring Parameters");
                
                // Update center (convert back to Vector2)
                _action.Center.Value = new Vector2(newCenter3D.x, newCenter3D.y);
                
                // Mark the action as dirty so changes are saved
                UndoHelper.RecordPrefabChanges(_action.Owner);
            }
        }
        
        public override void OnDrawGizmos()
        {
            if (!IsValid) return;
            
            var sceneView = SceneView.currentDrawingSceneView;
            if (!sceneView) return;
                
            // Get the scene view camera
            var sceneCamera = sceneView.camera;
            var cameraForward = sceneCamera ? sceneCamera.transform.forward : Vector3.forward;
            var center3D = new Vector3(_action.Center.Value.x, _action.Center.Value.y, 0f);
            
            // Draw inner circle (red)
            using (new Handles.DrawingScope(Color.red))
            {
                Handles.DrawWireDisc(center3D, cameraForward, _action.InnerRadius.Value);
            }
            
            // Draw outer circle (yellow)
            using (new Handles.DrawingScope(Color.yellow))
            {
                Handles.DrawWireDisc(center3D, cameraForward, _action.OuterRadius.Value);
            }
        }
    }
}

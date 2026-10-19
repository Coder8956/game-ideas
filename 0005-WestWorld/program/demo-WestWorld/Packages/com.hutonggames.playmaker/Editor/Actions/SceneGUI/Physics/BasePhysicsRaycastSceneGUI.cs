using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(PhysicsRaycast))]
    public class PhysicsRaycastSceneGUI : BasePhysicsRaycastSceneGUI
    {
        public PhysicsRaycastSceneGUI(PhysicsRaycast target) : base(target)
        {
        }
    }
    
    [PublicAPI]
    [SceneGUI(typeof(PhysicsRaycast__GameObject))]
    public class PhysicsRaycast__GameObjectSceneGUI : BasePhysicsRaycastSceneGUI
    {
        public PhysicsRaycast__GameObjectSceneGUI(PhysicsRaycast__GameObject target) : base(target)
        {
        }
    }
    
    [PublicAPI]
    [SceneGUI(typeof(BasePhysicsRaycast))]
    public class BasePhysicsRaycastSceneGUI : SceneGUIDrawer
    {
        private BasePhysicsRaycast _rayCast;
        private Vector3 StartPosition => _rayCast.StartPosition;
        private Vector3 EndPosition => _rayCast.EndPosition;
        private float MaxDistance => Mathf.Min(_rayCast.MaxDistance.Value, 10000);
        private Vector3 RayEndPosition => StartPosition + _rayCast.DirectionVector.normalized * MaxDistance;

        public BasePhysicsRaycastSceneGUI(BasePhysicsRaycast target) : base(target)
        {
            _rayCast = target;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            var style = SceneGUIStyles.LabelStyle;
            var fromLabel = new GUIContent("Origin", "Raycast Origin");
            var toLabel = new GUIContent("Target", "Raycast Direction");
            var maxLabel = new GUIContent(DebugUtility.GetDebugString(_rayCast.MaxDistance), "Raycast MaxDistance");
            Handles.Label(StartPosition, fromLabel, style);
            Handles.Label(EndPosition, toLabel, style);
            Handles.Label(RayEndPosition, maxLabel, style);
            
            var endPosition = _rayCast.EndPosition;
            
            HalfSizeHandles();
            
            EditorGUI.BeginChangeCheck();
            
            var rotation = _rayCast.TargetGizmoRotation;
            var newTargetPosition = Handles.PositionHandle(endPosition * 2, rotation);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Raycast Direction");
                _rayCast.EndPosition = newTargetPosition / 2;
                UndoHelper.RecordPrefabChanges(Owner);
            }
            
            RestoreHandlesMatrix();
        }

        public override void OnDrawGizmos()
        {
            var color = Color.yellow;
            if (_rayCast.DebugRay != null)
            {
                color = _rayCast.DebugRay.RayColor.Value;
            }
            
            using (new Handles.DrawingScope(color))
            {
                Handles.DrawLine(StartPosition, RayEndPosition);
            }
        }
    }
}
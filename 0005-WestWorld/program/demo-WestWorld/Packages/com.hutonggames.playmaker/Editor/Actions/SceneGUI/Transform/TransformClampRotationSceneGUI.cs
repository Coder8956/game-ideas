using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(TransformClampRotation))]
    public class TransformClampRotationSceneGUI : SceneGUIDrawer
    {
        private TransformClampRotation _clampRotation;
        private ArcHandle _minAngleHandle = new();
        private ArcHandle _maxAngleHandle = new();
        
        public TransformClampRotationSceneGUI(TransformClampRotation target) : base(target)
        {
            _clampRotation = target;
            
            // If MinAngle > 0 or MaxAngle < 0 the preview is incorrect.
            // So we hide the fill and outline and draw the arc separately.
            _minAngleHandle.fillColor = Color.clear;
            _minAngleHandle.wireframeColor = Color.clear;
            _maxAngleHandle.fillColor = Color.clear;
            _maxAngleHandle.wireframeColor = Color.clear;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            var radius = 5; // TODO: Determine or expose radius
            _minAngleHandle.radius = radius;
            _maxAngleHandle.radius = radius;
            
            _minAngleHandle.angle = _clampRotation.MinAngle.Value;
            _maxAngleHandle.angle = _clampRotation.MaxAngle.Value;
            var transform = _clampRotation.Transform;
            if (transform == null) return;

            var rotation = GetHandlesRotation(transform.parent);
            var handleMatrix = Matrix4x4.TRS(transform.position, rotation, Vector3.one);
            
            using (new Handles.DrawingScope(handleMatrix))
            {
                EditorGUI.BeginChangeCheck();
                _minAngleHandle.DrawHandle();
                _maxAngleHandle.DrawHandle();
                DrawArc(Vector3.zero, Vector3.up, _clampRotation.MinAngle.Value, _clampRotation.MaxAngle.Value, radius);
                if (EditorGUI.EndChangeCheck())
                {
                    UndoHelper.RecordObject(_clampRotation.Owner, "Change Clamp Rotation");
                    _clampRotation.MinAngle.Value = _minAngleHandle.angle;
                    _clampRotation.MaxAngle.Value = _maxAngleHandle.angle;
                    UndoHelper.RecordPrefabChanges(_clampRotation.Owner);
                }
            }
        }

        private void DrawArc(Vector3 position, Vector3 normal, float minAngle, float maxAngle, float radius)
        {
            Handles.color = new Color(1, 1, 1, 0.2f);
            HandlesUtility.DrawSolidArc(position, normal, minAngle, maxAngle, radius);
        }
        
        private Quaternion GetHandlesRotation(Transform transform)
        {
            if (transform == null)
            {
                return _clampRotation.Axis switch
                {
                    RotationAxis.X => Quaternion.LookRotation(Vector3.forward , Vector3.right),
                    RotationAxis.Y => Quaternion.LookRotation(Vector3.forward, Vector3.up),
                    RotationAxis.Z => Quaternion.LookRotation(Vector3.up, Vector3.forward),
                    _ => Quaternion.identity
                };
            }
            return _clampRotation.Axis switch
            {
                RotationAxis.X => Quaternion.LookRotation(transform.forward , transform.right),
                RotationAxis.Y => Quaternion.LookRotation(transform.forward, transform.up),
                RotationAxis.Z => Quaternion.LookRotation(transform.up, transform.forward),
                _ => Quaternion.identity
            };
        }
    }
}

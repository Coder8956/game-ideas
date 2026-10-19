using HutongGames.Editor;
using HutongGames.Editor.Extensions;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(TransformAlignToDirection))]
    public class TransformAlignToDirectionSceneGUI : SceneGUIDrawer
    {
        private TransformAlignToDirection _alignToDirection;
        
        public TransformAlignToDirectionSceneGUI(TransformAlignToDirection target) : base(target)
        {
            _alignToDirection = target;
        }

        public override bool IsValid => Check(_alignToDirection.Transform, _alignToDirection.Direction);

        public override void OnSceneGUI(SceneView sceneView)
        {
            HalfSizeHandles();
            
            EditorGUI.BeginChangeCheck();

            var targetPosition = _alignToDirection.Transform.position + _alignToDirection.Direction.Value;
            var handlePosition = Handles.PositionHandle(targetPosition * 2, Quaternion.identity);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Align To Direction");
                _alignToDirection.Direction.Value = handlePosition/2 - _alignToDirection.Transform.position;
                UndoHelper.RecordPrefabChanges(Owner);
            }
            
            RestoreHandlesMatrix();

            _alignToDirection.Transform.DrawAxis(_alignToDirection.AlignAxis);
            
            var center = _alignToDirection.Transform.position;
            HandlesUtil.DrawDottedLineThroughPoint(center, targetPosition, 5f);
            var axisDirection = _alignToDirection.AlignAxis.GetDirection(_alignToDirection.Transform);
            HandlesUtil.DrawRotation(center, axisDirection, _alignToDirection.Direction.Value, 3f);
            
            var style = SceneGUIStyles.LabelStyle;
            var label = new GUIContent("Align To");
            Handles.Label(targetPosition, label, style);
        }
    }
}
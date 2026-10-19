/* Obsolete
using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(TransformSmoothMoveToPosition))]
    public class TransformSmoothMoveToPositionSceneGUI : SceneGUIDrawer
    {
        private TransformSmoothMoveToPosition _smoothMoveTo;
        
        public TransformSmoothMoveToPositionSceneGUI(TransformSmoothMoveToPosition target) : base(target)
        {
            _smoothMoveTo = target;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            HalfSizeHandles();
            
            EditorGUI.BeginChangeCheck();
            
            var position = _smoothMoveTo.Position.Value;
            var newPosition = Handles.PositionHandle(position * 2, Quaternion.identity);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Smooth Move To Position");
                _smoothMoveTo.Position.Value = newPosition / 2;
                UndoHelper.RecordPrefabChanges(Owner);
            }
            
            RestoreHandlesMatrix();
            
            var style = SceneGUIStyles.LabelStyle;
            var label = new GUIContent("Move To");
            Handles.Label(position, label, style);

            var transformPosition = _smoothMoveTo.Transform.position;
            newPosition = MoveAxisHelper.Apply(_smoothMoveTo.Axis, transformPosition, newPosition/2);
            
            Handles.DrawDottedLine(transformPosition, newPosition, 5f);
        }
    }
}
*/
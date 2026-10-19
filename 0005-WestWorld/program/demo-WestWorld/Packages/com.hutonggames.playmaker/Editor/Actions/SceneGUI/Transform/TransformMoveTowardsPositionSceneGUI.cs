using HutongGames.Editor;
using HutongGames.PlayMaker.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(TransformMoveTowardsPosition))]
    public class TransformMoveTowardsPositionSceneGUI : SceneGUIDrawer
    {
        private TransformMoveTowardsPosition _moveTowards;
        
        public TransformMoveTowardsPositionSceneGUI(TransformMoveTowardsPosition target) : base(target)
        {
            _moveTowards = target;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            HalfSizeHandles();
            
            EditorGUI.BeginChangeCheck();
            
            var position = _moveTowards.Position.Value;
            var newPosition = Handles.PositionHandle(position * 2, Quaternion.identity);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Move Towards Position");
                _moveTowards.Position.Value = newPosition / 2;
                UndoHelper.RecordPrefabChanges(Owner);
            }
            
            RestoreHandlesMatrix();
            
            var style = SceneGUIStyles.LabelStyle;
            var label = new GUIContent("Move To");
            Handles.Label(position, label, style);

            var transform = _moveTowards.Transform;
            if (transform == null) return;

            var transformPosition = transform.position;
            newPosition = MoveAxisHelper.Apply(_moveTowards.Axis, transformPosition, newPosition/2);
            
            Handles.DrawDottedLine(transformPosition, newPosition, 5f);
        }
    }
}

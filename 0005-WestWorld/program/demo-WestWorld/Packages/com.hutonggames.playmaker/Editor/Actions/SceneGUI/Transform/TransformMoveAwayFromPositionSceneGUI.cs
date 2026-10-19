using HutongGames.Editor;
using HutongGames.PlayMaker.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(TransformMoveAwayFromPosition))]
    public class TransformMoveAwayFromPositionSceneGUI : SceneGUIDrawer
    {
        private readonly TransformMoveAwayFromPosition _moveAway;

        public TransformMoveAwayFromPositionSceneGUI(TransformMoveAwayFromPosition target) : base(target)
        {
            _moveAway = target;
        }

        public override void OnSceneGUI(SceneView sceneView)
        {
            if (_moveAway.Transform == null) return;

            HalfSizeHandles();

            EditorGUI.BeginChangeCheck();

            var position = _moveAway.Position.Value;
            var newPosition = Handles.PositionHandle(position * 2, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Move Away From Position");
                _moveAway.Position.Value = newPosition / 2;
                UndoHelper.RecordPrefabChanges(Owner);
            }

            RestoreHandlesMatrix();

            var style = SceneGUIStyles.LabelStyle;
            var label = new GUIContent("Move Away From");
            Handles.Label(position, label, style);

            var transformPosition = _moveAway.Transform.position;
            newPosition = MoveAxisHelper.Apply(_moveAway.Axis, transformPosition, newPosition / 2);

            Handles.DrawDottedLine(transformPosition, newPosition, 5f);
        }
    }
}

using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(TransformLookAtPoint))]
    public class TransformLookAtPointSceneGUI : SceneGUIDrawer
    {
        private TransformLookAtPoint _lookAtPoint;
        
        public TransformLookAtPointSceneGUI(TransformLookAtPoint target) : base(target)
        {
            _lookAtPoint = target;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            HalfSizeHandles();
            
            EditorGUI.BeginChangeCheck();

            var position = _lookAtPoint.WorldPosition.Value;
            var newPosition = Handles.PositionHandle(position * 2, Quaternion.identity);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Look At Point");
                _lookAtPoint.WorldPosition.Value = newPosition / 2;
                UndoHelper.RecordPrefabChanges(Owner);
            }
            
            RestoreHandlesMatrix();
            
            var style = SceneGUIStyles.LabelStyle;
            var label = new GUIContent("Look At");
            Handles.Label(position, label, style);
            
            Handles.DrawDottedLine(_lookAtPoint.Transform.position, position, 5f);
        }
    }
}
using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{    
    [PublicAPI]
    [SceneGUI(typeof(OffsetCurrentPositionBlock))]
    public class OffsetCurrentPositionBlockSceneGUI : SceneGUIDrawer
    {
        private readonly OffsetCurrentPositionBlock _offsetCurrentPosition;

        public OffsetCurrentPositionBlockSceneGUI(object target) : base(target)
        {
            _offsetCurrentPosition = target as OffsetCurrentPositionBlock;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            Handles.DrawOutline(new []{_offsetCurrentPosition.Action.TargetTransform.gameObject}, Color.yellow, 0.1f);
            
            HalfSizeHandles();
            
            EditorGUI.BeginChangeCheck();

            var rotation = _offsetCurrentPosition.InSpace == Space.Self
                ? _offsetCurrentPosition.Action.TargetTransform.rotation
                : Quaternion.identity;

            var newTargetPosition = Handles.PositionHandle(_offsetCurrentPosition.GetWorldPosition() * 2, rotation);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Offset Position Handle");
                _offsetCurrentPosition.SetWorldPosition(newTargetPosition / 2);
                UndoHelper.RecordPrefabChanges(Owner);
            }
            
            RestoreHandlesMatrix();
        }
    }
}
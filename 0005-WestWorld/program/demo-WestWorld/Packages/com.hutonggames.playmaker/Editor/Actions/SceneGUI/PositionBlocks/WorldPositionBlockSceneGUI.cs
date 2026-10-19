using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{    
    [PublicAPI]
    [SceneGUI(typeof(WorldPositionBlock))]
    public class WorldPositionBlockSceneGUI : SceneGUIDrawer
    {
        private readonly BasePositionBlock _worldPosition;

        public WorldPositionBlockSceneGUI(object target) : base(target)
        {
            _worldPosition = target as WorldPositionBlock;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            HalfSizeHandles();
            
            EditorGUI.BeginChangeCheck();
            
            var newTargetPosition = Handles.PositionHandle(_worldPosition.GetWorldPosition() * 2, Quaternion.identity);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit World Position");
                _worldPosition.SetWorldPosition(newTargetPosition / 2);
                UndoHelper.RecordPrefabChanges(Owner);
            }
            
            RestoreHandlesMatrix();
        }
    }
}
using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{    
    [PublicAPI]
    [SceneGUI(typeof(GameObjectOffsetPositionBlock))]
    public class GameObjectOffsetPositionBlockSceneGUI : SceneGUIDrawer
    {
        private readonly GameObjectOffsetPositionBlock _gameObjectOffsetPosition;
        
        public GameObjectOffsetPositionBlockSceneGUI(object target) : base(target)
        {
            _gameObjectOffsetPosition = target as GameObjectOffsetPositionBlock;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            Handles.DrawOutline(new []{_gameObjectOffsetPosition.GameObject.Value}, Color.yellow, 0.1f);
            
            HalfSizeHandles();
            
            EditorGUI.BeginChangeCheck();

            var rotation = _gameObjectOffsetPosition.InSpace == Space.Self
                ? _gameObjectOffsetPosition.GameObject.Value.transform.rotation
                : Quaternion.identity;

            var newTargetPosition = Handles.PositionHandle(_gameObjectOffsetPosition.GetWorldPosition() * 2, rotation);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit GameObject Offset Position Handle");
                _gameObjectOffsetPosition.SetWorldPosition(newTargetPosition / 2);
                UndoHelper.RecordPrefabChanges(Owner);
            }
            
            RestoreHandlesMatrix();
        }
    }
}
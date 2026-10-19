using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{    
    [PublicAPI]
    [SceneGUI(typeof(GameObjectPositionBlock))]
    public class GameObjectPositionBlockSceneGUI : SceneGUIDrawer
    {
        private readonly GameObjectPositionBlock _gameObjectPosition;

        public GameObjectPositionBlockSceneGUI(object target) : base(target)
        {
            _gameObjectPosition = target as GameObjectPositionBlock;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            Handles.DrawOutline(new []{_gameObjectPosition.GameObject.Value}, Color.yellow, 0.1f);
        }
    }
}
using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(DebugDrawLine))]
    public class DebugDrawLineSceneGUI : SceneGUIDrawer
    {
        private DebugDrawLine _debugDrawLine;

        public DebugDrawLineSceneGUI(DebugDrawLine target) : base(target)
        {
            _debugDrawLine = target;
        }
        
        public override bool IsValid => _debugDrawLine.IsEnabled && _debugDrawLine.CanExecute();
        
        public override void OnDrawGizmos()
        {
            if (!IsValid) return;
            
            var startPosition = _debugDrawLine.StartPosition;
            var endPosition = _debugDrawLine.EndPosition;

            using (new Handles.DrawingScope(_debugDrawLine.Color))
            {
                Handles.DrawLine(startPosition, endPosition);
            }
        }
    }
}
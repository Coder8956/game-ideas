using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(TweenPosition))]
    public class TweenPositionSceneGUI : SceneGUIDrawer
    {
        private TweenPosition _tweenPosition;

        public TweenPositionSceneGUI(TweenPosition target) : base(target)
        {
            _tweenPosition = target;
        }
        
        public override bool IsValid => _tweenPosition.IsEnabled && _tweenPosition.StartPosition.IsValid && _tweenPosition.EndPosition.IsValid;
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            if (!IsValid) return;
            
            var startPosition = _tweenPosition.GetStartPosition();
            var endPosition = _tweenPosition.GetEndPosition();

            var style = SceneGUIStyles.LabelStyle;
            var fromLabel = new GUIContent("From", "Tween Position");
            var toLabel = new GUIContent("To", "Tween Position");
            Handles.Label(startPosition, fromLabel, style);
            Handles.Label(endPosition, toLabel, style);
        }

        
        public override void OnDrawGizmos()
        {
            var startPosition = _tweenPosition.GetStartPosition();
            var endPosition = _tweenPosition.GetEndPosition();

            using (new Handles.DrawingScope(Color.yellow))
            {
                Handles.DrawLine(startPosition, endPosition);
            }
        }
    }
}
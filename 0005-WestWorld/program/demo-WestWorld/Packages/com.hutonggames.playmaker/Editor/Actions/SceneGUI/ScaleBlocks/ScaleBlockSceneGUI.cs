using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [UsedImplicitly]
    [SceneGUI(typeof(LocalScaleBlock))]
    public class LocalScaleBlockSceneGUI : ScaleBlockSceneGUI
    {
       public LocalScaleBlockSceneGUI(object target) : base(target){}
    }
    
    [UsedImplicitly]
    [SceneGUI(typeof(OffsetScaleBlock))]
    public class OffsetScaleBlockSceneGUI : ScaleBlockSceneGUI
    {
        public OffsetScaleBlockSceneGUI(object target) : base(target){}
    }
    
    public class ScaleBlockSceneGUI : SceneGUIDrawer
    {
        private readonly BaseScaleBlock _scaleBlock;

        protected ScaleBlockSceneGUI(object target) : base(target)
        {
            _scaleBlock = target as BaseScaleBlock;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            var target = _scaleBlock.Action.TargetTransform;
            if (target == null) return; // on playmode change?
            
            // TODO: Set color based on field
            // E.g., From = fromColor, To = toColor.
            
            var scale = _scaleBlock.GetScale();
            HandlesUtility.DrawLocalBounds(target, scale);
            
            /* Need a better solution than scale handles.
               - From and To handles draw on top of each other.
               - Doesn't stick to bounds.
            
            var position = target.position;
            var rotation = target.rotation;
            var handleSize = HandleUtility.GetHandleSize(position) * 0.75f;
            
            EditorGUI.BeginChangeCheck();
            
            var newScale = Handles.ScaleHandle(scale, position, rotation, handleSize);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordUndo(Owner, "Edit Scale");
                _scaleBlock.SetScale(newScale);
            }
            */
        }
    }
}
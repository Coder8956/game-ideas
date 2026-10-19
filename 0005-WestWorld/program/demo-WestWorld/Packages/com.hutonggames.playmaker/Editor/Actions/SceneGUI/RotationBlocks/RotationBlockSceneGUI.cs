using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [UsedImplicitly]
    [SceneGUI(typeof(RotationBlock))]
    public class RotationBlockSceneGUI : BaseRotationBlockSceneGUI
    {
       public RotationBlockSceneGUI(object target) : base(target){}
    }
    
    public class BaseRotationBlockSceneGUI : SceneGUIDrawer
    {
        private readonly BaseRotationBlock _rotationBlock;

        protected BaseRotationBlockSceneGUI(object target) : base(target)
        {
            _rotationBlock = target as BaseRotationBlock;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            var target = _rotationBlock.Action.TargetTransform;
            if (target == null) return; // on playmode change?
            
            // TODO: Set color based on field
            // E.g., From = fromColor, To = toColor.
            
            EditorGUI.BeginChangeCheck();
            
            var rotation = _rotationBlock.GetRotation();
            var position = target.position;
            var newRotation = Handles.RotationHandle(rotation, position);
            HandlesUtility.DrawRotatedBounds(target, newRotation);

            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Rotation");
                _rotationBlock.SetRotation(newRotation);
                UndoHelper.RecordPrefabChanges(Owner);
            }
        }
    }
}
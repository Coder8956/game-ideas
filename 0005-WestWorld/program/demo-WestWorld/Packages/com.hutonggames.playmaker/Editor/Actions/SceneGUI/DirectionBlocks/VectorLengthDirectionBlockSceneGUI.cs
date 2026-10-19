using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{    
    [PublicAPI]
    [SceneGUI(typeof(VectorLengthDirectionBlock))]
    public class VectorLengthDirectionBlockSceneGUI : SceneGUIDrawer
    {
        private readonly VectorLengthDirectionBlock _vectorDirection;

        public VectorLengthDirectionBlockSceneGUI(object target) : base(target)
        {
            _vectorDirection = target as VectorLengthDirectionBlock;
        }

        public override void OnSceneGUI(SceneView sceneView)
        {
            HalfSizeHandles();
            
            EditorGUI.BeginChangeCheck();
            
            var newTargetPosition = Handles.PositionHandle((_vectorDirection.StartPosition + _vectorDirection.GetDirection()) * 2, Quaternion.identity);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Direction");
                _vectorDirection.SetDirection(newTargetPosition/2);
                UndoHelper.RecordPrefabChanges(Owner);
            }
            
            RestoreHandlesMatrix();
        }
    }
}
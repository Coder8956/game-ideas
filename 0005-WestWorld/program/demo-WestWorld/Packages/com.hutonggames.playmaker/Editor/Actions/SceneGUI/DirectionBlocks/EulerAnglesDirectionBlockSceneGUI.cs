using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{    
    [PublicAPI]
    [SceneGUI(typeof(EulerAnglesDirectionBlock))]
    public class EulerAnglesDirectionBlockSceneGUI : SceneGUIDrawer
    {
        private readonly EulerAnglesDirectionBlock _anglesDirection;

        public EulerAnglesDirectionBlockSceneGUI(object target) : base(target)
        {
            _anglesDirection = target as EulerAnglesDirectionBlock;
        }

        public override void OnSceneGUI(SceneView sceneView)
        {
            EditorGUI.BeginChangeCheck();
            
            var newRotation = Handles.RotationHandle(Quaternion.Euler(_anglesDirection.Angles.Value), _anglesDirection.StartPosition);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Direction");
                _anglesDirection.SetDirection(_anglesDirection.StartPosition + newRotation * Vector3.forward * _anglesDirection.Length.Value);
                UndoHelper.RecordPrefabChanges(Owner);
            }
        }
    }
}
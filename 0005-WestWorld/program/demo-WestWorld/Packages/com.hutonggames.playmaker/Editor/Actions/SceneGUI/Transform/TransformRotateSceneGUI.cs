/*
using HutongGames.Editor;
using HutongGames.PlayMaker.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(TransformRotate))]
    public class TransformRotateSceneGUI : SceneGUIDrawer
    {
        private TransformRotate _rotate;
        
        public TransformRotateSceneGUI(TransformRotate target) : base(target)
        {
            _rotate = target;
        }
        
        public override void OnSceneGUI(SceneView sceneView)
        {
            EditorGUI.BeginChangeCheck();

            var rotation = _rotate.Eulers.Value;
            var position = _rotate.Transform.position;
            var newRotation = Handles.RotationHandle(Quaternion.Euler(rotation), position);
            HandlesUtility.DrawRotatedBounds(_rotate.Transform, newRotation);
            
            if (EditorGUI.EndChangeCheck())
            {
                UndoHelper.RecordObject(Owner, "Edit Rotation");
                _rotate.Eulers.Value = newRotation.eulerAngles;
            }
        }
    }
}*/
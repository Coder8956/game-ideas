using HutongGames.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Editor
{
    [PublicAPI]
    [SceneGUI(typeof(RandomGetPositionInSphere))]
    public class GetRandomPositionInSphereSceneGUI : SceneGUIDrawer
    {
        private RandomGetPositionInSphere _action;
        
        public GetRandomPositionInSphereSceneGUI(object target) : base(target)
        {
            _action = target as RandomGetPositionInSphere;
        }
        
        [PublicAPI]
        [SceneGUI(typeof(RandomGetPositionInSphere))]
        public override void OnSceneGUI(SceneView sceneView)
        {
            var center = _action.CenterAt?.GetWorldPosition() ?? _action.TargetPosition;
            var radius = _action.Size.GetScale().x;
            
            SetColor(new Color(1, 1, 1, 0.25f));
            Handles.DrawWireDisc(center, Vector3.up, radius);
            Handles.DrawWireDisc(center, Vector3.left, radius);
            Handles.DrawWireDisc(center, Vector3.forward, radius);
            RestoreColor();

            var cameraTransform = sceneView.camera.transform;
            var lookAt = Quaternion.LookRotation(cameraTransform.forward, cameraTransform.up);
            Handles.DrawWireDisc(center, lookAt * Vector3.forward, radius);
            
            Handles.Label(center, "TEST");
        }
    }
}
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Checks if a Transform's bounds are visible to a Camera.")]
    [HelpURL("actions/transform-actions/measurement-actions/")]
    public class TransformCheckIsVisible : BaseTrueFalseAction
    {
        [Tooltip("The Transform to check.")]
        [SerializeField]
        private TransformVar _transform;

        [Tooltip("The size of the bounds.")]
        [SerializeField]
        private Vector3Var _size;
        
        [Tooltip("The camera to check against. Uses MainCamera if not specified.")]
        [SerializeField, OptionalField]
        private CameraVar _camera;
        
        public override bool CanExecute() => CheckParameters(_transform, _size);
        
        protected override bool Test()
        {
            var camera = _camera.Value.IsUnityNull() ? Camera.main : _camera.Value;
            if (camera == null) return false;
            
            var bounds = new Bounds(_transform.Value.position, _size.Value);
            var frustumPlanes = GeometryUtility.CalculateFrustumPlanes(camera);
            return GeometryUtility.TestPlanesAABB(frustumPlanes, bounds);
        }

        protected override string TrueSummary => "{_transform} bounds {_size} is visible" + CameraSummary;
        protected override string FalseSummary => "{_transform} bounds {_size} is not visible" + CameraSummary;

        private string CameraSummary => _camera.Value.IsUnityNull() ? "" : " to {_camera}";
        
        #if UNITY_EDITOR
        
        public override bool HasGizmos => true;
		
        public override void OnDrawGizmosSelected()
        {
            var transform = _transform.Value;
            if (transform == null) return;
            
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, _size.Value);
        }
        
        #endif
    }
}
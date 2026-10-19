using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Clamps a Transform's 2D position. By default, this is done in LateUpdate.")]
    [HelpURL("actions/transform-actions/transform-clamp-actions/")]
    public class TransformClampPosition2D : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;
        
        [Tooltip("The Transform to clamp.")]
        [SerializeField]
        private TransformVar _transform;
        
        [Tooltip("World or local space.")]
        [SerializeField]
        private SpaceVar _inSpace;

        [Tooltip("Clamp X position to be greater than this value.")]
        [SerializeField]
        private FloatVar _xMin;

        [Tooltip("Clamp X position to be less than this value.")]
        [SerializeField]
        private FloatVar _xMax;

        [Tooltip("Clamp Y position to be greater than this value.")]
        [SerializeField]
        private FloatVar _yMin;
        
        [Tooltip("Clamp Y position to be less than this value.")]
        [SerializeField]
        private FloatVar _yMax;
        
        private Transform _thisTransform;
        
        public override bool CanExecute() => CheckParameters(_transform, _inSpace, _xMin, _xMax, _yMin, _yMax);

        public override void Execute()
        {
            _thisTransform = _transform.Value;
            if(_thisTransform == null) return;
            
            var position = _inSpace.Value == Space.World ?  _thisTransform.position : _thisTransform.localPosition;
            position.x = Mathf.Clamp(position.x, _xMin.Value, _xMax.Value);
            position.y = Mathf.Clamp(position.y, _yMin.Value, _yMax.Value);
            if (_inSpace.Value == Space.World)
            {
                _thisTransform.position = position;
            }
            else
            {
                _thisTransform.localPosition = position;
            }
        }
        
        public override string GetSummary() => 
            "Clamp {_transform} X: {_xMin} to {_xMax} Y: {_yMin} to {_yMax} ({_inSpace})";
    }
}
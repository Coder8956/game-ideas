using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Clamps a Transform's X position. By default, this is done in LateUpdate.")]
    [HelpURL("actions/transform-actions/transform-clamp-actions/")]
    public class TransformClampPositionX : BaseAction
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
        
        private Transform _thisTransform;
        
        public override bool CanExecute() => CheckParameters(_transform, _inSpace, _xMin, _xMax);

        public override void Execute()
        {
            _thisTransform = _transform.Value;
            if (_thisTransform == null) return;
            
            var position = _inSpace.Value == Space.World ?  _thisTransform.position : _thisTransform.localPosition;
            position.x = Mathf.Clamp(position.x, _xMin.Value, _xMax.Value);
            if (_inSpace.Value == Space.World)
            {
                _thisTransform.position = position;
            }
            else
            {
                _thisTransform.localPosition = position;
            }
        }
        
        public override string GetSummary() => "Clamp {_transform} X: {_xMin} to {_xMax} ({_inSpace})";
    }
}
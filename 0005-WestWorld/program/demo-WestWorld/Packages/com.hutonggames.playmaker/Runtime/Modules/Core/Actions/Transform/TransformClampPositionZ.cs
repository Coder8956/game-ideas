using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Clamps a Transform's Z position. By default, this is done in LateUpdate.")]
    [HelpURL("actions/transform-actions/transform-clamp-actions/")]
    public class TransformClampPositionZ : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;
        
        [Tooltip("The Transform to clamp.")]
        [SerializeField]
        private TransformVar _transform;
        
        [Tooltip("World or local space.")]
        [SerializeField]
        private SpaceVar _inSpace;
        
        [Tooltip("Clamp Z position to be greater than this value.")]
        [SerializeField]
        private FloatVar _zMin;
        
        [Tooltip("Clamp Z position to be less than this value.")]
        [SerializeField]
        private FloatVar _zMax;
        
        private Transform _thisTransform;
        
        public override bool CanExecute() => CheckParameters(_transform, _inSpace, _zMin, _zMax);

        public override void Execute()
        {
            _thisTransform = _transform.Value;
            if (_thisTransform == null) return;
            
            var position = _inSpace.Value == Space.World ?  _thisTransform.position : _thisTransform.localPosition;
            position.z = Mathf.Clamp(position.z, _zMin.Value, _zMax.Value);
            if (_inSpace.Value == Space.World)
            {
                _thisTransform.position = position;
            }
            else
            {
                _thisTransform.localPosition = position;
            }
        }
        
        public override string GetSummary() => "Clamp {_transform} Z: {_zMin} to {_zMax} ({_inSpace})";
    }
}
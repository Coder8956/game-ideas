using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [HasSceneGUI]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Clamps a Transform's rotation around a local axis. By default, this is done in LateUpdate." +
                       "\nNOTE: The range is calculated relative to the parent transform, or world space if the Transform has no parent.")]
    [HelpURL("actions/transform-actions/transform-clamp-actions/")]
    public class TransformClampRotation : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.LateUpdate | UpdateMode.EveryFrame;
        
        public Transform Transform => _transform.Value;
        public RotationAxis Axis => _rotationAxis.Value;
        public FloatVar MinAngle => _minAngle;
        public FloatVar MaxAngle => _maxAngle;
        
        
        [Tooltip("The Transform to clamp.")]
        [SerializeField]
        private TransformVar _transform;
        
        [Tooltip("The local axis to constraint the rotation around.")]
        [SerializeField]
        private RotationAxisVar _rotationAxis;

        [Tooltip("The minimum angle allowed.")]
        [SerializeField, DefaultValue(-45f)]
        private FloatVar _minAngle;

        [Tooltip("The maximum angle allowed.")]
        [SerializeField, DefaultValue(45f)]
        private FloatVar _maxAngle;
        
        private float _angleFromMin;
        private float _angleFromMax;

        private Transform _thisTransform;
        private Vector3 _rotateAround;
        private Quaternion _minQuaternion;
        private Quaternion _maxQuaternion;
        private float _range;

        private RotationAxis _axis;
        private int _axisIndex;
        private Quaternion _axisRotation;
        
        public override bool CanExecute() => CheckParameters(_transform, _rotationAxis, _minAngle, _maxAngle);

        public override void OnStart()
        {
            _thisTransform = _transform.Value;
            if (_thisTransform == null) return;

            _axis = _rotationAxis.Value;
            _axisIndex = (int)_axis;
            
            // Set the axis that we will rotate around
            _rotateAround = _axis switch
            {
                RotationAxis.X => Vector3.right,
                RotationAxis.Y => Vector3.up,
                RotationAxis.Z => Vector3.forward,
                _ => _rotateAround
            };

            _axisRotation = Quaternion.AngleAxis( 0, _rotateAround );
            _minQuaternion = _axisRotation * Quaternion.AngleAxis( _minAngle.Value, _rotateAround );
            _maxQuaternion = _axisRotation * Quaternion.AngleAxis( _maxAngle.Value, _rotateAround );
            _range = _maxAngle.Value - _minAngle.Value;
        }

        public override void Execute()
        {
            _thisTransform = _transform.Value;
            
            _axisRotation = Quaternion.AngleAxis( _thisTransform.localRotation.eulerAngles[_axisIndex], _rotateAround );

            _angleFromMin = Quaternion.Angle( _axisRotation, _minQuaternion );
            _angleFromMax = Quaternion.Angle( _axisRotation, _maxQuaternion );
			
            if ( _angleFromMin <= _range && _angleFromMax <= _range )
                return; // within range

            // Keep the current rotations around other axes and only
            // clamp the axis that is out of range.
            
            var euler =  _thisTransform.localRotation.eulerAngles;
            if (_angleFromMin > _angleFromMax)
            {
                euler[ _axisIndex ] = _maxQuaternion.eulerAngles[_axisIndex];
            }
            else
            {
                euler[ _axisIndex ] = _minQuaternion.eulerAngles[_axisIndex];
            }
				
            _thisTransform.localEulerAngles = euler;
        }
        
        public override string GetSummary() => 
            "Clamp {_transform} Rotation around {_rotationAxis} min: {_minAngle} max: {_maxAngle}";
    }
}
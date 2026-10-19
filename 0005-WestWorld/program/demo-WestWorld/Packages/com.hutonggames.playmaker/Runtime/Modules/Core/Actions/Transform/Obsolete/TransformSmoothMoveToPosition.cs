using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [Obsolete("Use TransformMoveTowardsPosition instead.")]
    [PublicAPI]
    [HasSceneGUI]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformMove")]
    [ActionDescription("Smoothly moves the Transform towards a position. Uses SmoothDamp to smooth the motion. " +
                       "This works well if the target position is changing.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Vector3.SmoothDamp.html")]
    
    public class TransformSmoothMoveToPosition : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        public Transform Transform => _transform.Value;
        public Vector3Var Position => _position;
        public MoveAxis Axis => _axis.Value;
        
        [OwnerDefaultValue]
        [Tooltip("The Transform to move.")]
        [SerializeField]
        private TransformVar _transform;
        
        [Tooltip("The Position to move towards.")]
        [SerializeField]
        private Vector3Var _position;

        [Tooltip("The axis to move along.")]
        [SerializeField]
        private MoveAxisVar _axis;
        
        [Tooltip("Approximately the time it will take to reach the target. A smaller value will reach the target faster.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _smoothTime;
        
        //[HasFloatSlider(0, 20)]
        [Tooltip("The maximum movement speed (Unity units per second).")]
        [SerializeField, DefaultValue(100f)]
        private FloatVar _maxSpeed;

        private SmoothMoveToHelper _smoothMoveTo;
        
        public override bool CanExecute() => CheckParameters(_transform, _position, _smoothTime, _maxSpeed);

        public override void OnStart()
        {
            _smoothMoveTo = new SmoothMoveToHelper();
        }

        public override void Execute()
        {
            var moveTransform = _transform.Value;
            if (moveTransform == null) return;
            
            moveTransform.position = _smoothMoveTo.Update(_axis.Value, moveTransform.position, _position.Value, _smoothTime.Value, _maxSpeed.Value);
        }

        public override string GetSummary() => "Smooth Move {_transform} To {_position} Time {_smoothTime} MaxSpeed {_maxSpeed}/s.";
    }
}
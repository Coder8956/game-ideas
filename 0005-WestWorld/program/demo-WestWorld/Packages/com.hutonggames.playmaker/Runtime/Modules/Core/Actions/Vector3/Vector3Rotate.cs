using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Vector3)]
    [ActionDescription("Rotate a Vector3 by a Quaternion (result = rotation * vector).")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Quaternion-operator_multiply.html")]
    public sealed class Vector3Rotate : BaseAction
    {
        [Tooltip("The Vector3 to rotate.")] 
        [SerializeField]
        private Vector3Var _vector3;
        
        [Tooltip("The Quaternion (rotation).")] 
        [SerializeField]
        private QuaternionRef _rotation;
        
        [Tooltip("Store the rotated Vector3.")] 
        [SerializeField] [WriteOnly]
        private Vector3Ref _result;

        public override bool CanExecute() => CheckParameters(_rotation, _vector3, _result);

        public override void Execute() => _result.Value = _rotation.Value * _vector3.Value;

        public override string GetSummary() => "{_vector3} rotate {_rotation} -> {_result}";
    }
}
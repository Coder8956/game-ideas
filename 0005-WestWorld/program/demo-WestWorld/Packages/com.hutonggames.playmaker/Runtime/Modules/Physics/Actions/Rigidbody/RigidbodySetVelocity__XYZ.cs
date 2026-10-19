using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Rigidbody)]
    [ConvertibleGroup("RigidbodySetVelocity")]
    [ActionDescription("Set the velocity of the rigidbody using individual x, y, z components in either world or local space. It represents the rate of change of Rigidbody position.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
    public sealed class RigidbodySetVelocity_XYZ : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
        
        [Tooltip("The Rigidbody")]
        [SerializeField]
        private RigidbodyVar _rigidbody;
        
        [Tooltip("Set X Velocity")]
        [SerializeField]
        private FloatVar _setXVelocity;
        
        [Tooltip("Set Y Velocity")]
        [SerializeField]
        private FloatVar _setYVelocity;
        
        [Tooltip("Set Z Velocity")]
        [SerializeField]
        private FloatVar _setZVelocity;

        [Tooltip("Select if the velocity is in world or local space")]
        [SerializeField, DefaultValue(Space.World)]
        private SpaceVar _space;
        
        public override bool CanExecute()
        {
            return CheckParameters(_rigidbody, _setXVelocity, _setYVelocity, _setZVelocity);
        }
        
        public override void Execute()
        {
            var velocity = new Vector3(_setXVelocity.Value, _setYVelocity.Value, _setZVelocity.Value);
            
            if (_space.Value == Space.Self)
            {
                velocity = _rigidbody.Value.transform.TransformDirection(velocity);
            }

#if UNITY_6000_0_OR_NEWER
            _rigidbody.Value.linearVelocity = velocity;
#else
            _rigidbody.Value.velocity = velocity;
#endif
        }
        
        public override string GetSummary()
        {
            return "Set {_rigidbody} velocity to ({_setXVelocity}, {_setYVelocity}, {_setZVelocity})" +
                   (_space.IsNotDefault(Space.World) ? " (local)" : string.Empty);
        }
    }
}

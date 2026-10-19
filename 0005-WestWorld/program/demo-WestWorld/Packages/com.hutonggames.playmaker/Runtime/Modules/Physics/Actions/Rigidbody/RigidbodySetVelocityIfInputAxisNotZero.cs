
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameplayMovementRigidbody)]
    [ConvertibleGroup("RigidbodySetVelocity")]
    [ActionDescription("Set the rigidbody velocity on any axis where the input magnitude is not zero in either world or local space." +
                      "\n\nThis is useful when you want to keep the existing velocity when there is no input.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
    public sealed class RigidbodySetVelocityIfInputAxisNotZero : BaseAction
    {
        [Tooltip("The Rigidbody")]
        [SerializeField]
        private RigidbodyVar _rigidbody;
        
        [Tooltip("Set Rigidbody Velocity")]
        [SerializeField]
        private Vector3Var _input;

        [Tooltip("A magnitude less than this is considered 'zero'")]
        [SerializeField]
        private FloatVar _threshold;

        [Tooltip("Select if the velocity is in world or local space")]
        [SerializeField, DefaultValue(Space.World)]
        private SpaceVar _space;
        
        public override bool CanExecute() => CheckParameters(_rigidbody, _input, _threshold);

        public override void Execute()
        {
#if UNITY_6000_0_OR_NEWER
            var velocity = _rigidbody.Value.linearVelocity;
#else
            var velocity = _rigidbody.Value.velocity;
#endif
            
            if (_space.Value == Space.World)
            {
                if (Mathf.Abs(_input.Value.x) > _threshold.Value)
                {
                    velocity.x = _input.Value.x;
                }
                if (Mathf.Abs(_input.Value.y) > _threshold.Value)
                {
                    velocity.y = _input.Value.y;
                }
                if (Mathf.Abs(_input.Value.z) > _threshold.Value)
                {
                    velocity.z = _input.Value.z;
                }
            }
            else
            {
                // Convert current world velocity to local space
                var localVelocity = _rigidbody.Value.transform.InverseTransformDirection(velocity);
                var localInput = _input.Value;

                if (Mathf.Abs(localInput.x) > _threshold.Value)
                {
                    localVelocity.x = localInput.x;
                }
                if (Mathf.Abs(localInput.y) > _threshold.Value)
                {
                    localVelocity.y = localInput.y;
                }
                if (Mathf.Abs(localInput.z) > _threshold.Value)
                {
                    localVelocity.z = localInput.z;
                }

                // Convert back to world space
                velocity = _rigidbody.Value.transform.TransformDirection(localVelocity);
            }
        
#if UNITY_6000_0_OR_NEWER
            _rigidbody.Value.linearVelocity = velocity;
#else
            _rigidbody.Value.velocity = velocity;
#endif
        }
        
        public override string GetSummary() => "Set {_rigidbody} velocity to {_input} on axes where input > {_threshold}" +
                                             (_space.IsNotDefault(Space.World) ? " (local)" : string.Empty);
    }
}

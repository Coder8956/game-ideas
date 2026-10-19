using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameplayMovementRigidbody)]
    [ConvertibleGroup("RigidbodySetVelocity")]
    [ActionDescription("Set the rigidbody velocity in either world or local space if the input magnitude is not zero." +
                       "\n\nThis is useful when you want to keep the existing velocity when there is no input.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
    public sealed class RigidbodySetVelocityIfInputNotZero : BaseAction
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
            if (_input.Value.magnitude < _threshold.Value) return;

            var velocity = _input.Value;
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
        
        public override string GetSummary() => "Set {_rigidbody} velocity to {_input} if input > {_threshold}" +
                                               (_space.IsNotDefault(Space.World) ? " (local)" : string.Empty);
    }
}

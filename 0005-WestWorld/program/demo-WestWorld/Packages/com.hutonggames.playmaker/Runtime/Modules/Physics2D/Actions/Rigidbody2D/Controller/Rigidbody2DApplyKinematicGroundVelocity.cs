using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Rigidbody2DController)]
    [ActionDescription("Checks if the supplied ground Rigidbody2D is kinematic and apply it's velocity.")]
    [MovedFrom(false,null,null,"Rigidbody2DOnGround")]
    public class Rigidbody2DApplyKinematicGroundVelocity : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;

        [Tooltip("The Rigidbody to control.")]
        [SerializeField] 
        private Rigidbody2DVar _rigidbody;
        
        [Tooltip("The ground Rigidbody2D, typically returned from a GroundCheck action.")]
        [SerializeField] 
        private Rigidbody2DRef _ground;

        [Tooltip("Gravity multiplier to apply to gravity when on kinematic ground. This can be used to make the character stick to fast moving platforms.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _gravityMultiplier;

        private Rigidbody2DKinematicVelocityHelper _helper = new ();

        public override bool CanExecute() => CheckParameters(_rigidbody) && _ground.IsAssigned;
        
        private float _originalGravityScale;
        
        public override void OnStart()
        {
            _originalGravityScale = _rigidbody.Value.gravityScale;
            _helper.GetVelocity(_ground.Value);
        }

        public override void OnStop()
        {
            _rigidbody.Value.gravityScale = _originalGravityScale;
        }

        public override void Execute()
        {
            var rb = _rigidbody.Value;
            var groundVelocity = _helper.GetVelocity(_ground.Value);

            if (_ground.Value)
            {
                rb.gravityScale = _originalGravityScale * _gravityMultiplier.Value;
            }
            else
            {
                rb.gravityScale = _originalGravityScale;
            }
            
#if UNITY_6000_0_OR_NEWER
            var velocity = rb.linearVelocity;
            rb.linearVelocity = new Vector2(velocity.x + groundVelocity.x, velocity.y);
#else
            var velocity = rb.velocity;
            rb.velocity = new Vector2(velocity.x + groundVelocity.x, velocity.y);
#endif
        }

        public override string GetSummary() => "{_rigidbody} apply kinematic {_ground} velocity";
    }
}
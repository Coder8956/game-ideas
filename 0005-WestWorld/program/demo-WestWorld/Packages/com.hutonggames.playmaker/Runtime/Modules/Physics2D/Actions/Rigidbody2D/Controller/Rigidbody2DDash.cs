using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Rigidbody2DController)]
    [ActionDescription("Dash in facing direction. Generally used for a short burst of speed.")]
    public class Rigidbody2DDash : BaseAction
    {
        public override bool CanFinish => true;
        
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;

        [Tooltip("The Rigidbody to control.")]
        [SerializeField] private Rigidbody2DVar _rigidbody;
        
        [Tooltip("The speed to apply when dashing.")]
        [SerializeField, DefaultValue(40f)] 
        private FloatVar _dashSpeed;

        [Tooltip("How long the dash lasts in seconds.")]
        [SerializeField, DefaultValue(.4f)] 
        private FloatVar _dashDuration;
        
        [OptionalField]
        [Tooltip("Event sent when the dash ends.")]
        [SerializeField]
        private EventRef _finishedEvent;

        private float _originalGravityScale;
        private float _originalSpeed;
        private float _timeElapsed;
        private float _startTime;
        
        private float CurrentTime => InFixedUpdate ? Time.fixedTime : Time.time;
        
        public override bool CanExecute() => CheckParameters(_rigidbody, _dashSpeed, _dashDuration);

        public override void OnStart()
        {
#if UNITY_6000_0_OR_NEWER
            _originalSpeed = _rigidbody.Value.linearVelocity.x;
#else
            _originalSpeed = _rigidbody.Value.velocity.x;
#endif
            _originalGravityScale = _rigidbody.Value.gravityScale;
            _rigidbody.Value.gravityScale = 0;
            _timeElapsed = 0;
            _startTime = CurrentTime;
        }
        
        public override void OnStop()
        {
            _rigidbody.Value.gravityScale = _originalGravityScale;
        }

        public override void Execute()
        {
            var rigidbody = _rigidbody.Value;
            var dashSpeed = _dashSpeed.Value * Mathf.Sign(rigidbody.transform.localScale.x);
            
#if UNITY_6000_0_OR_NEWER
            rigidbody.linearVelocity = new Vector2(dashSpeed, 0);
#else
            rigidbody.velocity = new Vector2(dashSpeed, 0);
#endif
            _timeElapsed = Mathf.Max(0f, CurrentTime - _startTime);
            if (_timeElapsed >= _dashDuration.Value)
            {
                Finish();
                SendEvent(_finishedEvent);
            }
        }
        
        public override string GetSummary() => 
            "Dash {_rigidbody} Speed: {_dashSpeed} " + 
            (_finishedEvent.IsSet ? $" Finished {_finishedEvent}" : "");
    }
}

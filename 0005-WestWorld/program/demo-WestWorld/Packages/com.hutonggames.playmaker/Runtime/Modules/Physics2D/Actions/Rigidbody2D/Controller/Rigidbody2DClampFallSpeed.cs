using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Rigidbody2DController)]
    [ActionDescription("Clamp the fall speed of a Rigidbody2D.")]
    public class Rigidbody2DClampFallSpeed : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;

        [Tooltip("The Rigidbody to control.")]
        [SerializeField] private Rigidbody2DVar _rigidbody;
        
        [Tooltip("The maximum fall speed. This should be a negative value.")]
        [SerializeField, DefaultValue(-10f)] 
        private FloatVar _maxFallSpeed;
        
        public override bool CanExecute() => CheckParameters(_rigidbody, _maxFallSpeed);
        
        public override void Execute()
        {
            var rb = _rigidbody.Value;
#if UNITY_6000_0_OR_NEWER
            if (rb.linearVelocity.y < _maxFallSpeed.Value)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, _maxFallSpeed.Value);
            }
#else
            if (rb.velocity.y < _maxFallSpeed.Value)
            {
                rb.velocity = new Vector2(rb.velocity.x, _maxFallSpeed.Value);
            }
#endif
        }

        public override string GetSummary() => "Clamp {_rigidbody} Fall Speed: {_maxFallSpeed}";
    }
}
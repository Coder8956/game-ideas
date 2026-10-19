using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI, Serializable]
    [ActionCategory(Category.Rigidbody2DController)]
    [ActionDescription("Multiplies the effect of gravity when falling.")]
    public class Rigidbody2DMultiplyFallSpeed : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;

        [Tooltip("The Rigidbody to control.")]
        [SerializeField] private Rigidbody2DVar _rigidbody;
        
        [Tooltip("Multiplies the effect of gravity when falling. For example, a value of 2 will double gravity while falling." +
                 "This tweak can make jumping feel less 'floaty'." +
                 "\n\nNOTE: This uses the Gravity Scale property of the Rigidbody2D. " +
                 "So if the Gravity Scale is 4 and the Fall Multiplier is 2, the effective gravity will be 8.")]
        [SerializeField, DefaultValue(2f)] 
        private FloatVar _fallMultiplier;
        
        public override bool CanExecute() => CheckParameters(_rigidbody, _fallMultiplier);
        
        public override void Execute()
        {
            var rb = _rigidbody.Value;
#if UNITY_6000_0_OR_NEWER
            if (rb.linearVelocity.y >= 0) return;
            var scale = rb.gravityScale;
            rb.linearVelocity += Vector2.up * (Physics2D.gravity.y * Time.deltaTime * (scale * _fallMultiplier.Value - 1));
#else
            if (rb.velocity.y >= 0) return;
            var scale = rb.gravityScale;
            rb.velocity += Vector2.up * (Physics2D.gravity.y * Time.deltaTime * (scale * _fallMultiplier.Value - 1));
#endif
        }

        public override string GetSummary() => "Multiply {_rigidbody} fall speed by {_fallMultiplier}";
    }
}
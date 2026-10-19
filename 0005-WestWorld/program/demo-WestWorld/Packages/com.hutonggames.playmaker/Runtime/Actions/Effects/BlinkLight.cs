using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Blink)]
    [ActionDescription("Turns a Light on and off in a blink pattern.")]
    public class BlinkLight : BaseBlinkAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Light to turn on/off.")]
        public LightVar Light;

        private bool _originalEnabled;

        public override bool CanExecute() => CheckParameters(Light);

        protected override string Target => nameof(Light);

        protected override void CaptureOriginalState()
        {
            if (Light.Value != null)
                _originalEnabled = Light.Value.enabled;
        }

        protected override void RestoreOriginalState()
        {
            if (Light.Value != null)
                Light.Value.enabled = _originalEnabled;
        }
        
        protected override void Apply(bool on)
        {
            if (Light.Value != null)
                Light.Value.enabled = on;
        }
    }
}

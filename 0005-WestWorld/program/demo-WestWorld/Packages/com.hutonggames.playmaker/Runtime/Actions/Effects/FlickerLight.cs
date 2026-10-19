using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Flicker)]
    [ActionDescription("Randomly flickers a Light on/off.")]
    public class FlickerLight : BaseFlickerAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Light to flicker on/off.")]
        public LightVar Light;

        private bool _originalEnabled;

        public override bool CanExecute() => CheckParameters(Light);

        protected override string Target => nameof(Light);

        protected override void CaptureOriginalState()
        {
            _originalEnabled = Light.Value.enabled;
        }

        protected override void RestoreOriginalState()
        {
            Light.Value.enabled = _originalEnabled;
        }
        
        protected override void Apply(bool on) => Light.Value.enabled = on;
    }
}

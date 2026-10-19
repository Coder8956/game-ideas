using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Fade)]
    [ActionDescription("Fades a Light out by animating its intensity down to 0.")]
    public class FadeOutLight : BaseFadeAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Light to fade out.")]
        public LightVar Light;

        [DefaultValue(true)]
        [Tooltip("Disable the Light when the fade completes.")]
        public BoolVar DisableOnComplete;

        private float _fromIntensity;

        public override bool CanExecute() => CheckParameters(Light);

        public override void OnStart()
        {
            _fromIntensity = Light.Value.intensity;
            base.OnStart();
        }

        protected override void Apply(float t)
        {
            Light.Value.intensity = Mathf.Lerp(_fromIntensity, 0f, t);

            // If Duration is tiny, we may complete in OnStart/first tick.
            if (t >= 1f && DisableOnComplete.Value)
                Light.Value.enabled = false;
        }

        public override string GetSummary() => GetFadeOutSummary(nameof(Light));
    }
}
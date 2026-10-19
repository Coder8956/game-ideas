using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Fade)]
    [ActionDescription("Fades a Light in by animating its intensity from 0 to its starting intensity.")]
    public class FadeInLight : BaseFadeAction
    {
        [Tooltip("The Light to fade in.")]
        public LightVar Light;

        private float _toIntensity;

        public override bool CanExecute() => CheckParameters(Light);

        public override void OnStart()
        {
            _toIntensity = Light.Value.intensity;

            // Ensure it's visible during fade.
            Light.Value.enabled = true;
            Light.Value.intensity = 0f;

            base.OnStart();
        }

        protected override void Apply(float t)
        {
            Light.Value.intensity = Mathf.Lerp(0f, _toIntensity, t);
        }
        
        public override string GetSummary() => GetFadeInSummary(nameof(Light));
    }
}
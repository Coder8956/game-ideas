using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Blink)]
    [ActionDescription("Turns a Renderer on and off in a blink pattern.")]
    [MovedFrom(true, null, null, "RendererBlink")]
    public class BlinkRenderer : BaseBlinkAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Renderer to turn on/off.")]
        public RendererVar Renderer;

        private bool _originalEnabled;

        public override bool CanExecute() => CheckParameters(Renderer);

        protected override string Target => nameof(Renderer);

        protected override void CaptureOriginalState()
        {
            if (Renderer.Value != null)
                _originalEnabled = Renderer.Value.enabled;
        }

        protected override void RestoreOriginalState()
        {
            if (Renderer.Value != null)
                Renderer.Value.enabled = _originalEnabled;
        }
        
        protected override void Apply(bool on)
        {
            if (Renderer.Value != null)
                Renderer.Value.enabled = on;
        }
    }
}

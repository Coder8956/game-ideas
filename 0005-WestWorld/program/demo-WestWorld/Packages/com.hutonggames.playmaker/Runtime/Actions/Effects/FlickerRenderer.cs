using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Flicker)]
    [ActionDescription("Randomly flickers a Renderer on/off.")]
    public class FlickerRenderer : BaseFlickerAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Renderer to flicker on/off.")]
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

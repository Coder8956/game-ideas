using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Flicker)]
    [ActionDescription("Randomly flickers a Canvas Group on/off by toggling its alpha.")]
    public class FlickerCanvasGroup : BaseFlickerAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Canvas Group to flicker on/off.")]
        public CanvasGroupVar CanvasGroup;

        private float _originalAlpha;

        public override bool CanExecute() => CheckParameters(CanvasGroup);

        protected override void CaptureOriginalState()
        {
            if (CanvasGroup.Value != null)
                _originalAlpha = CanvasGroup.Value.alpha;
        }

        protected override void RestoreOriginalState()
        {
            if (CanvasGroup.Value != null)
                CanvasGroup.Value.alpha = _originalAlpha;
        }

        protected override string Target => nameof(CanvasGroup);

        protected override void Apply(bool on)
        {
            if (CanvasGroup.Value != null)
                CanvasGroup.Value.alpha = on ? _originalAlpha : 0f;
        }
    }
}

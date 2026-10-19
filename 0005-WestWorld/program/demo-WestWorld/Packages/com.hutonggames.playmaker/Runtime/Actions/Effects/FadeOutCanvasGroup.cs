using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Fade)]
    [ActionDescription("Fades a Canvas Group out by animating its alpha from the current alpha to 0.")]
    public class FadeOutCanvasGroup : BaseFadeAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Canvas Group to fade out.")]
        public CanvasGroupVar CanvasGroup;

        private float _fromAlpha;

        public override bool CanExecute() => CheckParameters(CanvasGroup);

        public override void OnStart()
        {
            _fromAlpha = CanvasGroup.Value.alpha;
            base.OnStart();
        }

        protected override void Apply(float t)
        {
            CanvasGroup.Value.alpha = Mathf.Lerp(_fromAlpha, 0f, t);
        }
        
        public override string GetSummary() => GetFadeOutSummary(nameof(CanvasGroup));
    }
}
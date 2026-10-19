using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Fade)]
    [ActionDescription("Fades a Canvas Group in by animating its alpha from 0 to the current alpha.")]
    public class FadeInCanvasGroup : BaseFadeAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Canvas Group to fade in.")]
        public CanvasGroupVar CanvasGroup;

        float _toAlpha;

        public override bool CanExecute() => CheckParameters(CanvasGroup);

        public override void OnStart()
        {
            _toAlpha = CanvasGroup.Value.alpha;
            CanvasGroup.Value.alpha = 0f;

            base.OnStart();
        }

        protected override void Apply(float t)
        {
            CanvasGroup.Value.alpha = Mathf.Lerp(0f, _toAlpha, t);
        }
        
        public override string GetSummary() => GetFadeInSummary(nameof(CanvasGroup));
    }
}
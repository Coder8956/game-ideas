using System;
using HutongGames.PlayMaker.Actions.UI;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Fade)]
    [ActionDescription("Fades a UI Graphic in by animating its alpha from 0 to the current alpha.")]
    public class FadeInGraphic : BaseFadeAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Graphic to fade in.")]
        public GraphicVar Graphic;

        private float _toAlpha;

        public override bool CanExecute() => CheckParameters(Graphic);

        public override void OnStart()
        {
            var g = Graphic.Value;

            // Capture the intended final alpha (as authored / currently set).
            _toAlpha = g.color.a;

            // Start hidden.
            var c = g.color;
            c.a = 0f;
            g.color = c;

            base.OnStart();
        }

        protected override void Apply(float t)
        {
            var g = Graphic.Value;
            var c = g.color;
            c.a = Mathf.Lerp(0f, _toAlpha, t);
            g.color = c;
        }
        
        public override string GetSummary() => GetFadeInSummary(nameof(Graphic));
    }
}
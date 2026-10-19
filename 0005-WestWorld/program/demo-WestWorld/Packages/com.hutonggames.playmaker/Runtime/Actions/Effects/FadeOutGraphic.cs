using System;
using HutongGames.PlayMaker.Actions.UI;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Fade)]
    [ActionDescription("Fades a UI Graphic out by animating its alpha from the current alpha to 0.")]
    public class FadeOutGraphic : BaseFadeAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Graphic to fade out.")]
        public GraphicVar Graphic;

        private float _fromAlpha;

        public override bool CanExecute() => CheckParameters(Graphic);

        public override void OnStart()
        {
            _fromAlpha = Graphic.Value.color.a;
            base.OnStart();
        }

        protected override void Apply(float t)
        {
            var g = Graphic.Value;
            var c = g.color;
            c.a = Mathf.Lerp(_fromAlpha, 0f, t);
            g.color = c;
        }
        
        public override string GetSummary() => GetFadeOutSummary(nameof(Graphic));
    }
}
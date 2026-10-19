using System;
using HutongGames.PlayMaker.Actions.UI;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Flicker)]
    [ActionDescription("Randomly flickers a UI Graphic on/off.")]
    public class FlickerGraphic : BaseFlickerAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Graphic to flicker on/off.")]
        public GraphicVar Graphic;

        private bool _originalEnabled;

        public override bool CanExecute() => CheckParameters(Graphic);

        protected override string Target => nameof(Graphic);

        protected override void CaptureOriginalState()
        {
            if (Graphic.Value != null)
                _originalEnabled = Graphic.Value.enabled;
        }

        protected override void RestoreOriginalState()
        {
            if (Graphic.Value != null)
                Graphic.Value.enabled = _originalEnabled;
        }

        protected override void Apply(bool on)
        {
            if (Graphic.Value != null)
                Graphic.Value.enabled = on;
        }
    }
}

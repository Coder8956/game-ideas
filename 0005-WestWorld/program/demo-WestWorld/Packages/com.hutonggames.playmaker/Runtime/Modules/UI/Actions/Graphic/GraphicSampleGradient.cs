using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.UI
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.UGUI_Graphic)]
    [ActionDescription("Set the base color of the Graphic by sampling a Gradient at a normalized position.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Gradient.html")]
    public sealed class GraphicSampleGradient : BaseAction
    {
        [Tooltip("The Graphic")]
        [SerializeField]
        private GraphicVar _graphic;

        [Tooltip("Gradient to sample for the Graphic color.")]
        [SerializeField]
        private GradientVar _gradient;

        [Tooltip("Normalized position (0–1) used to sample the Gradient.")]
        [SerializeField]
        private FloatVar _position;

        public override bool CanExecute()
        {
            return CheckParameters(_graphic, _gradient, _position);
        }

        public override void Execute()
        {
            var graphic = _graphic.Value;
            var gradient = _gradient.Value;

            if (graphic == null || gradient == null)
                return;

            var t = Mathf.Clamp01(_position.Value);
            graphic.color = gradient.Evaluate(t);
        }

        public override string GetSummary()
        {
            return "Set {_graphic} color from {_gradient} at {_position}";
        }
    }
}
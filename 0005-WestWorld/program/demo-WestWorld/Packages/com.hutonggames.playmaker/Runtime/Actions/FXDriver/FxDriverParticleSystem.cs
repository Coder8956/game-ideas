using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.FxDriver)]
    [ActionDescription(
        "Drives a ParticleSystem from an input value.\n" +
        "Maps the input into 0–1 using InputMin/Max, then scales emission rate\n" +
        "and optionally start size.")]
    public sealed class FxDriverParticleSystem : BaseFxDriver
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        #region Particle System

        [ActionHeader("Particle System")]

        [Tooltip("The ParticleSystem to control.")]
        [SerializeField]
        private ParticleSystemVar _particleSystem;

        #endregion

        #region Emission

        [ActionHeader("Emission")]

        [Tooltip("Scale emission rate based on normalized input.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _scaleEmission;

        [Tooltip("Emission rate at normalized input 0 (particles per second).")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _minEmissionRate;

        [Tooltip("Emission rate at normalized input 1 (particles per second).")]
        [SerializeField, DefaultValue(50f)]
        private FloatVar _maxEmissionRate;

        #endregion

        #region Start Size

        [ActionHeader("Start Size")]

        [Tooltip("Scale start size based on normalized input.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _scaleStartSize;

        [Tooltip("Start size at normalized input 0.")]
        [SerializeField, DefaultValue(0.1f)]
        private FloatVar _minStartSize;

        [Tooltip("Start size at normalized input 1.")]
        [SerializeField, DefaultValue(0.3f)]
        private FloatVar _maxStartSize;

        #endregion

        public override bool CanExecute() =>
            base.CanExecute() && CheckParameters(_particleSystem);

        public override void Execute()
        {
            var ps = _particleSystem.Value;
            if (ps == null)
                return;

            var t = Mathf.Clamp01(GetInput01());

            if (_scaleEmission.Value)
            {
                var minRate = Mathf.Max(_minEmissionRate.Value, 0f);
                var maxRate = Mathf.Max(_maxEmissionRate.Value, minRate);

                var emission = ps.emission;
                var rate     = emission.rateOverTime;

                var newRate = Mathf.Lerp(minRate, maxRate, t);
                rate.constant = newRate;
                emission.rateOverTime = rate;
            }

            if (_scaleStartSize.Value)
            {
                var minSize = Mathf.Max(_minStartSize.Value, 0f);
                var maxSize = Mathf.Max(_maxStartSize.Value, minSize);

                var main  = ps.main;
                var size  = main.startSize;
                var value = Mathf.Lerp(minSize, maxSize, t);

                size.constant = value;
                main.startSize = size;
            }
        }

        public override string GetSummary() => "Drive {_particleSystem} FX with {_input}";
    }
}

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Base class for FX driver actions.
    /// Handles mapping a raw input value into a normalized 0–1 range.
    /// </summary>
    [Serializable]
    [HelpURL("actions/effects-actions/fx-driver-actions/")]
    public abstract class BaseFxDriver : BaseAction
    {
        #region Input

        [ActionHeader("Input")]

        [DisplayOrder(-10)]
        [Tooltip("Raw input value used to drive this FX.\n" +
                 "Can be any changing value: speed, thrust, health, charge, etc.")]
        [SerializeField]
        protected FloatVar _input;

        [DisplayOrder(-9)]
        [Tooltip("Input value that maps to 0.\n" +
                 "For example, 0 speed, 0 health, or minimum thrust.")]
        [SerializeField, DefaultValue(0f)]
        protected FloatVar _inputMin;

        [DisplayOrder(-8)]
        [Tooltip("Input value that maps to 1.\n" +
                 "For example, max speed, max health, or full thrust.")]
        [SerializeField, DefaultValue(1f)]
        protected FloatVar _inputMax;

        [DisplayOrder(-7)]
        [Tooltip("If true, clamp the input into the [Min, Max] range before mapping.")]
        [SerializeField, DefaultValue(true)]
        protected BoolVar _clampInput;

        #endregion

        /// <summary>
        /// Returns the current input mapped into the 0–1 range using InputMin/InputMax.
        /// Safe against swapped min/max and zero-length ranges.
        /// </summary>
        protected float GetInput01()
        {
            var raw = _input.Value;

            var a = _inputMin.Value;
            var b = _inputMax.Value;

            // Handle degenerate ranges
            if (Mathf.Approximately(a, b))
                return 0f;

            var min = Mathf.Min(a, b);
            var max = Mathf.Max(a, b);

            if (_clampInput.Value)
                raw = Mathf.Clamp(raw, min, max);

            return Mathf.InverseLerp(min, max, raw);
        }

        /// <summary>
        /// Quick helper to remap input into an arbitrary [outMin, outMax] range.
        /// </summary>
        protected float RemapInput(float outMin, float outMax)
        {
            var t = GetInput01();
            return Mathf.Lerp(outMin, outMax, t);
        }

        public override bool CanExecute() => CheckParameters(_input);
    }
}

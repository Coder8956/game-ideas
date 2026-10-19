using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Widget that formats a numeric value (and optional max) into a label.
    /// Can be used alongside FilledImageMeter/TiledImageMeter or standalone.
    ///
    /// Configure the label and formatting in the inspector, then call SetValue()
    /// (and optionally SetMaxValue()/SetRangeAndValue()) at runtime.
    /// In edit mode, the label previews the current Value if Update In Edit Mode is enabled.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("PlayMaker/Widgets/Meter Label")]
    [Icon(Strings.EditorIconsPath + "MeterLabelIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/meter-label/")]
    public sealed class MeterLabel : MonoBehaviour
    {
        public enum LabelMode
        {
            RawValue,      // e.g., "37"
            Normalized01,  // e.g., "0.37"
            Percentage,    // e.g., "37%"
            RawOverMax     // e.g., "37 / 100"
        }

        [Header("Value")]

        [Tooltip("Current value shown by the label. In edit mode, this is used for preview.")]
        [SerializeField]
        private float _value = 0f;

        [Tooltip("Minimum value that maps to normalized = 0.")]
        [SerializeField]
        private float _minValue = 0f;

        [Tooltip("Maximum value that maps to normalized = 1 and 100%.")]
        [SerializeField]
        private float _maxValue = 100f;

        [Tooltip("Clamp values outside the [Min, Max] range before normalizing.")]
        [SerializeField]
        private bool _clampToRange = true;

        [Tooltip("Invert normalized/percentage values (1 - t).")]
        [SerializeField]
        private bool _invert = false;

        [Header("Target")]

        [Tooltip("Target TextMeshProUGUI label (preferred). If not set, a TMP label is searched on this GameObject.")]
        [SerializeField]
        private TextMeshProUGUI _tmpLabel;

        [Tooltip("Legacy Text label. Used if no TMP label is set or found.")]
        [SerializeField]
        private Text _uiText;

        [Header("Formatting")]

        [Tooltip("How to interpret the value when formatting the label.")]
        [SerializeField]
        private LabelMode _mode = LabelMode.Percentage;

        [Tooltip(
            "Format string.\n" +
            "RawValue / Normalized01 / Percentage use {0} for the value.\n" +
            "RawOverMax uses {0} for value and {1} for max.\n" +
            "Examples: \"{0:0}%\", \"{0:0.00}\", \"{0:0} / {1:0}\"")]
        [SerializeField]
        private string _format = "{0:0}%";

        [Header("Color")]

        [Tooltip("If enabled, the label color is driven by a gradient evaluated by normalized value.")]
        [SerializeField]
        private bool _useColorGradient = false;

        [Tooltip("Gradient evaluated from 0 (min value) to 1 (max value).")]
        [SerializeField]
        private Gradient _colorGradient;

#if UNITY_EDITOR
        // -------------------------
        // DEBUG / EDITOR SECTION
        // -------------------------

        [Header("Debug")]

        [Tooltip("If enabled, the label updates in edit mode using the current Value and settings.")]
        [SerializeField]
        private bool _updateInEditMode = true;
#endif

        private void Reset()
        {
            // Try to auto-find a label on this GameObject
            _tmpLabel = GetComponent<TextMeshProUGUI>();
            if (_tmpLabel == null)
            {
                _uiText = GetComponent<Text>();
            }

            EnsureColorGradient();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_maxValue <= _minValue)
            {
                _maxValue = _minValue + 1f;
            }

            if (!_tmpLabel)
                _tmpLabel = GetComponent<TextMeshProUGUI>();
            if (!_uiText && !_tmpLabel)
                _uiText = GetComponent<Text>();

            EnsureColorGradient();

            if (_updateInEditMode && !Application.isPlaying)
            {
                UpdateLabelInternal();
            }
        }
#endif

        /// <summary>
        /// Set the current value at runtime and update the label.
        /// </summary>
        public void SetValue(float value)
        {
            _value = value;
            UpdateLabelInternal();
        }

        /// <summary>
        /// Set the current max value at runtime and update the label.
        /// Useful for RawOverMax mode.
        /// </summary>
        public void SetMaxValue(float max)
        {
            _maxValue = GetValidMaxValue(_minValue, max);
            UpdateLabelInternal();
        }

        /// <summary>
        /// Set both value and max, then update the label.
        /// </summary>
        public void SetValueAndMax(float value, float max)
        {
            _value = value;
            _maxValue = GetValidMaxValue(_minValue, max);
            UpdateLabelInternal();
        }

        /// <summary>
        /// Set the label min/max range at runtime.
        /// </summary>
        public void SetRange(float minValue, float maxValue)
        {
            _minValue = minValue;
            _maxValue = GetValidMaxValue(minValue, maxValue);
            UpdateLabelInternal();
        }

        /// <summary>
        /// Set the label min/max range and current value at runtime.
        /// </summary>
        public void SetRangeAndValue(float minValue, float maxValue, float value)
        {
            _minValue = minValue;
            _maxValue = GetValidMaxValue(minValue, maxValue);
            _value = value;
            UpdateLabelInternal();
        }

        private void UpdateLabelInternal()
        {
            var label = (TMP_Text)_tmpLabel;
            if (label == null && _uiText != null)
            {
                // We can't cast Text to TMP_Text, so handle separately below.
            }

            if (_tmpLabel == null && _uiText == null)
                return;

            var normalized = Normalize(_value);
            var text = FormatText(_value, normalized, _maxValue);
            var color = _useColorGradient && _colorGradient != null
                ? _colorGradient.Evaluate(normalized)
                : Color.clear;

            if (_tmpLabel != null)
            {
                _tmpLabel.text = text;
                if (_useColorGradient)
                {
                    _tmpLabel.color = color;
                }
            }
            else if (_uiText != null)
            {
                _uiText.text = text;
                if (_useColorGradient)
                {
                    _uiText.color = color;
                }
            }
        }

        private float Normalize(float value)
        {
            var v = value;

            if (_clampToRange)
            {
                if (v < _minValue) v = _minValue;
                if (v > _maxValue) v = _maxValue;
            }

            var range = _maxValue - _minValue;
            if (range <= 0.0001f)
                return _invert ? 1f : 0f;

            var t = (v - _minValue) / range;
            t = Mathf.Clamp01(t);

            if (_invert)
                t = 1f - t;

            return t;
        }

        private string FormatText(float rawValue, float normalized, float maxValue)
        {
            object primary;

            switch (_mode)
            {
                case LabelMode.RawValue:
                    primary = rawValue;
                    break;

                case LabelMode.Normalized01:
                    primary = normalized;
                    break;

                case LabelMode.Percentage:
                    primary = normalized * 100f;
                    break;

                case LabelMode.RawOverMax:
                    primary = rawValue;
                    break;

                default:
                    primary = rawValue;
                    break;
            }

            try
            {
                if (_mode == LabelMode.RawOverMax)
                {
                    // {0} = rawValue, {1} = maxValue
                    return string.Format(_format, primary, maxValue);
                }

                // {0} = primary
                return string.Format(_format, primary);
            }
            catch (FormatException)
            {
                // Fallbacks if the format string is invalid
                switch (_mode)
                {
                    case LabelMode.RawOverMax:
                        return $"{rawValue:0} / {maxValue:0}";

                    case LabelMode.Percentage:
                        return $"{normalized * 100f:0}%";

                    case LabelMode.Normalized01:
                        return $"{normalized:0.00}";

                    default:
                        return primary?.ToString() ?? string.Empty;
                }
            }
        }

        private static float GetValidMaxValue(float minValue, float maxValue)
        {
            if (maxValue <= minValue)
                return minValue + 1f;

            return maxValue;
        }

        private void EnsureColorGradient()
        {
            if (_colorGradient != null)
                return;

            _colorGradient = new Gradient
            {
                colorKeys = new[]
                {
                    new GradientColorKey(Color.red, 0f),
                    new GradientColorKey(Color.yellow, 0.5f),
                    new GradientColorKey(Color.green, 1f)
                },
                alphaKeys = new[]
                {
                    new GradientAlphaKey(1f, 0f),
                    new GradientAlphaKey(1f, 1f)
                }
            };
        }
    }
}

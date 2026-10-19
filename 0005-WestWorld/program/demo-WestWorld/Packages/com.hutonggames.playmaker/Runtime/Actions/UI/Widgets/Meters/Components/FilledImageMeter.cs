using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Widget that drives an Image-based filled meter (health bar, mana bar, progress bar, etc.).
    ///
    /// Configure the meter in the inspector, then call SetValue() at runtime.
    /// In edit mode, the meter previews the current Value if Update In Edit Mode is enabled.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("PlayMaker/Widgets/Filled Image Meter")]
    [Icon(Strings.EditorIconsPath + "FilledImageMeterIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/filled-image-meter/")]
    public sealed class FilledImageMeter : MonoBehaviour
    {
        [Header("Value")]

        [Tooltip("Current value shown by the meter. In edit mode, this is used to preview the layout.")]
        [SerializeField]
        private float _value = 100f;

        [Tooltip("Minimum value that maps to an empty meter (fillAmount = 0).")]
        [SerializeField]
        private float _minValue = 0f;

        [Tooltip("Maximum value that maps to a full meter (fillAmount = 1).")]
        [SerializeField]
        private float _maxValue = 100f;

        [Tooltip("Clamp values outside the [Min, Max] range before mapping.")]
        [SerializeField]
        private bool _clampToRange = true;

        [Tooltip("Invert the mapping so Min -> full and Max -> empty.")]
        [SerializeField]
        private bool _invert = false;

        [Header("Target")]

        [Tooltip("Image to drive. Image.type should be Filled.")]
        [SerializeField]
        private Image _image;

        [Tooltip("Optional MeterLabel to update whenever this meter updates.")]
        [SerializeField]
        private MeterLabel _updateLabel;

#if UNITY_EDITOR
        [Tooltip("Automatically set Image.type = Filled in edit mode if it is not already.")]
        [SerializeField]
        private bool _autoSetImageType = true;
#endif

        [Header("Color")]

        [Tooltip("If enabled, the Image color is driven by a gradient evaluated by normalized value.")]
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

        [Tooltip("If enabled, the meter updates in edit mode using the current Value.")]
        [SerializeField]
        private bool _updateInEditMode = true;

        [NonSerialized]
        private bool _pendingPreview;
#endif

        private void Reset()
        {
            _image = GetComponent<Image>();

            // Provide a simple default gradient (green -> red) for convenience.
            if (_colorGradient == null)
            {
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

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!_image)
                _image = GetComponent<Image>();

            if (_maxValue <= _minValue)
                _maxValue = _minValue + 1f;

            if (_autoSetImageType && _image && _image.type != Image.Type.Filled)
            {
                _image.type = Image.Type.Filled;
            }

            if (_colorGradient == null)
            {
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

            if (_updateInEditMode && !Application.isPlaying)
            {
                // Defer the update to avoid SendMessage/OnValidate issues
                if (!_pendingPreview)
                {
                    _pendingPreview = true;
                    EditorApplication.delayCall += PreviewInEditMode;
                }
            }
        }

        private void PreviewInEditMode()
        {
            _pendingPreview = false;

            if (!this || !_updateInEditMode || Application.isPlaying)
                return;

            SetValueInternal(_value);
        }
#endif

        /// <summary>
        /// Set the meter value at runtime.
        /// </summary>
        public void SetValue(float value)
        {
            _value = value;
            SetValueInternal(_value);
        }

        /// <summary>
        /// Set the meter min/max range at runtime.
        /// </summary>
        public void SetRange(float minValue, float maxValue)
        {
            _minValue = minValue;
            _maxValue = GetValidMaxValue(minValue, maxValue);
            SetValueInternal(_value);
        }

        /// <summary>
        /// Set the meter min/max range and current value at runtime.
        /// </summary>
        public void SetRangeAndValue(float minValue, float maxValue, float value)
        {
            _minValue = minValue;
            _maxValue = GetValidMaxValue(minValue, maxValue);
            _value = value;
            SetValueInternal(_value);
        }

        private void SetValueInternal(float value)
        {
            if (!_image)
                return;

            var t = Normalize(value);

            // Drive fill amount
            _image.fillAmount = t;

            // Optional color from gradient
            if (_useColorGradient && _colorGradient != null)
            {
                var color = _colorGradient.Evaluate(t);
                _image.color = color;
            }

            if (_updateLabel)
            {
                _updateLabel.SetRangeAndValue(_minValue, _maxValue, value);
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

        private static float GetValidMaxValue(float minValue, float maxValue)
        {
            if (maxValue <= minValue)
                return minValue + 1f;

            return maxValue;
        }
    }
}

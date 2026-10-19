using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Widget that drives a sprite-based UI Image meter.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("PlayMaker/Widgets/Image Sprite Meter")]
    [Icon(Strings.EditorIconsPath + "FilledImageMeterIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/image-sprite-meter/")]
    public sealed class ImageSpriteMeter : MonoBehaviour
    {
        public enum FillMethod
        {
            ScaleTransform,
            ResizeImage,
            AnimationFrames
        }

        public enum Axis
        {
            X,
            Y
        }

        public enum AnchorMode
        {
            Center,
            Start,
            End
        }

        [Header("Value")]

        [Tooltip("Current value shown by the meter.")]
        [SerializeField]
        private float _value = 100f;

        [Tooltip("Minimum value that maps to an empty meter.")]
        [SerializeField]
        private float _minValue = 0f;

        [Tooltip("Maximum value that maps to a full meter.")]
        [SerializeField]
        private float _maxValue = 100f;

        [Tooltip("Clamp values outside the [Min, Max] range before mapping.")]
        [SerializeField]
        private bool _clampToRange = true;

        [Tooltip("Invert the mapping so Min -> full and Max -> empty.")]
        [SerializeField]
        private bool _invert;

        [Header("Target")]

        [Tooltip("Image to drive.")]
        [SerializeField]
        private Image _image;

        [Tooltip("How the meter is applied to the image.")]
        [SerializeField]
        private FillMethod _fillMethod = FillMethod.ScaleTransform;

        [Tooltip("Axis used for ScaleTransform or ResizeImage.")]
        [SerializeField]
        private Axis _axis = Axis.X;

        [Tooltip("Where the meter is anchored while filling. Start = left (X) or bottom (Y), End = right (X) or top (Y). Anchor behavior respects RectTransform pivot.")]
        [SerializeField]
        private AnchorMode _anchorMode = AnchorMode.Start;

        [Tooltip("Optional MeterLabel to update whenever this meter updates.")]
        [SerializeField]
        private MeterLabel _updateLabel;

        [Header("Frames")]

        [Tooltip("Optional frame list used when Fill Method is AnimationFrames. First sprite = empty, last sprite = full.")]
        [SerializeField]
        private Sprite[] _animationFrames;

        [Header("Color")]

        [Tooltip("If enabled, the Image color is driven by a gradient evaluated by normalized value.")]
        [SerializeField]
        private bool _useColorGradient;

        [Tooltip("Gradient evaluated from 0 (min value) to 1 (max value).")]
        [SerializeField]
        private Gradient _colorGradient;

        private RectTransform _targetRectTransform;
        private Vector3 _fullScale = Vector3.one;
        private Vector2 _fullSize = Vector2.one;
        private Vector2 _fullAnchoredPosition;
        private bool _defaultsCached;

        private void Reset()
        {
            _image = GetComponent<Image>();
            CacheDefaults();
            EnsureDefaultGradient();
        }

        private void Awake()
        {
            CacheDefaults();
        }

        private void OnEnable()
        {
            EnsureDefaultsCached();
            SetValueInternal(_value, true);
        }

        private void OnValidate()
        {
            if (!_image)
                _image = GetComponent<Image>();

            if (_maxValue <= _minValue)
                _maxValue = _minValue + 1f;

            EnsureDefaultGradient();
            CacheDefaults();
        }

        public void SetValue(float value)
        {
            _value = value;
            SetValueInternal(_value, true);
        }

        public void SetRange(float minValue, float maxValue)
        {
            _minValue = minValue;
            _maxValue = GetValidMaxValue(minValue, maxValue);
            SetValueInternal(_value, true);
        }

        public void SetRangeAndValue(float minValue, float maxValue, float value)
        {
            _minValue = minValue;
            _maxValue = GetValidMaxValue(minValue, maxValue);
            _value = value;
            SetValueInternal(_value, true);
        }

        private void SetValueInternal(float value, bool updateLabel)
        {
            EnsureDefaultsCached();

            if (!_image)
                return;

            var t = Normalize(value);
            ApplyNormalizedInternal(t, updateLabel, value);
        }

        private void ApplyNormalizedInternal(float t, bool updateLabel, float rawValue)
        {
            switch (_fillMethod)
            {
                case FillMethod.AnimationFrames:
                    ApplyAnimationFrame(t);
                    break;
                case FillMethod.ResizeImage:
                    ApplySize(t);
                    break;
                default:
                    ApplyScale(t);
                    break;
            }

            if (_useColorGradient && _colorGradient != null)
                _image.color = _colorGradient.Evaluate(t);

            if (updateLabel && _updateLabel)
                _updateLabel.SetRangeAndValue(_minValue, _maxValue, rawValue);
        }

        private void ApplyAnimationFrame(float t)
        {
            if (_animationFrames == null || _animationFrames.Length == 0)
                return;

            RestoreTargetToFullState();

            var lastIndex = _animationFrames.Length - 1;
            var index = Mathf.Clamp(Mathf.RoundToInt(t * lastIndex), 0, lastIndex);
            var frame = _animationFrames[index];

            if (_image.sprite != frame)
                _image.sprite = frame;
        }

        private void ApplyScale(float t)
        {
            if (!_targetRectTransform)
                return;

            var scale = _targetRectTransform.localScale;
            float fullLength;
            float currentLength;

            switch (_axis)
            {
                case Axis.Y:
                    scale.y = _fullScale.y * t;
                    fullLength = GetFullLengthForScaleY();
                    currentLength = fullLength * t;
                    break;
                default:
                    scale.x = _fullScale.x * t;
                    fullLength = GetFullLengthForScaleX();
                    currentLength = fullLength * t;
                    break;
            }

            _targetRectTransform.localScale = scale;
            ApplyAnchor(currentLength, fullLength);
        }

        private void ApplySize(float t)
        {
            if (!_targetRectTransform)
                return;

            float fullLength;
            float currentLength;

            switch (_axis)
            {
                case Axis.Y:
                    SetSizeOnAxis(RectTransform.Axis.Vertical, _fullSize.y * t);
                    fullLength = _fullSize.y * Mathf.Abs(_fullScale.y);
                    currentLength = fullLength * t;
                    break;
                default:
                    SetSizeOnAxis(RectTransform.Axis.Horizontal, _fullSize.x * t);
                    fullLength = _fullSize.x * Mathf.Abs(_fullScale.x);
                    currentLength = fullLength * t;
                    break;
            }

            ApplyAnchor(currentLength, fullLength);
        }

        private void ApplyAnchor(float currentLength, float fullLength)
        {
            if (!_targetRectTransform)
                return;

            var anchoredPosition = _targetRectTransform.anchoredPosition;

            switch (_axis)
            {
                case Axis.Y:
                    anchoredPosition.y = GetAnchoredPosition(_fullAnchoredPosition.y, currentLength, fullLength);
                    break;
                default:
                    anchoredPosition.x = GetAnchoredPosition(_fullAnchoredPosition.x, currentLength, fullLength);
                    break;
            }

            _targetRectTransform.anchoredPosition = anchoredPosition;
        }

        private float GetAnchoredPosition(float baseline, float currentLength, float fullLength)
        {
            var diff = Mathf.Max(0f, fullLength - currentLength);
            var pivot = GetEffectivePivot01();

            return _anchorMode switch
            {
                AnchorMode.Start => baseline - (pivot * diff),
                AnchorMode.End => baseline + ((1f - pivot) * diff),
                _ => baseline
            };
        }

        private float GetEffectivePivot01()
        {
            if (!_targetRectTransform)
                return 0.5f;

            var scale = _axis == Axis.Y ? _targetRectTransform.lossyScale.y : _targetRectTransform.lossyScale.x;
            var pivot = _axis == Axis.Y ? _targetRectTransform.pivot.y : _targetRectTransform.pivot.x;

            if (scale < 0f)
                pivot = 1f - pivot;

            return Mathf.Clamp01(pivot);
        }

        private float GetFullLengthForScaleX() => _fullSize.x * Mathf.Abs(_fullScale.x);

        private float GetFullLengthForScaleY() => _fullSize.y * Mathf.Abs(_fullScale.y);

        private void CacheDefaults()
        {
            if (!_image)
            {
                _defaultsCached = false;
                return;
            }

            _targetRectTransform = _image.rectTransform;
            if (!_targetRectTransform)
            {
                _defaultsCached = false;
                return;
            }

            _fullScale = _targetRectTransform.localScale;
            _fullAnchoredPosition = _targetRectTransform.anchoredPosition;
            _fullSize = _targetRectTransform.rect.size;
            _defaultsCached = true;
        }

        private void EnsureDefaultsCached()
        {
            if (_defaultsCached && _targetRectTransform && _image)
                return;

            CacheDefaults();
        }

        private void RestoreTargetToFullState()
        {
            if (!_targetRectTransform || !_image)
                return;

            _targetRectTransform.localScale = _fullScale;
            _targetRectTransform.anchoredPosition = _fullAnchoredPosition;
            SetSizeOnAxis(RectTransform.Axis.Horizontal, _fullSize.x);
            SetSizeOnAxis(RectTransform.Axis.Vertical, _fullSize.y);
        }

        private void SetSizeOnAxis(RectTransform.Axis axis, float size)
        {
            if (!_targetRectTransform)
                return;

            _targetRectTransform.SetSizeWithCurrentAnchors(axis, size);
        }

        private void EnsureDefaultGradient()
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

        private float Normalize(float value)
        {
            var v = value;

            if (_clampToRange)
            {
                if (v < _minValue)
                    v = _minValue;
                if (v > _maxValue)
                    v = _maxValue;
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

using System;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Widget that drives a SpriteRenderer-based meter (for world-space health bars, etc.).
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("PlayMaker/Widgets/Sprite Meter")]
    [Icon(Strings.EditorIconsPath + "FilledImageMeterIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/sprite-meter/")]
    public sealed class SpriteMeter : MonoBehaviour
    {
        public enum FillMethod
        {
            ScaleTransform,
            ResizeSprite,
            AnimationFrames
        }

        public enum Axis
        {
            X,
            Y
        }

        public enum AnchorMode
        {
            /// <summary>
            /// Keep the sprite centered while filling.
            /// </summary>
            Center,
            /// <summary>
            /// Keep the start edge fixed (left on X, bottom on Y) using sprite pivot orientation.
            /// </summary>
            Start,
            /// <summary>
            /// Keep the end edge fixed (right on X, top on Y) using sprite pivot orientation.
            /// </summary>
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
        private bool _invert = false;

        [Header("Target")]

        [Tooltip("SpriteRenderer to drive.")]
        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        [Tooltip("How the meter is applied to the sprite.")]
        [SerializeField]
        private FillMethod _fillMethod = FillMethod.ScaleTransform;

        [Tooltip("Axis used for ScaleTransform or ResizeSprite.")]
        [SerializeField]
        private Axis _axis = Axis.X;

        [Tooltip("Where the meter is anchored while filling. Start = left (X) or bottom (Y), End = right (X) or top (Y). Anchor behavior respects sprite pivot.")]
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

        [Tooltip("If enabled, the SpriteRenderer color is driven by a gradient evaluated by normalized value.")]
        [SerializeField]
        private bool _useColorGradient = false;

        [Tooltip("Gradient evaluated from 0 (min value) to 1 (max value).")]
        [SerializeField]
        private Gradient _colorGradient;

        private Transform _targetTransform;
        private Vector3 _fullScale = Vector3.one;
        private Vector2 _fullSize = Vector2.one;
        private Vector3 _fullLocalPosition;
        private bool _defaultsCached;

        private void Reset()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
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
            if (!_spriteRenderer)
                _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_maxValue <= _minValue)
                _maxValue = _minValue + 1f;

            EnsureDefaultGradient();
            CacheDefaults();
        }

        /// <summary>
        /// Set the meter value at runtime.
        /// </summary>
        public void SetValue(float value)
        {
            _value = value;
            SetValueInternal(_value, true);
        }

        /// <summary>
        /// Set the meter min/max range at runtime.
        /// </summary>
        public void SetRange(float minValue, float maxValue)
        {
            _minValue = minValue;
            _maxValue = GetValidMaxValue(minValue, maxValue);
            SetValueInternal(_value, true);
        }

        /// <summary>
        /// Set the meter min/max range and current value at runtime.
        /// </summary>
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

            if (!_spriteRenderer)
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
                case FillMethod.ResizeSprite:
                    ApplySize(t);
                    break;
                default:
                    ApplyScale(t);
                    break;
            }

            if (_useColorGradient && _colorGradient != null)
                _spriteRenderer.color = _colorGradient.Evaluate(t);

            if (updateLabel && _updateLabel)
                _updateLabel.SetRangeAndValue(_minValue, _maxValue, rawValue);
        }

        private void ApplyAnimationFrame(float t)
        {
            if (_animationFrames == null || _animationFrames.Length == 0)
                return;

            // Ensure frame mode does not keep a previously scaled/resized meter transform.
            RestoreTargetToFullState();

            var lastIndex = _animationFrames.Length - 1;
            var index = Mathf.Clamp(Mathf.RoundToInt(t * lastIndex), 0, lastIndex);
            var frame = _animationFrames[index];

            if (_spriteRenderer.sprite != frame)
                _spriteRenderer.sprite = frame;
        }

        private void ApplyScale(float t)
        {
            if (!_targetTransform)
                _targetTransform = _spriteRenderer.transform;

            var scale = _targetTransform.localScale;
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

            _targetTransform.localScale = scale;
            ApplyAnchor(currentLength, fullLength);
        }

        private void ApplySize(float t)
        {
            var size = _spriteRenderer.size;
            float fullLength;
            float currentLength;

            switch (_axis)
            {
                case Axis.Y:
                    size.y = _fullSize.y * t;
                    fullLength = _fullSize.y * Mathf.Abs(_fullScale.y);
                    currentLength = fullLength * t;
                    break;
                default:
                    size.x = _fullSize.x * t;
                    fullLength = _fullSize.x * Mathf.Abs(_fullScale.x);
                    currentLength = fullLength * t;
                    break;
            }

            _spriteRenderer.size = size;
            ApplyAnchor(currentLength, fullLength);
        }

        private void ApplyAnchor(float currentLength, float fullLength)
        {
            if (!_targetTransform)
                return;

            var localPosition = _targetTransform.localPosition;

            switch (_axis)
            {
                case Axis.Y:
                    localPosition.y = GetAnchoredPosition(_fullLocalPosition.y, currentLength, fullLength);
                    break;
                default:
                    localPosition.x = GetAnchoredPosition(_fullLocalPosition.x, currentLength, fullLength);
                    break;
            }

            _targetTransform.localPosition = localPosition;
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
            if (!_targetTransform)
                _targetTransform = _spriteRenderer ? _spriteRenderer.transform : transform;

            var s = _axis == Axis.Y ? _targetTransform.lossyScale.y : _targetTransform.lossyScale.x;

            if (_spriteRenderer)
            {
                if (_axis == Axis.X && _spriteRenderer.flipX)
                    s = -s;

                if (_axis == Axis.Y && _spriteRenderer.flipY)
                    s = -s;
            }

            var pivot = 0.5f;
            if (_spriteRenderer && _spriteRenderer.sprite)
            {
                var rect = _spriteRenderer.sprite.rect;
                if (_axis == Axis.Y)
                    pivot = rect.height > 0f ? _spriteRenderer.sprite.pivot.y / rect.height : 0.5f;
                else
                    pivot = rect.width > 0f ? _spriteRenderer.sprite.pivot.x / rect.width : 0.5f;
            }

            // If the visual direction is flipped, swap start/end pivot interpretation.
            if (s < 0f)
                pivot = 1f - pivot;

            return Mathf.Clamp01(pivot);
        }

        private float GetFullLengthForScaleX()
        {
            var spriteWidth = _spriteRenderer && _spriteRenderer.sprite ? _spriteRenderer.sprite.bounds.size.x : 1f;
            return spriteWidth * Mathf.Abs(_fullScale.x);
        }

        private float GetFullLengthForScaleY()
        {
            var spriteHeight = _spriteRenderer && _spriteRenderer.sprite ? _spriteRenderer.sprite.bounds.size.y : 1f;
            return spriteHeight * Mathf.Abs(_fullScale.y);
        }

        private void CacheDefaults()
        {
            if (!_spriteRenderer)
            {
                _defaultsCached = false;
                return;
            }

            _targetTransform = _spriteRenderer.transform;
            _fullScale = _targetTransform.localScale;
            _fullLocalPosition = _targetTransform.localPosition;
            _fullSize = _spriteRenderer.size;
            _defaultsCached = true;
        }

        private void EnsureDefaultsCached()
        {
            if (_defaultsCached && _targetTransform && _spriteRenderer)
                return;

            CacheDefaults();
        }

        private void RestoreTargetToFullState()
        {
            if (!_targetTransform || !_spriteRenderer)
                return;

            _targetTransform.localScale = _fullScale;
            _targetTransform.localPosition = _fullLocalPosition;
            _spriteRenderer.size = _fullSize;
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

using System;
using HutongGames.PlayMaker.Actions;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    
    
    
    /// <summary>
    /// Widget that displays a "tiled" meter using a Tiled Image.
    /// For example, hearts, lives, ammo pips, etc.
    ///
    /// Configure the meter in the inspector, then call SetValue() at runtime.
    /// In edit mode, the meter previews the current Value if Update In Edit Mode is enabled.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("PlayMaker/Widgets/Tiled Image Meter")]
    [Icon(Strings.EditorIconsPath + "TiledImageMeterIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/meters/tiled-image-meter/")]
    public sealed class TiledImageMeter : MonoBehaviour
    {
        public enum Axis
        {
            Horizontal,
            Vertical
        }

        public enum RoundingMode
        {
            Floor,
            Ceil,
            Round
        }

        [Header("Value")]

        [Tooltip("Current value shown by the meter.")]
        [SerializeField] 
        private float _value = 3f;

        [Header("Target")]

        [Tooltip("Image using a tiled sprite (Image.type should be Tiled).")]
        [SerializeField] 
        private Image _image;

        [Tooltip("Optional MeterLabel to update whenever this meter updates.")]
        [SerializeField]
        private MeterLabel _updateLabel;

        [Tooltip("Axis along which the meter grows.")]
        [SerializeField] 
        private Axis _axis = Axis.Horizontal;

        [Header("Icons")]

        [Tooltip("Size of one icon in UI units (usually pixels).")]
        [SerializeField] 
        private Vector2 _iconSize = new Vector2(16f, 16f);

        [Tooltip("Value represented by one icon (e.g., 1 HP per heart, or 0.5 for half-hearts).")]
        [SerializeField] 
        private float _valuePerIcon = 1f;

        [Tooltip("Maximum number of icons to show (0 = unlimited).")]
        [SerializeField] 
        private int _maxIcons = 0;

        [Tooltip("How to round the calculated icon count.")]
        [SerializeField] 
        private RoundingMode _rounding = RoundingMode.Floor;

        private RectTransform _rectTransform;

        private void Reset()
        {
            _image = GetComponent<Image>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Awake()
        {
            if (!_rectTransform)
                _rectTransform = GetComponent<RectTransform>();
        }

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

        private void OnValidate()
        {
            if (!_image)
                _image = GetComponent<Image>();
            if (!_rectTransform)
                _rectTransform = GetComponent<RectTransform>();

            if (_valuePerIcon <= 0f)
                _valuePerIcon = 1f;

            if (_updateInEditMode && !Application.isPlaying)
            {
                // Defer resize to avoid SendMessage errors during validation.
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

            // Component might have been destroyed or disabled since OnValidate.
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
        /// Set value, value-per-icon, and max-icons, then update the meter.
        /// </summary>
        public void SetValues(float value, float valuePerIcon, int maxIcons)
        {
            _value = value;
            _valuePerIcon = valuePerIcon <= 0f ? 1f : valuePerIcon;
            _maxIcons = maxIcons;
            SetValueInternal(_value);
        }

        private void SetValueInternal(float value)
        {
            if (!_image || !_rectTransform)
                return;

            var unitsPerIcon = _valuePerIcon;
            if (unitsPerIcon <= 0f)
                unitsPerIcon = 1f;

            var rawIcons = value / unitsPerIcon;

            if (rawIcons < 0f)
                rawIcons = 0f;

            var iconCount = ApplyRounding(rawIcons);

            if (_maxIcons > 0 && iconCount > _maxIcons)
                iconCount = _maxIcons;

            if (iconCount < 0f)
                iconCount = 0f;

            var iconSize = _iconSize;
            var size = _rectTransform.sizeDelta;

            switch (_axis)
            {
                case Axis.Horizontal:
                    size.x = iconCount * iconSize.x;
                    if (iconSize.y > 0f) size.y = iconSize.y;
                    break;

                case Axis.Vertical:
                    size.y = iconCount * iconSize.y;
                    if (iconSize.x > 0f) size.x = iconSize.x;
                    break;
            }

            _rectTransform.sizeDelta = size;

            if (_updateLabel)
            {
                if (_maxIcons > 0)
                {
                    _updateLabel.SetRangeAndValue(0f, _maxIcons * unitsPerIcon, value);
                }
                else
                {
                    _updateLabel.SetValue(value);
                }
            }
        }

        private float ApplyRounding(float v) =>
            _rounding switch
            {
                RoundingMode.Ceil => Mathf.Ceil(v),
                RoundingMode.Round => Mathf.Round(v),
                _ => Mathf.Floor(v)
            };
    }
}

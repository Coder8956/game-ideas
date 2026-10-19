using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HutongGames.PlayMaker
{
    /// <summary>
    /// Binds a GlobalVariableAsset to a UI text element (TMP or legacy Text).
    /// - Supports scalar values and lists (IEnumerable)
    /// - Per-item formatting for lists (Item Format)
    /// - Escaped separators such as "\n", "\t", "\\"
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("PlayMaker/Bindings/Global Variable Text Binding")]
    [Icon("Packages/com.hutonggames.playmaker/Editor/Resources/playmakerIconSmall.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/helpers/global-variable-text-binding/")]
    public sealed class GlobalVariableTextBinding : MonoBehaviour
    {
        // --------------------------------------------------------------------
        // Fields
        // --------------------------------------------------------------------

        [Header("Source")]
        [Tooltip("Global variable asset to read the value from.")]
        [SerializeField]
        private GlobalVariableAsset _globalVariable;

        [Header("Target")]
        [Tooltip("TextMeshProUGUI component to update. If not set, auto-detected on this GameObject.")]
        [SerializeField]
        private TextMeshProUGUI _tmpText;

        [Tooltip("Legacy Text component. Used if TMP is not assigned.")]
        [SerializeField]
        private Text _uiText;

        [Header("Formatting")]
        [Tooltip("Format string for scalar values. Use {0} for the value. Leave empty to use ToString().")]
        [SerializeField]
        private string _format = "{0}";

        [Tooltip("Format applied to each list item. Use {0} for the value. Leave empty to use the main Format field.")]
        [SerializeField]
        private string _itemFormat = "";

        [Tooltip("Separator for list values. Supports escaped sequences like \\n, \\t, \\\\.")]
        [SerializeField]
        private string _listSeparator = ", ";
        
        private string _lastRenderedText;
        private IVariable _subscribedVariable;

        private IVariable BoundVariable => _globalVariable != null ? _globalVariable.Variable : null;

        // --------------------------------------------------------------------
        // Unity lifecycle
        // --------------------------------------------------------------------

        private void Reset()
        {
            _tmpText = GetComponent<TextMeshProUGUI>();
            if (!_tmpText)
                _uiText = GetComponent<Text>();
        }

        private void OnEnable()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                UpdateText();
                return;
            }
#endif
            SyncSubscription();
            UpdateText();
        }

        private void OnDisable()
        {
            UnsubscribeFromVariable();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!_tmpText)
                _tmpText = GetComponent<TextMeshProUGUI>();
            if (!_uiText && !_tmpText)
                _uiText = GetComponent<Text>();

            if (Application.isPlaying)
            {
                SyncSubscription();
            }
            UpdateText();
        }
#endif

        // --------------------------------------------------------------------
        // Subscriptions
        // --------------------------------------------------------------------

        private void SyncSubscription()
        {
            var variable = BoundVariable;

            if (ReferenceEquals(_subscribedVariable, variable))
                return;

            if (_subscribedVariable != null)
            {
                _subscribedVariable.ValueChanged -= OnValueChanged;
            }

            _subscribedVariable = variable;

            if (_subscribedVariable != null)
            {
                _subscribedVariable.ValueChanged += OnValueChanged;
            }
        }

        private void UnsubscribeFromVariable()
        {
            if (_subscribedVariable != null)
            {
                _subscribedVariable.ValueChanged -= OnValueChanged;
                _subscribedVariable = null;
            }
        }

        private void OnValueChanged()
        {
            UpdateText();
        }

        // --------------------------------------------------------------------
        // Core logic
        // --------------------------------------------------------------------

        /// <summary>
        /// Manually force the binding to update the UI.
        /// </summary>
        [ContextMenu("Refresh Preview")]
        public void Refresh()
        {
            UpdateText();
        }

        private void UpdateText()
        {
            if (!this || !_globalVariable)
                return;

            string valueString = GetValueString() ?? string.Empty;

            // Avoid spamming UI if text hasn't changed.
            if (valueString == _lastRenderedText)
                return;

            _lastRenderedText = valueString;

            if (_tmpText)
            {
                _tmpText.text = valueString;
                NotifyTargetChanged(_tmpText);
            }
            else if (_uiText)
            {
                _uiText.text = valueString;
                NotifyTargetChanged(_uiText);
            }
        }

        // --------------------------------------------------------------------
        // Value formatting
        // --------------------------------------------------------------------

        private string GetValueString()
        {
            var variable = BoundVariable;
            var value = variable?.GetValue();

            if (value == null)
                return string.Empty;

            // Strings are IEnumerable<char>, so treat them as scalars.
            if (value is string str)
                return FormatScalar(str);

            // Lists/arrays/any IEnumerable
            if (value is IEnumerable enumerable)
                return FormatEnumerable(enumerable);

            // Scalar fallback
            return FormatScalar(value);
        }

        private string FormatEnumerable(IEnumerable items)
        {
            var result = new List<string>();

            foreach (object item in items)
            {
                result.Add(FormatScalar(item, Unescape(_itemFormat)));
            }

            string sep = Unescape(_listSeparator);
            var listString = string.Join(sep, result);

            if (string.IsNullOrWhiteSpace(_format))
            {
                return listString;
            }
            
            return string.Format(Unescape(_format), listString);
        }

        private string FormatScalar(object value)
        {
            return FormatScalar(value, _format);
        }

        private string FormatScalar(object value, string formatOverride)
        {
            if (value == null)
                return string.Empty;

            if (string.IsNullOrWhiteSpace(formatOverride))
                return value.ToString();

            try
            {
                return string.Format(formatOverride, value);
            }
            catch (FormatException)
            {
                // If the user enters an incompatible format (e.g., numeric format for a string),
                // just fall back to ToString().
                return value.ToString();
            }
        }

        // --------------------------------------------------------------------
        // Utilities
        // --------------------------------------------------------------------

        /// <summary>
        /// Converts escaped sequences ("\\n", "\\t", "\\\\", etc.) into actual characters.
        /// </summary>
        private static string Unescape(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            return s
                .Replace("\\n", "\n")
                .Replace("\\r", "\r")
                .Replace("\\t", "\t")
                .Replace("\\\\", "\\");
        }

        private static void NotifyTargetChanged(Graphic graphic)
        {
            if (graphic == null)
                return;

            graphic.SetAllDirty();

#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(graphic);
            }
#endif
        }
    }
}

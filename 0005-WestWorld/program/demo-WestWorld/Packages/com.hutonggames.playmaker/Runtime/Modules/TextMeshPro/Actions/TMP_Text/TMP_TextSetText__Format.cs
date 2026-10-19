
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.TMP_Text)]
    [ConvertibleGroup("SetText")]
    [ActionDescription("Set the text to display with formatting. Use standard C# format strings, e.g., '0000' formats a number as four digits.")]
    [HelpURL("https://docs.microsoft.com/en-us/dotnet/standard/base-types/formatting-types")]
    public sealed class TMP_TextSetText__Format : BaseAction
    {
        [Tooltip("The TextMeshPro - Text component")]
        [SerializeField]
        private TMP_TextVar _tMP_Text;
        
        [Tooltip("Variable to format")]
        [SerializeField]
        private AnyVariableRef _variable;

        [Tooltip("Format string. Use a composite template like 'Level: {0}' (or '{0:D4}'), or a value format like '0000' for four digits. See help for all options.")]
        [SerializeField, CanBeNullOrEmpty]
        private StringVar _format;

        public override bool CanExecute()
        {
            return CheckParameters(_tMP_Text, _variable);
        }
        
        public override void Execute()
        {
            var value = _variable.GetValue();
            var format = _format.Value;
    
            if (string.IsNullOrEmpty(format))
            {
                _tMP_Text.Value.text = value?.ToString() ?? "";
            }
            else
            {
                try
                {
                    if (format.Contains("{0"))
                    {
                        _tMP_Text.Value.text = string.Format(format, value ?? "");
                    }
                    // Try to parse the input as a number first if it's a string
                    else if (value is string strValue && double.TryParse(strValue, out var number))
                    {
                        _tMP_Text.Value.text = number.ToString(format);
                    }
                    // If it's already a numeric type
                    else if (value is IFormattable formattable)
                    {
                        _tMP_Text.Value.text = formattable.ToString(format, null);
                    }
                    // For all other cases, use string.Format with escaped format string
                    else
                    {
                        _tMP_Text.Value.text = string.Format($"{{0:{format}}}", value ?? "");
                    }
                }
                catch (FormatException)
                {
                    // Fallback if format is invalid
                    _tMP_Text.Value.text = value?.ToString() ?? "";
                }
            }
        }
        
        public override string GetSummary() => _format.IsDefault() 
                ? "Set {_tMP_Text} text to {_variable}" 
                : "Set {_tMP_Text} text to {_variable} ({_format})";
    }
}

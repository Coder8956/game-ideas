using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    [Serializable]
    public sealed class TextTarget : IDataFieldTarget
    {
        public enum TextComponentKind
        {
            [InspectorName("TMP Text")] TmpText, 
            [InspectorName("UGUI Text")] UguiText
        }

        [SerializeField] private TextComponentKind _componentKind = TextComponentKind.TmpText;

        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private Text _uguiText;

        [SerializeField] private string _format;
        [SerializeField] private string _missingValueText = "—";

        public void Apply(IVariableVar value, DataDefinition def, SerializableGuid fieldGuid)
        {
            // Compute string
            var text = _missingValueText;
            if (value is { IsNone: false })
            {
                var raw = value.GetValue();
                if (raw != null)
                    text = string.IsNullOrEmpty(_format) ? raw.ToString() : string.Format(_format, raw);
            }

            // Write to selected component type
            switch (_componentKind)
            {
                case TextComponentKind.TmpText:
                    if (_tmpText != null) _tmpText.text = text;
                    break;
                case TextComponentKind.UguiText:
                    if (_uguiText != null) _uguiText.text = text;
                    break;
            }
        }
    }
}
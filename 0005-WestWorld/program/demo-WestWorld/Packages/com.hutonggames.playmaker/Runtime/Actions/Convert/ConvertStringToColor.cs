using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a String to a Color.\n" +
                       "Supports HTML colors (#RRGGBB / #RRGGBBAA) and CSV floats (r,g,b[,a]).")]
    [System.Serializable]
    public sealed class ConvertStringToColor : BaseAction
    {
        [ActionTarget]
        [Tooltip("The String to convert.")]
        [SerializeField]
        private StringRef _string;

        [Tooltip("Store the converted Color value.")]
        [SerializeField, WriteOnly]
        private ColorRef _color;

        [Tooltip("Event sent if conversion succeeds.")]
        [SerializeField, OptionalField]
        private EventRef _successEvent;

        [Tooltip("Event sent if conversion fails.")]
        [SerializeField, OptionalField]
        private EventRef _failureEvent;

        public override bool CanExecute() => CheckParameters(_string, _color);

        public override void Execute()
        {
            var text = _string.Value;

            if (string.IsNullOrWhiteSpace(text))
            {
                SendEvent(_failureEvent);
                return;
            }

            text = text.Trim();

            // 1) Try Unity HTML colors (#RRGGBB, #RRGGBBAA, named colors)
            if (ColorUtility.TryParseHtmlString(text, out var htmlColor))
            {
                _color.Value = htmlColor;
                SendEvent(_successEvent);
                return;
            }

            // 2) Try CSV floats: "r,g,b" or "r,g,b,a"
            if (TryParseCsvColor(text, out var csvColor))
            {
                _color.Value = csvColor;
                SendEvent(_successEvent);
                return;
            }

            SendEvent(_failureEvent);
        }

        private static bool TryParseCsvColor(string text, out Color color)
        {
            color = default;

            var parts = text.Split(',');
            if (parts.Length != 3 && parts.Length != 4)
                return false;

            if (!float.TryParse(parts[0], out var r)) return false;
            if (!float.TryParse(parts[1], out var g)) return false;
            if (!float.TryParse(parts[2], out var b)) return false;

            var a = 1f;
            if (parts.Length == 4 && !float.TryParse(parts[3], out a))
                return false;

            color = new Color(r, g, b, a);
            return true;
        }

        public override string GetSummary() => "Convert {_string} to Color -> {_color}";
    }
}

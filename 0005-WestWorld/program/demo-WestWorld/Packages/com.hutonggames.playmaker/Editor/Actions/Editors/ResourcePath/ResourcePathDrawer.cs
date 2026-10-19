
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [CustomPropertyDrawer(typeof(ResourcePath))]
    public sealed class ResourcePathDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            // Expecting ResourcePath has a serialized string field "_value"
            var valueProp = property.FindPropertyRelative("_value");

            var root = new VisualElement();

            // Label + text field
            var field = new TextField(property.displayName)
            {
                value = valueProp?.stringValue ?? string.Empty
            };

            field.isDelayed = true; // avoid thrashing while typing
            field.tooltip = "Resources-relative path (no extension). Example: \"Enemies/Enemy01\". \"Resources/\" prefix is optional.";

            field.RegisterValueChangedCallback(evt =>
            {
                if (valueProp == null) return;

                var normalized = Normalize(evt.newValue);
                if (normalized != evt.newValue)
                    field.SetValueWithoutNotify(normalized);

                valueProp.serializedObject.Update();
                valueProp.stringValue = normalized;
                valueProp.serializedObject.ApplyModifiedProperties();
            });

            root.Add(field);

            /*
            // Optional subtle hint line
            var hint = new Label("Example: Enemies/Enemy01 (Resources/ prefix not required)")
            {
                style =
                {
                    unityFontStyleAndWeight = UnityEngine.FontStyle.Italic,
                    fontSize = 11,
                    marginLeft = 4,
                    marginTop = 2,
                    opacity = 0.7f
                }
            };
            root.Add(hint);*/

            return root;
        }

        private static string Normalize(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            s = s.Trim();
            s = s.Replace('\\', '/');

            // Allow users to paste "Resources/Foo/Bar" or "Assets/.../Resources/Foo/Bar"
            const string resourcesSlash = "Resources/";
            int idx = s.IndexOf(resourcesSlash, System.StringComparison.OrdinalIgnoreCase);
            if (idx >= 0)
                s = s[(idx + resourcesSlash.Length)..];

            // Remove extension if pasted (optional; can be strict if you prefer)
            var dot = s.LastIndexOf('.');
            var slash = s.LastIndexOf('/');
            if (dot > slash) // dot after last slash => looks like extension
                s = s[..dot];

            return s;
        }
    }
}


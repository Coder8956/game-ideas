using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(DataComponentUI))]
    public sealed class DataComponentUIEditor : UnityEditor.Editor
    {
        private readonly DataUIBindingsEditor _bindings = new();

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            var srcProp = serializedObject.FindProperty("_dataComponent");
            var defProp = serializedObject.FindProperty("_definition");
            var refreshOnEnableProp = serializedObject.FindProperty("_refreshOnEnable");
            var refreshOnChangedProp = serializedObject.FindProperty("_refreshOnChanged");
            
            root.Add(new PropertyField(srcProp, "Data Component"));
            root.Add(new PropertyField(refreshOnEnableProp, "Refresh On Enable"));
            root.Add(new PropertyField(refreshOnChangedProp, "Refresh On Changed"));

            // Bindings UI (definition resolves from source first, then fallback)
            var uiProp = serializedObject.FindProperty("_ui");

            root.Add(_bindings.Build(
                serializedObject,
                uiProp,
                getAutoBindRoot: () => ((DataComponentUI)target)?.gameObject,
                createDefaultTarget: (dataType, subType) =>
                {
                    if (dataType == typeof(bool)) return new ToggleTarget();
                    if (dataType == typeof(Sprite)) return new ImageSpriteTarget();
                    return new TextTarget();
                },
                definitionProp: defProp,
                getResolvedDefinition: () =>
                {
                    var ui = (DataComponentUI)target;
                    return ui != null ? ui.Source?.Data?.DataDefinition ?? ui.Definition : null;
                },
                showDefinitionPicker: true));

            return root;
        }
    }
}

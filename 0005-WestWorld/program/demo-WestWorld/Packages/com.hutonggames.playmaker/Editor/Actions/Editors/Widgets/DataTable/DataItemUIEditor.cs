using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(DataItemUI))]
    public sealed class DataItemUIEditor : UnityEditor.Editor
    {
        private readonly DataUIBindingsEditor _bindings = new();

        public override VisualElement CreateInspectorGUI()
        {
            var uiProp = serializedObject.FindProperty("_ui");
            var defProp = serializedObject.FindProperty("_definition");

            return _bindings.Build(
                serializedObject,
                uiProp,
                getAutoBindRoot: () => ((DataItemUI)target)?.gameObject,
                createDefaultTarget: (dataType, subType) =>
                {
                    if (dataType == typeof(bool)) return new ToggleTarget();
                    if (dataType == typeof(Sprite)) return new ImageSpriteTarget();
                    return new TextTarget();
                },
                definitionProp: defProp,
                getResolvedDefinition: null,
                showDefinitionPicker: true);
        }
    }
}
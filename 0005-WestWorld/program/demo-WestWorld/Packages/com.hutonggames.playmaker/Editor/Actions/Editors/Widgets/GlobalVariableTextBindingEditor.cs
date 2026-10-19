using HutongGames.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [CustomEditor(typeof(GlobalVariableTextBinding))]
    [CanEditMultipleObjects]
    internal sealed class GlobalVariableTextBindingEditor : UnityEditor.Editor
    {
        private const string UssGuid = "7821acb3fab9462b9ee0cefb2659e464";

        private static readonly System.Reflection.FieldInfo GlobalVariableField =
            typeof(GlobalVariableTextBinding).GetField(
                "_globalVariable",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

        private VisualElement _root;
        private VisualElement _debugValueHost;
        private VisualElement _listFormattingContainer;

        public override VisualElement CreateInspectorGUI()
        {
            _root = new VisualElement();
            EditorThemes.ApplyCurrentTheme(_root);
            UITK.LoadStyleSheet(_root, UssGuid);
            
            var globalVariableProp = serializedObject.FindProperty("_globalVariable");
            var tmpTextProp = serializedObject.FindProperty("_tmpText");
            var uiTextProp = serializedObject.FindProperty("_uiText");
            var formatProp = serializedObject.FindProperty("_format");
            var itemFormatProp = serializedObject.FindProperty("_itemFormat");
            var listSeparatorProp = serializedObject.FindProperty("_listSeparator");

            _root.Add(new PropertyField(globalVariableProp));

            _debugValueHost = new VisualElement();
            _root.Add(_debugValueHost);

            _root.Add(new PropertyField(tmpTextProp, "TMP Text"));
            _root.Add(new PropertyField(uiTextProp, "UI Text"));
            _root.Add(new PropertyField(formatProp));

            _listFormattingContainer = new VisualElement();
            _listFormattingContainer.Add(new PropertyField(itemFormatProp));
            _listFormattingContainer.Add(new PropertyField(listSeparatorProp));
            _root.Add(_listFormattingContainer);

            _root.Add(new HelpBox(
                "Use Refresh Preview to update the bound text in edit mode.",
                HelpBoxMessageType.Info));

            var refreshButton = new Button(RefreshTargets)
            {
                text = "Refresh Preview"
            };
            _root.Add(refreshButton);

            _root.Bind(serializedObject);
            _root.TrackPropertyValue(globalVariableProp, _ => RefreshDynamicUi());
            _root.TrackSerializedObjectValue(serializedObject, _ => RefreshDynamicUi());

            RefreshDynamicUi();

            return _root;
        }

        private void RefreshDynamicUi()
        {
            RefreshListFormattingVisibility();
            RefreshDebugInfo();
        }

        private void RefreshListFormattingVisibility()
        {
            if (_listFormattingContainer == null)
                return;

            _listFormattingContainer.style.display = ShouldShowListFormatting()
                ? DisplayStyle.Flex
                : DisplayStyle.None;
        }

        private void RefreshDebugInfo()
        {
            if (_debugValueHost == null)
                return;

            _debugValueHost.Clear();

            if (serializedObject.isEditingMultipleObjects)
            {
                _debugValueHost.style.display = DisplayStyle.None;
                return;
            }

            if (target is not GlobalVariableTextBinding binding)
            {
                _debugValueHost.style.display = DisplayStyle.None;
                return;
            }

            var globalVariable = GetGlobalVariable(binding);
            if (globalVariable?.Variable == null)
            {
                _debugValueHost.style.display = DisplayStyle.None;
                return;
            }

            var variable = globalVariable.Variable;
            var debugValueField = new DebugValueField(variable);
            debugValueField.style.paddingLeft = 0;
            debugValueField.style.paddingRight = 0;
            _debugValueHost.Add(debugValueField);
            _debugValueHost.style.display = DisplayStyle.Flex;
        }

        private bool ShouldShowListFormatting()
        {
            var hasBinding = false;

            foreach (var obj in targets)
            {
                if (obj is not GlobalVariableTextBinding binding)
                    continue;

                hasBinding = true;

                var globalVariable = GetGlobalVariable(binding);
                if (globalVariable?.Variable is not IListVariable)
                    return false;
            }

            return hasBinding;
        }

        private static GlobalVariableAsset GetGlobalVariable(GlobalVariableTextBinding binding)
        {
            return GlobalVariableField?.GetValue(binding) as GlobalVariableAsset;
        }

        private void RefreshTargets()
        {
            foreach (var obj in targets)
            {
                if (obj is not GlobalVariableTextBinding binding)
                    continue;

                binding.Refresh();
                EditorUtility.SetDirty(binding);
            }

            RefreshDynamicUi();
        }
    }
}

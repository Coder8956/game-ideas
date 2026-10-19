using System;
using System.Collections.Generic;
using HutongGames.Editor;
using HutongGames.Extensions;
using HutongGames.PlayMaker.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    internal sealed class DataUIBindingsEditor
    {
        private const string DefaultUssGuid = "d510bb6596344f2aa32e08bc9fec3fbb";
        private const string UssClassName = "hutong-data-row-view-editor";

        private const string DefinitionUssClassName = UssClassName + "__definition";
        private const string DefinitionHelpUssClassName = UssClassName + "__definition-help";
        private const string AutoBindUssClassName = UssClassName + "__auto-bind";
        private const string ButtonsRowUssClassName = UssClassName + "__buttons-row";
        private const string TitleUssClassName = UssClassName + "__title";
        private const string BindingsContainerUssClassName = UssClassName + "__bindings-container";
        private const string BindingContainerUssClassName = UssClassName + "__binding-container";
        private const string BindingHeaderUssClassName = UssClassName + "__binding-header";
        private const string BindingIconUssClassName = UssClassName + "__binding-icon";
        private const string BindingNameUssClassName = UssClassName + "__binding-name";
        private const string BindingUssClassName = UssClassName + "__binding";
        private const string KindRowUssClassName = UssClassName + "__kind-row";
        private const string KindLabelUssClassName = UssClassName + "__kind-label";
        private const string KindDropdownUssClassName = UssClassName + "__kind-dropdown";
        private const string OrphanLabelUssClassName = UssClassName + "__orphan-label";

        private const string UiAutoBindPropName = "_autoBind";
        private const string UiBindingsPropName = "_bindings";

        private const string BindingFieldGuidPropName = "FieldGuid";
        private const string BindingTargetPropName = "Target";

        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        private SerializedObject _so;
        private SerializedProperty _uiProp;
        private SerializedProperty _autoBindProp;
        private SerializedProperty _bindingsProp;

        private SerializedProperty _definitionProp;               // optional (DataItemUI)
        private Func<DataDefinition> _getResolvedDefinition;      // optional (DataComponentUI)

        private Func<GameObject> _getAutoBindRoot;
        private Func<Type, Type, IDataFieldTarget> _createDefaultTarget;

        private VisualElement _root;
        private Label _title;
        private VisualElement _bindingsContainer;
        private HelpBox _infoBox;

        private VisualElement _buttonsRow;
        private Button _syncBtn;
        private Button _removeOrphansBtn;

        public VisualElement Build(
            SerializedObject so,
            SerializedProperty uiProp,
            Func<GameObject> getAutoBindRoot,
            Func<Type, Type, IDataFieldTarget> createDefaultTarget,
            SerializedProperty definitionProp = null,
            Func<DataDefinition> getResolvedDefinition = null,
            bool showDefinitionPicker = true,
            string ussGuid = DefaultUssGuid)
        {
            _so = so;
            _uiProp = uiProp;
            _definitionProp = definitionProp;
            _getResolvedDefinition = getResolvedDefinition;

            _getAutoBindRoot = getAutoBindRoot;
            _createDefaultTarget = createDefaultTarget;

            _autoBindProp = _uiProp?.FindPropertyRelative(UiAutoBindPropName);
            _bindingsProp = _uiProp?.FindPropertyRelative(UiBindingsPropName);

            _root = new VisualElement();
            _root.AddToClassList(UssClassName);
            UITK.LoadEditorStyles(_root);
            UITK.LoadStyleSheet(_root, ussGuid);

            if (_uiProp == null || _autoBindProp == null || _bindingsProp == null)
            {
                _root.Add(new HelpBox(
                    "DataUIBindingsEditor: Could not find required properties. Expected DataUIBindings to contain: _autoBind, _bindings.",
                    HelpBoxMessageType.Error));
                return _root;
            }

            // Optional definition picker (DataItemUI)
            PropertyField defField = null;
            if (showDefinitionPicker && _definitionProp != null)
            {
                defField = new PropertyField(_definitionProp, "Data Definition");
                defField.AddToClassList(DefinitionUssClassName);
                _root.Add(defField);
            }

            _infoBox = new HelpBox("", HelpBoxMessageType.Info);
            _infoBox.AddToClassList(DefinitionHelpUssClassName);
            _infoBox.style.display = DisplayStyle.None;
            _root.Add(_infoBox);

            // Auto-bind
            var autoBindField = new PropertyField(_autoBindProp, "Auto-bind");
            autoBindField.AddToClassList(AutoBindUssClassName);
            _root.Add(autoBindField);

            // Buttons row
            _buttonsRow = new VisualElement();
            _buttonsRow.AddToClassList(ButtonsRowUssClassName);

            _syncBtn = new Button(() =>
            {
                SyncBindingsToSchema(createMissingTargets: false);
                RebuildBindingsUI();
            })
            {
                text = "Sync To Definition"
            };

            _removeOrphansBtn = new Button(() =>
            {
                RemoveOrphans();
                RebuildBindingsUI();
            })
            {
                text = "Remove Orphans"
            };

            _buttonsRow.Add(_syncBtn);
            _buttonsRow.Add(_removeOrphansBtn);
            _root.Add(_buttonsRow);

            _title = new Label();
            _title.AddToClassList(TitleUssClassName);
            _root.Add(_title);

            _bindingsContainer = new VisualElement();
            _bindingsContainer.AddToClassList(BindingsContainerUssClassName);
            _root.Add(_bindingsContainer);

            // Initial build
            RebuildSchemaCache();
            SyncBindingsToSchema(createMissingTargets: false);
            TryAutoBindIfEnabled();
            RebuildBindingsUI();

            // React to definition changes (only if we have a picker)
            defField?.RegisterValueChangeCallback(_ =>
            {
                RebuildSchemaCache();
                RemoveOrphans();
                SyncBindingsToSchema(createMissingTargets: false);
                TryAutoBindIfEnabled();
                RebuildBindingsUI();
            });

            autoBindField.RegisterValueChangeCallback(_ =>
            {
                TryAutoBindIfEnabled();
                RebuildBindingsUI();
            });

            return _root;
        }

        private DataDefinition GetDefinition()
        {
            var def = _getResolvedDefinition?.Invoke();
            if (def != null) return def;

            return _definitionProp != null ? _definitionProp.objectReferenceValue as DataDefinition : null;
        }

        private void RebuildSchemaCache()
        {
            _so.Update();
            _schemaFields.Clear();

            var def = GetDefinition();
            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);
        }

        private void SyncBindingsToSchema(bool createMissingTargets)
        {
            _so.Update();

            if (_bindingsProp == null || !_bindingsProp.isArray)
            {
                _so.ApplyModifiedProperties();
                return;
            }

            var def = GetDefinition();
            if (def == null)
            {
                _so.ApplyModifiedProperties();
                return;
            }

            Undo.RecordObjects(_so.targetObjects, "Sync Data UI Bindings");

            SchemaStoreListUtility.SyncToSchema(
                _schemaFields,
                _bindingsProp,
                createStore: createMissingTargets && _createDefaultTarget != null
                    ? f => _createDefaultTarget(f.DataType, f.SubType)
                    : (Func<DataSchemaUtility.SchemaField, object>)null,
                fieldGuidPropName: BindingFieldGuidPropName,
                storePropName: BindingTargetPropName);

            _so.ApplyModifiedProperties();
            MarkTargetsDirty(_so);
        }

        private void RemoveOrphans()
        {
            _so.Update();

            if (_bindingsProp == null || !_bindingsProp.isArray)
            {
                _so.ApplyModifiedProperties();
                return;
            }

            Undo.RecordObjects(_so.targetObjects, "Remove Orphan Data UI Bindings");

            var schemaSet = SchemaStoreListUtility.BuildSchemaGuidSet(_schemaFields);
            SchemaStoreListUtility.RemoveOrphans(_bindingsProp, schemaSet, fieldGuidPropName: BindingFieldGuidPropName);

            _so.ApplyModifiedProperties();
            MarkTargetsDirty(_so);
        }

        private void RebuildBindingsUI()
        {
            _bindingsContainer.Clear();
            _so.Update();

            var def = GetDefinition();
            _title.text = def != null ? def.name : "No Definition";

            if (def == null)
            {
                _infoBox.text = "Assign a Data Definition (or provide a source that supplies one) to edit UI bindings.";
                _infoBox.messageType = HelpBoxMessageType.Info;
                _infoBox.style.display = DisplayStyle.Flex;
                _buttonsRow?.Hide();

                if (_bindingsProp is { isArray: true, arraySize: > 0 })
                    _bindingsContainer.Add(new PropertyField(_bindingsProp, "Bindings (Raw)"));

                return;
            }

            if (_schemaFields.Count == 0)
            {
                _infoBox.text = "The resolved Data Definition has no fields.";
                _infoBox.messageType = HelpBoxMessageType.Info;
                _infoBox.style.display = DisplayStyle.Flex;
                _buttonsRow?.Hide();
                return;
            }

            var schemaSet = SchemaStoreListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphans = SchemaStoreListUtility.CollectOrphanIndices(_bindingsProp, schemaSet, fieldGuidPropName: BindingFieldGuidPropName);

            _infoBox.style.display = orphans.Count > 0 ? DisplayStyle.Flex : DisplayStyle.None;
            if (orphans.Count > 0)
            {
                _infoBox.text = $"There are {orphans.Count} orphan binding(s) (field no longer exists in the definition).";
                _infoBox.messageType = HelpBoxMessageType.Warning;
            }

            RefreshButtonVisibility(schemaSet);

            for (int i = 0; i < _bindingsProp.arraySize; i++)
            {
                var elem = _bindingsProp.GetArrayElementAtIndex(i);
                if (elem == null) continue;

                var guidProp = elem.FindPropertyRelative(BindingFieldGuidPropName);
                var targetProp = elem.FindPropertyRelative(BindingTargetPropName);
                if (guidProp == null || targetProp == null) continue;

                var guid = ReadGuid(guidProp);
                bool isOrphan = guid == SerializableGuid.None || !schemaSet.Contains(guid);

                string fieldName;
                string fieldTooltip;
                Type fieldType = null;
                Type fieldSubType = null;

                if (TryGetSchemaField(guid, out var sf))
                {
                    fieldName = sf.Name;
                    fieldTooltip = sf.Tooltip;
                    fieldType = sf.DataType;
                    fieldSubType = sf.SubType;
                }
                else
                {
                    fieldName = def.GetFieldNameOrFallback(guid);
                    fieldTooltip = "Field not found in Data Definition (orphan binding).";
                }

                _bindingsContainer.Add(MakeBindingRow(fieldName, fieldTooltip, isOrphan, targetProp, fieldType, fieldSubType));
            }
        }

        private void RefreshButtonVisibility(HashSet<SerializableGuid> schemaSet)
        {
            if (_buttonsRow != null) _buttonsRow.style.display = DisplayStyle.None;
            if (_syncBtn != null) _syncBtn.style.display = DisplayStyle.None;
            if (_removeOrphansBtn != null) _removeOrphansBtn.style.display = DisplayStyle.None;

            if (_bindingsProp == null || !_bindingsProp.isArray) return;
            if (_schemaFields.Count == 0) return;

            bool hasOrphans = false;
            bool isOutOfSync = false;

            var seen = new HashSet<SerializableGuid>();
            bool sawOrphan = false;
            int lastSchemaIndex = -1;

            for (int i = 0; i < _bindingsProp.arraySize; i++)
            {
                var elem = _bindingsProp.GetArrayElementAtIndex(i);
                var guidProp = elem?.FindPropertyRelative(BindingFieldGuidPropName);
                if (guidProp == null) continue;

                var guid = ReadGuid(guidProp);
                bool isSchemaGuid = guid != SerializableGuid.None && schemaSet.Contains(guid);

                if (!isSchemaGuid)
                {
                    hasOrphans = true;
                    sawOrphan = true;
                    continue;
                }

                if (sawOrphan) isOutOfSync = true;
                if (!seen.Add(guid)) isOutOfSync = true;

                int schemaIndex = GetSchemaIndex(guid);
                if (schemaIndex < 0 || schemaIndex < lastSchemaIndex)
                    isOutOfSync = true;
                else
                    lastSchemaIndex = schemaIndex;
            }

            bool showAny = false;

            if (hasOrphans) { _removeOrphansBtn?.Show(); showAny = true; }
            if (isOutOfSync) { _syncBtn?.Show(); showAny = true; }

            if (showAny) _buttonsRow?.Show();
        }

        private int GetSchemaIndex(SerializableGuid guid)
        {
            var (ga, gb) = guid.ToParts();
            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var f = _schemaFields[i];
                if (f.GuidA == ga && f.GuidB == gb)
                    return i;
            }
            return -1;
        }

        private VisualElement MakeBindingRow(string fieldName, string fieldTooltip, bool isOrphan,
            SerializedProperty targetProp, Type fieldType, Type fieldSubType)
        {
            var container = new VisualElement();
            container.AddToClassList(BindingContainerUssClassName);

            var header = new VisualElement();
            header.AddToClassList(BindingHeaderUssClassName);

            var icon = new VisualElement();
            icon.AddToClassList(BindingIconUssClassName);
            icon.style.backgroundImage = Icons.GetIcon(fieldType);
            header.Add(icon);

            var nameLabel = new Label(fieldName);
            nameLabel.AddToClassList(BindingNameUssClassName);
            nameLabel.tooltip = string.IsNullOrEmpty(fieldTooltip) ? null : fieldTooltip;
            header.Add(nameLabel);

            if (isOrphan)
            {
                var orphan = new Label("Orphan");
                orphan.AddToClassList(OrphanLabelUssClassName);
                header.Add(orphan);
            }

            container.Add(header);

            var body = new VisualElement();
            body.AddToClassList(BindingUssClassName);

            var kindRow = new VisualElement();
            kindRow.AddToClassList(KindRowUssClassName);

            var kindLabel = new Label("UI Binding");
            kindLabel.AddToClassList(KindLabelUssClassName);

            var inlineContainer = new VisualElement();
            inlineContainer.style.minWidth = 0;

            void RebuildInline()
            {
                inlineContainer.Clear();
                targetProp.serializedObject.Update();
                var inline = DrawTargetInline(targetProp);
                inline.style.minWidth = 0;
                inlineContainer.Add(inline);
            }

            var kindDropdown = MakeBindingKindDropdown(targetProp, isOrphan, fieldType, fieldSubType, RebuildInline);
            kindDropdown.AddToClassList(KindDropdownUssClassName);

            kindRow.Add(kindLabel);
            kindRow.Add(kindDropdown);

            body.Add(kindRow);
            body.Add(inlineContainer);

            RebuildInline();

            container.Add(body);
            return container;
        }

        // ---------------------------------------------------------------------
        // Auto-bind
        // ---------------------------------------------------------------------

        private void TryAutoBindIfEnabled()
        {
            _so.Update();

            if (_autoBindProp == null || !_autoBindProp.boolValue) return;
            if (_bindingsProp == null || !_bindingsProp.isArray) return;
            if (_schemaFields.Count == 0) return;

            var rootGo = _getAutoBindRoot?.Invoke();
            if (rootGo == null) return;

            // Cache lookups of components once.
            var tmpTexts = rootGo.GetComponentsInChildren<TMPro.TMP_Text>(true);
            var uguiTexts = rootGo.GetComponentsInChildren<UnityEngine.UI.Text>(true);
            var toggles = rootGo.GetComponentsInChildren<UnityEngine.UI.Toggle>(true);
            var sliders = rootGo.GetComponentsInChildren<UnityEngine.UI.Slider>(true);
            var images = rootGo.GetComponentsInChildren<UnityEngine.UI.Image>(true);

            bool changed = false;

            Undo.RecordObjects(_so.targetObjects, "Auto-bind Data UI");

            for (int i = 0; i < _bindingsProp.arraySize; i++)
            {
                var elem = _bindingsProp.GetArrayElementAtIndex(i);
                if (elem == null) continue;

                var guidProp = elem.FindPropertyRelative(BindingFieldGuidPropName);
                var targetProp = elem.FindPropertyRelative(BindingTargetPropName);
                if (guidProp == null || targetProp == null) continue;

                var guid = ReadGuid(guidProp);

                // Skip orphan bindings (no schema field)
                if (!TryGetSchemaField(guid, out var sf))
                    continue;

                // 1) Create target if missing (but never overwrite)
                if (targetProp.managedReferenceValue == null && _createDefaultTarget != null)
                {
                    var newTarget = _createDefaultTarget(sf.DataType, sf.SubType);
                    if (newTarget != null)
                    {
                        targetProp.managedReferenceValue = newTarget;
                        changed = true;
                    }
                }

                // 2) Top-up missing references inside target (never overwrite)
                if (ApplyAutoTargetAssignmentIfEmpty(targetProp, sf.Name, tmpTexts, uguiTexts, toggles, sliders, images))
                    changed = true;
            }

            if (!changed)
                return;

            _so.ApplyModifiedProperties();
            MarkTargetsDirty(_so);
        }

        private static bool ApplyAutoTargetAssignmentIfEmpty(
            SerializedProperty targetProp,
            string fieldName,
            TMPro.TMP_Text[] tmpTexts,
            UnityEngine.UI.Text[] uguiTexts,
            UnityEngine.UI.Toggle[] toggles,
            UnityEngine.UI.Slider[] sliders,
            UnityEngine.UI.Image[] images)
        {
            if (string.IsNullOrEmpty(fieldName))
                return false;

            // TextTarget
            if (targetProp.managedReferenceValue is TextTarget)
            {
                var kindProp = targetProp.FindPropertyRelative("_componentKind");
                var tmpProp = targetProp.FindPropertyRelative("_tmpText");
                var uguiProp = targetProp.FindPropertyRelative("_uguiText");

                var tmpIsEmpty = tmpProp != null && tmpProp.objectReferenceValue == null;
                var uguiIsEmpty = uguiProp != null && uguiProp.objectReferenceValue == null;

                // Unknown kind? treat as TMP
                int kind = kindProp?.enumValueIndex ?? 0; // 0 TMP, 1 UGUI

                if (kind == 0 && tmpIsEmpty)
                {
                    var tmp =
                        FindByName(tmpTexts, fieldName) ??
                        FindByName(tmpTexts, fieldName + "Text") ??
                        FindByName(tmpTexts, fieldName + "Label");

                    if (tmp != null)
                    {
                        tmpProp.objectReferenceValue = tmp;
                        return true;
                    }
                }
                else if (kind == 1 && uguiIsEmpty)
                {
                    var ugui =
                        FindByName(uguiTexts, fieldName) ??
                        FindByName(uguiTexts, fieldName + "Text") ??
                        FindByName(uguiTexts, fieldName + "Label");

                    if (ugui != null)
                    {
                        uguiProp.objectReferenceValue = ugui;
                        return true;
                    }
                }

                // Fallback tries (TMP then UGUI), optionally switch kind
                if (tmpIsEmpty && kind != 0)
                {
                    var tmp =
                        FindByName(tmpTexts, fieldName) ??
                        FindByName(tmpTexts, fieldName + "Text") ??
                        FindByName(tmpTexts, fieldName + "Label");

                    if (tmp != null)
                    {
                        if (kindProp != null) kindProp.enumValueIndex = 0;
                        tmpProp.objectReferenceValue = tmp;
                        return true;
                    }
                }

                if (uguiIsEmpty && kind != 1)
                {
                    var ugui =
                        FindByName(uguiTexts, fieldName) ??
                        FindByName(uguiTexts, fieldName + "Text") ??
                        FindByName(uguiTexts, fieldName + "Label");

                    if (ugui != null)
                    {
                        if (kindProp != null) kindProp.enumValueIndex = 1;
                        uguiProp.objectReferenceValue = ugui;
                        return true;
                    }
                }

                return false;
            }

            // ToggleTarget
            if (targetProp.managedReferenceValue is ToggleTarget)
            {
                var toggleProp = targetProp.FindPropertyRelative("_toggle");
                if (toggleProp == null || toggleProp.objectReferenceValue != null)
                    return false;

                var t =
                    FindByName(toggles, fieldName) ??
                    FindByName(toggles, fieldName + "Toggle");

                if (t == null) return false;

                toggleProp.objectReferenceValue = t;
                return true;
            }

            // SliderTarget
            if (targetProp.managedReferenceValue is SliderTarget)
            {
                var sliderProp = targetProp.FindPropertyRelative("_slider");
                if (sliderProp == null || sliderProp.objectReferenceValue != null)
                    return false;

                var s =
                    FindByName(sliders, fieldName) ??
                    FindByName(sliders, fieldName + "Slider");

                if (s == null) return false;

                sliderProp.objectReferenceValue = s;
                return true;
            }

            // ImageSpriteTarget
            if (targetProp.managedReferenceValue is ImageSpriteTarget)
            {
                var imageProp = targetProp.FindPropertyRelative("_image");
                if (imageProp == null || imageProp.objectReferenceValue != null)
                    return false;

                var img =
                    FindByName(images, fieldName) ??
                    FindByName(images, fieldName + "Image") ??
                    FindByName(images, fieldName + "Icon");

                if (img == null) return false;

                imageProp.objectReferenceValue = img;
                return true;
            }

            return false;
        }

        private static T FindByName<T>(T[] components, string name) where T : Component
        {
            if (components == null || string.IsNullOrEmpty(name))
                return null;

            for (int i = 0; i < components.Length; i++)
            {
                var c = components[i];
                if (c == null) continue;

                if (string.Equals(c.name, name, StringComparison.Ordinal))
                    return c;
            }

            return null;
        }

        // ---------------------------------------------------------------------
        // Binding kind dropdown + inline target renderers
        // ---------------------------------------------------------------------

        private static DropdownField MakeBindingKindDropdown(
            SerializedProperty targetProp,
            bool isOrphan,
            Type fieldType,
            Type fieldSubType,
            Action onChanged)
        {
            // Keep this list small; targets can have internal dropdowns (TMP vs UGUI).
            var choices = new List<string> { "None", "Text", "Toggle", "Slider", "Image (Sprite)" };

            string current = GetBindingKindName(targetProp.managedReferenceValue);
            if (string.IsNullOrEmpty(current)) current = "None";

            var dd = new DropdownField(choices, current)
            {
                tooltip = "Choose which UI binding type to use for this field."
            };

            dd.RegisterValueChangedCallback(evt =>
            {
                if (isOrphan)
                    return;

                Undo.RecordObjects(targetProp.serializedObject.targetObjects, "Change UI Binding Type");

                targetProp.serializedObject.Update();

                targetProp.managedReferenceValue = evt.newValue switch
                {
                    "None" => null,
                    "Text" => new TextTarget(),
                    "Toggle" => new ToggleTarget(),
                    "Slider" => new SliderTarget(),
                    "Image (Sprite)" => new ImageSpriteTarget(),
                    _ => targetProp.managedReferenceValue
                };

                targetProp.serializedObject.ApplyModifiedProperties();
                MarkTargetsDirty(targetProp.serializedObject);

                onChanged?.Invoke();
            });

            return dd;
        }

        private static string GetBindingKindName(object target)
        {
            return target switch
            {
                null => "None",
                TextTarget => "Text",
                ToggleTarget => "Toggle",
                SliderTarget => "Slider",
                ImageSpriteTarget => "Image (Sprite)",
                _ => "Text"
            };
        }

        private static VisualElement DrawTargetInline(SerializedProperty targetProp)
        {
            if (targetProp.managedReferenceValue == null)
                return new HelpBox("No UI binding assigned.", HelpBoxMessageType.None);

            return targetProp.managedReferenceValue switch
            {
                TextTarget => DrawTextTarget(targetProp),
                ToggleTarget => DrawToggleTarget(targetProp),
                SliderTarget => DrawSliderTarget(targetProp),
                ImageSpriteTarget => DrawImageSpriteTarget(targetProp),
                _ => new PropertyField(targetProp, "UI Binding")
            };
        }

        private static VisualElement DrawTextTarget(SerializedProperty targetProp)
        {
            var kindProp = targetProp.FindPropertyRelative("_componentKind");
            var tmpProp = targetProp.FindPropertyRelative("_tmpText");
            var uguiProp = targetProp.FindPropertyRelative("_uguiText");
            var formatProp = targetProp.FindPropertyRelative("_format");
            var missingProp = targetProp.FindPropertyRelative("_missingValueText");

            var root = new VisualElement();

            // TMP
            var tmpField = new ObjectField("Text")
            {
                objectType = typeof(TMPro.TMP_Text),
                allowSceneObjects = true,
                tooltip = "Assign a TextMeshPro text component (recommended)."
            };
            tmpField.BindProperty(tmpProp);

            // UGUI
            var uguiField = new ObjectField("Text")
            {
                objectType = typeof(UnityEngine.UI.Text),
                allowSceneObjects = true,
                tooltip = "Assign a legacy uGUI Text component."
            };
            uguiField.BindProperty(uguiProp);

            root.Add(MakeTwoOptionComponentPicker(
                kindProp,
                kindLabel: "Component",
                kindTooltip: "Choose which text component type this binding writes to.",
                optionAField: tmpField,
                optionBField: uguiField));

            // Format
            var formatField = new TextField("Format")
            {
                tooltip = "Optional string.Format pattern. Uses the value as {0}. Example: {0:0.##} or HP: {0}."
            };
            formatField.BindProperty(formatProp);
            root.Add(formatField);

            // Missing value
            var missingField = new TextField("Missing")
            {
                tooltip = "Shown when the cell is missing, None, or null."
            };
            missingField.BindProperty(missingProp);
            root.Add(missingField);

            return root;
        }

        private static VisualElement DrawToggleTarget(SerializedProperty targetProp)
        {
            var toggleProp = targetProp.FindPropertyRelative("_toggle");

            var field = new ObjectField("Toggle")
            {
                objectType = typeof(UnityEngine.UI.Toggle),
                allowSceneObjects = true,
                tooltip = "Toggle that reflects the boolean value."
            };
            field.BindProperty(toggleProp);
            return field;
        }

        private static VisualElement DrawSliderTarget(SerializedProperty targetProp)
        {
            var sliderProp = targetProp.FindPropertyRelative("_slider");

            var field = new ObjectField("Slider")
            {
                objectType = typeof(UnityEngine.UI.Slider),
                allowSceneObjects = true,
                tooltip = "Slider that reflects numeric values."
            };
            field.BindProperty(sliderProp);
            return field;
        }

        private static VisualElement DrawImageSpriteTarget(SerializedProperty targetProp)
        {
            var imageProp = targetProp.FindPropertyRelative("_image");

            var field = new ObjectField("Image")
            {
                objectType = typeof(UnityEngine.UI.Image),
                allowSceneObjects = true,
                tooltip = "Image that displays the Sprite value."
            };
            field.BindProperty(imageProp);
            return field;
        }

        private static VisualElement MakeTwoOptionComponentPicker(
            SerializedProperty kindProp,
            string kindLabel,
            string kindTooltip,
            ObjectField optionAField,
            ObjectField optionBField)
        {
            var root = new VisualElement();
            root.style.minWidth = 0;
            root.style.flexDirection = FlexDirection.Column;

            var kindField = new EnumField(kindLabel);
            kindField.tooltip = kindTooltip;
            kindField.BindProperty(kindProp);

            root.Add(kindField);
            root.Add(optionAField);
            root.Add(optionBField);

            void RefreshVisibility()
            {
                // Assumes enum index 0 = A, 1 = B
                int idx = kindProp.enumValueIndex;
                bool showA = idx == 0;

                optionAField.style.display = showA ? DisplayStyle.Flex : DisplayStyle.None;
                optionBField.style.display = showA ? DisplayStyle.None : DisplayStyle.Flex;
            }

            kindField.RegisterValueChangedCallback(_ =>
            {
                kindProp.serializedObject.Update();
                RefreshVisibility();
            });

            RefreshVisibility();
            return root;
        }

        // ---------------------------------------------------------------------
        // Utilities
        // ---------------------------------------------------------------------

        private bool TryGetSchemaField(SerializableGuid guid, out DataSchemaUtility.SchemaField field)
        {
            field = default;
            if (guid == SerializableGuid.None) return false;

            var (ga, gb) = guid.ToParts();
            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var f = _schemaFields[i];
                if (f.GuidA == ga && f.GuidB == gb)
                {
                    field = f;
                    return true;
                }
            }
            return false;
        }

        private static SerializableGuid ReadGuid(SerializedProperty guidProp)
        {
            if (guidProp == null) return SerializableGuid.None;

            if (DataRowSerializedUtility.TryGetGuidParts(guidProp, out var a, out var b))
                return new SerializableGuid(a, b);

            return SerializableGuid.None;
        }

        private static void MarkTargetsDirty(SerializedObject so)
        {
            foreach (var t in so.targetObjects)
                EditorUtility.SetDirty(t);
        }
    }
}

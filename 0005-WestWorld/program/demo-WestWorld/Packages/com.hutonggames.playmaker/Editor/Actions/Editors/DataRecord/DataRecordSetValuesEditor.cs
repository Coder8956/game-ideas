using System.Collections.Generic;
using HutongGames.Editor;
using HutongGames.Editor.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataRecordSetValues))]
    public sealed class DataRecordSetValuesEditor : CustomActionEditor
    {
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        private VisualElement _panel;
        private DataRecordSetValues _action;
        private DataDefinitionWatcher _definitionWatcher;

        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        public override void BuildGUI()
        {
            AddField(nameof(DataRecordSetValues.Record));

            _action = (DataRecordSetValues)Target;

            _panel = new VisualElement();
            Add(_panel);

            _definitionWatcher = new DataDefinitionWatcher(
                Root,
                getDefinition: () => _action?.Record?.Value?.DataDefinition,
                onChanged: UpdateUI);

            _definitionWatcher.Subscribe();

            var recordProp = TargetProperty.FindPropertyRelative(nameof(DataRecordSetValues.Record));
            Root.TrackPropertyValue(recordProp, _ =>
            {
                _definitionWatcher.Subscribe();
                _definitionWatcher.RequestRefresh();
                NotifyActionChanged();
            });

            UpdateUI();
        }

        private void UpdateUI()
        {
            _panel.Clear();

            var def = _action?.Record?.Value?.DataDefinition;
            if (def == null)
            {
                _panel.Add(new HelpBox(
                    "Assign a DataRecord reference to build schema-driven inputs.",
                    HelpBoxMessageType.Info));
                return;
            }

            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);

            var so = TargetProperty.serializedObject;
            so.Update();

            var setValuesProp = TargetProperty.FindPropertyRelative(nameof(DataRecordSetValues.SetValues));
            if (setValuesProp == null)
                return;
            var fsm = setValuesProp.TryGetFsmOwner();

            // Sync FieldGuid->Value list to schema (create missing, reorder; keep orphans at end)
            SyncValuesToSchema(_schemaFields, setValuesProp);

            // Header
            var header = new Label("Set Record Values")
            {
                tooltip = "Inputs used to set values on the DataRecord. One input per field in the DataDefinition."
            };
            header.AddToClassList("hutong-field__header");
            _panel.Add(header);
            _panel.Add(Spacer(6));

            // Render schema fields in schema order
            var guidToIndex = SchemaStoreListUtility.BuildGuidToIndexMap(setValuesProp, fieldGuidPropName: nameof(DataFieldValue.FieldGuid));

            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var sf = _schemaFields[i];
                var guid = new SerializableGuid(sf.GuidA, sf.GuidB);

                if (!guidToIndex.TryGetValue(guid, out var idx))
                    continue;

                var elemProp = setValuesProp.GetArrayElementAtIndex(idx);
                if (elemProp == null)
                    continue;

                var valueProp = elemProp.FindPropertyRelative(nameof(DataFieldValue.Value));
                var valueObj = valueProp?.managedReferenceValue as IVariableVar;

                var metaData = new MemberMetaData
                {
                    DataType = sf.DataType,
                    DisplayName = sf.Name,
                    IsWriteOnly = false,
                    IsOptional = true
                };
                metaData.SetSubType(sf.SubType);
                metaData.UpdateTooltipData("");

                var field = new VariableVarField(valueObj, metaData, valueProp);
                field.RegisterTooltip(sf.Tooltip);
                _panel.Add(field);
                if (fsm != null && valueObj != null)
                    DebugValueField.Add(_panel, fsm, valueObj);
            }

            // Orphans section
            var schemaGuidSet = SchemaStoreListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaStoreListUtility.CollectOrphanIndices(
                setValuesProp,
                schemaGuidSet,
                fieldGuidPropName: nameof(DataFieldValue.FieldGuid));

            if (orphanIndices.Count > 0)
            {
                _panel.Add(Spacer(10));

                var orphanHeader = new Label("Orphaned Inputs")
                {
                    tooltip = "Inputs that no longer exist in the DataDefinition. These are kept to avoid losing connections."
                };
                orphanHeader.AddToClassList("hutong-field__header");
                _panel.Add(orphanHeader);

                _panel.Add(Spacer(6));

                for (int j = 0; j < orphanIndices.Count; j++)
                {
                    int idx = orphanIndices[j];

                    var elemProp = setValuesProp.GetArrayElementAtIndex(idx);
                    if (elemProp == null)
                        continue;

                    var valueProp = elemProp.FindPropertyRelative(nameof(DataFieldValue.Value));
                    var valueObj = valueProp?.managedReferenceValue as IVariableVar;

                    var metaData = new MemberMetaData
                    {
                        DataType = valueObj?.DataType ?? typeof(object),
                        DisplayName = "(Orphaned)",
                        IsWriteOnly = false,
                        IsOptional = true
                    };
                    metaData.SetSubType(valueObj?.SubType);
                    metaData.UpdateTooltipData("");

                    var field = new VariableVarField(valueObj, metaData, valueProp);
                    field.AddToClassList(OrphanedUssClassName);
                    _panel.Add(field);
                    if (fsm != null && valueObj != null)
                        DebugValueField.Add(_panel, fsm, valueObj);
                }

                _panel.Add(Spacer(6));

                var removeOrphansBtn = new Button(() =>
                {
                    so.Update();
                    SchemaStoreListUtility.RemoveOrphans(
                        setValuesProp,
                        schemaGuidSet,
                        fieldGuidPropName: nameof(DataFieldValue.FieldGuid));
                    so.ApplyModifiedProperties();
                    UpdateUI();
                })
                {
                    text = "Remove Orphans",
                    tooltip = "Remove inputs for fields that no longer exist in the DataDefinition.",
                    style =
                    {
                        width = 150,
                        alignSelf = Align.FlexEnd
                    }
                };

                _panel.Add(removeOrphansBtn);
            }

            so.ApplyModifiedProperties();
        }

        private static void SyncValuesToSchema(
            IReadOnlyList<DataSchemaUtility.SchemaField> schemaFields,
            SerializedProperty setValuesProp)
        {
            // Existing guid -> index
            var existing = new Dictionary<SerializableGuid, int>();

            for (int i = 0; i < setValuesProp.arraySize; i++)
            {
                var e = setValuesProp.GetArrayElementAtIndex(i);
                if (e == null) continue;

                var guidProp = e.FindPropertyRelative(nameof(DataFieldValue.FieldGuid));
                if (guidProp == null) continue;

                if (DataRowSerializedUtility.TryGetGuidParts(guidProp, out var a, out var b))
                    existing[new SerializableGuid(a, b)] = i;
            }

            var schemaGuids = new List<SerializableGuid>(schemaFields.Count);

            // Add missing schema fields
            for (int i = 0; i < schemaFields.Count; i++)
            {
                var f = schemaFields[i];
                var g = new SerializableGuid(f.GuidA, f.GuidB);
                if (g == SerializableGuid.None)
                    continue;

                schemaGuids.Add(g);

                if (existing.ContainsKey(g))
                    continue;

                int newIndex = setValuesProp.arraySize;
                setValuesProp.arraySize++;

                var newElem = setValuesProp.GetArrayElementAtIndex(newIndex);

                var guidProp = newElem.FindPropertyRelative(nameof(DataFieldValue.FieldGuid));
                if (guidProp != null)
                    DataRowInitUtility.SetSerializableGuid(guidProp, g);

                var valueProp = newElem.FindPropertyRelative(nameof(DataFieldValue.Value));
                if (valueProp != null)
                {
                    var vv = CreateVarForSchemaField(f);
                    valueProp.managedReferenceValue = vv;
                }
            }

            // Reorder to schema order; orphans remain at end
            for (int targetIndex = 0; targetIndex < schemaGuids.Count; targetIndex++)
            {
                var g = schemaGuids[targetIndex];
                int currentIndex = FindIndexByGuid(setValuesProp, g);

                if (currentIndex < 0 || currentIndex == targetIndex)
                    continue;

                setValuesProp.MoveArrayElement(currentIndex, targetIndex);
            }
        }

        private static IVariableVar CreateVarForSchemaField(DataSchemaUtility.SchemaField f)
        {
            return VariableFactory.CreateVariableVarForDataType(f.DataType, f.SubType);
        }

        private static int FindIndexByGuid(SerializedProperty setValuesProp, SerializableGuid guid)
        {
            var (ga, gb) = guid.ToParts();

            for (int i = 0; i < setValuesProp.arraySize; i++)
            {
                var e = setValuesProp.GetArrayElementAtIndex(i);
                if (e == null)
                    continue;

                var guidProp = e.FindPropertyRelative(nameof(DataFieldValue.FieldGuid));
                if (guidProp == null)
                    continue;

                if (DataRowSerializedUtility.TryGetGuidParts(guidProp, out var a, out var b))
                {
                    if (a == ga && b == gb)
                        return i;
                }
            }

            return -1;
        }

        private static VisualElement Spacer(int height)
        {
            var ve = new VisualElement();
            ve.style.height = height;
            return ve;
        }
    }
}


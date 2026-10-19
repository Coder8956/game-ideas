/*
using System.Collections.Generic;
using HutongGames;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMaker.Editor;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace MyNamespace
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataRecordAssetSetValues))]
    public sealed class DataRecordAssetSetValuesEditor : CustomActionEditor
    {
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        private VisualElement _panel;
        private DataRecordAssetSetValues _action;
        private DataDefinitionWatcher _definitionWatcher;

        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        public override void BuildGUI()
        {
            BuildDefaultGUI();

            _action = (DataRecordAssetSetValues)Target;

            _panel = new VisualElement();
            Add(_panel);

            // Watch the effective definition (instance definition if known, else fallback field)
            _definitionWatcher = new DataDefinitionWatcher(
                Root,
                getDefinition: () => _action?.Record?.Value?.DataDefinition ?? _action?.DataDefinition,
                onChanged: UpdateUI);

            _definitionWatcher.Subscribe();

            var instanceProp = TargetProperty.FindPropertyRelative(nameof(DataRecordAssetSetValues.Record));
            Root.TrackPropertyValue(instanceProp, _ =>
            {
                _definitionWatcher.Subscribe();
                _definitionWatcher.RequestRefresh();
            });

            var defProp = TargetProperty.FindPropertyRelative(nameof(DataRecordAssetSetValues.DataDefinition));
            Root.TrackPropertyValue(defProp, _ =>
            {
                _definitionWatcher.Subscribe();
                _definitionWatcher.RequestRefresh();
            });

            UpdateUI();
        }

        private void UpdateUI()
        {
            _panel.Clear();

            // Need a definition to build dynamic inputs
            var instance = _action.Record?.Value;
            var def = instance?.DataDefinition ?? _action.DataDefinition;
            if (def == null) return;

            // Schema fields in editor order
            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);

            var so = TargetProperty.serializedObject;
            so.Update();

            var setValuesProp = TargetProperty.FindPropertyRelative(nameof(DataRecordAssetSetValues.SetValues));
            if (setValuesProp == null)
                return;

            // Sync FieldGuid->Value list to schema (creates missing Value vars, reorders; keeps orphans at end)
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
            var guidToIndex = SchemaStoreListUtility.BuildGuidToIndexMap(setValuesProp);

            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var sf = _schemaFields[i];
                var guid = new SerializableGuid(sf.GuidA, sf.GuidB);

                if (!guidToIndex.TryGetValue(guid, out var idx))
                    continue;

                var elementProp = setValuesProp.GetArrayElementAtIndex(idx);
                if (elementProp == null)
                    continue;

                var valueProp = elementProp.FindPropertyRelative(nameof(DataRecordAssetSetValues.FieldValue.Value));
                var valueObj = valueProp?.managedReferenceValue as IVariableVar;

                var metaData = new MemberMetaData
                {
                    DataType = sf.DataType,
                    DisplayName = sf.Name,
                    IsWriteOnly = false,
                    IsOptional = true,
                };
                metaData.UpdateTooltipData("");
                metaData.SetSubType(sf.SubType);

                var field = new VariableVarField(valueObj, metaData, valueProp);
                _panel.Add(field);
            }

            // Orphans section (only if any exist)
            var schemaGuidSet = SchemaStoreListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaStoreListUtility.CollectOrphanIndices(setValuesProp, schemaGuidSet);

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

                    var elementProp = setValuesProp.GetArrayElementAtIndex(idx);
                    if (elementProp == null)
                        continue;

                    var valueProp = elementProp.FindPropertyRelative(nameof(DataRecordAssetSetValues.FieldValue.Value));
                    var valueObj = valueProp?.managedReferenceValue as IVariableVar;

                    var metaData = new MemberMetaData
                    {
                        DataType = valueObj?.DataType ?? typeof(object),
                        DisplayName = "(Orphaned)",
                        IsWriteOnly = false,
                    };
                    metaData.UpdateTooltipData("");

                    var field = new VariableVarField(valueObj, metaData, valueProp);
                    field.AddToClassList(OrphanedUssClassName);
                    _panel.Add(field);
                }

                _panel.Add(Spacer(6));

                var removeOrphansBtn = new Button(() =>
                {
                    so.Update();
                    SchemaStoreListUtility.RemoveOrphans(setValuesProp, schemaGuidSet);
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
                if (e == null)
                    continue;

                var guidProp = e.FindPropertyRelative(nameof(DataRecordAssetSetValues.FieldValue.FieldGuid));
                if (guidProp == null)
                    continue;

                if (DataRowSerializedUtility.TryGetGuidParts(guidProp, out var a, out var b))
                    existing[new SerializableGuid(a, b)] = i;
            }

            var schemaGuids = new List<SerializableGuid>(schemaFields.Count);

            // Add missing schema fields (create Value as IVariableVar)
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

                var guidProp = newElem.FindPropertyRelative(nameof(DataRecordAssetSetValues.FieldValue.FieldGuid));
                if (guidProp != null)
                    DataRowInitUtility.SetSerializableGuid(guidProp, g);

                var valueProp = newElem.FindPropertyRelative(nameof(DataRecordAssetSetValues.FieldValue.Value));
                if (valueProp != null)
                    valueProp.managedReferenceValue = VariableFactory.CreateVariableVarForDataType(f.DataType, f.SubType);
            }

            // Reorder to schema order; orphans remain at end
            // (We can reuse SchemaStoreListUtility's guid-to-index map logic, but reordering is easiest inline.)
            for (int targetIndex = 0; targetIndex < schemaGuids.Count; targetIndex++)
            {
                var g = schemaGuids[targetIndex];
                int currentIndex = FindIndexByGuid(setValuesProp, g);

                if (currentIndex < 0 || currentIndex == targetIndex)
                    continue;

                setValuesProp.MoveArrayElement(currentIndex, targetIndex);
            }
        }

        private static int FindIndexByGuid(SerializedProperty setValuesProp, SerializableGuid guid)
        {
            var (ga, gb) = guid.ToParts();

            for (int i = 0; i < setValuesProp.arraySize; i++)
            {
                var e = setValuesProp.GetArrayElementAtIndex(i);
                if (e == null)
                    continue;

                var guidProp = e.FindPropertyRelative(nameof(DataRecordAssetSetValues.FieldValue.FieldGuid));
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
*/

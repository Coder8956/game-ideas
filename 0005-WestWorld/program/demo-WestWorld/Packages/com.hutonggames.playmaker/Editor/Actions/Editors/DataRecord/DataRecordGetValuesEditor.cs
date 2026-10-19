using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataRecordGetValues))]
    public sealed class DataRecordGetValuesEditor : CustomActionEditor
    {
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        private VisualElement _panel;
        private DataRecordGetValues _action;
        private DataDefinitionWatcher _definitionWatcher;

        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        public override void BuildGUI()
        {
            AddField(nameof(DataRecordGetValues.Record));
            
            _action = (DataRecordGetValues)Target;

            _panel = new VisualElement();
            Add(_panel);

            _definitionWatcher = new DataDefinitionWatcher(
                Root,
                getDefinition: () => _action?.Record?.Value?.DataDefinition,
                onChanged: UpdateUI);

            _definitionWatcher.Subscribe();

            var recordProp = TargetProperty.FindPropertyRelative(nameof(DataRecordGetValues.Record));
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
                // Optional hint: can’t build dynamic UI until record is assigned
                var hint = new HelpBox(
                    "Assign a DataRecord reference to build schema-driven outputs.",
                    HelpBoxMessageType.Info);

                _panel.Add(hint);
                return;
            }

            // Build schema list in editor order
            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);

            var so = TargetProperty.serializedObject;
            so.Update();

            var storeValuesProp = TargetProperty.FindPropertyRelative(nameof(DataRecordGetValues.StoreValues));
            if (storeValuesProp == null)
                return;

            // Sync FieldGuid->Store list to schema
            SchemaStoreListUtility.SyncToSchema(_schemaFields, storeValuesProp);

            // Header
            var header = new Label("Store Record Values")
            {
                tooltip = "Variables to store values from the DataRecord. One output per field in the DataDefinition."
            };
            header.AddToClassList("hutong-field__header");
            _panel.Add(header);
            _panel.Add(Spacer(6));

            // Render schema fields (in schema order) + DebugValueField (schema only)
            var guidToIndex = SchemaStoreListUtility.BuildGuidToIndexMap(storeValuesProp);

            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var sf = _schemaFields[i];
                var guid = new SerializableGuid(sf.GuidA, sf.GuidB);

                if (!guidToIndex.TryGetValue(guid, out var idx))
                    continue;

                var fieldStoreProp = storeValuesProp.GetArrayElementAtIndex(idx);
                if (fieldStoreProp == null)
                    continue;

                var storeProp = fieldStoreProp.FindPropertyRelative(nameof(DataFieldStore.Store));
                var storeObj = storeProp?.managedReferenceValue as IVariableRef;

                var metaData = new MemberMetaData
                {
                    DataType = storeObj?.DataType ?? sf.DataType,
                    DisplayName = sf.Name,
                    IsWriteOnly = true,
                    IsOptional = true,
                };
                metaData.UpdateTooltipData("");

                var field = new VariableRefField(storeObj, metaData, storeProp);
                _panel.Add(field);

                // DebugValueField: schema fields only
                DebugValueField.Add(_panel, _action.State.Fsm, storeObj);
            }

            // Orphans section (only if any exist)
            var schemaGuidSet = SchemaStoreListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaStoreListUtility.CollectOrphanIndices(storeValuesProp, schemaGuidSet);

            if (orphanIndices.Count > 0)
            {
                _panel.Add(Spacer(10));

                var orphanHeader = new Label("Orphaned Outputs")
                {
                    tooltip = "Outputs that no longer exist in the DataDefinition. These are kept to avoid losing connections."
                };
                orphanHeader.AddToClassList("hutong-field__header");
                _panel.Add(orphanHeader);

                _panel.Add(Spacer(6));

                for (int j = 0; j < orphanIndices.Count; j++)
                {
                    int idx = orphanIndices[j];

                    var fieldStoreProp = storeValuesProp.GetArrayElementAtIndex(idx);
                    if (fieldStoreProp == null)
                        continue;

                    var storeProp = fieldStoreProp.FindPropertyRelative(nameof(DataFieldStore.Store));
                    var storeObj = storeProp?.managedReferenceValue as IVariableRef;

                    var metaData = new MemberMetaData
                    {
                        DataType = storeObj?.DataType ?? typeof(object),
                        DisplayName = "(Orphaned)",
                        IsWriteOnly = true,
                        IsOptional = true
                    };
                    metaData.UpdateTooltipData("");

                    var field = new VariableRefField(storeObj, metaData, storeProp);
                    field.AddToClassList(OrphanedUssClassName);
                    _panel.Add(field);
                }

                _panel.Add(Spacer(6));

                var removeOrphansBtn = new Button(() =>
                {
                    so.Update();
                    SchemaStoreListUtility.RemoveOrphans(storeValuesProp, schemaGuidSet);
                    so.ApplyModifiedProperties();
                    UpdateUI();
                })
                {
                    text = "Remove Orphans",
                    tooltip = "Remove outputs for fields that no longer exist in the DataDefinition.",
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

        private static VisualElement Spacer(int height)
        {
            var ve = new VisualElement();
            ve.style.height = height;
            return ve;
        }
    }
}

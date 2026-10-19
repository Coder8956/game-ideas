using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(GameObjectGetData))]
    public sealed class GameObjectGetDataEditor : CustomActionEditor
    {
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        private VisualElement _panel;
        private GameObjectGetData _action;

        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        public override void BuildGUI()
        {
            //BuildDefaultGUI();
            AddField(nameof(GameObjectGetData.GameObject));
            AddField(nameof(GameObjectGetData.DataDefinition));
            AddField(nameof(GameObjectGetData.StoreDefaultsIfMissing));
            
            _action = (GameObjectGetData)Target;

            _panel = new VisualElement();
            Add(_panel);

            // Rebuild on DataDefinition changes.
            var defProp = TargetProperty.FindPropertyRelative(nameof(GameObjectGetData.DataDefinition));
            if (defProp != null)
            {
                Root.TrackPropertyValue(defProp, _ =>
                {
                    UpdateUI();
                    NotifyActionChanged();
                });
            }

            UpdateUI();
            
            AddField(nameof(GameObjectGetData.NotFoundEvent));
            AddField(nameof(GameObjectGetData.UsedDefaults));
            AddField(nameof(GameObjectGetData.Succeeded));
        }

        private void UpdateUI()
        {
            // Important when rebuilding dynamic UI
            _panel.Unbind();
            _panel.Clear();

            var def = _action?.DataDefinition;
            if (def == null)
            {
                _panel.Add(new HelpBox(
                    "Assign a DataDefinition to build schema-driven outputs.",
                    HelpBoxMessageType.Info));
                return;
            }

            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);

            if (_schemaFields.Count == 0)
            {
                _panel.Add(new HelpBox("The selected DataDefinition has no fields.", HelpBoxMessageType.Info));
                return;
            }

            var so = TargetProperty.serializedObject;
            so.Update();

            var getValuesProp = TargetProperty.FindPropertyRelative(nameof(GameObjectGetData.GetValues));
            if (getValuesProp == null)
                return;

            var fieldGuidPropName = nameof(DataFieldStore.FieldGuid);
            var storePropName     = nameof(DataFieldStore.Store);

            // Sync FieldGuid->Store list to schema
            SchemaFieldOutputListUtility.SyncToSchema(
                _schemaFields,
                getValuesProp,
                fieldGuidPropName: fieldGuidPropName,
                storePropName: storePropName,
                createDefaultStoreWhenNull: true);

            // Apply so managedReference defaults exist for drawing
            so.ApplyModifiedProperties();
            so.Update();

            // Header
            var header = new Label("Store Data Values")
            {
                tooltip = "Variables to store values from the GameObject's Data Component.\n" +
                          "One output per field in the DataDefinition."
            };
            header.AddToClassList("hutong-field__header");
            _panel.Add(header);
            _panel.Add(Spacer(6));

            // Render schema fields (schema order)
            var guidToIndex = SchemaFieldOutputListUtility.BuildGuidToIndexMap(getValuesProp, fieldGuidPropName);

            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var sf = _schemaFields[i];
                var guid = new SerializableGuid(sf.GuidA, sf.GuidB);

                if (!guidToIndex.TryGetValue(guid, out var idx))
                    continue;

                var fieldProp = getValuesProp.GetArrayElementAtIndex(idx);
                if (fieldProp == null)
                    continue;

                var storeProp = fieldProp.FindPropertyRelative(storePropName);
                var storeObj = storeProp?.managedReferenceValue as IVariableRef;

                var metaData = new MemberMetaData
                {
                    DataType = storeObj?.DataType ?? sf.DataType,
                    DisplayName = sf.Name,
                    IsWriteOnly = true,
                    IsOptional = true,
                };
                metaData.UpdateTooltipData(sf.Tooltip ?? "");

                var field = new VariableRefField(storeObj, metaData, storeProp);
                _panel.Add(field);

                // Matches DataRecordGetValuesEditor behavior
                DebugValueField.Add(_panel, _action.State.Fsm, storeObj);
            }

            // Orphans
            var schemaGuidSet = SchemaFieldOutputListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaFieldOutputListUtility.CollectOrphanIndices(getValuesProp, schemaGuidSet, fieldGuidPropName);

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
                    var idx = orphanIndices[j];

                    var fieldProp = getValuesProp.GetArrayElementAtIndex(idx);
                    if (fieldProp == null)
                        continue;

                    var storeProp = fieldProp.FindPropertyRelative(storePropName);
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

                var removeBtn = new Button(() =>
                {
                    so.Update();
                    SchemaFieldOutputListUtility.RemoveOrphans(getValuesProp, schemaGuidSet, fieldGuidPropName);
                    so.ApplyModifiedProperties();
                    UpdateUI();
                })
                {
                    text = "Remove Orphans",
                    tooltip = "Remove outputs for fields that no longer exist in the DataDefinition.",
                    style = { width = 150, alignSelf = Align.FlexEnd }
                };

                _panel.Add(removeBtn);
            }

            so.ApplyModifiedProperties();

            // ✅ Helps with “first select” incomplete binding edge cases
            _panel.schedule.Execute(() =>
            {
                _panel.Unbind();
                _panel.Bind(so);
            });
        }

        private static VisualElement Spacer(int height)
        {
            var ve = new VisualElement();
            ve.style.height = height;
            return ve;
        }
    }
}

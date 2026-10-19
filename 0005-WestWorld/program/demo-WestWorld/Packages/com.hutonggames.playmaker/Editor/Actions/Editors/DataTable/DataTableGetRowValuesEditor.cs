using System.Collections.Generic;
using HutongGames.Editor;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableGetRowValues))]
    public sealed class DataTableGetRowValuesEditor: BaseDataTableWithOverrideEditor<DataTableGetRowValues>
    {
        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        protected override void BuildBeforeContentGUI()
        {
            AddField(nameof(DataTableGetRowValues.Row));
            AddField(nameof(DataTableGetRowValues.OnRowNotFound));
        }

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableGetRowValues.NotFoundEvent));
        }

        private static string StoreValuesFieldName => nameof(DataTableGetRowValues.StoreValues);
        
        private void TrackRowSelector()
        {
            var rowProp = TargetProperty.FindPropertyRelative(nameof(DataTableGetRowValues.Row));
            if (rowProp != null)
                Root.TrackPropertyValue(rowProp, _ => RequestRebuild());
        }

        public override void BuildGUI()
        {
            // Let the base build DataTable + DataDefinition + ContentRoot + override logic.
            base.BuildGUI();

            // Track changes on row selector so the UI refreshes when Key/Index changes.
            TrackRowSelector();
        }

        protected override void BuildTableUI(DataDefinition def)
        {
            ContentRoot.Clear();

            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);

            if (_schemaFields.Count == 0)
            {
                ContentRoot.Add(new HelpBox("The selected DataDefinition has no fields.", HelpBoxMessageType.Info));
                return;
            }

            var so = TargetProperty.serializedObject;
            so.Update();

            var storeValuesProp = TargetProperty.FindPropertyRelative(StoreValuesFieldName);
            if (storeValuesProp == null)
                return;
            
            SchemaStoreListUtility.SyncToSchema(_schemaFields, storeValuesProp);

            // Header
            var header = new Label("Store Row Values");
            header.RegisterTooltip(new TooltipInfo(
                "Store values from the selected row. " +
                "\nOne output per field in the DataDefinition.")
            {
                Hints="Alt Click dropdowns to auto-add variables."
            });
            header.AddToClassList("hutong-field__header");
            ContentRoot.Add(header);
            ContentRoot.AddSpacer(6);

            // Render schema fields (schema order) + DebugValueField
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
                ContentRoot.Add(field);

                DebugValueField.Add(ContentRoot, Target.State.Fsm, storeObj);
            }

            // Orphans
            var schemaGuidSet = SchemaStoreListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaStoreListUtility.CollectOrphanIndices(storeValuesProp, schemaGuidSet);

            if (orphanIndices.Count > 0)
            {
                ContentRoot.AddSpacer(10);

                var orphanHeader = new Label("Orphaned Outputs")
                {
                    tooltip = "Outputs that no longer exist in the DataDefinition. These are kept to avoid losing connections."
                };
                orphanHeader.AddToClassList("hutong-field__header");
                ContentRoot.Add(orphanHeader);

                ContentRoot.AddSpacer(6);

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
                        IsOptional = true,
                    };
                    metaData.UpdateTooltipData("");

                    var field = new VariableRefField(storeObj, metaData, storeProp);
                    field.AddToClassList(OrphanedUssClassName);
                    ContentRoot.Add(field);
                }

                ContentRoot.AddSpacer(6);

                var removeOrphansBtn = new Button(() =>
                {
                    so.Update();
                    SchemaStoreListUtility.RemoveOrphans(storeValuesProp, schemaGuidSet);
                    so.ApplyModifiedProperties();
                    // Rebuild the UI after removing
                    BuildTableUI(def);
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

                ContentRoot.Add(removeOrphansBtn);
            }

            so.ApplyModifiedProperties();
        }
    }
}

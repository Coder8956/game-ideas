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
    [CustomActionEditor(typeof(DataTableSetRowValues))]
    public sealed class DataTableSetRowValuesEditor : BaseDataTableWithOverrideEditor<DataTableSetRowValues>
    {
        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        private static string SetValuesFieldName => nameof(DataTableSetRowValues.SetValues);
        
        protected override void BuildBeforeContentGUI()
        {
            AddField(nameof(DataTableSetRowValues.Row));
            AddField(nameof(DataTableSetRowValues.AddIfMissing));
        }

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableSetRowValues.Succeeded));
            AddField(nameof(DataTableSetRowValues.Added));
            AddField(nameof(DataTableSetRowValues.NotFoundEvent));
        }

        private void TrackRowSelector()
        {
            var rowProp = TargetProperty.FindPropertyRelative(nameof(DataTableSetRowValues.Row));
            if (rowProp != null)
                Root.TrackPropertyValue(rowProp, _ => RequestRebuild());
        }

        public override void BuildGUI()
        {
            base.BuildGUI();
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

            var setValuesProp = TargetProperty.FindPropertyRelative(SetValuesFieldName);
            if (setValuesProp == null)
                return;
            var fsm = setValuesProp.TryGetFsmOwner();

            // Sync FieldGuid->SetValues list to schema (preserve existing value refs)
            SchemaFieldValueListUtility.SyncToSchema(_schemaFields, setValuesProp);

            // Header
            var header = new Label("Set Row Values");
            header.RegisterTooltip(new TooltipInfo(
                "Values to apply to the selected row. " +
                "\nOne input per field in the DataDefinition."));
            header.AddToClassList("hutong-field__header");
            ContentRoot.Add(header);
            ContentRoot.AddSpacer(6);

            var guidToIndex = SchemaFieldValueListUtility.BuildGuidToIndexMap(setValuesProp);

            // Schema fields
            for (var i = 0; i < _schemaFields.Count; i++)
            {
                var sf = _schemaFields[i];
                var guid = new SerializableGuid(sf.GuidA, sf.GuidB);

                if (!guidToIndex.TryGetValue(guid, out var idx))
                    continue;

                var fieldValueProp = setValuesProp.GetArrayElementAtIndex(idx);
                if (fieldValueProp == null)
                    continue;

                var valueProp = fieldValueProp.FindPropertyRelative(nameof(DataFieldValue.Value));
                var valueObj = valueProp?.managedReferenceValue as IVariableVar;

                // Ensure there is a correctly-typed input var object for this field.
                valueObj = EnsureInputVarForField(valueProp, valueObj, sf.DataType);

                var metaData = new MemberMetaData
                {
                    DataType = sf.DataType,
                    DisplayName = sf.Name,
                    IsWriteOnly = false,
                    IsOptional = true
                };
                metaData.UpdateTooltipData("");
                
                var field = new VariableVarField(valueObj, metaData, valueProp);
                ContentRoot.Add(field);
                if (fsm != null && valueObj != null)
                    DebugValueField.Add(ContentRoot, fsm, valueObj);
                
            }

            // Orphans
            //DrawOrphans(so, setValuesProp);

            so.ApplyModifiedProperties();
            
            Rebind(ContentRoot);
        }

        private IVariableVar EnsureInputVarForField(SerializedProperty valueProp, IVariableVar current, System.Type dataType)
        {
            if (valueProp == null) return current;

            // If it exists and matches, keep it.
            if (current != null && current.DataType == dataType)
                return current;

            // Create a new typed VariableVar<T> instance (constant by default).
            // Replace this with your actual factory.
            var created = VariableFactory.CreateVariableVarForDataType(dataType); // e.g. returns VariableVar<float>, EnumVar, TypeVar, etc.

            valueProp.managedReferenceValue = created;
            return created;
        }

        private void DrawOrphans(SerializedObject so, SerializedProperty setValuesProp)
        {
            var schemaGuidSet = SchemaFieldValueListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaFieldValueListUtility.CollectOrphanIndices(setValuesProp, schemaGuidSet);
            var fsm = setValuesProp.TryGetFsmOwner();

            if (orphanIndices.Count <= 0)
                return;

            ContentRoot.AddSpacer(10);

            var orphanHeader = new Label("Orphaned Inputs")
            {
                tooltip = "Inputs for fields that no longer exist in the DataDefinition. These are kept to avoid losing connections."
            };
            orphanHeader.AddToClassList("hutong-field__header");
            ContentRoot.Add(orphanHeader);

            ContentRoot.AddSpacer(6);

            for (var j = 0; j < orphanIndices.Count; j++)
            {
                var idx = orphanIndices[j];

                var fieldValueProp = setValuesProp.GetArrayElementAtIndex(idx);
                if (fieldValueProp == null)
                    continue;

                var valueProp = fieldValueProp.FindPropertyRelative(nameof(DataFieldValue.Value));
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
                ContentRoot.Add(field);
                if (fsm != null && valueObj != null)
                    DebugValueField.Add(ContentRoot, fsm, valueObj);
            }

            ContentRoot.AddSpacer(6);

            var removeOrphansBtn = new Button(() =>
            {
                so.Update();
                SchemaFieldValueListUtility.RemoveOrphans(setValuesProp, schemaGuidSet);
                so.ApplyModifiedProperties();
                BuildTableUI(Action.DataTable.GetEditTimeDataDefinition() ?? Action.DataDefinition);
            })
            {
                text = "Remove Orphans",
                tooltip = "Remove inputs for fields that no longer exist in the DataDefinition.",
                style = { width = 150, alignSelf = Align.FlexEnd }
            };

            ContentRoot.Add(removeOrphansBtn);
        }
    }
}


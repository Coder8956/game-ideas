using System.Collections.Generic;
using HutongGames.Editor.Extensions;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableAddRow))]
    public sealed class DataTableAddRowEditor : BaseDataTableWithOverrideEditor<DataTableAddRow>
    {
        private const string OrphanedUssClassName = "hutong-field--orphaned";

        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        protected override void BuildBeforeContentGUI()
        {
            AddField(nameof(DataTableAddRow.Key));
        }
        
        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableAddRow.Index));
            AddField(nameof(DataTableAddRow.Added));
        }

        protected override void BuildTableUI(DataDefinition def)
        {
            DataSchemaUtility.BuildSchemaFieldsInEditorOrder(def, _schemaFields);

            if (_schemaFields.Count == 0)
            {
                ContentRoot.Add(new HelpBox("The selected DataDefinition has no fields.", HelpBoxMessageType.Info));
                return;
            }

            var so = TargetProperty.serializedObject;
            so.Update();

            var setValuesProp = TargetProperty.FindPropertyRelative(nameof(DataTableAddRow.SetValues));
            if (setValuesProp == null) return;
            var fsm = setValuesProp.TryGetFsmOwner();

            var fieldGuidPropName = nameof(DataFieldValue.FieldGuid);
            SchemaFieldValueListUtility.SyncToSchema(
                _schemaFields,
                setValuesProp,
                fieldGuidPropName: fieldGuidPropName,
                valuePropName: nameof(DataFieldValue.Value));
            
            so.ApplyModifiedProperties();
            so.Update();

            var header = new Label("Set Field Values")
            {
                tooltip = "Values to assign to the new row. One entry per field in the DataDefinition."
            };
            header.AddToClassList("hutong-field__header");
            ContentRoot.Add(header);

            ContentRoot.Add(Spacer(6));

            // Render in schema order
            var guidToIndex = SchemaFieldValueListUtility.BuildGuidToIndexMap(setValuesProp, fieldGuidPropName);

            for (int i = 0; i < _schemaFields.Count; i++)
            {
                var sf = _schemaFields[i];
                var guid = new SerializableGuid(sf.GuidA, sf.GuidB);

                if (!guidToIndex.TryGetValue(guid, out var idx))
                    continue;

                var fvProp = setValuesProp.GetArrayElementAtIndex(idx);
                if (fvProp == null) continue;

                var valueProp = fvProp.FindPropertyRelative(nameof(DataFieldValue.Value));
                var valueObj = valueProp?.managedReferenceValue as IVariableVar;

                var meta = new MemberMetaData
                {
                    DataType = valueObj?.DataType ?? sf.DataType,
                    SubType = valueObj?.SubType ?? sf.SubType,
                    DisplayName = sf.Name
                };
                meta.UpdateTooltipData(sf.Tooltip ?? "");

                // TODO: replace VariableVarField with your actual PM2 field for IVariableVar
                var field = new VariableVarField(valueObj, meta, valueProp);
                ContentRoot.Add(field);
                if (fsm != null && valueObj != null)
                    DebugValueField.Add(ContentRoot, fsm, valueObj);
            }

            // Orphans
            var schemaGuidSet = SchemaFieldValueListUtility.BuildSchemaGuidSet(_schemaFields);
            var orphanIndices = SchemaFieldValueListUtility.CollectOrphanIndices(
                setValuesProp, schemaGuidSet, fieldGuidPropName);

            if (orphanIndices.Count > 0)
            {
                ContentRoot.Add(Spacer(10));

                var orphanHeader = new Label("Orphaned Values")
                {
                    tooltip = "Values for fields that no longer exist in the DataDefinition. Kept to avoid losing data."
                };
                orphanHeader.AddToClassList("hutong-field__header");
                ContentRoot.Add(orphanHeader);

                ContentRoot.Add(Spacer(6));

                for (int j = 0; j < orphanIndices.Count; j++)
                {
                    var idx = orphanIndices[j];
                    var fvProp = setValuesProp.GetArrayElementAtIndex(idx);
                    if (fvProp == null) continue;

                    var valueProp = fvProp.FindPropertyRelative(nameof(DataFieldValue.Value));
                    var valueObj = valueProp?.managedReferenceValue as IVariableVar;

                    var meta = new MemberMetaData
                    {
                        DataType = valueObj?.DataType ?? typeof(object),
                        DisplayName = "(Orphaned)"
                    };
                    meta.UpdateTooltipData("");

                    var field = new VariableVarField(valueObj, meta, valueProp);
                    field.AddToClassList(OrphanedUssClassName);
                    ContentRoot.Add(field);
                    if (fsm != null && valueObj != null)
                        DebugValueField.Add(ContentRoot, fsm, valueObj);
                }

                ContentRoot.Add(Spacer(6));

                var removeBtn = new Button(() =>
                {
                    so.Update();
                    SchemaFieldValueListUtility.RemoveOrphans(setValuesProp, schemaGuidSet, fieldGuidPropName);
                    so.ApplyModifiedProperties();
                    RequestRebuild(); // correct: clears and rebuilds ContentRoot
                })
                {
                    text = "Remove Orphans",
                    tooltip = "Remove values for fields that no longer exist in the DataDefinition.",
                    style = { width = 150, alignSelf = Align.FlexEnd }
                };

                ContentRoot.Add(removeBtn);
            }
            
            // Bind AFTER UI exists. Scheduling avoids "first attach" timing issues.
            ContentRoot.schedule.Execute(() =>
            {
                ContentRoot.Unbind();      // safe if Unity auto-bound something earlier
                ContentRoot.Bind(so);
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

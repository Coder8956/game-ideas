using System;
using System.Collections.Generic;
using HutongGames.Editor;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableGetCellValue))]
    public sealed class DataTableGetCellValueEditor : BaseDataTableWithOverrideEditor<DataTableGetCellValue>
    {
        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        protected override void BuildBeforeContentGUI()
        {
            AddField(nameof(DataTableGetCellValue.Row));
            AddField(nameof(DataTableGetCellValue.OnNotFound));
        }

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableGetCellValue.Found));
            AddField(nameof(DataTableGetCellValue.NotFoundEvent));
        }

        private static string StoreValueFieldName => nameof(DataTableGetCellValue.StoreValue);

        private void TrackRowSelector()
        {
            var rowProp = TargetProperty.FindPropertyRelative(nameof(DataTableGetCellValue.Row));
            if (rowProp != null)
                Root.TrackPropertyValue(rowProp, _ => RequestRebuild());

            var storeValueProp = TargetProperty.FindPropertyRelative(StoreValueFieldName);
            var fieldGuidProp = storeValueProp?.FindPropertyRelative(nameof(DataFieldStore.FieldGuid));
            if (fieldGuidProp != null)
                Root.TrackPropertyValue(fieldGuidProp, _ => RequestRebuild());
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

            var storeValueProp = TargetProperty.FindPropertyRelative(StoreValueFieldName);
            if (storeValueProp == null)
                return;

            var header = new Label("Store Cell Value");
            header.RegisterTooltip(new TooltipInfo(
                "Store values from the selected row. " +
                "\nOne output per field in the DataDefinition."));
            header.AddToClassList("hutong-field__header");
            ContentRoot.Add(header);
            ContentRoot.AddSpacer(6);

            var cellValue = new DataFieldStoreEditor(Target.Fsm, def, storeValueProp);
            ContentRoot.Add(cellValue);

            var defaultValueProp = TargetProperty.FindPropertyRelative(nameof(DataTableGetCellValue.DefaultValue));
            DrawDefaultValueField(storeValueProp, defaultValueProp);

            so.ApplyModifiedProperties();
            Rebind(ContentRoot);
        }

        private void DrawDefaultValueField(SerializedProperty storeValueProp, SerializedProperty defaultValueProp)
        {
            if (storeValueProp == null || defaultValueProp == null)
                return;

            var fieldGuidProp = storeValueProp.FindPropertyRelative(nameof(DataFieldStore.FieldGuid));
            if (fieldGuidProp == null)
                return;

            var selectedType = ResolveSelectedFieldType((SerializableGuid)fieldGuidProp.boxedValue);
            if (selectedType == null)
                return;

            var current = defaultValueProp.managedReferenceValue as IVariableVar;
            current = EnsureInputVarForField(defaultValueProp, current, selectedType);

            var metaData = new MemberMetaData
            {
                DataType = selectedType,
                DisplayName = "Default Value",
                IsWriteOnly = false,
                IsOptional = true
            };
            metaData.UpdateTooltipData("Optional. Used when the row or field is not found. Takes precedence over On Not Found behavior.");

            ContentRoot.AddSpacer(6);
            ContentRoot.Add(new VariableVarField(current, metaData, defaultValueProp));
        }

        private Type ResolveSelectedFieldType(SerializableGuid fieldGuid)
        {
            if (fieldGuid == SerializableGuid.None)
                return null;

            for (var i = 0; i < _schemaFields.Count; i++)
            {
                var field = _schemaFields[i];
                if (fieldGuid != new SerializableGuid(field.GuidA, field.GuidB))
                    continue;

                return field.SubType ?? field.DataType;
            }

            return null;
        }

        private static IVariableVar EnsureInputVarForField(SerializedProperty valueProp, IVariableVar current, Type dataType)
        {
            if (valueProp == null)
                return current;

            if (current != null && current.DataType == dataType)
                return current;

            var created = VariableFactory.CreateVariableVarForDataType(dataType);
            valueProp.managedReferenceValue = created;
            return created;
        }
    }
}

using System;
using System.Collections.Generic;
using HutongGames.Editor;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    [UsedImplicitly]
    [CustomActionEditor(typeof(DataTableSetCellValue))]
    public sealed class DataTableSetCellValueEditor : BaseDataTableWithOverrideEditor<DataTableSetCellValue>
    {
        private readonly List<DataSchemaUtility.SchemaField> _schemaFields = new();

        private static string SetValueFieldName => nameof(DataTableSetCellValue.SetValue);
        
        protected override void BuildBeforeContentGUI()
        {
            AddField(nameof(DataTableSetRowValues.Row));
            AddField(nameof(DataTableSetRowValues.AddIfMissing));
        }

        protected override void BuildAfterContentGUI()
        {
            AddField(nameof(DataTableSetCellValue.Succeeded));
            AddField(nameof(DataTableSetCellValue.Added));
            AddField(nameof(DataTableSetCellValue.NotFoundEvent));
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
            
            var setValueProp = TargetProperty.FindPropertyRelative(SetValueFieldName);
            if (setValueProp == null)
                return;

            // Header
            var header = new Label("Set Cell Value");
            header.AddToClassList("hutong-field__header");
            ContentRoot.Add(header);
            ContentRoot.AddSpacer(6);

            var cellValue = new DataFieldValueEditor(def, setValueProp, guid => ResolveSelectedValueType(guid));
            ContentRoot.Add(cellValue);

            so.ApplyModifiedProperties();
        }

        private Type ResolveSelectedValueType(SerializableGuid fieldGuid)
        {
            var typeFromCell = GetTypeFromSelectedRowCell(fieldGuid);
            if (typeFromCell != null)
                return typeFromCell;

            for (var i = 0; i < _schemaFields.Count; i++)
            {
                var field = _schemaFields[i];
                if (fieldGuid != new SerializableGuid(field.GuidA, field.GuidB))
                    continue;

                return field.SubType ?? field.DataType;
            }

            return null;
        }

        private Type GetTypeFromSelectedRowCell(SerializableGuid fieldGuid)
        {
            var table = Action.DataTable.ResolveData();
            if (table == null)
                return null;

            var row = Action.Row.Resolve(table);
            var cells = row?.Cells;
            if (cells == null)
                return null;

            for (var i = 0; i < cells.Count; i++)
            {
                var cell = cells[i];
                if (cell == null || cell.FieldGuid != fieldGuid)
                    continue;

                return cell.Value?.SubType ?? cell.Value?.DataType;
            }

            return null;
        }
    }
}

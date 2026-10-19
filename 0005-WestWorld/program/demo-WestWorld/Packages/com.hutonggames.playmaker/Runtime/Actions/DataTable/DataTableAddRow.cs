using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Add a new row to a DataTable and set field values.")]
    [HelpURL("actions/data-actions/data-table/data-table-add-row/")]
    public sealed class DataTableAddRow : BaseAction, IDataTableAction
    {
        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        [Tooltip("The DataTable to add a row to.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [OptionalField]
        [Tooltip("Optional row key. Used for lookups.")]
        public StringVar Key;
        
        public List<DataFieldValue> SetValues = new();

        [ActionHeader("Outputs")]
        
        [OptionalField, WriteOnly]
        [Tooltip("Zero-based index of the added row.")]
        public IntegerRef Index;

        [OptionalField, WriteOnly]
        [Tooltip("True if a row was added.")]
        public BoolRef Added;

        public override void Execute()
        {
            if (Added != null) Added.Value = false;

            var table = DataTable.ResolveData();
            if (table == null) return;

            var def = table.DataDefinition;
            if (def == null) return;

            try
            {
                var row = table.AddRow(table.IsAssetBacked, Key?.Value);
            
                DataTableSchema.ApplySchema(table, row);

                if (SetValues != null)
                {
                    for (int i = 0; i < SetValues.Count; i++)
                    {
                        var fv = SetValues[i];
                        if (fv == null) continue;

                        var guid = fv.FieldGuid;
                        if (guid == SerializableGuid.None) continue;

                        var vv = fv.Value;
                        if (vv == null) continue;

                        SetCellValue(row, guid, vv.GetValue());
                    }
                }

                if (Index != null) Index.Value = table.RowCount - 1;
                if (Added != null) Added.Value = true;
            }
            catch (Exception e)
            {
                LogError(e.Message);
                Finish();
            }
        }

        private static void SetCellValue(DataRow row, SerializableGuid fieldGuid, object value)
        {
            var cells = row.Cells;
            for (int i = 0; i < cells.Count; i++)
            {
                var c = cells[i];
                if (c != null && c.FieldGuid == fieldGuid)
                {
                    c.Value?.SetValue(value);
                    return;
                }
            }
        }

        public override string GetSummary()
        {
            var keySummary = Key.IsDefault()
                ? string.Empty
                : " {Key}";
            var summary = $"Add {DataTable.GetSummary()}{keySummary} row: ";
            var def = DataTable.GetEditTimeDataDefinition(DataDefinition);

            if (def == null || SetValues == null || SetValues.Count == 0)
                return summary;

            var hasFieldValues = false;

            for (int i = 0; i < SetValues.Count; i++)
            {
                var fieldValue = SetValues[i];
                if (fieldValue == null || fieldValue.FieldGuid == SerializableGuid.None || fieldValue.Value == null)
                    continue;

                hasFieldValues = true;
                break;
            }

            return !hasFieldValues
                ? summary + "{Index:output} {Added:output}"
                : summary + "{SetValues:data-field-values} {Index:output} {Added:output}";
        }
    }
}

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Add a new row to a DataTable and set field values.")]
    [HelpURL("actions/data-actions/data-table/data-table-add-record/")]
    public sealed class DataTableAddRecord : BaseAction, IDataTableAction
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

        [Tooltip("The DataRecord to add to the table.")]
        public DataRecordRef Record;

        [ActionHeader("Outputs")]
        
        [OptionalField, WriteOnly]
        [Tooltip("Zero-based index of the added row.")]
        public IntegerRef Index;

        [OptionalField, WriteOnly]
        [Tooltip("Set to true if a row was added.")]
        public BoolRef Added;

        public override void Execute()
        {
            if (Added.IsAssigned) Added.Value = false;
            
            var record = Record.Value;
            if (record == null) return;

            var table = DataTable.ResolveData();
            if (table == null) return;

            var def = table.DataDefinition;
            if (def == null) return;

            try
            {
                var row = table.AddRow(table.IsAssetBacked, Key?.Value);
            
                DataTableSchema.ApplySchema(table, row);

                foreach (var field in record.Data.Cells)
                {
                    var guid = field.FieldGuid;
                    if (guid == SerializableGuid.None) continue;

                    var vv = field.Value;
                    if (vv == null) continue;

                    SetCellValue(row, guid, vv.GetValue());
                }

                if (Index.IsAssigned) Index.Value = table.RowCount - 1;
                if (Added.IsAssigned) Added.Value = true;
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

            return "Add {Record} to " + DataTable.GetSummary() + keySummary + " {Index:output} {Added:output}";
        }
    }
}

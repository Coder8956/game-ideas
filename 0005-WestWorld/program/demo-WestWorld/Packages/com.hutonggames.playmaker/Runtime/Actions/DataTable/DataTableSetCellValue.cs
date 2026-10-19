using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Set the value of a cell in a DataTable.")]
    [HelpURL("actions/data-actions/data-table/data-table-set-cell-value/")]
    public sealed class DataTableSetCellValue : BaseAction, IDataTableAction
    {
        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;
        
        [Tooltip("The source DataTable.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;
        
        [Tooltip("Find row by key or index.")]
        public DataTableRow Row;

        [Tooltip("If true and selecting by Key, adds a new row when the key is not found.")]
        [DefaultValue(false)]
        public BoolVar AddIfMissing;

        [Tooltip("Field/value to set.")]
        public DataFieldValue SetValue;

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("True if a row was found/added and the value was applied.")]
        public BoolRef Succeeded;

        [OptionalField, WriteOnly]
        [Tooltip("True if a new row was added.")]
        public BoolRef Added;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the row was not found and no row was added.")]
        public EventRef NotFoundEvent;

        public override bool CanExecute() =>
            SetValue != null && SetValue.FieldGuid != SerializableGuid.None && SetValue.Value != null;

        public override void Execute()
        {
            if (Succeeded is { IsAssigned: true }) Succeeded.Value = false;
            if (Added is { IsAssigned: true }) Added.Value = false;

            var table = DataTable.ResolveData();
            if (table == null) return;

            var def = table.DataDefinition;
            if (def == null) return;

            // Resolve row
            var row = Row.Resolve(table);

            var added = false;
            if (row == null && AddIfMissing.Value)
            {
                row = table.AddRow(table.IsAssetBacked, key: Row.Key.Value);
                added = row != null;
            }

            if (row == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            // Keep row aligned with schema
            table.EnsureRowSchemaUpToDate(row);
            
            var ok = DataRowUtility.ApplyValue(row, SetValue);

            if (ok)
                table.NotifyChanged();

            if (Added is { IsAssigned: true }) Added.Value = added;
            if (Succeeded is { IsAssigned: true }) Succeeded.Value = ok;
        }

        public override string GetSummary()
        {
            var def = DataTable.GetEditTimeDataDefinition(DataDefinition);
            var fieldName = SetValue != null && def != null
                ? SetValue.GetFieldName(def)
                : "(field)";

            return $"Set {DataTable.GetSummary()} row {Row.GetSummary()} <b>{fieldName}</b> to {{SetValue.Value}} {{Succeeded:output}} {{Added:output}}";
        }
    }
}

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Set values of a DataTable row.")]
    [HelpURL("actions/data-actions/data-table/data-table-set-row-values/")]
    public sealed class DataTableSetRowValues : BaseAction, IDataTableAction
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
        
        [OptionalField]
        public List<DataFieldValue> SetValues = new();

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("True if a row was found/added and values were applied.")]
        public BoolRef Succeeded;

        [OptionalField, WriteOnly]
        [Tooltip("True if a new row was added.")]
        public BoolRef Added;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the row was not found and no row was added.")]
        public EventRef NotFoundEvent;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;
            if (Added.IsAssigned) Added.Value = false;

            var table = DataTable.ResolveData();
            if (table == null) return;

            var def = table.DataDefinition;
            if (def == null) return;

            // Resolve row
            var row = Row.Resolve(table);

            var added = false;

            // Optional add behavior (typically only meaningful for Key mode)
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

            // Ensure schema for the row before writing (prevents drift)
            table.EnsureRowSchemaUpToDate(row);

            // Apply values
            DataRowUtility.ApplyValues(row, SetValues);
            table.NotifyChanged();

            if (Added.IsAssigned) Added.Value = added;
            if (Succeeded.IsAssigned) Succeeded.Value = true;
        }

        public override string GetSummary()
        {
            var summary = $"Set {DataTable.GetSummary()} row {Row.GetSummary()} values";
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
                ? summary + " {Succeeded:output} {Added:output}"
                : summary + ": {SetValues:data-field-values} {Succeeded:output} {Added:output}";
        }
    }
}

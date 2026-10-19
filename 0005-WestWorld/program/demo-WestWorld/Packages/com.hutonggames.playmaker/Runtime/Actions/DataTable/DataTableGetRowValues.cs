using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Get all values from a row in a DataTable.")]
    [HelpURL("actions/data-actions/data-table/data-table-get-row-values/")]
    public sealed class DataTableGetRowValues : BaseAction, IDataTableAction
    {
        [Tooltip("The DataTable to read values from.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Find row by key or index.")]
        public DataTableRow Row;

        [Tooltip("What to do with output store values when the row is not found.")]
        [SerializeField, DefaultValue(DataTableMissingValueBehavior.KeepExisting)]
        public DataTableMissingValueBehavior OnRowNotFound = DataTableMissingValueBehavior.KeepExisting;
        
        public List<DataFieldStore> StoreValues = new();

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the row was not found.")]
        public EventRef NotFoundEvent;

        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        public override bool CanExecute() => CheckParameters(DataTable, Row);

        public override void Execute()
        {
            if (!TryGetTableAndDefinition(out var table, out _))
                return;

            var row = Row.Resolve(table);
            if (row == null)
            {
                ApplyMissingRowBehavior(table?.DataDefinition);
                SendEvent(NotFoundEvent);
                return;
            }

            table.EnsureRowSchemaUpToDate(row);
            ApplyRowStores(row);
        }

        public override string GetSummary()
        {
            var summary = $"Get {DataTable.GetSummary()} row {Row.GetSummary()} values";

            foreach (var storeValue in StoreValues)
                summary += storeValue.GetSummary();

            return summary;
        }

        private bool TryGetTableAndDefinition(out DataTable table, out DataDefinition def)
        {
            table = DataTable.ResolveData();
            def = table?.DataDefinition;

            // Runtime prefers the table's real definition.
            if (def == null) def = DataDefinition;

            return table != null && def != null;
        }

        private void ApplyRowStores(DataRow row)
        {
            if (row == null) return;
            DataRowUtility.ApplyStores(row, StoreValues);
        }

        private void ApplyMissingRowBehavior(DataDefinition definition)
        {
            if (StoreValues == null)
                return;

            for (var i = 0; i < StoreValues.Count; i++)
            {
                var fieldStore = StoreValues[i];
                DataTableUtility.ApplyMissingValueBehavior(definition, fieldStore, null, OnRowNotFound);
            }
        }

        public override string ErrorCheck()
        {
            if (DataTable.GetEditTimeDataDefinition() == null && DataDefinition == null)
                return "@DataDefinition: This is needed when the table is not known at edit time.";
            return null;
        }
    }
}

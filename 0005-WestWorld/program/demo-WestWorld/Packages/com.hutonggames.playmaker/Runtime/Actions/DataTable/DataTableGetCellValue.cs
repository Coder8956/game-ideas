using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Get the value of a cell in a DataTable.")]
    [HelpURL("actions/data-actions/data-table/data-table-get-cell-value/")]
    public sealed class DataTableGetCellValue : BaseAction, IDataTableAction
    {
        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        public IVariableRef StoreTarget => StoreValue?.Store;
        
        [Tooltip("The DataTable to read values from.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Find row by key or index.")]
        public DataTableRow Row;

        [Tooltip("What to do with the output value when the row or field is not found. Explicit DefaultValue takes precedence when assigned.")]
        [SerializeField, DefaultValue(DataTableMissingValueBehavior.ResetValue)]
        public DataTableMissingValueBehavior OnNotFound = DataTableMissingValueBehavior.ResetValue;
        
        public DataFieldStore StoreValue = new();

        [SerializeReference, OptionalField]
        [MatchType(nameof(StoreTarget))]
        [Tooltip("Optional fallback value to store if the row or field is not found. If not assigned, the output variable is reset instead.")]
        public IVariableVar DefaultValue;

        [OptionalField, WriteOnly]
        [Tooltip("True if the row and field were found and the value was stored.")]
        public BoolRef Found;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the row or field was not found.")]
        public EventRef NotFoundEvent;

        public override bool CanExecute() => CheckParameters(DataTable, Row);

        public override void Execute()
        {
            if (Found.IsAssigned) Found.Value = false;

            if (!TryGetTableAndDefinition(out var table, out _))
            {
                ApplyFallbackValue();
                return;
            }

            var row = Row.Resolve(table);
            if (row == null)
            {
                ApplyFallbackValue();
                SendEvent(NotFoundEvent);
                return;
            }

            table.EnsureRowSchemaUpToDate(row);
            if (!ApplyCellStore(row))
            {
                ApplyFallbackValue();
                SendEvent(NotFoundEvent);
                return;
            }

            if (Found.IsAssigned) Found.Value = true;
        }

        public override string GetSummary()
        {
            var def = DataTable.GetEditTimeDataDefinition(DataDefinition);
            return $"Get {DataTable.GetSummary()} row {Row.GetSummary()} <b>" +
                   StoreValue.GetFieldName(def) +
                   $"</b> {{StoreValue.Store:output}} {{Found:output}}";
        }

        private bool TryGetTableAndDefinition(out DataTable table, out DataDefinition def)
        {
            table = DataTable.ResolveData();
            def = table?.DataDefinition;

            // Runtime prefers the table's real definition.
            if (def == null) def = DataDefinition;

            return table != null && def != null;
        }

        private bool ApplyCellStore(DataRow row)
        {
            return row != null && DataRowUtility.ApplyStore(row, StoreValue);
        }

        private void ApplyFallbackValue()
        {
            DataTableUtility.ApplyMissingValueBehavior(DataTable.ResolveData()?.DataDefinition ?? DataDefinition,
                                                       StoreValue,
                                                       DefaultValue,
                                                       OnNotFound);
        }

        public override string ErrorCheck()
        {
            if (DataTable.GetEditTimeDataDefinition() == null && DataDefinition == null)
                return "@DataDefinition: This is needed when the table is not known at edit time.";
            return null;
        }
    }
}

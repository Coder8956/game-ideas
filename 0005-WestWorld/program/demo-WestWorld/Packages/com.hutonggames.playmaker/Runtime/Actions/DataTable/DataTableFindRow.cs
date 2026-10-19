using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Finds the first row in a DataTable that matches the specified conditions.")]
    public sealed class DataTableFindRow : BaseAction, IDataTableAction
    {
        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        [Tooltip("The DataTable to search.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [BaseType(typeof(DataRow))]
        [Tooltip("Conditions used to match a row.")]
        public ConditionTest FindFirstRowWhere = new();

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("Zero-based index of the matching row.")]
        public IntegerRef Index;

        [OptionalField, WriteOnly]
        [Tooltip("Key of the matching row.")]
        public StringRef Key;

        [OptionalField, WriteOnly]
        [Tooltip("Copy the matching row into a DataRecord.")]
        public DataRecordRef Record;

        [OptionalField, WriteOnly]
        [Tooltip("Set to true if a matching row was found.")]
        public BoolRef Found;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if no matching row was found.")]
        public EventRef NotFoundEvent;

        public override bool CanExecute() => CheckParameters(DataTable);

        public override void Execute()
        {
            if (Index.IsAssigned) Index.Value = -1;
            if (Key.IsAssigned) Key.Value = string.Empty;
            if (Found.IsAssigned) Found.Value = false;

            var table = DataTable.ResolveData();
            var rows = table?.Rows;
            if (rows == null || rows.Count == 0)
                return;

            for (var i = 0; i < rows.Count; i++)
            {
                var row = rows[i];
                if (!DataRowPredicateUtility.EvaluateWithRowIndex(FindFirstRowWhere, row, i, table))
                    continue;

                if (Index.IsAssigned) Index.Value = i;
                if (Key.IsAssigned) Key.Value = table.GetRowKey(row);

                if (Record.IsAssigned)
                {
                    var definition = table.DataDefinition ?? DataDefinition;
                    if (definition != null)
                        DataRecordCopyUtility.CopyFromRow(Record.Value, definition, row);
                }

                if (Found.IsAssigned) Found.Value = true;
                return;
            }

            SendEvent(NotFoundEvent);
        }

        public override string GetSummary() =>
            $"Find first row in {DataTable.GetSummary()} where {{FindFirstRowWhere}}" + 
            "{Index:output} {Key:output} {Record:output} {Found:output}";

        public override string ErrorCheck()
        {
            if (DataTable.GetEditTimeDataDefinition() == null && DataDefinition == null)
                return "@DataDefinition: This is needed when the table is not known at edit time.";
            return null;
        }
    }
}

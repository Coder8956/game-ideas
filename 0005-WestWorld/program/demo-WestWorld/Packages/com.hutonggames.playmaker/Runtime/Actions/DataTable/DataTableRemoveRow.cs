using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Remove a row from a DataTable.")]
    [HelpURL("actions/data-actions/data-table/data-table-remove-row/")]
    public sealed class DataTableRemoveRow : BaseAction
    {
        [Tooltip("The DataTable to read values from.")]
        public DataTableSource DataTable;

        [Tooltip("Find row by key or index.")]
        public DataTableRow Row;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the row was not found.")]
        public EventRef NotFoundEvent;

        public override bool CanExecute() => CheckParameters(DataTable, Row);

        public override void Execute()
        {
            var table = DataTable.ResolveData();
            var row = Row.Resolve(table);
            if (row == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            table.RemoveRowById(table.IsAssetBacked, row.Id);
        }

        public override string GetSummary() =>
            $"Remove {DataTable.GetSummary()} row {Row.GetSummary()}";
    }
}

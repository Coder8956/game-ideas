using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Checks if a DataTable has no rows.")]
    [HelpURL("actions/data-actions/data-table/data-table-check-is-empty/")]
    public sealed class DataTableCheckIsEmpty : BaseTrueFalseAction
    {
        [Tooltip("The DataTable to check.")]
        public DataTableSource DataTable;

        public override bool CanExecute() => CheckParameters(DataTable);

        protected override bool Test()
        {
            var table = DataTable.ResolveData();
            return table == null || table.RowCount == 0;
        }

        protected override string TrueSummary => $"{DataTable.GetSummary()} is empty";
        protected override string FalseSummary => $"{DataTable.GetSummary()} is not empty";
    }
}

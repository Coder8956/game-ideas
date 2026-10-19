using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Get the number of rows in a DataTable.")]
    [HelpURL("actions/data-actions/data-table/data-table-get-count/")]
    public sealed class DataTableGetCount : BaseAction
    {
        [Tooltip("The DataTable to count rows from.")]
        public DataTableSource DataTable;

        [Tooltip("Store the number of rows in the table.")]
        public IntegerRef Count;

        public override void Execute()
        {
            var table = DataTable.ResolveData();
            if (table == null)
            {
                Count.Value = 0;
                return;
            }

            var rows = table.Rows;
            Count.Value = rows?.Count ?? 0;
        }

        public override string GetSummary()
        {
            return $"Get {DataTable.GetSummary()} Count {{Count:output}}";
        }
    }
}

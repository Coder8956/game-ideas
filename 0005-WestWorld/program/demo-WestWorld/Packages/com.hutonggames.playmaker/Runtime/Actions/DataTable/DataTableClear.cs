using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Removes all rows from a DataTable.")]
    [HelpURL("actions/data-actions/data-table/data-table-clear/")]
    public sealed class DataTableClear : BaseAction
    {
        [Tooltip("The target DataTable.")]
        public DataTableSource DataTable;

        public override void Execute()
        {
            var table = DataTable.ResolveData();
            
            try
            {
                table?.Clear(table.IsAssetBacked);
            }
            catch (Exception e)
            {
                LogError(e.Message);
                Finish();
            }
        }

        public override string GetSummary() => $"Clear {DataTable.GetSummary()}";
    }
}

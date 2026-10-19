using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Trim a DataTable to a maximum number of rows.")]
    [HelpURL("actions/data-actions/data-table/data-table-trim/")]
    public sealed class DataTableTrim : BaseAction
    {
        public enum TrimFrom { End, Start }

        [Tooltip("The target DataTable.")]
        public DataTableSource DataTable;

        [Tooltip("Maximum number of rows to keep.")]
        public IntegerVar MaxRows;

        [Tooltip("Where to remove rows from when trimming.")]
        public TrimFrom RemoveFrom = TrimFrom.End;

        [Tooltip("True if the table was trimmed (rows removed), otherwise false.")]
        [OptionalField, WriteOnly]
        public BoolRef Trimmed;

        public override void Execute()
        {
            if (Trimmed != null) Trimmed.Value = false;

            var table = DataTable.ResolveData();
            if (table == null) return;

            var max = MaxRows.Value;
            if (max < 0) max = 0;

            if (table.RowCount <= max) return;
            
            var removeFromEnd = RemoveFrom == TrimFrom.End;

            try
            {
                table.Trim(table.IsAssetBacked, max, removeFromEnd);
                if (Trimmed != null) Trimmed.Value = true;
            }
            catch (InvalidOperationException e)
            {
                LogError(e.Message);
            }
        }

        public override string GetSummary() => $"Trim {DataTable.GetSummary()} to {{MaxRows}} items {{Trimmed:output}}";
    }
}

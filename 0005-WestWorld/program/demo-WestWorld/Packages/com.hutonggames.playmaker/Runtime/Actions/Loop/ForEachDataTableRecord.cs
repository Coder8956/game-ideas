using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Loop)]
    [ActionDescription("Run actions in this state on each record in a DataTable." +
                       "\n\nIf the DataTable is empty, no actions will be run.")]
    public class ForEachDataTableRecord : BaseForEachAction, IDataDefinitionSource
    {
        public DataTableSource Table;

        [Tooltip("The current item retrieved from the DataTable.")]
        [WriteOnly]
        public DataRecordRef Record;

        protected override int ItemCount => Table.ResolveData()?.RowCount ?? 0;

        public override void EachAction(int index)
        {
            var table = Table.ResolveData();
            if (table == null) return;

            var def = table.DataDefinition;
            if (def == null) return;

            DataRecordCopyUtility.CopyFromRow(Record.Value, def, table.Rows[index]);
        }

        public DataDefinition GetEditTimeDataDefinition() => Table.GetEditTimeDataDefinition();
        
        public override string GetSummary() => "For each record in {Table} -> {Record}";
    }
}

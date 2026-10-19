using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTableAsset)]
    [ActionDescription("Get a DataTable from a DataTable Asset.")]
    public sealed class DataTableAssetGetDataTable : BaseAction, IDataTableDefinitionSource
    {
        [Tooltip("The DataTable Asset to read from.")]
        public DataTableAssetVar DataTableAsset;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("Store the DataTable from the asset.")]
        public DataTableRef DataTable;

        [OptionalField, WriteOnly]
        [Tooltip("True if the DataTable asset was found and returned a table.")]
        public BoolRef Succeeded;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the DataTable asset or table was not found.")]
        public EventRef NotFoundEvent;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;
            if (DataTable.IsAssigned) DataTable.Value = null;

            var asset = DataTableAsset.Value;
            if (asset == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var table = asset.Table;
            if (table == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            if (DataTable.IsAssigned) DataTable.Value = table;
            if (Succeeded.IsAssigned) Succeeded.Value = true;
        }

        public override string GetSummary() =>
            "Get {DataTableAsset} DataTable {DataTable:output} {Succeeded:output}";

        public DataDefinition GetEditTimeDataDefinition() => DataTableAsset?.DataDefinition;
    }
}

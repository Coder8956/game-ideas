using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Add multiple rows to a DataTable from a list of DataRecords, another DataTable, or DataComponents.")]
    [HelpURL("actions/data-actions/data-table/data-table-add-records/")]
    public sealed class DataTableAddRecords : BaseAction, IDataTableAction
    {
        public enum RecordSource
        {
            DataTableComponent,
            DataTableAsset,
            DataTable,
            DataComponents,
            DataRecords
        }

        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        [Tooltip("The DataTable to add rows to.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Where to read source records from.")]
        [DefaultValue(RecordSource.DataRecords)]
        public RecordSource Source;

        [HideIf(nameof(HideRecordList))]
        [Tooltip("Source list of DataRecords.")]
        public DataRecordListRef Records;

        [HideIf(nameof(HideDataTableComponentSource))]
        [Tooltip("Source DataTable Component.")]
        public DataTableComponentRef SourceDataTableComponent;

        [HideIf(nameof(HideDataTableAssetSource))]
        [Tooltip("Source DataTable Asset.")]
        public DataTableAssetRef SourceDataTableAsset;

        [HideIf(nameof(HideDataTableSource))]
        [Tooltip("Source DataTable.")]
        public DataTableRef SourceDataTable;

        [HideIf(nameof(HideDataComponentList))]
        [Tooltip("Source list of DataComponents.")]
        public DataRecordComponentListRef DataComponents;

        [Tooltip("Copy source row keys when available.")]
        [DefaultValue(true)]
        public BoolVar UseSourceKeys;

        [ActionHeader("Outputs")]

        [OptionalField, WriteOnly]
        [Tooltip("How many rows were added.")]
        public IntegerRef AddedCount;

        [OptionalField, WriteOnly]
        [Tooltip("True if one or more rows were added.")]
        public BoolRef Added;

        private bool HideRecordList => Source != RecordSource.DataRecords;
        private bool HideDataTableComponentSource => Source != RecordSource.DataTableComponent;
        private bool HideDataTableAssetSource => Source != RecordSource.DataTableAsset;
        private bool HideDataTableSource => Source != RecordSource.DataTable;
        private bool HideDataComponentList => Source != RecordSource.DataComponents;

        public override void Execute()
        {
            if (AddedCount.IsAssigned) AddedCount.Value = 0;
            if (Added.IsAssigned) Added.Value = false;

            var table = DataTable.ResolveData();
            if (table == null) return;

            var def = table.DataDefinition;
            if (def == null) return;

            try
            {
                var addedCount = AddFromSourceList(table, def);

                if (AddedCount.IsAssigned) AddedCount.Value = addedCount;
                if (Added.IsAssigned) Added.Value = addedCount > 0;
            }
            catch (Exception e)
            {
                LogError(e.Message);
                Finish();
            }
        }

        private int AddFromSourceList(DataTable table, DataDefinition def)
        {
            var addedCount = 0;
            if (Source == RecordSource.DataTableComponent)
            {
                return AddFromDataTable(table, def, SourceDataTableComponent.Value?.Table);
            }

            if (Source == RecordSource.DataTableAsset)
            {
                return AddFromDataTable(table, def, SourceDataTableAsset.Value?.Table);
            }

            if (Source == RecordSource.DataTable)
            {
                return AddFromDataTable(table, def, SourceDataTable.ResolveData());
            }

            if (Source == RecordSource.DataComponents)
            {
                var dataComponents = DataComponents.Value;
                if (dataComponents == null || dataComponents.Count == 0) return 0;

                for (var i = 0; i < dataComponents.Count; i++)
                {
                    var component = dataComponents[i];
                    addedCount += AddRecord(table, def, component?.Data) ? 1 : 0;
                }

                return addedCount;
            }

            if (Source == RecordSource.DataRecords)
            {
                var records = Records.Value;
                if (records == null || records.Count == 0) return 0;

                for (var i = 0; i < records.Count; i++)
                    addedCount += AddRecord(table, def, records[i]) ? 1 : 0;

                return addedCount;
            }

            return 0;
        }

        private int AddFromDataTable(DataTable table, DataDefinition def, DataTable sourceTable)
        {
            var rows = sourceTable?.Rows;
            if (rows == null || rows.Count == 0) return 0;

            var addedCount = 0;
            var rowCount = rows.Count;

            for (var i = 0; i < rowCount; i++)
            {
                var sourceRow = rows[i];
                if (sourceRow == null) continue;

                sourceTable.EnsureRowSchemaUpToDate(sourceRow);
                addedCount += AddRow(table, def, sourceRow) ? 1 : 0;
            }

            return addedCount;
        }

        private bool AddRecord(DataTable table, DataDefinition def, DataRecord record)
        {
            return AddRow(table, def, record?.Data);
        }

        private bool AddRow(DataTable table, DataDefinition def, DataRow sourceRow)
        {
            if (sourceRow == null) return false;

            var key = UseSourceKeys.Value ? GetResolvedSourceKey(sourceRow) : null;
            var row = table.AddRow(table.IsAssetBacked, key);
            if (row == null) return false;

            DataTableSchema.ApplySchema(table, row);

            var sourceCells = sourceRow.Cells;
            if (sourceCells == null || sourceCells.Count == 0)
                return true;

            for (var i = 0; i < sourceCells.Count; i++)
            {
                var sourceCell = sourceCells[i];
                if (sourceCell == null) continue;

                var fieldGuid = sourceCell.FieldGuid;
                if (fieldGuid == SerializableGuid.None) continue;

                var value = sourceCell.Value;
                if (value == null) continue;

                SetCellValue(row, fieldGuid, value.GetValue());
            }

            return true;
        }

        private string GetResolvedSourceKey(DataRow sourceRow)
        {
            switch (Source)
            {
                case RecordSource.DataTableComponent:
                    return SourceDataTableComponent.Value?.Table?.GetRowKey(sourceRow) ?? string.Empty;
                case RecordSource.DataTableAsset:
                    return SourceDataTableAsset.Value?.Table?.GetRowKey(sourceRow) ?? string.Empty;
                case RecordSource.DataTable:
                    return SourceDataTable.ResolveData()?.GetRowKey(sourceRow) ?? string.Empty;
                default:
                    return sourceRow?.Key ?? string.Empty;
            }
        }

        private static void SetCellValue(DataRow row, SerializableGuid fieldGuid, object value)
        {
            var cells = row.Cells;
            for (var i = 0; i < cells.Count; i++)
            {
                var c = cells[i];
                if (c != null && c.FieldGuid == fieldGuid)
                {
                    c.Value?.SetValue(value);
                    return;
                }
            }
        }

        public override string GetSummary()
        {
            if (Source == RecordSource.DataTableComponent)
                return "Add {SourceDataTableComponent} to " + DataTable.GetSummary() + " {AddedCount:output} {Added:output}";

            if (Source == RecordSource.DataTableAsset)
                return "Add {SourceDataTableAsset} to " + DataTable.GetSummary() + " {AddedCount:output} {Added:output}";

            if (Source == RecordSource.DataTable)
                return "Add {SourceDataTable} to " + DataTable.GetSummary() + " {AddedCount:output} {Added:output}";

            return Source == RecordSource.DataComponents
                ? "Add {DataComponents} to " + DataTable.GetSummary() + " {AddedCount:output} {Added:output}"
                : "Add {Records} to " + DataTable.GetSummary() + " {AddedCount:output} {Added:output}";
        }
    }
}

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Find the row with the minimum or maximum value for a field (or Row Key).")]
    [HelpURL("actions/data-actions/data-table/data-table-find-best-row/")]
    public sealed class DataTableFindBestRow : BaseAction, IDataTableAction
    {
        public enum BestMode { Max, Min }

        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        [Tooltip("The DataTable to query.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        // Drawn by editor: dropdown of fields; stored as GUID
        [HideInInspector]
        public SerializableGuid FieldGuid;

        [Tooltip("Choose whether to find the minimum or maximum value.")]
        public BestMode Mode = BestMode.Max;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("Zero-based index of the best row.")]
        public IntegerRef Index;

        [OptionalField, WriteOnly]
        [Tooltip("Key of the best row.")]
        public StringRef Key;

        [OptionalField, WriteOnly]
        [Tooltip("Copy the best row into a DataRecord.")]
        public DataRecordRef Record;
        
        [OptionalField, WriteOnly]
        [Tooltip("Set to true if a row was found.")]
        public BoolRef Found;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if no matching row was found.")]
        public EventRef NotFoundEvent;
        
        public override void Execute()
        {
            if (Index.IsAssigned) Index.Value = -1;
            if (Key.IsAssigned) Key.Value = string.Empty;
            if (Found.IsAssigned) Found.Value = false;

            var table = DataTable.ResolveData();
            var rows = table?.Rows;
            if (rows == null || rows.Count == 0)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var guid = FieldGuid;
            if (guid == SerializableGuid.None) return;

            var wantMax = Mode == BestMode.Max;

            // Row Key path (no DataDefinition needed)
            if (guid == DataTableUtility.RowKeyGuid)
            {
                var best = FindBestByRowKey(table, rows, wantMax);
                if (best < 0)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                SetOutputs(table, rows, best);
                return;
            }

            var def = table.DataDefinition ?? DataDefinition;
            if (def == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            if (!TryGetFieldType(def, guid, out var dataType))
                return;

            var bestIndex = FindBestByField(rows, guid, dataType, wantMax);
            if (bestIndex < 0)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            SetOutputs(table, rows, bestIndex);
        }

        private void SetOutputs(DataTable table, IReadOnlyList<DataRow> rows, int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= rows.Count)
                return;

            var row = rows[rowIndex];

            if (Index.IsAssigned) Index.Value = rowIndex;
            if (Key.IsAssigned) Key.Value = table.GetRowKey(row);

            if (Record.IsAssigned)
            {
                var definition = table?.DataDefinition ?? DataDefinition;
                if (definition != null)
                    DataRecordCopyUtility.CopyFromRow(Record.Value, definition, row);
            }

            if (Found.IsAssigned) Found.Value = true;
        }

        private static int FindBestByRowKey(DataTable table, IReadOnlyList<DataRow> rows, bool wantMax)
        {
            var bestIndex = -1;
            var bestKey = string.Empty;

            for (int i = 0; i < rows.Count; i++)
            {
                var key = table.GetRowKey(rows[i]);

                if (bestIndex < 0)
                {
                    bestIndex = i;
                    bestKey = key;
                    continue;
                }

                var cmp = string.Compare(key, bestKey, StringComparison.Ordinal);
                if (wantMax ? (cmp > 0) : (cmp < 0))
                {
                    bestIndex = i;
                    bestKey = key;
                }
            }

            return bestIndex;
        }

        private static int FindBestByField(IReadOnlyList<DataRow> rows, SerializableGuid fieldGuid, Type dataType, bool wantMax)
        {
            var bestIndex = -1;
            object bestValue = null;

            for (int i = 0; i < rows.Count; i++)
            {
                if (!TryGetCellValue(rows[i], fieldGuid, out var value))
                    continue;

                if (bestIndex < 0)
                {
                    bestIndex = i;
                    bestValue = value;
                    continue;
                }

                var cmp = CompareValues(value, bestValue, dataType);
                if (cmp == 0) continue;

                if (wantMax ? (cmp > 0) : (cmp < 0))
                {
                    bestIndex = i;
                    bestValue = value;
                }
            }

            return bestIndex;
        }

        private static int CompareValues(object a, object b, Type dataType)
        {
            if (ReferenceEquals(a, b)) return 0;
            if (a == null) return -1;
            if (b == null) return 1;

            if (dataType == typeof(string))
                return string.Compare(a as string ?? a.ToString(), b as string ?? b.ToString(), StringComparison.Ordinal);

            if (dataType == typeof(int))
                return (a is int ai ? ai : 0).CompareTo(b is int bi ? bi : 0);

            if (dataType == typeof(float))
                return (a is float af ? af : 0f).CompareTo(b is float bf ? bf : 0f);

            if (dataType == typeof(double))
                return (a is double ad ? ad : 0d).CompareTo(b is double bd ? bd : 0d);

            if (a is IComparable ca && b is IComparable)
                return ca.CompareTo(b);

            return string.Compare(a.ToString(), b.ToString(), StringComparison.Ordinal);
        }

        private static bool TryGetCellValue(DataRow row, SerializableGuid fieldGuid, out object value)
        {
            value = null;
            var cells = row?.Cells;
            if (cells == null) return false;

            for (int i = 0; i < cells.Count; i++)
            {
                var c = cells[i];
                if (c == null || c.FieldGuid != fieldGuid)
                    continue;

                var vv = c.Value;
                if (vv == null) return false;

                value = vv.GetValue();
                return value != null;
            }

            return false;
        }

        private static bool TryGetFieldType(DataDefinition def, SerializableGuid fieldGuid, out Type dataType)
        {
            dataType = null;

            foreach (var v in def.Variables.GetVariables())
            {
                if (v is not BaseVariable bv)
                    continue;

                if (bv.Guid != fieldGuid)
                    continue;

                dataType = bv.DataType;
                return dataType != null;
            }

            return false;
        }

        public override string GetSummary()
        {
#if UNITY_EDITOR
            var fieldName = GetFieldSummaryName();
#else
            var fieldName = "Field";
#endif
            return "Find " + DataTable.GetSummary() + "{Mode} <b>" + fieldName +
                   "</b> {Index:output} {Key:output} {Record:output} {Found:output}";
        }

#if UNITY_EDITOR
        private string GetFieldSummaryName()
        {
            if (FieldGuid == SerializableGuid.None)
                return "—";

            if (FieldGuid == DataTableUtility.RowKeyGuid)
                return "Row Key";

            var def = DataTable?.ResolveData()?.DataDefinition ?? DataDefinition;
            if (def == null) return "Field";

            foreach (var v in def.Variables.GetVariablesInEditorOrder())
            {
                if (v is BaseVariable bv && bv.Guid == FieldGuid)
                    return bv.Name;
            }

            return "Missing Field";
        }
#endif
    }
}

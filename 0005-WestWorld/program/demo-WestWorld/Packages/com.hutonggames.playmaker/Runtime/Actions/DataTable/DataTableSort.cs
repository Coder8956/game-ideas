using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Sort rows in a DataTable by a field (column).")]
    [HelpURL("actions/data-actions/data-table/data-table-sort/")]
    public sealed class DataTableSort : BaseAction, IDataTableAction
    {
        public enum SortDirection { Ascending, Descending }

        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;
        
        [Tooltip("The Table to sort.")]
        public DataTableSource DataTable;
        
        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        // Drawn by editor only when Table source can't be resolved at edit time
        [OptionalField]
        public DataDefinition DataDefinition;
        
        // Drawn by editor: dropdown of fields; stored as GUID
        [HideInInspector]
        public SerializableGuid SortFieldGuid;

        // Drawn by editor: optional secondary dropdown of fields; stored as GUID
        [HideInInspector]
        public SerializableGuid ThenByFieldGuid = SerializableGuid.None;
        
        [Tooltip("The order to sort rows in.")]
        public SortDirection Direction = SortDirection.Ascending;
        
        [Tooltip("The order to sort rows in for the optional secondary key.")]
        public SortDirection ThenByDirection = SortDirection.Ascending;

        [Tooltip("Set to true if the table was successfully sorted.")]
        [OptionalField, WriteOnly]
        public BoolRef Sorted;

        public override void Execute()
        {
            if (Sorted != null) Sorted.Value = false;

            var table = DataTable.ResolveData();
            if (table == null) return;

            if (table.RowCount < 2) return;

            var fieldGuid = SortFieldGuid;
            if (fieldGuid == SerializableGuid.None) return;

            if (!TryBuildComparer(table, fieldGuid, Direction, out var comparer))
                return;

            var thenByFieldGuid = ThenByFieldGuid;
            if (thenByFieldGuid != SerializableGuid.None)
            {
                if (!TryBuildComparer(table, thenByFieldGuid, ThenByDirection, out var thenByComparer))
                    return;

                comparer = new CompositeComparer(comparer, thenByComparer);
            }

            try
            {
                table.Sort(table.IsAssetBacked, comparer);
                if (Sorted != null) Sorted.Value = true;
            }
            catch (InvalidOperationException e)
            {
                // Prefer your normal PM2 logging pattern
                LogError(e.Message);
            }
        }

        private static bool TryBuildComparer(DataTable table, SerializableGuid fieldGuid, SortDirection direction, out IComparer<DataRow> comparer)
        {
            comparer = null;

            var desc = direction == SortDirection.Descending;

            // Handle Row Key sentinel first
            if (fieldGuid == DataTableUtility.RowKeyGuid)
            {
                comparer = DataTableRowComparer.GetRowKey(table, desc);
                return true;
            }

            var def = table.DataDefinition;
            if (def == null) return false;

            if (!TryGetFieldType(def, fieldGuid, out var dataType))
                return false;

            // Fast paths first
            if (dataType == typeof(float))
            {
                comparer = DataTableRowComparer.GetFloatField(fieldGuid, desc);
                return true;
            }

            if (dataType == typeof(int))
            {
                comparer = DataTableRowComparer.GetIntField(fieldGuid, desc);
                return true;
            }

            comparer = DataTableRowComparer.GetField(fieldGuid, dataType, desc);
            return true;
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
            var fieldName = GetSortFieldSummaryName();
#else
            var fieldName = "Field";
#endif

            var summary = $"Sort {DataTable.GetSummary()} by <b>{fieldName}</b> {{Direction}}";

#if UNITY_EDITOR
            if (ThenByFieldGuid != SerializableGuid.None)
            {
                var thenByFieldName = GetSortFieldSummaryName(ThenByFieldGuid);
                summary += $" then by <b>{thenByFieldName}</b> {{ThenByDirection}}";
            }
#endif
            return summary + " {Sorted:output}";
        }

#if UNITY_EDITOR
        private string GetSortFieldSummaryName()
        {
            return GetSortFieldSummaryName(SortFieldGuid);
        }

        private string GetSortFieldSummaryName(SerializableGuid guid)
        {
            if (guid == SerializableGuid.None)
                return "—";

            if (guid == DataTableUtility.RowKeyGuid)
                return "Row Key";

            var def = DataTable?.ResolveData()?.DataDefinition
                      ?? DataDefinition;

            if (def == null)
                return "Field";

            foreach (var v in def.Variables.GetVariablesInEditorOrder())
            {
                if (v is BaseVariable bv && bv.Guid == guid)
                    return bv.Name;
            }

            return "Missing Field";
        }
#endif

        private sealed class CompositeComparer : IComparer<DataRow>
        {
            private readonly IComparer<DataRow> _primary;
            private readonly IComparer<DataRow> _secondary;

            public CompositeComparer(IComparer<DataRow> primary, IComparer<DataRow> secondary)
            {
                _primary = primary;
                _secondary = secondary;
            }

            public int Compare(DataRow x, DataRow y)
            {
                var primaryResult = _primary.Compare(x, y);
                if (primaryResult != 0) return primaryResult;
                return _secondary.Compare(x, y);
            }
        }
    }
}

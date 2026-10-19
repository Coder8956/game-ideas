using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Keep or remove rows in a DataTable based on a condition test.")]
    public sealed class DataTableFilterRows : BaseAction, IDataTableAction
    {
        public enum FilterMode
        {
            KeepRows,
            RemoveRows
        }

        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        [Tooltip("The DataTable to filter.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Choose whether matching rows are kept or removed.")]
        public FilterMode Mode = FilterMode.KeepRows;

        [BaseType(typeof(DataRow))]
        [Tooltip("Conditions used to match rows.")]
        public ConditionTest Where = new();

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("Number of rows removed by the filter.")]
        public IntegerRef AffectedRows;

        [OptionalField, WriteOnly]
        [Tooltip("Set to true if any rows were removed.")]
        public BoolRef Changed;

        public override bool CanExecute() => CheckParameters(DataTable);

        public override void Execute()
        {
            if (AffectedRows.IsAssigned) AffectedRows.Value = 0;
            if (Changed.IsAssigned) Changed.Value = false;

            var table = DataTable.ResolveData();
            if (table == null)
                return;

            try
            {
                var affected = table.FilterRows(
                    table.IsAssetBacked,
                    (row, rowIndex) => DataRowPredicateUtility.EvaluateWithRowIndex(Where, row, rowIndex, table),
                    Mode == FilterMode.KeepRows);

                if (AffectedRows.IsAssigned) AffectedRows.Value = affected;
                if (Changed.IsAssigned) Changed.Value = affected > 0;
            }
            catch (InvalidOperationException e)
            {
                LogError(e.Message);
            }
        }

        public override string GetSummary() =>
            $"{Mode} in {DataTable.GetSummary()} where {{Where}} {{AffectedRows:output}} {{Changed:output}}";

        public override string ErrorCheck()
        {
            if (DataTable.GetEditTimeDataDefinition() == null && DataDefinition == null)
                return "@DataDefinition: This is needed when the table is not known at edit time.";
            return null;
        }
    }
}

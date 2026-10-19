using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Copy a random row from a DataTable into a DataRecord. Optionally use a numeric field as the row weight.")]
    [HelpURL("actions/data-actions/data-table/data-table-get-random-record/")]
    public sealed class DataTableGetRandomRecord : BaseAction, IDataTableAction
    {
        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        [Tooltip("The source DataTable.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [HideInInspector]
        public SerializableGuid WeightFieldGuid = SerializableGuid.None;

        [ActionHeader("Outputs")]
        [WriteOnly]
        [Tooltip("Receives a copy of the selected row as a DataRecord.")]
        public DataRecordRef Record;

        [Tooltip("What to do with the output record when no row is selected.")]
        [SerializeField, DefaultValue(DataTableMissingRecordBehavior.KeepExisting)]
        public DataTableMissingRecordBehavior OnRowNotFound = DataTableMissingRecordBehavior.KeepExisting;

        [OptionalField, WriteOnly]
        [Tooltip("Zero-based index of the selected row.")]
        public IntegerRef Index;

        [OptionalField, WriteOnly]
        [Tooltip("Key of the selected row.")]
        public StringRef Key;

        [OptionalField, WriteOnly]
        [Tooltip("True if a row was selected and copied, otherwise false.")]
        public BoolRef Found;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if no row was selected.")]
        public EventRef NotFoundEvent;

        public override bool CanExecute() => CheckParameters(DataTable, Record);

        public override void Execute()
        {
            if (Index is { IsAssigned: true }) Index.Value = -1;
            if (Key is { IsAssigned: true }) Key.Value = string.Empty;
            if (Found is { IsAssigned: true }) Found.Value = false;

            var outputRecord = DataTableUtility.EnsureRecordExists(Record, DataDefinition);

            var table = DataTable.ResolveData();
            var rows = table?.Rows;
            if (rows == null || rows.Count == 0)
            {
                DataTableUtility.ApplyMissingRecordBehavior(table?.DataDefinition ?? DataDefinition, outputRecord, OnRowNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            var definition = table.DataDefinition ?? DataDefinition;
            if (definition == null)
            {
                DataTableUtility.ApplyMissingRecordBehavior(DataDefinition, outputRecord, OnRowNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            outputRecord = DataTableUtility.EnsureRecordExists(Record, definition);

            var selectedIndex = SelectRandomIndex(rows, WeightFieldGuid, Random.value);
            if (selectedIndex < 0 || selectedIndex >= rows.Count)
            {
                DataTableUtility.ApplyMissingRecordBehavior(definition, outputRecord, OnRowNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            var row = rows[selectedIndex];
            if (row == null)
            {
                DataTableUtility.ApplyMissingRecordBehavior(definition, outputRecord, OnRowNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            DataRecordCopyUtility.CopyFromRow(outputRecord, definition, row);

            if (Index is { IsAssigned: true }) Index.Value = selectedIndex;
            if (Key is { IsAssigned: true }) Key.Value = table.GetRowKey(row);
            if (Found is { IsAssigned: true }) Found.Value = true;
        }

        public override string GetSummary()
        {
#if UNITY_EDITOR
            var weightField = GetWeightFieldSummaryName();
            return WeightFieldGuid == SerializableGuid.None
                ? $"Random row from {DataTable.GetSummary()} {{Record:output}} {{Index:output}} {{Key:output}} {{Found:output}}"
                : $"Random weighted row from {DataTable.GetSummary()} by <b>{weightField}</b> {{Record:output}} {{Index:output}} {{Key:output}} {{Found:output}}";
#else
            return WeightFieldGuid == SerializableGuid.None
                ? $"Random row from {DataTable.GetSummary()} {{Record:output}} {{Index:output}} {{Key:output}} {{Found:output}}"
                : $"Random weighted row from {DataTable.GetSummary()} {{Record:output}} {{Index:output}} {{Key:output}} {{Found:output}}";
#endif
        }

        public override string ErrorCheck()
        {
            if (DataTable.GetEditTimeDataDefinition() == null && DataDefinition == null)
                return "@DataDefinition: This is needed when the table is not known at edit time.";

            var definition = DataTable.GetEditTimeDataDefinition(DataDefinition);
            if (definition == null || WeightFieldGuid == SerializableGuid.None)
                return null;

            return TryGetFieldType(definition, WeightFieldGuid, out var dataType) && IsSupportedWeightType(dataType)
                ? null
                : "@WeightFieldGuid: Weight field must be an int, float, or double field.";
        }

        internal static int SelectRandomIndex(
            System.Collections.Generic.IReadOnlyList<DataRow> rows,
            SerializableGuid weightFieldGuid,
            float randomValue)
        {
            if (rows == null || rows.Count == 0)
                return -1;

            var sample = Mathf.Clamp01(randomValue);
            if (weightFieldGuid == SerializableGuid.None)
                return SelectUniformIndex(rows.Count, sample);

            double totalWeight = 0d;
            for (var i = 0; i < rows.Count; i++)
            {
                if (TryGetWeight(rows[i], weightFieldGuid, out var weight) && weight > 0d)
                    totalWeight += weight;
            }

            if (totalWeight <= 0d)
                return SelectUniformIndex(rows.Count, sample);

            var threshold = sample * totalWeight;
            double cumulative = 0d;
            var lastValidIndex = -1;

            for (var i = 0; i < rows.Count; i++)
            {
                if (!TryGetWeight(rows[i], weightFieldGuid, out var weight) || weight <= 0d)
                    continue;

                lastValidIndex = i;
                cumulative += weight;
                if (threshold <= cumulative)
                    return i;
            }

            return lastValidIndex;
        }

        private static int SelectUniformIndex(int count, float sample)
        {
            if (count <= 0)
                return -1;

            return Mathf.Clamp(Mathf.FloorToInt(sample * count), 0, count - 1);
        }

        private static bool TryGetWeight(DataRow row, SerializableGuid fieldGuid, out double weight)
        {
            weight = 0d;

            var cells = row?.Cells;
            if (cells == null)
                return false;

            for (var i = 0; i < cells.Count; i++)
            {
                var cell = cells[i];
                if (cell == null || cell.FieldGuid != fieldGuid)
                    continue;

                var value = cell.Value?.GetValue();
                switch (value)
                {
                    case int intValue:
                        weight = intValue;
                        return true;
                    case float floatValue when !float.IsNaN(floatValue) && !float.IsInfinity(floatValue):
                        weight = floatValue;
                        return true;
                    case double doubleValue when !double.IsNaN(doubleValue) && !double.IsInfinity(doubleValue):
                        weight = doubleValue;
                        return true;
                    default:
                        return false;
                }
            }

            return false;
        }

        private static bool TryGetFieldType(DataDefinition definition, SerializableGuid fieldGuid, out Type dataType)
        {
            dataType = null;
            if (definition?.Variables == null)
                return false;

            foreach (var variable in definition.Variables.GetVariables())
            {
                if (variable is not BaseVariable baseVariable)
                    continue;

                if (baseVariable.Guid != fieldGuid)
                    continue;

                dataType = baseVariable.DataType;
                return dataType != null;
            }

            return false;
        }

        private static bool IsSupportedWeightType(Type dataType) =>
            dataType == typeof(int) || dataType == typeof(float) || dataType == typeof(double);

#if UNITY_EDITOR
        private string GetWeightFieldSummaryName()
        {
            var definition = DataTable.GetEditTimeDataDefinition(DataDefinition);
            if (definition == null)
                return "Weight";

            foreach (var variable in definition.Variables.GetVariablesInEditorOrder())
            {
                if (variable is BaseVariable baseVariable && baseVariable.Guid == WeightFieldGuid)
                    return baseVariable.Name;
            }

            return "Missing Field";
        }
#endif
    }
}

using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Copy a random row from a DataTable into a DataRecord, using a numeric field as the row weight.")]
    [HelpURL("actions/data-actions/data-table/data-table-get-random-weighted-record/")]
    public sealed class DataTableGetRandomWeightedRecord : BaseAction, IDataTableAction
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
            if (definition == null || WeightFieldGuid == SerializableGuid.None)
            {
                DataTableUtility.ApplyMissingRecordBehavior(definition ?? DataDefinition, outputRecord, OnRowNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            outputRecord = DataTableUtility.EnsureRecordExists(Record, definition);

            var selectedIndex = DataTableGetRandomRecord.SelectRandomIndex(rows, WeightFieldGuid, Random.value);
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
            return $"Random weighted row from {DataTable.GetSummary()} by <b>{weightField}</b> {{Record:output}} {{Index:output}} {{Key:output}} {{Found:output}}";
#else
            return $"Random weighted row from {DataTable.GetSummary()} {{Record:output}} {{Index:output}} {{Key:output}} {{Found:output}}";
#endif
        }

        public override string ErrorCheck()
        {
            if (DataTable.GetEditTimeDataDefinition() == null && DataDefinition == null)
                return "@DataDefinition: This is needed when the table is not known at edit time.";

            if (WeightFieldGuid == SerializableGuid.None)
                return "Select an int, float, or double field to use as the row weight.";

            var definition = DataTable.GetEditTimeDataDefinition(DataDefinition);
            if (definition == null)
                return null;

            return TryGetFieldType(definition, WeightFieldGuid, out var dataType) && IsSupportedWeightType(dataType)
                ? null
                : "Weight field must be an int, float, or double field.";
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
            if (WeightFieldGuid == SerializableGuid.None)
                return "Weight";

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

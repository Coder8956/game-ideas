using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Randomly trim a DataTable to a maximum number of rows. Optionally use a numeric field as the row weight.")]
    [HelpURL("actions/data-actions/data-table/data-table-trim-random/")]
    public sealed class DataTableTrimRandom : BaseAction, IDataTableAction
    {
        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        [Tooltip("The target DataTable.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Maximum number of rows to keep.")]
        public IntegerVar MaxRows;

        [HideInInspector]
        public SerializableGuid WeightFieldGuid = SerializableGuid.None;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("Number of rows removed.")]
        public IntegerRef RemovedCount;

        [OptionalField, WriteOnly]
        [Tooltip("True if the table was trimmed (rows removed), otherwise false.")]
        public BoolRef Trimmed;

        public override void Execute()
        {
            if (RemovedCount.IsAssigned) RemovedCount.Value = 0;
            if (Trimmed.IsAssigned) Trimmed.Value = false;

            var table = DataTable.ResolveData();
            if (table == null)
                return;

            var maxRows = Mathf.Max(0, MaxRows.Value);
            var rows = table.Rows;
            if (rows == null || rows.Count <= maxRows)
                return;

            var keepIndices = SelectKeepIndices(rows, maxRows, WeightFieldGuid, null);
            if (keepIndices == null)
                return;

            var removed = 0;

            try
            {
                for (var i = rows.Count - 1; i >= 0; i--)
                {
                    if (keepIndices.Contains(i))
                        continue;

                    table.RemoveRowById(table.IsAssetBacked, rows[i].Id);
                    removed++;
                }
            }
            catch (InvalidOperationException e)
            {
                LogError(e.Message);
                return;
            }

            if (RemovedCount.IsAssigned) RemovedCount.Value = removed;
            if (Trimmed.IsAssigned) Trimmed.Value = removed > 0;
        }

        public override string GetSummary()
        {
#if UNITY_EDITOR
            var weightField = GetWeightFieldSummaryName();
            return WeightFieldGuid == SerializableGuid.None
                ? $"Trim {DataTable.GetSummary()} to {{MaxRows}} random items {{RemovedCount:output}} {{Trimmed:output}}"
                : $"Trim {DataTable.GetSummary()} to {{MaxRows}} random items using <b>{weightField}</b> weights {{RemovedCount:output}} {{Trimmed:output}}";
#else
            return WeightFieldGuid == SerializableGuid.None
                ? $"Trim {DataTable.GetSummary()} to {{MaxRows}} random items {{RemovedCount:output}} {{Trimmed:output}}"
                : $"Trim {DataTable.GetSummary()} to {{MaxRows}} random items using weights {{RemovedCount:output}} {{Trimmed:output}}";
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

        internal static HashSet<int> SelectKeepIndices(
            IReadOnlyList<DataRow> rows,
            int maxRows,
            SerializableGuid weightFieldGuid,
            IReadOnlyList<float> randomValues)
        {
            if (rows == null)
                return null;

            var targetCount = Mathf.Clamp(maxRows, 0, rows.Count);
            var keepIndices = new HashSet<int>();
            if (targetCount == 0)
                return keepIndices;

            var candidates = new List<int>(rows.Count);
            for (var i = 0; i < rows.Count; i++)
                candidates.Add(i);

            var sampleIndex = 0;
            while (keepIndices.Count < targetCount && candidates.Count > 0)
            {
                var sample = randomValues != null && sampleIndex < randomValues.Count
                    ? randomValues[sampleIndex]
                    : Random.value;
                sampleIndex++;

                var selectedCandidate = SelectCandidateIndex(rows, candidates, weightFieldGuid, sample);
                if (selectedCandidate < 0 || selectedCandidate >= candidates.Count)
                    break;

                keepIndices.Add(candidates[selectedCandidate]);
                candidates.RemoveAt(selectedCandidate);
            }

            return keepIndices;
        }

        private static int SelectCandidateIndex(
            IReadOnlyList<DataRow> rows,
            IReadOnlyList<int> candidates,
            SerializableGuid weightFieldGuid,
            float randomValue)
        {
            if (candidates == null || candidates.Count == 0)
                return -1;

            var sample = Mathf.Clamp01(randomValue);
            if (weightFieldGuid == SerializableGuid.None)
                return SelectUniformIndex(candidates.Count, sample);

            double totalWeight = 0d;
            for (var i = 0; i < candidates.Count; i++)
            {
                if (TryGetWeight(rows[candidates[i]], weightFieldGuid, out var weight) && weight > 0d)
                    totalWeight += weight;
            }

            if (totalWeight <= 0d)
                return SelectUniformIndex(candidates.Count, sample);

            var threshold = sample * totalWeight;
            double cumulative = 0d;
            var lastValidIndex = -1;

            for (var i = 0; i < candidates.Count; i++)
            {
                if (!TryGetWeight(rows[candidates[i]], weightFieldGuid, out var weight) || weight <= 0d)
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

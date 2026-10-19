using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Data Field")]
    public sealed class TransformSortByDataFieldBlock : TransformSortBlock
    {
        [Tooltip("The Data Definition used to find the matching Data Component on each Transform.")]
        public DataDefinition DataDefinition;

        [Tooltip("The exact field name to sort by.")]
        public StringVar FieldName;

        [Tooltip("If no matching Data Component is found, sort using the Data Definition default value for this field.")]
        public BoolVar UseDefaultsIfMissing;

        [NonSerialized]
        private SerializableGuid _cachedFieldGuid = SerializableGuid.None;

        [NonSerialized]
        private DataDefinition _cachedDefinition;

        [NonSerialized]
        private string _cachedFieldName;

        public override bool CanExecute() =>
            DataDefinition != null &&
            FieldName != null &&
            !string.IsNullOrWhiteSpace(FieldName.Value);

        public override bool TryGetSortValue(Transform transform, out object value)
        {
            value = null;

            if (transform == null || !TryResolveFieldGuid(out var fieldGuid))
                return false;

            var row = ResolveRow(transform.gameObject);
            if (row == null)
                return false;

            var cell = FindCell(row, fieldGuid);
            if (cell?.Value == null)
                return false;

            value = cell.Value.GetValue();
            return value != null;
        }

        public override string GetSummary()
        {
            var fieldName = FieldName?.Value;
            if (string.IsNullOrWhiteSpace(fieldName))
                fieldName = "Field";

            return $"Data Field {fieldName}";
        }

        private bool TryResolveFieldGuid(out SerializableGuid fieldGuid)
        {
            fieldGuid = SerializableGuid.None;

            var definition = DataDefinition;
            var fieldName = FieldName?.Value;
            if (definition == null || string.IsNullOrWhiteSpace(fieldName))
                return false;

            if (_cachedDefinition != definition || !string.Equals(_cachedFieldName, fieldName, StringComparison.Ordinal))
            {
                _cachedDefinition = definition;
                _cachedFieldName = fieldName;
                _cachedFieldGuid = definition.GetFieldGuidByName(fieldName);
            }

            fieldGuid = _cachedFieldGuid;
            return fieldGuid != SerializableGuid.None;
        }

        private DataRow ResolveRow(GameObject gameObject)
        {
            if (gameObject == null || DataDefinition == null)
                return null;

            var component = DataRecordComponent.FindMatching(gameObject, DataDefinition);
            if (component?.Data?.Data != null)
                return component.Data.Data;

            if (UseDefaultsIfMissing == null || !UseDefaultsIfMissing.Value)
                return null;

            var record = new DataRecord
            {
                DataDefinition = DataDefinition
            };
            record.ApplySchema(DataDefinition);
            record.ResetToDefaults();
            return record.Data;
        }

        private static DataRow.Cell FindCell(DataRow row, SerializableGuid fieldGuid)
        {
            var cells = row?.Cells;
            if (cells == null)
                return null;

            for (var i = 0; i < cells.Count; i++)
            {
                var cell = cells[i];
                if (cell != null && cell.FieldGuid == fieldGuid)
                    return cell;
            }

            return null;
        }
    }
}
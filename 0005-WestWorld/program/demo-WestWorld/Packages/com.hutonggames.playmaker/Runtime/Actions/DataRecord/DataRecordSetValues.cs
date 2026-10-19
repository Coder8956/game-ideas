using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataRecord)]
    [ActionDescription("Set values on a DataRecord using inputs based on the record schema.")]
    [HelpURL("actions/data-actions/data-record/data-record-set-values/")]
    public sealed class DataRecordSetValues : BaseAction
    {
        [Tooltip("The DataRecord to write values to.")]
        public DataRecordRef Record;
        
        public List<DataFieldValue> SetValues = new();

        public override bool CanExecute() => CheckParameters(Record);

        public override void Execute()
        {
            var record = Record.Value;
            if (record == null) return;

            var def = record.DataDefinition;
            if (def == null) return;

            var row = record.Data;
            if (row == null) return;

            record.EnsureSchemaUpToDate();

            // Build a lookup of row cells by guid (PoC; you can cache later)
            var cellByGuid = new Dictionary<SerializableGuid, IVariableVar>(row.Cells.Count);
            for (int i = 0; i < row.Cells.Count; i++)
            {
                var c = row.Cells[i];
                if (c == null) continue;
                if (c.FieldGuid == SerializableGuid.None) continue;
                if (c.Value == null) continue;
                cellByGuid[c.FieldGuid] = c.Value;
            }

            // Apply inputs by guid
            for (int i = 0; i < SetValues.Count; i++)
            {
                var s = SetValues[i];
                if (s == null || s.FieldGuid == SerializableGuid.None || s.Value == null)
                    continue;

                if (!cellByGuid.TryGetValue(s.FieldGuid, out var cellValue) || cellValue == null)
                    continue;

                cellValue.SetValue(s.Value.GetValue());
            }
        }

        public override string GetSummary() => "Set {Record} values";

#if UNITY_EDITOR
        public override string ErrorCheck()
        {
            var record = Record.Value;
            if (record == null) return null;

            if (record.DataDefinition == null)
                return "@Record: DataRecord has no DataDefinition assigned.";

            return null;
        }
#endif

    }
}

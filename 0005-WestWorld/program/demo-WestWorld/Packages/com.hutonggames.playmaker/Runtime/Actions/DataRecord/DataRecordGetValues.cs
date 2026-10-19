using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataRecord)]
    [ActionDescription("Get all values from a DataRecord and store them in variables based on the record schema.")]
    [HelpURL("actions/data-actions/data-record/data-record-get-values/")]
    public sealed class DataRecordGetValues : BaseAction
    {
        [Tooltip("The DataRecord to read values from.")]
        public DataRecordRef Record;
        
        public List<DataFieldStore> StoreValues = new();

        public override bool CanExecute() => CheckParameters(Record);

        public override void Execute()
        {
            var record = Record.Value;
            if (record == null)
            {
                return;
            }

            var def = record.DataDefinition;
            if (def == null)
            {
                return;
            }

            var row = record.Data;
            if (row == null)
            {
                return;
            }

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

            // Apply stores by guid
            for (int i = 0; i < StoreValues.Count; i++)
            {
                var s = StoreValues[i];
                if (s == null || s.FieldGuid == SerializableGuid.None || s.Store == null)
                    continue;

                if (!cellByGuid.TryGetValue(s.FieldGuid, out var cellValue))
                    continue;

                s.Store.SetValue(cellValue.GetValue());
            }
        }

        public override string GetSummary()
        {
            var summary = "Get {Record} values";
            
            foreach (var s in StoreValues)
                summary += s.GetSummary();
            
            return summary;
        }

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

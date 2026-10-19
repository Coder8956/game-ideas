using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataRecord)]
    [ActionDescription("Set the value of a field in a DataRecord.")]
    [HelpURL("actions/data-actions/data-record/data-record-set-value/")]
    public sealed class DataRecordSetValue : BaseAction, IDataDefinitionSource
    {
        [Tooltip("The DataRecord to write values to.")]
        public DataRecordRef Record;

        [Tooltip("DataDefinition to use when the DataRecord cannot be resolved at edit time." +
                 "<br/> This is required if the DataRecord reference is a variable.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Field/value to set.")]
        public DataFieldValue SetValue;

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("True if the field value was applied.")]
        public BoolRef Succeeded;

        public override bool CanExecute() =>
            SetValue != null && SetValue.FieldGuid != SerializableGuid.None && SetValue.Value != null;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;

            var record = Record.Value;
            if (record == null) return;

            var def = record.DataDefinition;
            if (def == null)
            {
                def = DataDefinition;
                if (def == null) return;

                record.DataDefinition = def;
            }

            record.ApplySchema(def);

            var ok = DataRowUtility.ApplyValue(record, SetValue);
            if (Succeeded.IsAssigned) Succeeded.Value = ok;
        }

        public override string GetSummary()
        {
            var def = Record.Value?.DataDefinition ?? DataDefinition;
            var fieldName = SetValue != null && def != null
                ? SetValue.GetFieldName(def)
                : "(field)";

            return $"Set <b>{fieldName}</b> on {{Record}} to {{SetValue.Value}} {{Succeeded:output}}";
        }

        public DataDefinition GetEditTimeDataDefinition() => Record.Value?.DataDefinition ?? DataDefinition;

        public override string ErrorCheck()
        {
            if (Record.Value?.DataDefinition == null && DataDefinition == null)
                return "@DataDefinition: This is needed when the DataRecord definition is not known at edit time.";
            return null;
        }
    }
}

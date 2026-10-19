using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataRecord)]
    [ActionDescription("Get the value of a field from a DataRecord.")]
    [HelpURL("actions/data-actions/data-record/data-record-get-value/")]
    public sealed class DataRecordGetValue : BaseAction, IDataDefinitionSource
    {
        [Tooltip("The DataRecord to read values from.")]
        public DataRecordRef Record;

        [Tooltip("DataDefinition to use when the DataRecord cannot be resolved at edit time." +
                 "<br/> This is required if the DataRecord reference is a variable.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [OptionalField]
        [Tooltip("Event to send if the DataRecord or field was not found.")]
        public EventRef NotFoundEvent;

        [Tooltip("Field/value to store.")]
        public DataFieldStore StoreValue = new();

        [OptionalField, WriteOnly]
        [Tooltip("True if the DataRecord and field were found and the value was stored.")]
        public BoolRef Found;

        public override bool CanExecute() => CheckParameters(Record);

        public override void Execute()
        {
            if (Found.IsAssigned) Found.Value = false;

            var record = Record.Value;
            if (record == null)
            {
                ApplyFallbackValue(GetEditTimeDataDefinition());
                SendEvent(NotFoundEvent);
                return;
            }

            record.EnsureSchemaUpToDate();

            if (!DataRowUtility.ApplyStore(record.Data, StoreValue))
            {
                ApplyFallbackValue(record.DataDefinition ?? DataDefinition);
                SendEvent(NotFoundEvent);
                return;
            }

            if (Found.IsAssigned) Found.Value = true;
        }

        public override string GetSummary()
        {
            var def = Record.Value?.DataDefinition ?? DataDefinition;
            return "Get <b>" +
                   StoreValue.GetFieldName(def) +
                   $"</b> from {{Record}} {{StoreValue.Store:output}} {{Found:output}}";
        }

        public DataDefinition GetEditTimeDataDefinition() => Record.Value?.DataDefinition ?? DataDefinition;

        private void ApplyFallbackValue(DataDefinition definition)
        {
            var store = StoreValue?.Store;
            if (store == null)
                return;

            if (TryApplySchemaDefault(definition))
            {
                return;
            }

            store.Reset();
        }

        private bool TryApplySchemaDefault(DataDefinition definition)
        {
            if (definition == null)
                return false;

            var fieldGuid = StoreValue?.FieldGuid ?? SerializableGuid.None;
            if (fieldGuid == SerializableGuid.None)
                return false;

            var record = new DataRecord { DataDefinition = definition };
            record.ApplySchema(definition);
            record.ResetToDefaults(definition);

            return DataRowUtility.ApplyStore(record.Data, StoreValue);
        }

        public override string ErrorCheck()
        {
            if (Record.Value?.DataDefinition == null && DataDefinition == null)
                return "@DataDefinition: This is needed when the DataRecord definition is not known at edit time.";
            return null;
        }
    }
}

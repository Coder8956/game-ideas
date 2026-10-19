using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataComponent)]
    [ActionDescription("Get the value of a field from a Data Component.")]
    [HelpURL("actions/data-actions/game-object/data-component-get-field-value/")]
    public sealed class DataComponentGetFieldValue : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The Data Component to read values from.")]
        public DataRecordComponentVar DataComponent;

        [Tooltip("DataDefinition to use when the Data Component cannot be resolved at edit time." +
                 "<br/> This is required if the Data Component reference is a variable.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [OptionalField]
        [Tooltip("Event to send if the Data Component or record was not found.")]
        public EventRef NotFoundEvent;

        public DataFieldStore StoreValue = new();

        [OptionalField, WriteOnly]
        [Tooltip("True if the Data Component and field were found and the value was stored.")]
        public BoolRef Found;

        public override bool CanExecute() => CheckParameters(DataComponent);

        public override void Execute()
        {
            if (Found.IsAssigned) Found.Value = false;

            if (!TryGetRow(out var row))
            {
                ApplyFallbackValue(GetDefinition());
                SendEvent(NotFoundEvent);
                return;
            }

            if (!DataRowUtility.ApplyStore(row, StoreValue))
            {
                ApplyFallbackValue(GetDefinition());
                SendEvent(NotFoundEvent);
                return;
            }

            if (Found.IsAssigned) Found.Value = true;
        }

        public override string GetSummary()
        {
            var def = DataComponent.Value?.Data?.DataDefinition ?? DataDefinition;
            return "Get <b>" +
                   StoreValue.GetFieldName(def) +
                   $"</b> from {{DataComponent}} {{StoreValue.Store:output}}";
        }

        private bool TryGetRow(out DataRow row)
        {
            row = null;

            var component = DataComponent.Value;
            if (component == null)
                return false;

            var record = component.Data;
            if (record == null)
                return false;

            row = record.Data;
            return row != null;
        }

        private DataDefinition GetDefinition() =>
            DataComponent.Value?.Data?.DataDefinition ?? DataDefinition;

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
            if (DataComponent.IsVariable && DataDefinition == null)
                return "@DataDefinition: This is needed when the Data Component is not known at edit time.";
            return null;
        }
    }
}

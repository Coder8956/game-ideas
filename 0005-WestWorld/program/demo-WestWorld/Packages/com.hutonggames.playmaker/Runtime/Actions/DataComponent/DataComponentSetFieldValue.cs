using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataComponent)]
    [ActionDescription("Set the value of a field in a Data Component.")]
    [HelpURL("actions/data-actions/game-object/data-component-set-field-value/")]
    public sealed class DataComponentSetFieldValue : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The Data Component to write values to.")]
        public DataRecordComponentVar DataComponent;

        [Tooltip("DataDefinition to use when the Data Component cannot be resolved at edit time." +
                 "<br/> This is required if the Data Component reference is a variable.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Field/value to set.")]
        public DataFieldValue SetValue;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the Data Component or record was not found.")]
        public EventRef NotFoundEvent;

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("True if the field value was applied.")]
        public BoolRef Succeeded;

        public override bool CanExecute() =>
            SetValue != null && SetValue.FieldGuid != SerializableGuid.None && SetValue.Value != null;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;

            var component = DataComponent.Value;
            if (component == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var record = component.Data;
            if (record == null)
            {
                var sourceDef = DataDefinition;
                if (sourceDef == null)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                record = new DataRecord { DataDefinition = sourceDef };
                record.ApplySchema(sourceDef);
                component.Data = record;
            }

            var def = record.DataDefinition;
            if (def == null)
            {
                def = DataDefinition;
                if (def == null)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                record.DataDefinition = def;
            }

            // Ensure schema (creates missing cells, fixes drift)
            record.ApplySchema(def);

            var ok = DataRowUtility.ApplyValue(record, SetValue);
            if (Succeeded.IsAssigned) Succeeded.Value = ok;
        }

        public override string GetSummary()
        {
            var def = DataComponent.Value?.Data?.DataDefinition ?? DataDefinition;
            var fieldName = SetValue != null && def != null
                ? SetValue.GetFieldName(def)
                : "(field)";

            return $"Set <b>{fieldName}</b> on {{DataComponent}} to {{SetValue.Value}}";
        }

        public override string ErrorCheck()
        {
            if (DataComponent.IsVariable && DataDefinition == null)
                return "@DataDefinition: This is needed when the Data Component is not known at edit time.";
            return null;
        }
    }
}

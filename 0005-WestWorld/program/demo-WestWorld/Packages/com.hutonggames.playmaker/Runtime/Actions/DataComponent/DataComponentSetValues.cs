using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataComponent)]
    [ActionDescription("Set multiple field values in a Data Component.")]
    [HelpURL("actions/data-actions/game-object/data-component-set-values/")]
    public sealed class DataComponentSetValues : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The Data Component to write values to.")]
        public DataRecordComponentVar DataComponent;

        [Tooltip("DataDefinition to use when the Data Component cannot be resolved at edit time." +
                 "<br/> This is required if the Data Component reference is a variable.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Field values to set on the Data Component record.")]
        public List<DataFieldValue> SetValues = new();

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the Data Component or record was not found.")]
        public EventRef NotFoundEvent;

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("True if field values were applied to the Data Component.")]
        public BoolRef Succeeded;

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

            DataRowUtility.ApplyValues(record, SetValues);

            if (Succeeded.IsAssigned) Succeeded.Value = true;
        }

        public override string GetSummary() =>
            "Set values on {DataComponent}";

        public override string ErrorCheck()
        {
            if (DataComponent.IsVariable && DataDefinition == null)
                return "@DataDefinition: This is needed when the Data Component is not known at edit time.";
            return null;
        }
    }
}

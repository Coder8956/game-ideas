using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataComponent)]
    [ActionDescription("Get multiple field values from a Data Component.")]
    [HelpURL("actions/data-actions/game-object/data-component-get-values/")]
    public sealed class DataComponentGetValues : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The Data Component to read values from.")]
        public DataRecordComponentVar DataComponent;

        [Tooltip("DataDefinition to use when the Data Component cannot be resolved at edit time." +
                 "<br/> This is required if the Data Component reference is a variable.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Field stores to populate from the Data Component record.")]
        public List<DataFieldStore> GetValues = new();

        [ActionHeader("Output")]
        [OptionalField]
        [Tooltip("Event to send if the Data Component or record was not found.")]
        public EventRef NotFoundEvent;

        [OptionalField, WriteOnly]
        [Tooltip("True if field values were applied to outputs.")]
        public BoolRef Succeeded;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;

            if (!TryGetRow(out var row))
            {
                SendEvent(NotFoundEvent);
                return;
            }

            if (GetValues is { Count: > 0 })
                DataRowUtility.ApplyStores(row, GetValues);

            if (Succeeded.IsAssigned) Succeeded.Value = true;
        }

        public override string GetSummary() =>
            "Get values from {DataComponent}";

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

        public override string ErrorCheck()
        {
            if (DataComponent.IsVariable && DataDefinition == null)
                return "@DataDefinition: This is needed when the Data Component is not known at edit time.";
            return null;
        }
    }
}
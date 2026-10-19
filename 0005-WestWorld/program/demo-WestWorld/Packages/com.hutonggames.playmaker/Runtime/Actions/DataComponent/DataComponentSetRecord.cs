using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataComponent)]
    [ActionDescription("Copy values from a DataRecord into a Data Component record.\n\nThis always copies values; the component keeps its own record instance.")]
    [HelpURL("actions/data-actions/game-object/data-component-set-record/")]
    public sealed class DataComponentSetRecord : BaseAction
    {
        [NotOwnerDefaultValue]
        [Tooltip("The Data Component to write to.")]
        public DataRecordComponentVar DataComponent;

        [Tooltip("The DataRecord to copy values from.")]
        public DataRecordRef Record;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the Data Component or source record was not found.")]
        public EventRef NotFoundEvent;

        [ActionHeader("Output")]
        [OptionalField, WriteOnly]
        [Tooltip("True if values were copied to the Data Component.")]
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

            var source = Record.Value;
            if (source == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var target = component.Data;
            if (target == null)
            {
                var sourceDef = source.DataDefinition;
                if (sourceDef == null)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                target = new DataRecord { DataDefinition = sourceDef };
                target.ApplySchema(sourceDef);
                component.Data = target;
            }

            var targetDef = target.DataDefinition;
            if (targetDef == null)
            {
                targetDef = source.DataDefinition;
                if (targetDef == null)
                {
                    SendEvent(NotFoundEvent);
                    return;
                }

                target.DataDefinition = targetDef;
            }

            // Ensure target storage is schema-synced before copy.
            target.ApplySchema(targetDef);

            DataRecordCopyUtility.SetValue(target, source);
            target.NotifyChanged();

            if (Succeeded.IsAssigned) Succeeded.Value = true;
        }

        public override string GetSummary() =>
            "{Record} -> {DataComponent}";
    }
}

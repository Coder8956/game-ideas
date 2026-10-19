using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataComponent)]
    [ActionDescription("Copy data from a Data Component into a DataRecord.\n\nThis always copies; editing the DataRecord does not modify the component.")]
    [HelpURL("actions/data-actions/game-object/data-component-get-record/")]
    public sealed class DataComponentGetRecord : BaseAction, IDataDefinitionSource
    {
        [NotOwnerDefaultValue]
        [Tooltip("The source Data Component.")]
        public DataRecordComponentVar DataComponent;

        [ActionHeader("Outputs")]
        [WriteOnly]
        [Tooltip("Receives a copy of the Data Component record as a DataRecord.")]
        public DataRecordRef Record;

        [Tooltip("What to do with the output record when the Data Component record is not found.")]
        [SerializeField, DefaultValue(DataTableMissingRecordBehavior.KeepExisting)]
        public DataTableMissingRecordBehavior OnRecordNotFound = DataTableMissingRecordBehavior.KeepExisting;

        [OptionalField, WriteOnly]
        [Tooltip("True if the Data Component had a valid record and it was copied, otherwise false.")]
        public BoolRef Found;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the Data Component or record was not found.")]
        public EventRef NotFoundEvent;

        public override void Execute()
        {
            if (Found.IsAssigned) Found.Value = false;

            var fallbackDefinition = Record?.Value?.DataDefinition;
            var outputRecord = DataTableUtility.EnsureRecordExists(Record, fallbackDefinition);

            var component = DataComponent.Value;
            if (component == null)
            {
                DataTableUtility.ApplyMissingRecordBehavior(fallbackDefinition, outputRecord, OnRecordNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            var source = component.Data;
            if (source == null)
            {
                DataTableUtility.ApplyMissingRecordBehavior(fallbackDefinition, outputRecord, OnRecordNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            var def = source.DataDefinition;
            if (def == null)
            {
                DataTableUtility.ApplyMissingRecordBehavior(fallbackDefinition, outputRecord, OnRecordNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            var row = source.Data;
            if (row == null)
            {
                DataTableUtility.ApplyMissingRecordBehavior(fallbackDefinition, outputRecord, OnRecordNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            outputRecord = DataTableUtility.EnsureRecordExists(Record, def);
            DataRecordCopyUtility.CopyFromRow(outputRecord, def, row);
            if (Found.IsAssigned) Found.Value = true;
        }

        public override string GetSummary() =>
            "{DataComponent} -> {Record}";

        public DataDefinition GetEditTimeDataDefinition() => DataComponent?.Value?.Data?.DataDefinition;
    }
}

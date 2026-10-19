using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTable)]
    [ActionDescription("Copy a row from a DataTable into a DataRecord.\n\nThis always copies; editing the DataRecord does not modify the table.")]
    [HelpURL("actions/data-actions/data-table/data-table-get-record/")]
    public sealed class DataTableGetRecord : BaseAction, IDataTableAction
    {
        DataTableSource IDataTableAction.DataTable => DataTable;
        DataDefinition IDataTableAction.DataDefinition => DataDefinition;

        [Tooltip("The source DataTable.")]
        public DataTableSource DataTable;

        [Tooltip("DataDefinition to use when the table cannot be resolved at edit time." +
                 "<br/> This is only needed when the table definition is unavailable at edit time.")]
        [OptionalField]
        public DataDefinition DataDefinition;

        [Tooltip("Find row by key or index.")]
        public DataTableRow Row;

        [ActionHeader("Outputs")]
        [WriteOnly]
        [Tooltip("Receives a copy of the row as a DataRecord.")]
        public DataRecordRef Record;

        [Tooltip("What to do with the output record when the row is not found.")]
        [SerializeField, DefaultValue(DataTableMissingRecordBehavior.KeepExisting)]
        public DataTableMissingRecordBehavior OnRowNotFound = DataTableMissingRecordBehavior.KeepExisting;

        [OptionalField, WriteOnly]
        [Tooltip("True if a matching row was found and copied, otherwise false.")]
        public BoolRef Found;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the row was not found.")]
        public EventRef NotFoundEvent;

        public override void Execute()
        {
            if (Found is { IsAssigned: true }) Found.Value = false;

            var outputRecord = DataTableUtility.EnsureRecordExists(Record, DataDefinition);
            
            var table = DataTable.ResolveData();
            if (table == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var def = table.DataDefinition ?? DataDefinition;
            if (def == null)
            {
                DataTableUtility.ApplyMissingRecordBehavior(DataDefinition, outputRecord, OnRowNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            outputRecord = DataTableUtility.EnsureRecordExists(Record, def);

            var row = Row.Resolve(table);
            if (row == null)
            {
                DataTableUtility.ApplyMissingRecordBehavior(def, outputRecord, OnRowNotFound);
                SendEvent(NotFoundEvent);
                return;
            }

            table.EnsureRowSchemaUpToDate(row);
            DataRecordCopyUtility.CopyFromRow(outputRecord, def, row);
            if (Found is { IsAssigned: true }) Found.Value = true;
        }

        public override string GetSummary() => 
            $"Get {DataTable.GetSummary()} row {Row.GetSummary()} {{Record:output}} {{Found:output}}";

        public override string ErrorCheck()
        {
            if (DataTable.GetEditTimeDataDefinition() == null && DataDefinition == null)
                return "@DataDefinition: This is needed when the table is not known at edit time.";

            return null;
        }
    }
}

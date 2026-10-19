using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.DataTableComponent)]
    [ActionDescription("Get a DataTable from a DataTable Component.")]
    public sealed class DataTableComponentGetDataTable : BaseAction, IDataTableDefinitionSource
    {
        [Tooltip("The DataTable Component to read from.")]
        public DataTableComponentVar DataTableComponent;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("Store the DataTable from the component.")]
        public DataTableRef DataTable;

        [OptionalField, WriteOnly]
        [Tooltip("True if the DataTable component was found and returned a table.")]
        public BoolRef Succeeded;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the DataTable component or table was not found.")]
        public EventRef NotFoundEvent;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;
            if (DataTable.IsAssigned) DataTable.Value = null;

            var component = DataTableComponent.Value;
            if (component == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var table = component.Table;
            if (table == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            if (DataTable.IsAssigned) DataTable.Value = table;
            if (Succeeded.IsAssigned) Succeeded.Value = true;
        }

        public override string GetSummary() =>
            "Get DataTable from {DataTableComponent} {DataTable:output} {Succeeded:output}";

        public DataDefinition GetEditTimeDataDefinition() => DataTableComponent?.Value?.DataDefinition;
    }
}

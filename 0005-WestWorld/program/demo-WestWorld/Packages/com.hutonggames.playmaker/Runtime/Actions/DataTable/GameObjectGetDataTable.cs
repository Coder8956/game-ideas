using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameObjectData)]
    [ActionDescription("Get a DataTable from a DataTable Component on a GameObject.")]
    public sealed class GameObjectGetDataTable : BaseAction, IDataTableDefinitionSource
    {
        [Tooltip("The GameObject to read the DataTable Component from.")]
        public GameObjectVar GameObject;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("Store the DataTable Component found on the GameObject.")]
        public DataTableComponentRef DataTableComponent;

        [OptionalField, WriteOnly]
        [Tooltip("Store the DataTable from the component.")]
        public DataTableRef DataTable;

        [OptionalField, WriteOnly]
        [Tooltip("True if a DataTable component was found on the GameObject.")]
        public BoolRef Succeeded;

        [ActionHeader("Events")]
        [OptionalField]
        [Tooltip("Event to send if the GameObject, DataTable component, or table was not found.")]
        public EventRef NotFoundEvent;

        public override void Execute()
        {
            if (Succeeded.IsAssigned) Succeeded.Value = false;
            if (DataTableComponent.IsAssigned) DataTableComponent.Value = null;
            if (DataTable.IsAssigned) DataTable.Value = null;

            var go = GameObject.Value;
            if (go == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            var component = go.GetComponent<DataTableComponent>();
            if (component == null)
            {
                SendEvent(NotFoundEvent);
                return;
            }

            if (DataTableComponent.IsAssigned) DataTableComponent.Value = component;

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
            "Get {GameObject} DataTable {DataTableComponent:output} {DataTable:output} {Succeeded:output}";

        public DataDefinition GetEditTimeDataDefinition() =>
            GameObject?.Value != null
                ? GameObject.Value.GetComponent<DataTableComponent>()?.DataDefinition
                : null;
    }
}

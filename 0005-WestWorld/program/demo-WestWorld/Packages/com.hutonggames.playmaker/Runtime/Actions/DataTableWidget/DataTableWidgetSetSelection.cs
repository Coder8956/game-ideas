using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Sets selection on a DataTableWidget using a row key or row index.")]
    public sealed class DataTableWidgetSetSelection : BaseAction
    {
        [Tooltip("The DataTableWidget.")]
        public DataTableWidgetVar Widget;

        [Tooltip("Select row by key or by index.")]
        public DataTableRow Row;

        [ActionHeader("Options")]

        [OptionalField]
        [DefaultValue(true)]
        [Tooltip("Clear the current selection when the row cannot be resolved.")]
        public BoolVar ClearIfNotFound;

        [OptionalField]
        [DefaultValue(true)]
        [Tooltip("Also sync Unity UI EventSystem.currentSelectedGameObject when possible.")]
        public BoolVar SyncEventSystemSelection;

        [OptionalField]
        [Tooltip("Event to send if no matching row was found.")]
        public EventRef NotFoundEvent;

        public override bool CanExecute() => CheckParameters(Widget, Row);

        public override void Execute()
        {
            var widget = Widget.Value;
            if (widget == null) return;
            if (Row == null) return;

            var clearIfNotFound = ClearIfNotFound.IsNone || ClearIfNotFound.Value;
            var syncEventSystemSelection = SyncEventSystemSelection.IsNone || SyncEventSystemSelection.Value;

            var table = widget.CurrentTable;
            var row = table != null ? Row.Resolve(table) : null;

            if (row == null)
            {
                if (clearIfNotFound)
                    widget.ClearSelection(syncEventSystemSelection);

                SendEvent(NotFoundEvent);
                return;
            }

            widget.SetSelection(row.Id, row.Key, syncEventSystemSelection);
        }
        
    }
}

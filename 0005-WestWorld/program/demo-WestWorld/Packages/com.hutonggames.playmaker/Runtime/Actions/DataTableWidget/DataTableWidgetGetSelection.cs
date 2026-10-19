using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Gets current selection from a DataTableWidget.")]
    public sealed class DataTableWidgetGetSelection : BaseAction
    {
        [Tooltip("The DataTableWidget.")]
        public DataTableWidgetVar Widget;

        [ActionHeader("Options")]

        [OptionalField]
        [DefaultValue(true)]
        [Tooltip("If the widget has no internal selection, try mapping EventSystem.currentSelectedGameObject back to a row.")]
        public BoolVar EventSystemFallback;

        [ActionHeader("Outputs")]

        [OptionalField, WriteOnly]
        [Tooltip("True when a selection is available.")]
        public BoolRef HasSelection;

        [OptionalField, WriteOnly]
        [Tooltip("Selected row key (empty if key is not used).")]
        public StringRef SelectedRowKey;

        [OptionalField, WriteOnly]
        [Tooltip("Selected row index in the DataTable, or -1 if unavailable.")]
        public IntegerRef SelectedRowIndex;

        [OptionalField, WriteOnly]
        [Tooltip("Selected row GameObject if currently visible; otherwise null.")]
        public GameObjectRef SelectedRowGameObject;

        public override bool CanExecute() => CheckParameters(Widget);

        public override void Execute()
        {
            if (HasSelection != null) HasSelection.Value = false;
            if (SelectedRowKey != null) SelectedRowKey.Value = null;
            if (SelectedRowIndex != null) SelectedRowIndex.Value = -1;
            if (SelectedRowGameObject != null) SelectedRowGameObject.Value = null;

            var widget = Widget.Value;
            if (widget == null) return;

            var eventSystemFallback = EventSystemFallback.IsNone || EventSystemFallback.Value;
            if (!widget.TryGetSelection(out _, out var selectedRowKey, eventSystemFallback))
                return;

            if (HasSelection != null) HasSelection.Value = true;
            if (SelectedRowKey != null) SelectedRowKey.Value = selectedRowKey;
            if (SelectedRowIndex != null) SelectedRowIndex.Value = widget.GetSelectedTableIndex(eventSystemFallback);

            if (widget.TryGetSelectedItemGameObject(out var itemGameObject, eventSystemFallback))
            {
                if (SelectedRowGameObject != null)
                    SelectedRowGameObject.Value = itemGameObject;
            }
        }

        public override string GetSummary() =>
            "Get selection from {Widget} {HasSelection:output} {SelectedRowKey:output} {SelectedRowIndex:output}";
    }
}

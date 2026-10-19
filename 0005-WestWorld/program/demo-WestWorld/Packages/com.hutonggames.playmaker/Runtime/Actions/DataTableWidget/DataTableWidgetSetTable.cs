using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Sets the runtime DataTable used by a DataTableWidget directly.")]
    public sealed class DataTableWidgetSetTable : BaseAction
    {
        [Tooltip("The DataTableWidget.")]
        public DataTableWidgetVar Widget;

        [Tooltip("The DataTable to display. Set to None to clear the runtime override and use the widget's DataTableReference.")]
        public DataTableVar Table;

        [ActionHeader("Options")]

        [OptionalField]
        [DefaultValue(true)]
        [Tooltip("Rebuild the widget after changing the table.")]
        public BoolVar Rebuild;

        [OptionalField]
        [DefaultValue(true)]
        [Tooltip("Reset scroll position to the top when rebuilding.")]
        public BoolVar ResetScroll;

        public override bool CanExecute() => CheckParameters(Widget);

        public override void Execute()
        {
            var widget = Widget.Value;
            if (widget == null)
                return;

            var rebuild = Rebuild.IsNone || Rebuild.Value;
            var resetScroll = ResetScroll.IsNone || ResetScroll.Value;

            widget.SetTable(Table?.Value, rebuild, resetScroll);
        }

        public override string GetSummary() => "Set {Widget} Table {Table}";
    }
}

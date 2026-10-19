using System;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Clears all visible rows from a DataTableWidget.")]
    public sealed class DataTableWidgetClear : BaseAction
    {
        [Tooltip("The DataTableWidget.")]
        public DataTableWidgetVar Widget;

        public override void Execute()
        {
            var widget = Widget.Value;
            if (widget == null) return;

            widget.Clear();
        }

        public override string GetSummary() => "Clear {Widget}";
    }
}
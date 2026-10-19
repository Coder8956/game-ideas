using System;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Refreshes a DataTableWidget, " +
                       "reapplying values to the visible rows without recreating them.")]
    public sealed class DataTableWidgetRefresh : BaseAction
    {
        [Tooltip("The DataTableWidget to refresh.")]
        public DataTableWidgetVar Widget;

        public override void Execute()
        {
            var widget = Widget.Value;
            if (widget == null) return;

            widget.Refresh();
        }

        public override string GetSummary() => "Refresh {Widget}";
    }
}
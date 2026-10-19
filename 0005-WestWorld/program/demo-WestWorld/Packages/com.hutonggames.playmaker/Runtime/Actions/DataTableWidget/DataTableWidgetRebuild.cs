using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Rebuilds a DataTableWidget, recreating the visible row UI " +
                       "(e.g., after paging, sorting, or row add/remove).")]
    public sealed class DataTableWidgetRebuild : BaseAction
    {
        [Tooltip("The DataTableWidget to rebuild.")]
        public DataTableWidgetVar Widget;

        [ActionHeader("Options")]

        [OptionalField]
        [Tooltip("Reset scroll position to the top after rebuilding.")]
        [DefaultValue(true)]
        public BoolVar ResetScroll;

        public override void Execute()
        {
            var widget = Widget.Value;
            if (widget == null) return;

            var resetScroll = ResetScroll.IsNone || ResetScroll.Value;
            widget.Rebuild(resetScroll);
        }

        public override string GetSummary() => "Rebuild {Widget} widget";
    }
}
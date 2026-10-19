using System;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [Obsolete("Use DataPagingPreviousPage action instead.")]
    [ConvertibleGroup("DataPaging")]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Shows the previous page of a DataTableWidget.")]
    public sealed class DataTableWidgetPreviousPage : BaseAction
    {
        [Tooltip("The DataTableWidget.")]
        public DataTableWidgetVar Widget;

        [ActionHeader("Options")]
        [OptionalField]
        [DefaultValue(true)]
        [Tooltip("Rebuild the widget after changing page.")]
        public BoolVar Rebuild;

        [OptionalField]
        [DefaultValue(true)]
        [Tooltip("Reset scroll position after rebuilding.")]
        public BoolVar ResetScroll;

        public override void Execute()
        {
            // Obsolete
        }

        public override string GetSummary() => "Show previous page for {Widget}";
    }
}

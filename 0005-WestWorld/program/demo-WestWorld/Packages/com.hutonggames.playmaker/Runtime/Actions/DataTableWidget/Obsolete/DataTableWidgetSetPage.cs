using System;
using UnityEngine;
using HutongGames.PlayMaker.UI;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [Obsolete("Use DataPagingSetPage action instead.")]
    [ConvertibleGroup("DataPaging")]
    [ActionCategory(Category.DataTableWidget)]
    [ActionDescription("Sets the current page index on a DataTableWidget.")]
    public sealed class DataTableWidgetSetPage : BaseAction
    {
        [Tooltip("The DataTableWidget.")]
        public DataTableWidgetVar Widget;

        [ActionHeader("Paging")]
        [Tooltip("Zero-based page index to display.")]
        public IntegerVar PageIndex;

        [ActionHeader("Options")]
        [OptionalField]
        [Tooltip("Rebuild the widget after changing page.")]
        [DefaultValue(true)]
        public BoolVar Rebuild;

        [OptionalField]
        [Tooltip("Reset scroll position after rebuilding.")]
        [DefaultValue(true)]
        public BoolVar ResetScroll;

        public override void Execute()
        {
            // Obsolete
        }

        public override string GetSummary() => "Set Page {PageIndex} on {Widget}";
    }
}
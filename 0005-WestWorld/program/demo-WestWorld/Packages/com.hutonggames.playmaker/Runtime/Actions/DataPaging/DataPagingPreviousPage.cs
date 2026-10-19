using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataPaging)]
    [ActionDescription("Shows the previous page using a DataPaging component.")]
    [HelpURL("actions/data-actions/data-paging/data-paging-previous-page/")]
    public sealed class DataPagingPreviousPage : BaseAction
    {
        [Tooltip("The DataPaging component.")]
        public DataPagingVar Paging;

        [ActionHeader("Options")]

        [OptionalField]
        [DefaultValue(true)]
        [Tooltip("Rebuild the target after changing page.")]
        public BoolVar Rebuild;

        [OptionalField]
        [DefaultValue(true)]
        [Tooltip("Reset scroll position after rebuilding.")]
        public BoolVar ResetScroll;

        public override void Execute()
        {
            var paging = Paging.Value;
            if (paging == null) return;

            var rebuild = Rebuild.IsNone || Rebuild.Value;
            var resetScroll = ResetScroll.IsNone || ResetScroll.Value;

            paging.PreviousPage(rebuild, resetScroll);
        }

        public override string GetSummary() => "Show previous page for {Paging}";
    }
}

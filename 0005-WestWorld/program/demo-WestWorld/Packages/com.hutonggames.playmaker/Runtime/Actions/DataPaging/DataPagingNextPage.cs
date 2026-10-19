using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataPaging)]
    [ActionDescription("Shows the next page using a DataPaging component.")]
    [HelpURL("actions/data-actions/data-paging/data-paging-next-page/")]
    public sealed class DataPagingNextPage : BaseAction
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

            paging.NextPage(rebuild, resetScroll);
        }

        public override string GetSummary() => "Show next page for {Paging}";
    }
}

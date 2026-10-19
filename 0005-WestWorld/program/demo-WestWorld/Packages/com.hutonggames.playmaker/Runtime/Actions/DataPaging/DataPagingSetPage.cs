using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataPaging)]
    [ActionDescription("Sets the current page using a DataPaging component.")]
    [HelpURL("actions/data-actions/data-paging/data-paging-set-page/")]
    public sealed class DataPagingSetPage : BaseAction
    {
        [Tooltip("The DataPaging component.")]
        public DataPagingVar Paging;

        [Tooltip("Zero-based page index to show.")]
        public IntegerVar PageIndex;

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

            paging.SetPage(PageIndex.Value, rebuild, resetScroll);
        }

        public override string GetSummary() => "Set {Paging} page to {PageIndex}";
    }
}
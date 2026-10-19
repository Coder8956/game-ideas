using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.DataPaging)]
    [ActionDescription("Gets paging info (page index, total pages, total items) from a DataPaging component.")]
    [HelpURL("actions/data-actions/data-paging/data-paging-get-page-info/")]
    public sealed class DataPagingGetPageInfo : BaseAction
    {
        [Tooltip("The DataPaging component.")]
        public DataPagingVar Paging;

        [ActionHeader("Output")]

        [OptionalField, WriteOnly]
        [Tooltip("Zero-based current page index.")]
        public IntegerRef PageIndex;

        [OptionalField, WriteOnly]
        [Tooltip("Total number of pages.")]
        public IntegerRef TotalPages;

        [OptionalField, WriteOnly]
        [Tooltip("Total number of items in the target.")]
        public IntegerRef TotalItems;

        public override void Execute()
        {
            var paging = Paging.Value;
            if (paging == null) return;

            if (!paging.TryGetPageInfo(out int pageIndex, out int totalPages, out int totalItems))
                return;

            if (!PageIndex.IsNone) PageIndex.Value = pageIndex;
            if (!TotalPages.IsNone) TotalPages.Value = totalPages;
            if (!TotalItems.IsNone) TotalItems.Value = totalItems;
        }

        public override string GetSummary() =>
            "Get {Paging} page info {PageIndex:output} {TotalPages:output} {TotalItems:output}";
    }
}
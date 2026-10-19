using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Implemented by widgets that support paging (e.g. DataTableWidget).
    /// Paging UI is owned by <see cref="DataPaging"/>.
    /// </summary>
    public interface IDataPagingTarget
    {
        /// <summary>
        /// Total number of items in the backing collection.
        /// </summary>
        int TotalItemCount { get; }

        /// <summary>
        /// Set the current page index.
        /// </summary>
        void SetPage(int pageIndex, bool rebuild, bool resetScroll);

        /// <summary>
        /// Get page info for the given page size.
        /// </summary>
        void GetPageInfo(int pageSize, out int pageIndex, out int totalPages);
    }
}

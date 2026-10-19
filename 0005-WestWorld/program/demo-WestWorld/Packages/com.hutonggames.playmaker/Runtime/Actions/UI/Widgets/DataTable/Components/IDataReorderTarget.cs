using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Implemented by widgets that support drag-to-reorder.
    /// The dragger owns the UI interaction; the target owns the data move semantics.
    /// </summary>
    public interface IDataReorderTarget
    {
        /// <summary>
        /// Layout container whose children represent the visible items (e.g. ScrollRect Content).
        /// </summary>
        RectTransform Content { get; }

        /// <summary>
        /// Called at drag start to resolve the dragged item to an absolute index in the backing collection,
        /// and to provide the current visible slice for insert calculations.
        /// </summary>
        bool TryBeginReorder(
            GameObject itemGameObject,
            object payload,
            out int fromAbsoluteIndex,
            out int visibleStart,
            out int visibleCount);

        /// <summary>
        /// Insert semantics: move the item at <paramref name="fromAbsoluteIndex"/> so it ends up
        /// BEFORE <paramref name="insertBeforeAbsoluteIndex"/>.
        ///
        /// insertBeforeAbsoluteIndex is allowed to be RowCount (drop at end).
        /// Implementations may clamp/restrict to the visible slice (paging).
        /// </summary>
        bool TryInsertAbsolute(int fromAbsoluteIndex, int insertBeforeAbsoluteIndex);

        /// <summary>
        /// Request the widget to rebuild/refresh after end/cancel.
        /// </summary>
        void RequestRebuild();
    }
}
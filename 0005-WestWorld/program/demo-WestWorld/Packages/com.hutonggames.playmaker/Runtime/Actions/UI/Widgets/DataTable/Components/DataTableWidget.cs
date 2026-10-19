// DataTableWidget.cs
// uGUI runtime widget that maps a DataTable (via DataTableReference) to a repeated RowPrefab.
// Supports pooling + optional paging. RowId is primary identity, RowKey optional.

using System;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Optional row-prefab hook for item enter/exit transitions.
    /// Implement this on a component attached to the row prefab (or its children).
    /// </summary>
    public interface IDataTableRowTransition
    {
        /// <summary>Called when a row becomes visible.</summary>
        void PlayEnter();

        /// <summary>
        /// Called when a row is removed.
        /// Return true if exit is asynchronous and <paramref name="onComplete"/> will be invoked when finished.
        /// Return false for immediate completion.
        /// </summary>
        bool TryPlayExit(Action onComplete);
    }

    /// <summary>
    /// Displays rows from a DataTable using a row prefab.
    /// Supports pooling, paging slice selection, and automatic rebuilding when the table changes.
    ///
    /// Paging UI is handled by <see cref="DataPaging"/> (optional).
    /// Drag-to-reorder interaction is handled by <see cref="DataReorderDragger"/> (optional).
    ///
    /// Paging is considered active if a <see cref="DataPaging"/> reference is assigned and enabled.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Table Widget")]
    [Icon(Strings.EditorIconsPath + "DataTableWidgetIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-table-widget/")]
    public sealed class DataTableWidget : MonoBehaviour,
        IDataItemActionHost,
        IDataPagingTarget,
        IDataReorderTarget,
        ISelectHandler
    {
        public event Action<DataUIActionRequest> RowAction;

        private void RaiseRowAction(in DataUIActionRequest request)
        {
            RowAction?.Invoke(request);
        }

        [SerializeField, Tooltip(
            "Select the Data Table to display. You can reference a DataTableAsset (project asset) " +
            "or a DataTableComponent (scene object).")]
        private DataTableReference _table;

        // UI

        [SerializeField, Tooltip(
            "Parent RectTransform that will contain the generated row instances. " +
            "Typically this is the Content object of a ScrollRect with a VerticalLayoutGroup.")]
        private RectTransform _content;

        [SerializeField, Tooltip(
            "Prefab used to create each visible row. The prefab should contain a DataItemUI " +
            "component on the root or in its children.")]
        private GameObject _rowPrefab;

        [SerializeField, OptionalField, Tooltip(
            "Optional ScrollRect used to reset the scroll position when rebuilding or changing pages.")]
        private ScrollRect _scrollRect;

        // Extracted components

        [SerializeField, OptionalField, Tooltip("Optional paging controller (UI). Paging is active when this is enabled.")]
        private DataPaging _paging;

        [SerializeField, OptionalField, Tooltip("Optional drag-to-reorder controller.")]
        private DataReorderDragger _reorderDragger;

        // Lifecycle

        [SerializeField, Tooltip(
            "Rebuild the visible rows automatically when this component becomes enabled.")]
        private bool _rebuildOnEnable = true;

        [SerializeField, Tooltip(
            "Automatically rebuild when the DataTable structure changes (rows added, removed, sorted, or cleared). " +
            "Disable this if you prefer to control rebuilding manually.")]
        private bool _rebuildOnChanged = true;

        // Paging slice state (driven by DataPaging via IDataPagingTarget)

        [SerializeField, Tooltip("Rows per page (driven by DataPaging).")]
        private int _pageSize = 20;

        [SerializeField, Tooltip("Zero-based index of the currently displayed page.")]
        private int _pageIndex;

        [SerializeField, Tooltip(
            "If enabled, MoveUp/MoveDown and reorder drag operate only within the visible page when paging is active.")]
        private bool _reorderWithinVisiblePage = true;

        [Serializable]
        private enum RowNavigationMode
        {
            Default = 0,
            LockToTable = 1,
            Wrap = 2
        }

        public enum NavigationActionMode
        {
            FocusOnly = 0,
            SelectOnNavigation = 1,
            MoveOnNavigation = 2
        }

        [SerializeField, Tooltip("How row Up/Down behaves at the first/last visible row.\n" +
                                 "Default uses this widget GameObject Selectable navigation selectOnUp/selectOnDown for table exit/entry links.")]
        private RowNavigationMode _rowNavigationMode = RowNavigationMode.Default;

        [SerializeField, Tooltip("How row navigation input is interpreted.\n" +
                                 "Focus Only: navigation changes EventSystem focus only.\n" +
                                 "Select On Navigation: focus entry selects rows.\n" +
                                 "Move On Navigation: Up/Down sends MoveUp/MoveDown commands.")]
        private NavigationActionMode _navigationActionMode = NavigationActionMode.SelectOnNavigation;

        // Animation

        [SerializeField, Tooltip("Enable row transitions for add/remove/reorder. Add/remove are defined by the row prefab transition component.")]
        private bool _animateRows;

        [SerializeField, Min(0f), Tooltip("Seconds for rows to animate to their new position after reorder.")]
        private float _reorderMoveDuration = 0.12f;

        // Pool / active rows
        private readonly List<RowInstance> _active = new();
        private readonly Stack<RowInstance> _pool = new();
        private readonly List<RowInstance> _animatingOut = new();

        // RowId lookup (primary identity)
        private readonly Dictionary<SerializableGuid, RowInstance> _byId = new();

        // Cached last-resolved table (for Refresh without re-resolving every time)
        [NonSerialized] private DataTable _resolvedTable;
        [NonSerialized] private DataTable _runtimeTable;

        [NonSerialized] private DataTable _subscribedTable;
        
        private sealed class RowInstance
        {
            public GameObject Go;
            public RectTransform Rect;
            public DataItemUI RowUI;

            public SerializableGuid RowId;
            public string RowKey;

            public IDataItemSelectionVisual SelectionVisual;
            public Selectable PrimarySelectable;
            public LayoutElement LayoutElement;
            public IDataTableRowTransition Transition;
            public Coroutine Animation;
            public Vector3 BaseScale = Vector3.one;
            public int TransitionToken;

            public void SetActive(bool active)
            {
                if (Go != null)
                    Go.SetActive(active);
            }
        }

        private bool _rebuildQueued;

        private SerializableGuid _selectedId = SerializableGuid.None;
        private string _selectedKey;
        private bool _suppressNextReorderAnimation;
        private SerializableGuid _suppressNextReorderAnimationId = SerializableGuid.None;
        private string _suppressNextReorderAnimationKey;
        private GameObject _deferredFocusTarget;
        private Coroutine _deferredFocusCoroutine;

        private readonly struct RowIdentity : IEquatable<RowIdentity>
        {
            public readonly SerializableGuid Id;
            public readonly string Key;

            public RowIdentity(SerializableGuid id, string key)
            {
                Id = id;
                Key = key;
            }

            public bool Equals(RowIdentity other)
            {
                if (Id != SerializableGuid.None || other.Id != SerializableGuid.None)
                    return Id == other.Id;

                return string.Equals(Key, other.Key, StringComparison.Ordinal);
            }

            public override bool Equals(object obj) => obj is RowIdentity other && Equals(other);

            public override int GetHashCode()
            {
                if (Id != SerializableGuid.None)
                    return Id.GetHashCode();

                return Key == null ? 0 : StringComparer.Ordinal.GetHashCode(Key);
            }
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // Unity
        // ─────────────────────────────────────────────────────────────────────────────

        private void OnEnable()
        {
            UpdateSubscription(queueRebuild: false);

            if (_rebuildOnEnable)
                Rebuild(resetScroll: true);

            // Ensure no “first frame” queued rebuild runs.
            _rebuildQueued = false;

            _paging?.RefreshUI();
        }

        private void LateUpdate()
        {
            UpdateSubscription(queueRebuild: true);

            if (_rebuildQueued)
            {
                _rebuildQueued = false;
                Rebuild(resetScroll: false);
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
            _deferredFocusTarget = null;
            _deferredFocusCoroutine = null;
            FlushAnimatingOutToPool();
            Unsubscribe();
            _rebuildQueued = false;
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // Public API
        // ─────────────────────────────────────────────────────────────────────────────

        public DataTableReference Table
        {
            get => _table;
            set
            {
                _table = value;
                _runtimeTable = null;
            }
        }

        public DataTable CurrentTable => ResolveTable();

        public RectTransform Content
        {
            get => _content;
            set => _content = value;
        }

        public GameObject RowPrefab
        {
            get => _rowPrefab;
            set => _rowPrefab = value;
        }

        public int PageIndex
        {
            get => _pageIndex;
            set
            {
                _pageIndex = Mathf.Max(0, value);
                _paging?.RefreshUI();
            }
        }

        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = Mathf.Max(1, value);
                _paging?.RefreshUI();
            }
        }

        /// <summary>
        /// Rebuild visible rows (e.g., after page change, sorting, add/remove rows).
        /// </summary>
        public void Rebuild(bool resetScroll = false)
        {
            UpdateSubscription(queueRebuild: false);

            if (!ValidateSetup())
                return;

            _resolvedTable = ResolveTable();
            if (_resolvedTable == null)
            {
                Clear();
                _paging?.RefreshUI();
                return;
            }

            var rows = _resolvedTable.Rows;
            int totalRows = rows?.Count ?? 0;

            // Determine visible range
            GetVisibleRange(totalRows, out int start, out int count);

            FlushAnimatingOutToPool();

            // Diff-based rebuild so rows can animate between states.
            var previousByIdentity = new Dictionary<RowIdentity, RowInstance>();
            var previousIndexByIdentity = new Dictionary<RowIdentity, int>();
            var previousAnchoredByInstance = new Dictionary<RowInstance, Vector2>();
            var previousFallback = new List<RowInstance>();
            for (int i = 0; i < _active.Count; i++)
            {
                var prev = _active[i];
                if (prev == null)
                    continue;

                if (prev.Rect != null)
                    previousAnchoredByInstance[prev] = prev.Rect.anchoredPosition;

                var identity = new RowIdentity(prev.RowId, prev.RowKey);
                if (identity.Id != SerializableGuid.None || !string.IsNullOrEmpty(identity.Key))
                {
                    if (previousByIdentity.TryAdd(identity, prev))
                        previousIndexByIdentity[identity] = i;
                    else
                        previousFallback.Add(prev);
                }
                else
                {
                    previousFallback.Add(prev);
                }
            }

            var next = new List<RowInstance>(count);
            var movedRows = new List<RowInstance>();
            _byId.Clear();

            for (int i = 0; i < count; i++)
            {
                int rowIndex = start + i;
                if (rowIndex < 0 || rowIndex >= totalRows)
                    break;

                var row = rows?[rowIndex];
                if (row == null)
                    continue;

                var identity = new RowIdentity(row.Id, row.Key);
                var hadPrevious = previousByIdentity.TryGetValue(identity, out var inst);
                if (hadPrevious)
                    previousByIdentity.Remove(identity);
                else
                    inst = TryTakeFallback(previousFallback) ?? GetOrCreateInstance();

                StopRowAnimation(inst);
                inst.RowId = row.Id;
                inst.RowKey = row.Key;
                inst.RowUI.SetContext(this, inst.RowId, inst.RowKey);

                inst.Go.transform.SetSiblingIndex(next.Count);

                // Bind + apply
                inst.RowUI.Bind(_resolvedTable.DataDefinition, row);
                inst.RowUI.Apply();

                // Force selection visual for pooled/rebuilt rows
                inst.SelectionVisual?.SetSelected(IsSelected(inst.RowId, inst.RowKey));

                next.Add(inst);

                if (inst.RowId != SerializableGuid.None)
                    _byId.TryAdd(inst.RowId, inst);

                if (_animateRows && hadPrevious && previousIndexByIdentity.TryGetValue(identity, out var previousIndex) && previousIndex != i)
                    movedRows.Add(inst);
                else if (_animateRows && !hadPrevious)
                    PlayTransitionIn(inst);
            }

            for (int i = 0; i < previousFallback.Count; i++)
                ReleaseOrAnimateOut(previousFallback[i]);

            foreach (var pair in previousByIdentity)
                ReleaseOrAnimateOut(pair.Value);

            _active.Clear();
            _active.AddRange(next);
            ConfigureRowNavigation();

            if (_animateRows && _reorderMoveDuration > 0f && movedRows.Count > 0 && _content != null)
            {
                Canvas.ForceUpdateCanvases();
                LayoutRebuilder.ForceRebuildLayoutImmediate(_content);
                Canvas.ForceUpdateCanvases();

                for (int i = 0; i < movedRows.Count; i++)
                {
                    var inst = movedRows[i];
                    if (inst?.Rect == null)
                        continue;
                    if (ShouldSuppressReorderAnimation(inst))
                        continue;
                    if (!previousAnchoredByInstance.TryGetValue(inst, out var from))
                        continue;
                    if (!IsValidReorderStartPosition(from))
                        continue;

                    PlayReorderMove(inst, from, inst.Rect.anchoredPosition);
                }
            }

            _suppressNextReorderAnimation = false;
            _suppressNextReorderAnimationId = SerializableGuid.None;
            _suppressNextReorderAnimationKey = null;

            if (resetScroll)
                ResetScrollToTop();

            _paging?.RefreshUI();
        }

        /// <summary>
        /// Refresh currently visible rows (values changed; row set unchanged).
        /// If the table can't be resolved, does nothing.
        /// </summary>
        public void Refresh()
        {
            if (_active.Count == 0)
                return;

            _resolvedTable = ResolveTable();
            if (_resolvedTable == null)
                return;

            for (int i = 0; i < _active.Count; i++)
            {
                var inst = _active[i];
                if (inst == null || inst.RowUI == null)
                    continue;

                var row = _resolvedTable.FindRowById(inst.RowId);
                if (row == null && !string.IsNullOrEmpty(inst.RowKey))
                    row = _resolvedTable.FindRowByKey(inst.RowKey);

                if (row == null)
                    continue;

                inst.RowUI.Bind(_resolvedTable.DataDefinition, row);
                inst.RowUI.Apply();
            }
        }

        public void Clear()
        {
            _resolvedTable = null;
            FlushAnimatingOutToPool();
            ClearActiveToPool();
            _byId.Clear();
            _paging?.RefreshUI();
        }

        /// <summary>
        /// Sets a runtime DataTable source directly, bypassing the serialized DataTableReference.
        /// Pass null to clear the runtime override and fall back to the serialized reference.
        /// </summary>
        public void SetTable(DataTable table, bool rebuild = true, bool resetScroll = true)
        {
            _runtimeTable = table;

            if (rebuild)
            {
                Rebuild(resetScroll);
            }
            else
            {
                UpdateSubscription(queueRebuild: false);
                _paging?.RefreshUI();
            }
        }

        public void SetPage(int pageIndex, bool rebuild = true, bool resetScroll = true)
        {
            _pageIndex = Mathf.Max(0, pageIndex);
            if (rebuild)
                Rebuild(resetScroll);
            else
                _paging?.RefreshUI();
        }

        /// <summary>
        /// Suppress reorder movement animation for a specific visible row on the next rebuild.
        /// Useful for drag/drop where the dropped row should snap.
        /// </summary>
        public void SuppressNextReorderAnimationForItem(GameObject itemGameObject)
        {
            _suppressNextReorderAnimation = false;
            _suppressNextReorderAnimationId = SerializableGuid.None;
            _suppressNextReorderAnimationKey = null;

            if (itemGameObject == null)
                return;

            for (int i = 0; i < _active.Count; i++)
            {
                var inst = _active[i];
                if (inst?.Go != itemGameObject)
                    continue;

                _suppressNextReorderAnimation = true;
                _suppressNextReorderAnimationId = inst.RowId;
                _suppressNextReorderAnimationKey = inst.RowKey;
                return;
            }
        }

        public bool HasSelection =>
            _selectedId != SerializableGuid.None || !string.IsNullOrEmpty(_selectedKey);

        public bool TryGetSelection(out SerializableGuid selectedId, out string selectedKey, bool eventSystemFallback = false)
        {
            if (HasSelection)
            {
                selectedId = _selectedId;
                selectedKey = _selectedKey;
                return true;
            }

            if (eventSystemFallback && TryGetSelectionFromEventSystem(out selectedId, out selectedKey, out _))
                return true;

            selectedId = SerializableGuid.None;
            selectedKey = null;
            return false;
        }

        public int GetSelectedTableIndex(bool eventSystemFallback = false)
        {
            if (TryGetSelection(out var selectedId, out var selectedKey, eventSystemFallback))
                return FindTableIndex(selectedId, selectedKey);

            return -1;
        }

        public bool TryGetSelectedItemGameObject(out GameObject selectedItemGameObject, bool eventSystemFallback = false)
        {
            if (TryGetSelection(out var selectedId, out var selectedKey, eventSystemFallback) &&
                TryGetActiveItemByIdentity(selectedId, selectedKey, out selectedItemGameObject))
                return true;

            selectedItemGameObject = null;
            return false;
        }

        public void SetSelection(SerializableGuid id, string key, bool syncEventSystemSelection = false)
        {
            SetSelected(id, key);
            if (syncEventSystemSelection)
                SyncEventSystemSelection();
        }

        public void ClearSelection(bool syncEventSystemSelection = false)
        {
            ClearSelected();
            if (syncEventSystemSelection)
                SyncEventSystemSelection();
        }

        /// <summary>
        /// Selects the previous row in the table.
        /// Useful for wiring to UI Button onClick or keyboard navigation.
        /// </summary>
        public bool SelectPrevious()
        {
            return TryStepSelection(-1, wrap: false, syncEventSystemSelection: true);
        }

        /// <summary>
        /// Selects the next row in the table.
        /// Useful for wiring to UI Button onClick or keyboard navigation.
        /// </summary>
        public bool SelectNext()
        {
            return TryStepSelection(+1, wrap: false, syncEventSystemSelection: true);
        }

        /// <summary>
        /// Moves the currently selected row one step up within the visible list.
        /// Useful for wiring to UI Button onClick.
        /// </summary>
        public bool MoveSelectionUp()
        {
            if (!TryGetSelection(out var id, out var key, eventSystemFallback: true))
                return false;

            var req = new DataUIActionRequest(
                itemId: id,
                itemKey: key,
                command: DataUICommand.MoveUp);

            return TryHandleAction(in req);
        }

        /// <summary>
        /// Moves the currently selected row one step down within the visible list.
        /// Useful for wiring to UI Button onClick.
        /// </summary>
        public bool MoveSelectionDown()
        {
            if (!TryGetSelection(out var id, out var key, eventSystemFallback: true))
                return false;

            var req = new DataUIActionRequest(
                itemId: id,
                itemKey: key,
                command: DataUICommand.MoveDown);

            return TryHandleAction(in req);
        }

        public NavigationActionMode GetNavigationActionMode() => _navigationActionMode;

        public void SetNavigationActionMode(NavigationActionMode mode)
        {
            _navigationActionMode = mode;
        }

        public bool ShouldSelectOnNavigation()
        {
            return _navigationActionMode == NavigationActionMode.SelectOnNavigation;
        }

        public bool ShouldMoveOnNavigation()
        {
            return _navigationActionMode == NavigationActionMode.MoveOnNavigation;
        }

        public void OnSelect(BaseEventData eventData)
        {
            if (!isActiveAndEnabled)
                return;

            if (TryGetEntryRowSelectable(out var rowSelectable) && rowSelectable != null)
            {
                var eventSystem = EventSystem.current;
                if (eventSystem == null || eventSystem.currentSelectedGameObject == rowSelectable.gameObject)
                    return;

                if (eventSystem.alreadySelecting)
                {
                    QueueDeferredFocus(rowSelectable.gameObject);
                    return;
                }

                eventSystem.SetSelectedGameObject(rowSelectable.gameObject);
            }
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // IDataPagingTarget
        // ─────────────────────────────────────────────────────────────────────────────

        int IDataPagingTarget.TotalItemCount
        {
            get
            {
                _resolvedTable = ResolveTable();
                return _resolvedTable?.RowCount ?? 0;
            }
        }

        void IDataPagingTarget.SetPage(int pageIndex, bool rebuild, bool resetScroll)
        {
            SetPage(pageIndex, rebuild, resetScroll);
        }

        void IDataPagingTarget.GetPageInfo(int pageSize, out int pageIndex, out int totalPages)
        {
            _pageSize = Mathf.Max(1, pageSize);

            _resolvedTable = ResolveTable();
            int totalRows = _resolvedTable?.RowCount ?? 0;

            if (!IsPagingActive())
            {
                pageIndex = 0;
                totalPages = 1;
                return;
            }

            totalPages = Mathf.Max(1, (totalRows + _pageSize - 1) / _pageSize);
            pageIndex = Mathf.Clamp(_pageIndex, 0, totalPages - 1);
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // IDataReorderTarget (insert-before semantics)
        // ─────────────────────────────────────────────────────────────────────────────

        RectTransform IDataReorderTarget.Content => _content;

        bool IDataReorderTarget.TryBeginReorder(
            GameObject itemGameObject,
            object payload,
            out int fromAbsoluteIndex,
            out int visibleStart,
            out int visibleCount)
        {
            fromAbsoluteIndex = -1;
            visibleStart = 0;
            visibleCount = 0;

            if (itemGameObject == null || _content == null)
                return false;

            _resolvedTable = ResolveTable();
            if (_resolvedTable == null)
                return false;

            // Find the RowInstance for this item GO
            RowInstance inst = null;
            for (int i = 0; i < _active.Count; i++)
            {
                var a = _active[i];
                if (a?.Go == itemGameObject) { inst = a; break; }
            }

            if (inst == null)
                return false;

            // Absolute index by Id/Key
            int idx = FindTableIndex(inst.RowId, inst.RowKey);
            if (idx < 0)
                return false;

            GetVisibleRange(_resolvedTable.RowCount, out visibleStart, out visibleCount);

            fromAbsoluteIndex = idx;
            return true;
        }

        bool IDataReorderTarget.TryInsertAbsolute(int fromAbsoluteIndex, int insertBeforeAbsoluteIndex)
        {
            _resolvedTable = ResolveTable();
            if (_resolvedTable == null)
                return false;

            int rowCount = _resolvedTable.RowCount;
            if (fromAbsoluteIndex < 0 || fromAbsoluteIndex >= rowCount)
                return false;

            // insertBefore allows end (rowCount)
            insertBeforeAbsoluteIndex = Mathf.Clamp(insertBeforeAbsoluteIndex, 0, rowCount);

            if (IsPagingActive() && _reorderWithinVisiblePage)
            {
                GetVisibleRange(rowCount, out int start, out int count);
                int sliceStart = start;
                int sliceEndExclusive = start + Mathf.Max(0, count);

                insertBeforeAbsoluteIndex = Mathf.Clamp(insertBeforeAbsoluteIndex, sliceStart, sliceEndExclusive);
            }

            // Convert insert-before → MoveRow target index.
            int to = insertBeforeAbsoluteIndex;
            if (to > fromAbsoluteIndex)
                to = Mathf.Max(fromAbsoluteIndex + 1, to) - 1;

            // “insert at end” becomes last index
            to = Mathf.Clamp(to, 0, rowCount - 1);

            if (to == fromAbsoluteIndex)
                return false;

            var moved = _resolvedTable.MoveRow(false, fromAbsoluteIndex, to);
            if (moved && !_rebuildOnChanged)
                _rebuildQueued = true;

            return moved;
        }

        void IDataReorderTarget.RequestRebuild()
        {
            _rebuildQueued = true;
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // IDataItemActionHost
        // ─────────────────────────────────────────────────────────────────────────────

        public bool TryHandleAction(in DataUIActionRequest request)
        {
            var req = NormalizeRequest(request);

            switch (req.Command)
            {
                case DataUICommand.Select:
                    SetSelection(req.ItemId, req.ItemKey, syncEventSystemSelection: true);
                    RaiseRowAction(req);
                    return true;

                case DataUICommand.ToggleSelect:
                    if (IsSelected(req.ItemId, req.ItemKey))
                        ClearSelection(syncEventSystemSelection: true);
                    else
                        SetSelection(req.ItemId, req.ItemKey, syncEventSystemSelection: true);

                    RaiseRowAction(req);
                    return true;

                case DataUICommand.Delete:
                {
                    var ok = TryDelete(req);
                    if (ok) RaiseRowAction(req);
                    return ok;
                }

                case DataUICommand.MoveUp:
                {
                    var ok = TryMoveByVisibleDelta(req, -1);
                    if (ok) RaiseRowAction(req);
                    return ok;
                }

                case DataUICommand.MoveDown:
                {
                    var ok = TryMoveByVisibleDelta(req, +1);
                    if (ok) RaiseRowAction(req);
                    return ok;
                }

                // Drag lifecycle is handled by DataReorderDragger (optional)
                case DataUICommand.BeginDrag:
                case DataUICommand.DragUpdate:
                case DataUICommand.EndDrag:
                case DataUICommand.CancelDrag:
                {
                    if (_reorderDragger == null)
                        return false;

                    return _reorderDragger.TryHandleAction(req);
                }
            }

            return false;
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // Internals
        // ─────────────────────────────────────────────────────────────────────────────

        private bool IsPagingActive()
        {
            return _paging != null && _paging.isActiveAndEnabled;
        }

        private DataTable ResolveTable()
        {
            return _runtimeTable ?? _table?.ResolveData();
        }

        private bool ValidateSetup()
        {
            if (_content == null) return false;
            if (_rowPrefab == null) return false;
            return true;
        }

        /// <summary>
        /// UpdateSubscription(false) → sync subscription silently
        /// UpdateSubscription(true) → sync subscription and rebuild next frame if needed
        /// </summary>
        private void UpdateSubscription(bool queueRebuild)
        {
            if (!_rebuildOnChanged)
            {
                Unsubscribe();
                return;
            }

            var current = ResolveTable();

            if (ReferenceEquals(current, _subscribedTable))
                return;

            Unsubscribe();

            _subscribedTable = current;

            if (_subscribedTable != null)
                _subscribedTable.StructureChanged += OnTableStructureChanged;

            if (queueRebuild && isActiveAndEnabled)
                _rebuildQueued = true;
        }

        private void Unsubscribe()
        {
            if (_subscribedTable != null)
                _subscribedTable.StructureChanged -= OnTableStructureChanged;

            _subscribedTable = null;
        }

        private void OnTableStructureChanged()
        {
            if (!_rebuildOnChanged) return;
            if (!isActiveAndEnabled) return;

            _rebuildQueued = true;
        }

        private void GetVisibleRange(int totalRows, out int start, out int count)
        {
            start = 0;
            count = totalRows;

            if (!IsPagingActive())
                return;

            int size = Mathf.Max(1, _pageSize);
            int totalPages = Mathf.Max(1, (totalRows + size - 1) / size);

            _pageIndex = Mathf.Clamp(_pageIndex, 0, totalPages - 1);

            start = _pageIndex * size;
            count = Mathf.Max(0, Mathf.Min(size, totalRows - start));
        }

        private void ClearActiveToPool()
        {
            for (int i = 0; i < _active.Count; i++)
            {
                StopRowAnimation(_active[i]);
                ReleaseInstance(_active[i]);
            }

            _active.Clear();
        }

        private RowInstance GetOrCreateInstance()
        {
            if (_pool.Count > 0)
            {
                var inst = _pool.Pop();
                StopRowAnimation(inst);
                inst.SetActive(true);
                inst.Go.transform.SetAsLastSibling();
                if (inst.LayoutElement != null)
                    inst.LayoutElement.ignoreLayout = false;
                if (inst.Rect != null)
                    inst.Rect.localScale = inst.BaseScale;
                return inst;
            }

            var go = Instantiate(_rowPrefab, _content, worldPositionStays: false);

            var rowView = go.GetComponent<DataItemUI>() ??
                          go.GetComponentInChildren<DataItemUI>(includeInactive: true);

            if (rowView == null)
            {
                // Safe: adds to the instantiated clone, not the prefab asset.
                rowView = go.AddComponent<DataItemUI>();
            }

            var instance = new RowInstance
            {
                Go = go,
                Rect = go.transform as RectTransform,
                RowUI = rowView,
                SelectionVisual = go.GetComponentInChildren<IDataItemSelectionVisual>(includeInactive: true),
                PrimarySelectable = go.GetComponent<Selectable>() ?? go.GetComponentInChildren<Selectable>(includeInactive: true),
                LayoutElement = go.GetComponent<LayoutElement>() ?? go.AddComponent<LayoutElement>(),
                Transition = go.GetComponent<IDataTableRowTransition>() ??
                             go.GetComponentInChildren<IDataTableRowTransition>(includeInactive: true)
            };

            if (instance.Rect != null)
                instance.BaseScale = instance.Rect.localScale;

            return instance;
        }

        private void ReleaseInstance(RowInstance inst)
        {
            if (inst == null || inst.Go == null)
                return;

            inst.RowId = SerializableGuid.None;
            inst.RowKey = null;
            StopRowAnimation(inst);

            // Reset visuals before pooling
            inst.SelectionVisual?.SetSelected(false);
            if (inst.LayoutElement != null)
                inst.LayoutElement.ignoreLayout = false;
            if (inst.Rect != null)
                inst.Rect.localScale = inst.BaseScale;

            inst.SetActive(false);
            inst.Go.transform.SetAsLastSibling();

            _pool.Push(inst);
        }

        private void ResetScrollToTop()
        {
            if (_scrollRect == null)
                return;

            _scrollRect.verticalNormalizedPosition = 1f;
            _scrollRect.horizontalNormalizedPosition = 0f;
        }

        private DataUIActionRequest NormalizeRequest(in DataUIActionRequest request)
        {
            if (request.SourceIndex >= 0)
            {
                // Some callers can provide a page-local/visible index.
                // If identity is available, validate and remap to absolute table index.
                if (request.ItemId == SerializableGuid.None && string.IsNullOrEmpty(request.ItemKey))
                    return request;

                _resolvedTable = ResolveTable();
                var rows = _resolvedTable?.Rows;
                if (rows != null && request.SourceIndex < rows.Count)
                {
                    var row = rows[request.SourceIndex];
                    if (row != null &&
                        IsSelectedIdentity(request.ItemId, request.ItemKey, row.Id, row.Key))
                        return request;
                }

                var remapped = FindTableIndex(request.ItemId, request.ItemKey);
                if (remapped >= 0)
                {
                    return new DataUIActionRequest(
                        request.ItemId,
                        request.ItemKey,
                        request.Command,
                        remapped,
                        request.IntArg,
                        request.StringArg,
                        request.ItemGameObject,
                        request.InteractedGameObject,
                        request.Identifier,
                        request.Payload,
                        request.Sender);
                }

                // Fallback to clicked row object when identity cannot resolve uniquely.
                if (TryGetTableIndexFromItemGameObject(request.ItemGameObject, out var objectIndex))
                {
                    return new DataUIActionRequest(
                        request.ItemId,
                        request.ItemKey,
                        request.Command,
                        objectIndex,
                        request.IntArg,
                        request.StringArg,
                        request.ItemGameObject,
                        request.InteractedGameObject,
                        request.Identifier,
                        request.Payload,
                        request.Sender);
                }

                return request;
            }

            var idx = FindTableIndex(request.ItemId, request.ItemKey);
            if (idx >= 0)
            {
                return new DataUIActionRequest(
                    request.ItemId,
                    request.ItemKey,
                    request.Command,
                    idx,
                    request.IntArg,
                    request.StringArg,
                    request.ItemGameObject,
                    request.InteractedGameObject,
                    request.Identifier,
                    request.Payload,
                    request.Sender);
            }

            if (TryGetTableIndexFromItemGameObject(request.ItemGameObject, out var fallbackIndex))
            {
                return new DataUIActionRequest(
                    request.ItemId,
                    request.ItemKey,
                    request.Command,
                    fallbackIndex,
                    request.IntArg,
                    request.StringArg,
                    request.ItemGameObject,
                    request.InteractedGameObject,
                    request.Identifier,
                    request.Payload,
                    request.Sender);
            }

            return request;
        }

        private bool TryGetTableIndexFromItemGameObject(GameObject itemGameObject, out int tableIndex)
        {
            tableIndex = -1;
            if (itemGameObject == null)
                return false;

            int visibleIndex = FindVisibleIndexByItemGameObject(itemGameObject);
            if (visibleIndex < 0)
                return false;

            _resolvedTable = ResolveTable();
            if (_resolvedTable == null)
                return false;

            GetVisibleRange(_resolvedTable.RowCount, out int start, out _);
            tableIndex = start + visibleIndex;
            return tableIndex >= 0 && tableIndex < _resolvedTable.RowCount;
        }

        private int FindVisibleIndexByItemGameObject(GameObject itemGameObject)
        {
            var itemTransform = itemGameObject.transform;
            if (itemTransform == null)
                return -1;

            for (int i = 0; i < _active.Count; i++)
            {
                var inst = _active[i];
                if (inst?.Go == null)
                    continue;

                if (ReferenceEquals(inst.Go, itemGameObject))
                    return i;

                var rowRoot = inst.Go.transform;
                if (itemTransform.IsChildOf(rowRoot))
                    return i;
            }

            return -1;
        }

        private int FindTableIndex(SerializableGuid id, string key)
        {
            _resolvedTable = ResolveTable();
            if (_resolvedTable == null) return -1;

            var rows = _resolvedTable.Rows;

            if (id != SerializableGuid.None)
            {
                for (int i = 0; i < rows.Count; i++)
                    if (rows[i]?.Id == id) return i;
                return -1;
            }

            if (!string.IsNullOrEmpty(key))
            {
                for (int i = 0; i < rows.Count; i++)
                    if (string.Equals(rows[i]?.Key, key, StringComparison.Ordinal)) return i;
            }

            return -1;
        }

        private bool IsSelected(SerializableGuid id, string key)
        {
            if (id != SerializableGuid.None && _selectedId != SerializableGuid.None)
                return id == _selectedId;

            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(_selectedKey))
                return string.Equals(key, _selectedKey, StringComparison.Ordinal);

            return false;
        }

        private void SetSelected(SerializableGuid id, string key)
        {
            _selectedId = id;
            _selectedKey = key;
            UpdateSelectionVisuals();
        }

        private void ClearSelected()
        {
            _selectedId = SerializableGuid.None;
            _selectedKey = null;
            UpdateSelectionVisuals();
        }

        private void UpdateSelectionVisuals()
        {
            for (int i = 0; i < _active.Count; i++)
            {
                var inst = _active[i];
                if (inst?.Go == null) continue;

                var visual = inst.Go.GetComponentInChildren<IDataItemSelectionVisual>(includeInactive: true);
                if (visual == null) continue;

                visual.SetSelected(IsSelected(inst.RowId, inst.RowKey));
            }
        }

        private bool TryDelete(in DataUIActionRequest req)
        {
            _resolvedTable = ResolveTable();
            if (_resolvedTable == null) return false;

            bool removed = false;

            if (req.SourceIndex >= 0 && req.SourceIndex < _resolvedTable.RowCount)
            {
                var row = _resolvedTable.Rows[req.SourceIndex];
                if (row != null)
                    removed = _resolvedTable.RemoveRowById(false, row.Id);
            }
            else if (req.ItemId != SerializableGuid.None)
            {
                removed = _resolvedTable.RemoveRowById(false, req.ItemId);
            }
            else if (!string.IsNullOrEmpty(req.ItemKey))
            {
                var row = _resolvedTable.FindRowByKey(req.ItemKey);
                if (row != null)
                    removed = _resolvedTable.RemoveRowById(false, row.Id);
            }

            if (!removed) return false;

            if (IsSelected(req.ItemId, req.ItemKey))
                ClearSelection(syncEventSystemSelection: true);

            if (!_rebuildOnChanged) _rebuildQueued = true;
            return true;
        }

        private bool TryGetSelectionFromEventSystem(out SerializableGuid id, out string key, out GameObject itemGameObject)
        {
            id = SerializableGuid.None;
            key = null;
            itemGameObject = null;

            var eventSystem = EventSystem.current;
            if (eventSystem == null)
                return false;

            var selected = eventSystem.currentSelectedGameObject;
            if (selected == null)
                return false;

            for (int i = 0; i < _active.Count; i++)
            {
                var inst = _active[i];
                if (inst?.Go == null)
                    continue;

                var root = inst.Go.transform;
                if (!selected.transform.IsChildOf(root))
                    continue;

                id = inst.RowId;
                key = inst.RowKey;
                itemGameObject = inst.Go;
                return true;
            }

            return false;
        }

        private bool TryGetActiveItemByIdentity(SerializableGuid id, string key, out GameObject itemGameObject)
        {
            for (int i = 0; i < _active.Count; i++)
            {
                var inst = _active[i];
                if (inst?.Go == null)
                    continue;

                if (IsSelectedIdentity(id, key, inst.RowId, inst.RowKey))
                {
                    itemGameObject = inst.Go;
                    return true;
                }
            }

            itemGameObject = null;
            return false;
        }

        private void SyncEventSystemSelection()
        {
            var eventSystem = EventSystem.current;
            if (eventSystem == null)
                return;

            if (!TryGetSelection(out var selectedId, out var selectedKey) ||
                !TryGetActiveItemByIdentity(selectedId, selectedKey, out var selectedItemGo))
            {
                if (TryGetSelectionFromEventSystem(out _, out _, out _))
                    eventSystem.SetSelectedGameObject(null);
                return;
            }

            if (eventSystem.currentSelectedGameObject != selectedItemGo)
                eventSystem.SetSelectedGameObject(selectedItemGo);
        }

        private static bool IsSelectedIdentity(SerializableGuid selectedId, string selectedKey, SerializableGuid id, string key)
        {
            if (selectedId != SerializableGuid.None && id != SerializableGuid.None)
                return id == selectedId;

            if (!string.IsNullOrEmpty(selectedKey) && !string.IsNullOrEmpty(key))
                return string.Equals(key, selectedKey, StringComparison.Ordinal);

            return false;
        }

        private bool TryMoveByVisibleDelta(in DataUIActionRequest req, int delta)
        {
            if (delta == 0) return false;

            int visibleIndex = -1;
            SerializableGuid movedId = SerializableGuid.None;
            string movedKey = null;
            for (int i = 0; i < _active.Count; i++)
            {
                var inst = _active[i];
                if (inst == null) continue;

                if (req.ItemId != SerializableGuid.None && inst.RowId == req.ItemId)
                {
                    visibleIndex = i;
                    movedId = inst.RowId;
                    movedKey = inst.RowKey;
                    break;
                }
                if (req.ItemId == SerializableGuid.None && !string.IsNullOrEmpty(req.ItemKey) &&
                    string.Equals(inst.RowKey, req.ItemKey, StringComparison.Ordinal))
                {
                    visibleIndex = i;
                    movedId = inst.RowId;
                    movedKey = inst.RowKey;
                    break;
                }
            }

            if (visibleIndex < 0) return false;

            int targetVisible = visibleIndex + delta;
            if (targetVisible < 0 || targetVisible >= _active.Count)
                return false;

            _resolvedTable = ResolveTable();
            if (_resolvedTable == null) return false;

            int totalRows = _resolvedTable.RowCount;
            GetVisibleRange(totalRows, out int start, out int count);

            int fromTableIndex = start + visibleIndex;
            int toTableIndex = start + targetVisible;

            if (IsPagingActive() && _reorderWithinVisiblePage)
            {
                int sliceStart = start;
                int sliceEnd = start + Mathf.Max(0, count) - 1;

                fromTableIndex = Mathf.Clamp(fromTableIndex, sliceStart, sliceEnd);
                toTableIndex = Mathf.Clamp(toTableIndex, sliceStart, sliceEnd);
            }

            var moved = _resolvedTable.MoveRow(false, fromTableIndex, toTableIndex);
            if (!moved) return false;

            SetSelection(movedId, movedKey, syncEventSystemSelection: true);

            if (!_rebuildOnChanged) _rebuildQueued = true;
            return true;
        }

        private bool TryStepSelection(int delta, bool wrap, bool syncEventSystemSelection)
        {
            if (delta == 0)
                return false;

            _resolvedTable = ResolveTable();
            if (_resolvedTable == null || _resolvedTable.RowCount <= 0)
                return false;

            int totalRows = _resolvedTable.RowCount;
            int currentIndex = GetSelectedTableIndex(eventSystemFallback: true);

            int targetIndex;
            if (currentIndex < 0)
            {
                targetIndex = delta > 0 ? 0 : totalRows - 1;
            }
            else
            {
                targetIndex = currentIndex + delta;

                if (wrap)
                {
                    if (targetIndex < 0)
                        targetIndex = totalRows - 1;
                    else if (targetIndex >= totalRows)
                        targetIndex = 0;
                }
                else
                {
                    targetIndex = Mathf.Clamp(targetIndex, 0, totalRows - 1);
                }
            }

            if (targetIndex < 0 || targetIndex >= totalRows)
                return false;

            var row = _resolvedTable.Rows[targetIndex];
            if (row == null)
                return false;

            if (IsSelected(row.Id, row.Key))
                return false;

            bool pageChanged = false;
            if (IsPagingActive())
            {
                int size = Mathf.Max(1, _pageSize);
                int targetPage = Mathf.Clamp(targetIndex / size, 0, Mathf.Max(0, (totalRows - 1) / size));
                if (targetPage != _pageIndex)
                {
                    _pageIndex = targetPage;
                    Rebuild(resetScroll: false);
                    pageChanged = true;
                }
            }

            SetSelected(row.Id, row.Key);

            if (syncEventSystemSelection || pageChanged)
                SyncEventSystemSelection();

            return true;
        }

        private static RowInstance TryTakeFallback(List<RowInstance> fallback)
        {
            if (fallback == null || fallback.Count == 0)
                return null;

            int last = fallback.Count - 1;
            var inst = fallback[last];
            fallback.RemoveAt(last);
            return inst;
        }

        private void ConfigureRowNavigation()
        {
            var rows = new List<Selectable>(_active.Count);
            for (int i = 0; i < _active.Count; i++)
            {
                var selectable = _active[i]?.PrimarySelectable;
                if (selectable == null || !selectable.IsActive() || !selectable.IsInteractable())
                    continue;

                rows.Add(selectable);
            }

            if (rows.Count == 0)
                return;

            var first = rows[0];
            var last = rows[rows.Count - 1];
            var widgetSelectable = GetComponent<Selectable>();
            var widgetNavigation = widgetSelectable != null ? widgetSelectable.navigation : default;

            for (int i = 0; i < rows.Count; i++)
            {
                var current = rows[i];
                if (current == null)
                    continue;

                var nav = current.navigation;
                nav.mode = Navigation.Mode.Explicit;

                var up = i > 0 ? rows[i - 1] : GetUpEdgeTarget(first, last, current, widgetNavigation);
                var down = i < rows.Count - 1 ? rows[i + 1] : GetDownEdgeTarget(first, last, current, widgetNavigation);

                nav.selectOnUp = up;
                nav.selectOnDown = down;

                current.navigation = nav;
            }
        }

        private bool TryGetEntryRowSelectable(out Selectable selectable)
        {
            selectable = null;

            if (TryGetSelection(out var selectedId, out var selectedKey) &&
                TryGetActiveRowSelectableByIdentity(selectedId, selectedKey, out selectable))
                return true;

            for (int i = 0; i < _active.Count; i++)
            {
                var candidate = _active[i]?.PrimarySelectable;
                if (candidate == null || !candidate.IsActive() || !candidate.IsInteractable())
                    continue;

                selectable = candidate;
                return true;
            }

            return false;
        }

        private bool TryGetActiveRowSelectableByIdentity(SerializableGuid id, string key, out Selectable selectable)
        {
            selectable = null;

            for (int i = 0; i < _active.Count; i++)
            {
                var inst = _active[i];
                if (inst == null || inst.PrimarySelectable == null)
                    continue;

                if (!IsSelectedIdentity(id, key, inst.RowId, inst.RowKey))
                    continue;

                if (!inst.PrimarySelectable.IsActive() || !inst.PrimarySelectable.IsInteractable())
                    return false;

                selectable = inst.PrimarySelectable;
                return true;
            }

            return false;
        }

        private void QueueDeferredFocus(GameObject target)
        {
            _deferredFocusTarget = target;

            if (_deferredFocusCoroutine == null)
                _deferredFocusCoroutine = StartCoroutine(ApplyDeferredFocusNextFrame());
        }

        private System.Collections.IEnumerator ApplyDeferredFocusNextFrame()
        {
            yield return null;

            var eventSystem = EventSystem.current;
            var target = _deferredFocusTarget;
            _deferredFocusTarget = null;
            _deferredFocusCoroutine = null;

            if (!isActiveAndEnabled || eventSystem == null || target == null)
                yield break;

            if (eventSystem.currentSelectedGameObject == target)
                yield break;

            eventSystem.SetSelectedGameObject(target);
        }

        private Selectable GetUpEdgeTarget(Selectable first, Selectable last, Selectable current, Navigation widgetNavigation)
        {
            switch (_rowNavigationMode)
            {
                case RowNavigationMode.LockToTable:
                    return current;
                case RowNavigationMode.Wrap:
                    return last;
                default:
                    return widgetNavigation.selectOnUp;
            }
        }

        private Selectable GetDownEdgeTarget(Selectable first, Selectable last, Selectable current, Navigation widgetNavigation)
        {
            switch (_rowNavigationMode)
            {
                case RowNavigationMode.LockToTable:
                    return current;
                case RowNavigationMode.Wrap:
                    return first;
                default:
                    return widgetNavigation.selectOnDown;
            }
        }

        private void ReleaseOrAnimateOut(RowInstance inst)
        {
            if (inst == null)
                return;

            StopRowAnimation(inst);

            if (!_animateRows)
            {
                ReleaseInstance(inst);
                return;
            }

            if (inst.LayoutElement != null)
                inst.LayoutElement.ignoreLayout = true;

            var transition = inst.Transition;
            if (transition == null)
            {
                ReleaseInstance(inst);
                return;
            }

            if (!_animatingOut.Contains(inst))
                _animatingOut.Add(inst);

            int token = inst.TransitionToken;
            bool async;
            try
            {
                async = transition.TryPlayExit(() =>
                {
                    if (inst.TransitionToken != token)
                        return;

                    _animatingOut.Remove(inst);
                    ReleaseInstance(inst);
                });
            }
            catch
            {
                async = false;
            }

            if (!async)
            {
                _animatingOut.Remove(inst);
                ReleaseInstance(inst);
            }
        }

        private void FlushAnimatingOutToPool()
        {
            for (int i = _animatingOut.Count - 1; i >= 0; i--)
            {
                var inst = _animatingOut[i];
                _animatingOut.RemoveAt(i);
                ReleaseInstance(inst);
            }
        }

        private void StopRowAnimation(RowInstance inst)
        {
            if (inst == null)
                return;

            inst.TransitionToken++;

            if (inst.Animation != null)
            {
                StopCoroutine(inst.Animation);
                inst.Animation = null;
            }
        }

        private static void PlayTransitionIn(RowInstance inst)
        {
            if (inst == null)
                return;

            try
            {
                inst.Transition?.PlayEnter();
            }
            catch
            {
                // Row transition components are optional extension points.
            }
        }

        private void PlayReorderMove(RowInstance inst, Vector2 from, Vector2 to)
        {
            if (inst == null)
                return;

            StopRowAnimation(inst);

            if (_reorderMoveDuration <= 0f || inst.Rect == null)
                return;

            inst.Animation = StartCoroutine(AnimateReorderMove(inst, from, to));
        }

        private System.Collections.IEnumerator AnimateReorderMove(RowInstance inst, Vector2 from, Vector2 to)
        {
            if (inst == null || inst.Rect == null)
                yield break;

            var rect = inst.Rect;
            float duration = Mathf.Max(0.0001f, _reorderMoveDuration);
            float t = 0f;

            rect.anchoredPosition = from;

            while (t < duration)
            {
                t += Time.unscaledDeltaTime;
                float k = Mathf.Clamp01(t / duration);
                rect.anchoredPosition = Vector2.LerpUnclamped(from, to, k);

                yield return null;
            }

            rect.anchoredPosition = to;
            inst.Animation = null;
        }

        private bool IsValidReorderStartPosition(Vector2 from)
        {
            if (_content == null)
                return true;

            if (float.IsNaN(from.x) || float.IsNaN(from.y) || float.IsInfinity(from.x) || float.IsInfinity(from.y))
                return false;

            var size = _content.rect.size;
            float maxAbs = Mathf.Max(200f, Mathf.Max(size.x, size.y) * 4f);
            return Mathf.Abs(from.x) <= maxAbs && Mathf.Abs(from.y) <= maxAbs;
        }

        private bool ShouldSuppressReorderAnimation(RowInstance inst)
        {
            if (!_suppressNextReorderAnimation || inst == null)
                return false;

            if (_suppressNextReorderAnimationId != SerializableGuid.None && inst.RowId != SerializableGuid.None)
                return inst.RowId == _suppressNextReorderAnimationId;

            if (!string.IsNullOrEmpty(_suppressNextReorderAnimationKey) && !string.IsNullOrEmpty(inst.RowKey))
                return string.Equals(inst.RowKey, _suppressNextReorderAnimationKey, StringComparison.Ordinal);

            return false;
        }
    }
}

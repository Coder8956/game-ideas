using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HutongGames.Editor;
using HutongGames.PlayMaker.Actions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.Editor
{
    public sealed class InteractableBrowserView : VisualElement
    {
        private const string UssGuid = "f2bf2b939e16448799c9abf4e73d7d20";
        private const string UssClassName = "hutong-interactable-browser";
        private const string ToolbarUssClassName = UssClassName + "__toolbar";
        private const string CountLabelUssClassName = UssClassName + "__count";
        private const string EmptyHintUssClassName = UssClassName + "__empty-hint";
        private const string WarningCellUssClassName = UssClassName + "__warning-cell";
        private const string DimCellUssClassName = UssClassName + "__dim-cell";
        private const string ViewDataKey = "PlayMaker.InteractableBrowser.List";
        private const string ColumnLayoutVersionPrefsKey = ViewDataKey + ".LayoutVersion";
        private const float RowHeight = 22f;

        private readonly List<InteractableRow> _allRows = new();
        private readonly List<InteractableRow> _filteredRows = new();

        private ToolbarSearchField _searchField;
        private ToolbarToggle _selectionOnlyToggle;
        private ToolbarToggle _warningsOnlyToggle;
        private Button _settingsButton;
        private Label _countLabel;
        private VisualElement _listContainer;
        private MultiColumnListView _listView;
        private HelpBox _emptyHint;

        private bool _callbacksRegistered;

        private sealed class InteractableRow
        {
            public Interactable Interactable;
            public GameObject GameObject;
            public string Interaction;
            public string GameObjectName;
            public string SceneName;
            public string HierarchyPath;
            public bool Enabled;
            public bool NeedsActivation;
            public string ActivationId;
            public string DockingPolicy;
            public int DockingRank;
            public string TargetName;
            public int WarningCount;
            public string WarningSummary;
            public int Priority;
            public string SearchText;
        }

        public InteractableBrowserView()
        {
            viewDataKey = ViewDataKey + ".Root";
            UITK.LoadStyleSheet(this, UssGuid);
            AddToClassList(UssClassName);

            BuildToolbar();
            BuildListContainer();
            BuildFooter();
            RebuildListView();
            RefreshData();

            RegisterCallback<AttachToPanelEvent>(_ => AddCallbacks());
            RegisterCallback<DetachFromPanelEvent>(_ => RemoveCallbacks());
        }

        private void AddCallbacks()
        {
            if (_callbacksRegistered)
                return;

            EditorApplication.hierarchyChanged += QueueRefresh;
            EditorSceneManager.sceneOpened += OnSceneOpened;
            EditorSceneManager.sceneClosed += OnSceneClosed;
            EditorSceneManager.activeSceneChangedInEditMode += OnActiveSceneChanged;
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
            Selection.selectionChanged += OnUnitySelectionChanged;
            Undo.undoRedoPerformed += OnUndoRedoPerformed;
            InteractableEditorEvents.Changed += OnInteractableEdited;
            _callbacksRegistered = true;
        }

        private void RemoveCallbacks()
        {
            if (!_callbacksRegistered)
                return;

            EditorApplication.hierarchyChanged -= QueueRefresh;
            EditorSceneManager.sceneOpened -= OnSceneOpened;
            EditorSceneManager.sceneClosed -= OnSceneClosed;
            EditorSceneManager.activeSceneChangedInEditMode -= OnActiveSceneChanged;
            EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
            Selection.selectionChanged -= OnUnitySelectionChanged;
            Undo.undoRedoPerformed -= OnUndoRedoPerformed;
            InteractableEditorEvents.Changed -= OnInteractableEdited;
            EditorApplication.delayCall -= RefreshData;
            _callbacksRegistered = false;
        }

        private void BuildToolbar()
        {
            var toolbar = new Toolbar();
            toolbar.AddToClassList(ToolbarUssClassName);

            _selectionOnlyToggle = new ToolbarToggle { text = "Selection", tooltip = "Show only interactables on the selected GameObjects and their children." };
            _selectionOnlyToggle.RegisterValueChangedCallback(_ => ApplyFiltersAndSorting());
            toolbar.Add(_selectionOnlyToggle);

            _searchField = new ToolbarSearchField { tooltip = "Filter by interaction, GameObject, scene, target, or activation ID." };
            _searchField.RegisterValueChangedCallback(_ => ApplyFiltersAndSorting());
            toolbar.Add(_searchField);

            _warningsOnlyToggle = new ToolbarToggle { text = "Warnings", tooltip = "Show only interactables with setup warnings." };
            _warningsOnlyToggle.RegisterValueChangedCallback(_ => ApplyFiltersAndSorting());
            toolbar.Add(_warningsOnlyToggle);

            toolbar.AddFlexibleSpace();

            _settingsButton = new Button(OpenSettingsMenu)
            {
                tooltip = "Browser settings",
                focusable = false
            };
            _settingsButton.AddToClassList("hutong-editor__settings-button");
            toolbar.Add(_settingsButton);

            Add(toolbar);
        }

        private void BuildListContainer()
        {
            _listContainer = new VisualElement { style = { flexGrow = 1f, minWidth = 0f, minHeight = 0f } };
            Add(_listContainer);
        }

        private void RebuildListView()
        {
            if (_listView != null)
            {
                _listView.selectionChanged -= OnSelectionChanged;
                _listView.itemsChosen -= OnItemsChosen;
                _listView.columnSortingChanged -= OnColumnSortingChanged;
                _listView.RemoveFromHierarchy();
            }

            _listView = new MultiColumnListView
            {
                fixedItemHeight = RowHeight,
                showAlternatingRowBackgrounds = AlternatingRowBackground.ContentOnly,
                selectionType = SelectionType.Single,
                itemsSource = _filteredRows,
                viewDataKey = GetListViewDataKey()
            };
#if UNITY_6000_0_OR_NEWER
            _listView.sortingMode = ColumnSortingMode.Custom;
#else
            _listView.sortingEnabled = true;
#endif
            _listView.style.flexGrow = 1f;
            _listView.style.minWidth = 0f;
            _listView.style.minHeight = 0f;

            var sceneColumn = MakeTextColumn(
                "scene",
                "Scene",
                120,
                row => row.SceneName,
                row => row.HierarchyPath);
            sceneColumn.visible = false;
            _listView.columns.Add(sceneColumn);
            _listView.columns.Add(MakeTextColumn(
                "interaction",
                "Interaction",
                140,
                row => row.Interaction,
                row => row.Interaction));
            _listView.columns.Add(MakeTextColumn(
                "gameObject",
                "GameObject",
                180,
                row => row.GameObjectName,
                row => row.HierarchyPath));
            _listView.columns.Add(MakeTextColumn(
                "target",
                "Target",
                150,
                row => row.TargetName,
                row => row.TargetName));
            _listView.columns.Add(MakeBoolColumn(
                "enabled",
                "Enabled",
                72,
                row => row.Enabled));
            _listView.columns.Add(MakeBoolColumn(
                "activation",
                "Activation",
                80,
                row => row.NeedsActivation));
            _listView.columns.Add(MakeTextColumn(
                "activationId",
                "Activation ID",
                110,
                row => row.ActivationId,
                row => row.ActivationId));
            _listView.columns.Add(MakeTextColumn(
                "docking",
                "Docking",
                80,
                row => row.DockingPolicy,
                row => row.DockingPolicy));
            _listView.columns.Add(MakeTextColumn(
                "priority",
                "Priority",
                65,
                row => row.Priority.ToString(),
                row => row.Priority.ToString()));
            _listView.columns.Add(MakeWarningsColumn());

            _listView.selectionChanged += OnSelectionChanged;
            _listView.itemsChosen += OnItemsChosen;
            _listView.columnSortingChanged += OnColumnSortingChanged;

            _listContainer.Add(_listView);
        }

        private void BuildFooter()
        {
            _emptyHint = new HelpBox("No interactables found in loaded scenes.", HelpBoxMessageType.Info);
            _emptyHint.AddToClassList(EmptyHintUssClassName);
            Add(_emptyHint);

            _countLabel = new Label();
            _countLabel.AddToClassList(CountLabelUssClassName);
            Add(_countLabel);
        }

        private void OpenSettingsMenu()
        {
            var menu = new GenericMenu();
            menu.AppendAction("Refresh", RefreshData);
            menu.AppendSeparator();
            menu.AppendAction("Reset Columns", ResetColumns);
            menu.ShowAsContext();
        }

        private static string GetListViewDataKey()
        {
            return $"{ViewDataKey}.v{EditorPrefs.GetInt(ColumnLayoutVersionPrefsKey, 0)}";
        }

        private Column MakeTextColumn(string name, string title, float width, Func<InteractableRow, string> valueGetter, Func<InteractableRow, string> tooltipGetter)
        {
            return new Column
            {
                name = name,
                title = title,
                width = width,
                minWidth = 40,
                makeCell = () =>
                {
                    var label = new Label();
                    ConfigureCell(label);
                    return label;
                },
                bindCell = (element, index) =>
                {
                    var label = (Label)element;
                    var row = GetRow(index);
                    label.text = row == null ? string.Empty : valueGetter(row);
                    label.tooltip = row == null ? string.Empty : tooltipGetter(row);
                    label.EnableInClassList(DimCellUssClassName, row != null && string.IsNullOrEmpty(label.text));
                }
            };
        }

        private Column MakeBoolColumn(string name, string title, float width, Func<InteractableRow, bool> valueGetter)
        {
            return new Column
            {
                name = name,
                title = title,
                width = width,
                minWidth = 40,
                makeCell = () =>
                {
                    var label = new Label();
                    ConfigureCell(label);
                    label.style.unityTextAlign = TextAnchor.MiddleCenter;
                    return label;
                },
                bindCell = (element, index) =>
                {
                    var label = (Label)element;
                    var row = GetRow(index);
                    label.text = row == null ? string.Empty : (valueGetter(row) ? "Yes" : "No");
                    label.tooltip = label.text;
                    label.EnableInClassList(DimCellUssClassName, row != null && !valueGetter(row));
                }
            };
        }

        private Column MakeWarningsColumn()
        {
            return new Column
            {
                name = "warnings",
                title = "Warnings",
                width = 240,
                minWidth = 80,
                makeCell = () =>
                {
                    var label = new Label();
                    ConfigureCell(label);
                    label.AddToClassList(WarningCellUssClassName);
                    return label;
                },
                bindCell = (element, index) =>
                {
                    var label = (Label)element;
                    var row = GetRow(index);
                    label.text = row == null || row.WarningCount == 0 ? string.Empty : row.WarningSummary;
                    label.tooltip = row?.WarningSummary ?? string.Empty;
                    label.EnableInClassList(DimCellUssClassName, row == null || row.WarningCount == 0);
                }
            };
        }

        private static void ConfigureCell(Label label)
        {
            label.style.unityTextAlign = TextAnchor.MiddleLeft;
            label.style.whiteSpace = WhiteSpace.NoWrap;
            label.style.textOverflow = TextOverflow.Ellipsis;
            label.style.flexGrow = 1f;
            label.style.paddingLeft = 4f;
            label.style.paddingRight = 4f;
        }

        private InteractableRow GetRow(int index)
        {
            return index >= 0 && index < _filteredRows.Count ? _filteredRows[index] : null;
        }

        private void RefreshData()
        {
            _allRows.Clear();

            foreach (var scene in EditorSceneManagerHelper.GetLoadedScenes())
            {
                if (!scene.isLoaded)
                    continue;

                foreach (var root in scene.GetRootGameObjects())
                {
                    foreach (var interactable in root.GetComponentsInChildren<Interactable>(true))
                    {
                        if (interactable == null)
                            continue;

                        _allRows.Add(BuildRow(interactable));
                    }
                }
            }

            ApplyFiltersAndSorting();
        }

        private void ApplyFiltersAndSorting()
        {
            var filter = (_searchField?.value ?? string.Empty).Trim();

            _filteredRows.Clear();
            foreach (var row in _allRows)
            {
                if (!MatchesFilter(row, filter))
                    continue;

                _filteredRows.Add(row);
            }

            var ordered = OrderRows(_filteredRows).ToList();
            _filteredRows.Clear();
            _filteredRows.AddRange(ordered);

            _listView.itemsSource = _filteredRows;
            _listView.Rebuild();
            UpdateFooter();
            SyncSelectionFromUnity();
        }

        private IEnumerable<InteractableRow> OrderRows(IEnumerable<InteractableRow> rows)
        {
            var sortDescriptions = GetActiveSortDescriptions().ToList();
            if (sortDescriptions.Count == 0)
            {
                return rows
                    .OrderBy(row => row.Interaction, StringComparer.OrdinalIgnoreCase)
                    .ThenBy(row => row.GameObjectName, StringComparer.OrdinalIgnoreCase)
                    .ThenBy(row => row.HierarchyPath, StringComparer.OrdinalIgnoreCase);
            }

            IOrderedEnumerable<InteractableRow> ordered = null;
            for (var i = 0; i < sortDescriptions.Count; i++)
            {
                var description = sortDescriptions[i];
                ordered = i == 0
                    ? ApplyPrimarySort(rows, description)
                    : ApplySecondarySort(ordered, description);
            }

            return ordered
                .ThenBy(row => row.Interaction, StringComparer.OrdinalIgnoreCase)
                .ThenBy(row => row.GameObjectName, StringComparer.OrdinalIgnoreCase)
                .ThenBy(row => row.HierarchyPath, StringComparer.OrdinalIgnoreCase);
        }

        private IEnumerable<(string columnName, bool descending)> GetActiveSortDescriptions()
        {
            if (_listView == null)
                yield break;

            var sortDescriptionsProperty = _listView.GetType().GetProperty("sortColumnDescriptions", BindingFlags.Public | BindingFlags.Instance);
            var descriptions = sortDescriptionsProperty?.GetValue(_listView) as System.Collections.IEnumerable;
            if (descriptions == null)
                yield break;

            foreach (var item in descriptions)
            {
                if (item == null)
                    continue;

                var itemType = item.GetType();
                var columnName = itemType.GetProperty("columnName", BindingFlags.Public | BindingFlags.Instance)?.GetValue(item) as string;
                if (string.IsNullOrEmpty(columnName))
                    continue;

                var directionValue = itemType.GetProperty("direction", BindingFlags.Public | BindingFlags.Instance)?.GetValue(item);
                var descending = string.Equals(directionValue?.ToString(), "Descending", StringComparison.OrdinalIgnoreCase);
                yield return (columnName, descending);
            }
        }

        private static IOrderedEnumerable<InteractableRow> ApplyPrimarySort(IEnumerable<InteractableRow> rows, (string columnName, bool descending) description)
        {
            return description.columnName switch
            {
                "gameObject" => ApplySort(rows, row => row.GameObjectName, description.descending, StringComparer.OrdinalIgnoreCase),
                "scene" => ApplySort(rows, row => row.SceneName, description.descending, StringComparer.OrdinalIgnoreCase),
                "enabled" => ApplySort(rows, row => row.Enabled, description.descending),
                "activation" => ApplySort(rows, row => row.NeedsActivation, description.descending),
                "activationId" => ApplySort(rows, row => row.ActivationId, description.descending, StringComparer.OrdinalIgnoreCase),
                "docking" => ApplySort(rows, row => row.DockingRank, description.descending),
                "target" => ApplySort(rows, row => row.TargetName, description.descending, StringComparer.OrdinalIgnoreCase),
                "priority" => ApplySort(rows, row => row.Priority, description.descending),
                "warnings" => ApplySort(rows, row => row.WarningCount, description.descending),
                _ => ApplySort(rows, row => row.Interaction, description.descending, StringComparer.OrdinalIgnoreCase)
            };
        }

        private static IOrderedEnumerable<InteractableRow> ApplySecondarySort(IOrderedEnumerable<InteractableRow> rows, (string columnName, bool descending) description)
        {
            return description.columnName switch
            {
                "gameObject" => ApplyThenSort(rows, row => row.GameObjectName, description.descending, StringComparer.OrdinalIgnoreCase),
                "scene" => ApplyThenSort(rows, row => row.SceneName, description.descending, StringComparer.OrdinalIgnoreCase),
                "enabled" => ApplyThenSort(rows, row => row.Enabled, description.descending),
                "activation" => ApplyThenSort(rows, row => row.NeedsActivation, description.descending),
                "activationId" => ApplyThenSort(rows, row => row.ActivationId, description.descending, StringComparer.OrdinalIgnoreCase),
                "docking" => ApplyThenSort(rows, row => row.DockingRank, description.descending),
                "target" => ApplyThenSort(rows, row => row.TargetName, description.descending, StringComparer.OrdinalIgnoreCase),
                "priority" => ApplyThenSort(rows, row => row.Priority, description.descending),
                "warnings" => ApplyThenSort(rows, row => row.WarningCount, description.descending),
                _ => ApplyThenSort(rows, row => row.Interaction, description.descending, StringComparer.OrdinalIgnoreCase)
            };
        }

        private static IOrderedEnumerable<InteractableRow> ApplySort<TKey>(IEnumerable<InteractableRow> rows,
                                                                           Func<InteractableRow, TKey> selector,
                                                                           bool descending)
        {
            return descending ? rows.OrderByDescending(selector) : rows.OrderBy(selector);
        }

        private static IOrderedEnumerable<InteractableRow> ApplySort<TKey>(IEnumerable<InteractableRow> rows,
                                                                           Func<InteractableRow, TKey> selector,
                                                                           bool descending,
                                                                           IComparer<TKey> comparer)
        {
            return descending ? rows.OrderByDescending(selector, comparer) : rows.OrderBy(selector, comparer);
        }

        private static IOrderedEnumerable<InteractableRow> ApplyThenSort<TKey>(IOrderedEnumerable<InteractableRow> rows,
                                                                               Func<InteractableRow, TKey> selector,
                                                                               bool descending)
        {
            return descending ? rows.ThenByDescending(selector) : rows.ThenBy(selector);
        }

        private static IOrderedEnumerable<InteractableRow> ApplyThenSort<TKey>(IOrderedEnumerable<InteractableRow> rows,
                                                                               Func<InteractableRow, TKey> selector,
                                                                               bool descending,
                                                                               IComparer<TKey> comparer)
        {
            return descending ? rows.ThenByDescending(selector, comparer) : rows.ThenBy(selector, comparer);
        }

        private bool MatchesFilter(InteractableRow row, string filter)
        {
            if (_selectionOnlyToggle is { value: true } && !IsInCurrentSelection(row.GameObject))
                return false;

            if (_warningsOnlyToggle is { value: true } && row.WarningCount == 0)
                return false;

            return string.IsNullOrEmpty(filter) ||
                   row.SearchText.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static bool IsInCurrentSelection(GameObject gameObject)
        {
            if (gameObject == null)
                return false;

            foreach (var selectedGameObject in Selection.gameObjects)
            {
                if (selectedGameObject == null)
                    continue;

                if (gameObject == selectedGameObject || gameObject.transform.IsChildOf(selectedGameObject.transform))
                    return true;
            }

            return false;
        }

        private void UpdateFooter()
        {
            _emptyHint.style.display = _filteredRows.Count == 0 ? DisplayStyle.Flex : DisplayStyle.None;
            _emptyHint.text = _allRows.Count == 0
                ? "No interactables found in loaded scenes."
                : "No interactables match the current filters.";
            _countLabel.text = $"{_filteredRows.Count} of {_allRows.Count} interactables";
        }

        private static InteractableRow BuildRow(Interactable interactable)
        {
            var warnings = CollectWarnings(interactable);
            var targetGameObject = interactable.TargetGameObject;
            var targetName = targetGameObject != null
                ? targetGameObject.name
                : interactable.gameObject.name;
            var hierarchyPath = EditorSceneManagerHelper.GetHierarchyPath(interactable.gameObject);

            var parts = new[]
            {
                interactable.Interaction,
                interactable.gameObject.name,
                interactable.gameObject.scene.name,
                hierarchyPath,
                interactable.ActivationId,
                targetName,
                interactable.DockingMode.ToString()
            };

            return new InteractableRow
            {
                Interactable = interactable,
                GameObject = interactable.gameObject,
                Interaction = interactable.Interaction,
                GameObjectName = interactable.gameObject.name,
                SceneName = interactable.gameObject.scene.name,
                HierarchyPath = hierarchyPath,
                Enabled = interactable.IsEnabled,
                NeedsActivation = interactable.IsExplicitInteraction,
                ActivationId = interactable.ActivationId,
                DockingPolicy = interactable.DockingMode.ToString(),
                DockingRank = interactable.ShouldDock ? 1 : 0,
                TargetName = targetName,
                WarningCount = warnings.Count,
                WarningSummary = string.Join(" | ", warnings),
                Priority = interactable.Priority,
                SearchText = string.Join(" ", parts.Where(static part => !string.IsNullOrEmpty(part)))
            };
        }

        private static List<string> CollectWarnings(Interactable interactable)
        {
            var warnings = new List<string>();
            var hasCollider = HasResolvableCollider(interactable);

            if (!hasCollider)
            {
                warnings.Add("No resolvable collider");

                if (interactable.DistanceFrom == Interactable.DistanceFromMode.Collider)
                    warnings.Add("Collider distance mode");

                if (interactable.RequireRaycastHit)
                    warnings.Add("Require Raycast Hit");
            }

            if (interactable.InsideTrigger != null && !interactable.InsideTrigger.isTrigger)
                warnings.Add("Inside Trigger is not a trigger");

            if (interactable.InsideTrigger != null && !PhysicsColliderQueries.IsSupportedOverlapCollider(interactable.InsideTrigger))
                warnings.Add($"Unsupported Inside Trigger ({interactable.InsideTrigger.GetType().Name})");

            return warnings;
        }

        private static bool HasResolvableCollider(Interactable interactable)
        {
            if (interactable == null)
                return false;

            var current = interactable.transform;
            while (current != null)
            {
                if (current.GetComponentsInChildren<Collider>(true).Length > 0)
                    return true;

                current = current.parent;
            }

            return false;
        }

        private void OnSelectionChanged(IEnumerable<object> items)
        {
            var row = items.OfType<InteractableRow>().FirstOrDefault();
            if (row?.GameObject == null)
                return;

            Selection.activeGameObject = row.GameObject;
            EditorGUIUtility.PingObject(row.GameObject);
        }

        private void OnItemsChosen(IEnumerable<object> items)
        {
            var row = items.OfType<InteractableRow>().FirstOrDefault();
            if (row?.GameObject == null)
                return;

            Selection.activeGameObject = row.GameObject;
            EditorGUIUtility.PingObject(row.GameObject);
            SceneView.lastActiveSceneView?.FrameSelected();
        }

        private void OnUnitySelectionChanged()
        {
            SyncSelectionFromUnity();
        }

        private void SyncSelectionFromUnity()
        {
            var selected = Selection.activeGameObject;
            if (selected == null)
            {
                if (_listView.selectedIndex != -1)
                    _listView.ClearSelection();
                return;
            }

            var index = _filteredRows.FindIndex(row => row.GameObject == selected);
            if (index < 0)
                return;

            if (_listView.selectedIndex != index)
                _listView.SetSelection(index);
        }
        
        private void ResetColumns()
        {
            EditorPrefs.SetInt(ColumnLayoutVersionPrefsKey, EditorPrefs.GetInt(ColumnLayoutVersionPrefsKey, 0) + 1);
            RebuildListView();
            ApplyFiltersAndSorting();
        }

        private void QueueRefresh()
        {
            EditorApplication.delayCall -= RefreshData;
            EditorApplication.delayCall += RefreshData;
        }

        private void OnColumnSortingChanged()
        {
            ApplyFiltersAndSorting();
        }

        private void OnUndoRedoPerformed() => QueueRefresh();

        private void OnInteractableEdited() => QueueRefresh();
        
        private void OnSceneOpened(Scene _, OpenSceneMode __) => QueueRefresh();

        private void OnSceneClosed(Scene _) => QueueRefresh();

        private void OnActiveSceneChanged(Scene _, Scene __) => QueueRefresh();

        private void OnPlayModeStateChanged(PlayModeStateChange _) => QueueRefresh();
    }
}

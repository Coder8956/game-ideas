using HutongGames.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    /// <summary>
    /// Custom inspector for DataTableWidget.
    /// Keeps the inspector lightweight; paging UI is configured on DataPaging.
    /// </summary>
    [CustomEditor(typeof(DataTableWidget))]
    public sealed class DataTableWidgetEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            root.style.minWidth = 0;

            // --- Properties ---
            var tableProp = serializedObject.FindProperty("_table");

            var contentProp = serializedObject.FindProperty("_content");
            var rowPrefabProp = serializedObject.FindProperty("_rowPrefab");
            var scrollRectProp = serializedObject.FindProperty("_scrollRect");

            var pagingProp = serializedObject.FindProperty("_paging");
            var reorderDraggerProp = serializedObject.FindProperty("_reorderDragger");

            var rebuildOnEnableProp = serializedObject.FindProperty("_rebuildOnEnable");
            var rebuildOnChangedProp = serializedObject.FindProperty("_rebuildOnChanged");

            var rowNavigationModeProp = serializedObject.FindProperty("_rowNavigationMode");
            var navigationActionModeProp = serializedObject.FindProperty("_navigationActionMode");

            var animateRowsProp = serializedObject.FindProperty("_animateRows");
            var reorderMoveDurationProp = serializedObject.FindProperty("_reorderMoveDuration");

            // --- DATA TABLE ---
            root.AddHeader("Data Table");
            root.Add(new PropertyField(tableProp));

            // --- UI ---
            root.AddHeader("UI");
            root.Add(new PropertyField(contentProp));
            root.Add(new PropertyField(rowPrefabProp));

            var warning = new HelpBox(
                "Row Prefab has no DataItemUI. One will be added automatically at runtime. " +
                "\nAdd DataItemUI to the prefab to use built-in data binding.",
                HelpBoxMessageType.Info);

            warning.style.marginTop = 4;
            root.Add(warning);

            root.Add(new PropertyField(scrollRectProp));

            // --- Components ---
            root.AddHeader("Components");
            root.Add(new PropertyField(pagingProp));
            root.Add(new PropertyField(reorderDraggerProp));

            // --- Lifecycle ---
            root.AddHeader("Lifecycle");
            root.Add(new PropertyField(rebuildOnEnableProp));
            root.Add(new PropertyField(rebuildOnChangedProp));

            // --- Navigation ---
            root.AddHeader("Navigation");
            var rowNavigationModeField = new PropertyField(rowNavigationModeProp);
            var navigationActionModeField = new PropertyField(navigationActionModeProp);

            root.Add(rowNavigationModeField);
            root.Add(navigationActionModeField);

            // --- Animation ---
            root.AddHeader("Animation");
            var animateRowsField = new PropertyField(animateRowsProp);
            var reorderMoveDurationField = new PropertyField(reorderMoveDurationProp);
            var animationInfo = new HelpBox(
                "Add/remove transitions are defined by an IDataTableRowTransition component on the row prefab.",
                HelpBoxMessageType.Info);

            root.Add(animateRowsField);
            root.Add(reorderMoveDurationField);
            root.Add(animationInfo);

            void Refresh()
            {
                serializedObject.Update();

                warning.style.display = PrefabHasDataItemUI(rowPrefabProp.objectReferenceValue as GameObject)
                    ? DisplayStyle.None
                    : DisplayStyle.Flex;

                var showAnimationSettings = animateRowsProp.boolValue;
                var animationDisplay = showAnimationSettings ? DisplayStyle.Flex : DisplayStyle.None;
                reorderMoveDurationField.style.display = animationDisplay;
                animationInfo.style.display = animationDisplay;

            }

            root.TrackPropertyValue(rowPrefabProp, _ => Refresh());
            root.TrackPropertyValue(animateRowsProp, _ => Refresh());
            root.TrackPropertyValue(rowNavigationModeProp, _ => Refresh());
            root.TrackPropertyValue(navigationActionModeProp, _ => Refresh());
            Refresh();

            return root;
        }

        private static bool PrefabHasDataItemUI(GameObject prefab)
        {
            if (prefab == null) return true;

            return prefab.GetComponent<DataItemUI>() != null ||
                   prefab.GetComponentInChildren<DataItemUI>(true) != null;
        }
    }
}

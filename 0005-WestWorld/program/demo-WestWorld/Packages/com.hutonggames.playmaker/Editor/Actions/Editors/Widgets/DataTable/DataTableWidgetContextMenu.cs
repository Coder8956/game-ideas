using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.UI.Editor
{
    /// <summary>
    /// Adds context menu items to the DataTableWidget component header menu.
    /// </summary>
    internal static class DataTableWidgetContextMenu
    {
        private const string MenuRoot = "CONTEXT/DataTableWidget/";

        // ─────────────────────────────────────────────────────────────────────────────
        // Add DataPaging
        // ─────────────────────────────────────────────────────────────────────────────

        [MenuItem(MenuRoot + "Add DataPaging", priority = 1200)]
        private static void AddDataPaging(MenuCommand command)
        {
            var widget = command.context as DataTableWidget;
            if (widget == null) return;

            Undo.IncrementCurrentGroup();
            Undo.SetCurrentGroupName("Add DataPaging");
            int group = Undo.GetCurrentGroup();

            // Add (or reuse) component
            var paging = widget.GetComponent<DataPaging>();
            if (paging == null)
                paging = Undo.AddComponent<DataPaging>(widget.gameObject);

            // Wire the widget's serialized reference (_paging)
            var so = new SerializedObject(widget);
            var pagingProp = so.FindProperty("_paging");
            if (pagingProp != null)
            {
                pagingProp.objectReferenceValue = paging;
                so.ApplyModifiedPropertiesWithoutUndo();
                EditorUtility.SetDirty(widget);
            }

            // If DataPaging supports auto-targeting, set it here too
            // (safe if property doesn't exist)
            var pso = new SerializedObject(paging);
            var targetProp = pso.FindProperty("_target");
            if (targetProp != null && targetProp.objectReferenceValue == null)
            {
                targetProp.objectReferenceValue = widget;
                pso.ApplyModifiedPropertiesWithoutUndo();
                EditorUtility.SetDirty(paging);
            }

            Undo.CollapseUndoOperations(group);

            Selection.activeObject = widget;
            EditorGUIUtility.PingObject(paging);
        }

        [MenuItem(MenuRoot + "Add DataPaging", validate = true)]
        private static bool AddDataPaging_Validate(MenuCommand command)
        {
            var widget = command.context as DataTableWidget;
            if (widget == null) return false;

            // Allow even if exists; it's useful as "Ensure + Wire"
            return true;
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // (Optional) Add DataReorderDragger
        // ─────────────────────────────────────────────────────────────────────────────

        [MenuItem(MenuRoot + "Add DataReorderDragger", priority = 1201)]
        private static void AddDataReorderDragger(MenuCommand command)
        {
            var widget = command.context as DataTableWidget;
            if (widget == null) return;

            Undo.IncrementCurrentGroup();
            Undo.SetCurrentGroupName("Add DataReorderDragger");
            int group = Undo.GetCurrentGroup();

            var dragger = widget.GetComponent<DataReorderDragger>();
            if (dragger == null)
                dragger = Undo.AddComponent<DataReorderDragger>(widget.gameObject);

            // Wire widget reference (_reorderDragger)
            var so = new SerializedObject(widget);
            var draggerProp = so.FindProperty("_reorderDragger");
            if (draggerProp != null)
            {
                draggerProp.objectReferenceValue = dragger;
                so.ApplyModifiedPropertiesWithoutUndo();
                EditorUtility.SetDirty(widget);
            }

            // If DataReorderDragger has a _target field, wire it too
            var dso = new SerializedObject(dragger);
            var targetProp = dso.FindProperty("_target");
            if (targetProp != null && targetProp.objectReferenceValue == null)
            {
                targetProp.objectReferenceValue = widget;
                dso.ApplyModifiedPropertiesWithoutUndo();
                EditorUtility.SetDirty(dragger);
            }

            Undo.CollapseUndoOperations(group);

            Selection.activeObject = widget;
            EditorGUIUtility.PingObject(dragger);
        }

        [MenuItem(MenuRoot + "Add DataReorderDragger", validate = true)]
        private static bool AddDataReorderDragger_Validate(MenuCommand command)
        {
            return command.context is DataTableWidget;
        }
    }
}

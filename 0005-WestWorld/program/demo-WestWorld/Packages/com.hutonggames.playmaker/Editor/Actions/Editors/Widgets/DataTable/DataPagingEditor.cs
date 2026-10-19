// DataPagingEditor.cs

using HutongGames.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    /// <summary>
    /// Custom inspector for DataPaging that shows the correct Page Text field
    /// based on TextComponentKind.
    /// </summary>
    [CustomEditor(typeof(DataPaging))]
    public sealed class DataPagingEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            root.style.minWidth = 0;

            // --- Properties ---
            var targetProp = serializedObject.FindProperty("_target");
            var pageSizeProp = serializedObject.FindProperty("_pageSize");

            var prevProp = serializedObject.FindProperty("_prev");
            var nextProp = serializedObject.FindProperty("_next");

            var pageTextKindProp = serializedObject.FindProperty("_pageTextKind");
            var tmpTextProp = serializedObject.FindProperty("_tmpText");
            var uguiTextProp = serializedObject.FindProperty("_uguiText");
            var formatProp = serializedObject.FindProperty("_format");

            var disableEndsProp = serializedObject.FindProperty("_disableButtonsAtEnds");
            var resetScrollProp = serializedObject.FindProperty("_resetScrollOnPageChange");

            // --- Target ---
            root.AddHeader("Target");
            root.Add(new PropertyField(targetProp));
            root.Add(new PropertyField(pageSizeProp));

            // --- UI ---
            root.AddHeader("UI");
            root.Add(new PropertyField(prevProp));
            root.Add(new PropertyField(nextProp));

            var kindField = new PropertyField(pageTextKindProp);
            root.Add(kindField);

            var tmpField = new PropertyField(tmpTextProp);
            var uguiField = new PropertyField(uguiTextProp);
            root.Add(tmpField);
            root.Add(uguiField);

            root.Add(new PropertyField(formatProp));
            root.Add(new PropertyField(disableEndsProp));
            root.Add(new PropertyField(resetScrollProp));

            void RefreshVisibility()
            {
                serializedObject.Update();

                var kind = (DataPaging.TextComponentKind)pageTextKindProp.enumValueIndex;
                tmpField.style.display = kind == DataPaging.TextComponentKind.TmpText ? DisplayStyle.Flex : DisplayStyle.None;
                uguiField.style.display = kind == DataPaging.TextComponentKind.UguiText ? DisplayStyle.Flex : DisplayStyle.None;
            }

            root.TrackPropertyValue(pageTextKindProp, _ => RefreshVisibility());
            RefreshVisibility();

            return root;
        }
    }
}

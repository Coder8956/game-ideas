using UnityEditor;
using UnityEngine.UIElements;

#pragma warning disable CS0618 // Custom editor for intentionally obsolete reserved component.

namespace HutongGames.PlayMaker.UI.Editor
{
    /// <summary>
    /// Reserved compatibility stub for the future DataGridWidget inspector.
    /// </summary>
    [CustomEditor(typeof(DataGridWidget))]
    public sealed class DataGridWidgetEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            root.Add(new HelpBox(
                "DataGridWidget is reserved for a future supported DataGrid widget and is currently unsupported.",
                HelpBoxMessageType.Info));
            return root;
        }
    }
}

#pragma warning restore CS0618

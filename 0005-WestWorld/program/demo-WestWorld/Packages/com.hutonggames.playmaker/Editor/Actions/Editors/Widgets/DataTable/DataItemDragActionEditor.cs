using HutongGames.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(DataItemDragAction))]
    public sealed class DataItemDragActionEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            root.AddHeader("On Begin Drag");
            root.Add(new PropertyField(serializedObject.FindProperty("_beginCommand"), "Command"));

            root.AddHeader("On Update Drag");
            root.Add(new PropertyField(serializedObject.FindProperty("_updateCommand"), "Command"));

            root.AddHeader("On End Drag");
            root.Add(new PropertyField(serializedObject.FindProperty("_endCommand"), "Command"));

            root.AddHeader("On Cancel Drag");
            root.Add(new PropertyField(serializedObject.FindProperty("_cancelCommand"), "Command"));

            root.AddHeader("Options");
            root.Add(new PropertyField(serializedObject.FindProperty("_cancelOnPointerExit")));
            root.Add(new PropertyField(serializedObject.FindProperty("_disableDragThreshold")));

            root.AddHeader("Custom Data");
            root.Add(new PropertyField(serializedObject.FindProperty("_identifier")));
            root.Add(new PropertyField(serializedObject.FindProperty("_customInt")));
            root.Add(new PropertyField(serializedObject.FindProperty("_customString")));

            return root;
        }
    }
}

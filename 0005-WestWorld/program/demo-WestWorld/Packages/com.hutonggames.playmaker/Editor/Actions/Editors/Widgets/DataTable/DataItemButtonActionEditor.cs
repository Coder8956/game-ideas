using HutongGames.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(DataItemButtonAction))]
    public sealed class DataItemButtonActionEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            
            root.AddHeader("On Button Click");
            root.Add(new PropertyField(serializedObject.FindProperty("_command")));
            
            root.AddHeader("Custom Data");
            root.Add(new PropertyField(serializedObject.FindProperty("_identifier")));
            
            return root;
        }
    }
}

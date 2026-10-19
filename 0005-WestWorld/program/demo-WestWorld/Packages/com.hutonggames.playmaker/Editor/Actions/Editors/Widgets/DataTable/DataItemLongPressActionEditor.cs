// DataUILongPressActionEditor.cs
#if UNITY_EDITOR

using HutongGames.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(DataItemLongPressAction))]
    public sealed class DataItemLongPressActionEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            
            root.AddHeader("On Long Press");
            root.Add(new PropertyField(serializedObject.FindProperty("_command")));
            
            root.AddHeader("Options");
            root.Add(new PropertyField(serializedObject.FindProperty("_holdSeconds")));
            root.Add(new PropertyField(serializedObject.FindProperty("_requireDirectHit")));
            
            root.AddHeader("Custom Data");
            root.Add(new PropertyField(serializedObject.FindProperty("_identifier")));
            
            return root;
        }
    }
}

#endif
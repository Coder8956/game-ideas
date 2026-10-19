using HutongGames.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(DataItemClickAction))]
    public sealed class DataItemClickActionEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            
            root.AddHeader("On Click/Tap");
            root.Add(new PropertyField(serializedObject.FindProperty("_command")));
            
            root.AddHeader("Options");
            root.Add(new PropertyField(serializedObject.FindProperty("_tapTrigger")));
            root.Add(new PropertyField(serializedObject.FindProperty("_requireDirectHit")));

            root.AddHeader("Custom Data");
            root.Add(new PropertyField(serializedObject.FindProperty("_identifier")));
            
            return root;
        }
    }
}
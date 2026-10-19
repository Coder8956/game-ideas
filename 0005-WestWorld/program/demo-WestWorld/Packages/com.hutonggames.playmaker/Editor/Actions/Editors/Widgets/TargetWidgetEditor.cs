using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.UI.Editor
{
    [CustomEditor(typeof(TargetWidget))]
    public class TargetWidgetEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            // Optional: if you ever add serialized fields, draw them first:
            // DrawDefaultInspector();

            var targetObject = (TargetWidget)target;

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Runtime Info", EditorStyles.boldLabel);

            using (new EditorGUI.DisabledScope(true))
            {
                EditorGUILayout.ObjectField(
                    "Target",
                    targetObject.Target,
                    typeof(Transform),
                    true);

                // If you like, you can uncomment these extra lines:

                // EditorGUILayout.ObjectField(
                //     "Manager",
                //     targetObject.Manager,
                //     typeof(Component),
                //     true);
                //
                // EditorGUILayout.IntField(
                //     "Style Id",
                //     targetObject.StyleId);
            }

            EditorGUILayout.HelpBox(
                "Target is set at runtime by a TargetManager (e.g., OffscreenIndicator).",
                MessageType.Info);
        }
    }
}
#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Samples
{
    [CustomEditor(typeof(AutoFixSceneMaterials))]
    public sealed class AutoFixSceneMaterialsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawDefaultInspector();
            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox(
                "Use the prefab list to preprocess spawned prefab assets in edit mode so runtime instances already use the correct materials.",
                MessageType.Info);

            var autoFixSceneMaterials = (AutoFixSceneMaterials)target;

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Update Scene"))
                {
                    autoFixSceneMaterials.UpdateScenes();
                }

                if (GUILayout.Button("Update Prefabs"))
                {
                    autoFixSceneMaterials.UpdatePrefabAssets(autoFixSceneMaterials.confirmPrefabUpdates);
                }
            }

            if (GUILayout.Button("Reset Auto Prefab Prompt"))
            {
                autoFixSceneMaterials.ClearAutoProcessPrefabsAttempt();
            }
        }
    }
}
#endif

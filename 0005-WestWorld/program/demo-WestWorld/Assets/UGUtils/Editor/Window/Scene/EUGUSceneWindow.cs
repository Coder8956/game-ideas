using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UGU.Editor
{
    [Serializable]
    public class UGUSceneEntry
    {
        public string name;
        public string path;
    }

    [Serializable]
    public class EUGUSceneWindow : EditorWindow
    {
        private const string MenuTitle = "UGUtils/Scene/Scene Launcher";
        private const string PrefKey = "UGU.SceneWindow.Entries";
        private const float Spacing = 2f;

        private const float NameWidth = 100f;
        private const float OpenBtnWidth = 50f;
        private const float PlayBtnWidth = 50f;
        private const float DeleteBtnWidth = 50f;

        [SerializeField] private List<UGUSceneEntry> m_entries = new();

        private Vector2 m_scrollPos;
        private GUIStyle m_deleteBtnStyle;

        // ── 菜单入口 ──────────────────────────────────────────────

        [MenuItem(MenuTitle)]
        private static void OpenWindow()
        {
            var window = GetWindow<EUGUSceneWindow>("Scene Launcher");
            window.minSize = new Vector2(400, 150);
        }

        // ── 生命周期 ──────────────────────────────────────────────

        private void OnEnable()
        {
            LoadEntries();
        }

        // ── UI 绘制 ───────────────────────────────────────────────

        private void OnGUI()
        {
            m_deleteBtnStyle ??= new GUIStyle(GUI.skin.button)
            {
                normal = { textColor = new Color(0.9f, 0.3f, 0.3f) },
                hover = { textColor = new Color(1f, 0.4f, 0.4f) }
            };

            // ── 场景条目列表 ──────────────────────────────────────

            m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos);

            for (int i = 0; i < m_entries.Count; i++)
            {
                DrawEntryRow(i);
                EditorGUILayout.Space(Spacing);
            }

            EditorGUILayout.EndScrollView();

            // ── 底部操作 ────────────────────────────────────────────

            EditorGUILayout.Space(Spacing);

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("+ Add Scene", GUILayout.Height(24)))
                {
                    m_entries.Add(new UGUSceneEntry { name = "New Scene", path = "" });
                    SaveEntries();
                }

                GUILayout.FlexibleSpace();

                if (GUILayout.Button("Save Config", GUILayout.Width(100), GUILayout.Height(24)))
                {
                    SaveEntries();
                    ShowNotification(new GUIContent("Config Saved"));
                }
            }
        }

        private void DrawEntryRow(int index)
        {
            var entry = m_entries[index];

            using (new EditorGUILayout.HorizontalScope(GUI.skin.box))
            {
                entry.name = EditorGUILayout.TextField(
                    entry.name, GUILayout.Width(NameWidth));

                entry.path = EditorGUILayout.TextField(
                    string.IsNullOrEmpty(entry.path) ? "Assets/.../Scene.unity" : entry.path);

                if (GUILayout.Button("Open", GUILayout.Width(OpenBtnWidth)))
                {
                    if (!string.IsNullOrEmpty(entry.path))
                        OpenScene(entry.path);
                }

                if (GUILayout.Button("Play", GUILayout.Width(PlayBtnWidth)))
                {
                    if (!string.IsNullOrEmpty(entry.path))
                        PlayScene(entry.path);
                }

                if (GUILayout.Button("Del", m_deleteBtnStyle, GUILayout.Width(DeleteBtnWidth)))
                {
                    m_entries.RemoveAt(index);
                    SaveEntries();
                    GUIUtility.ExitGUI();
                }
            }
        }

        // ── 场景操作 ─────────────────────────────────────────────

        /// <summary>
        /// 保存当前场景并打开目标场景
        /// </summary>
        private static void OpenScene(string scenePath)
        {
            if (EditorApplication.isPlaying) return;

            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                EditorSceneManager.OpenScene(scenePath);
        }

        /// <summary>
        /// 保存当前场景，打开目标场景并进入运行模式
        /// </summary>
        private static void PlayScene(string scenePath)
        {
            if (EditorApplication.isPlaying) return;

            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                EditorSceneManager.OpenScene(scenePath);

            if (!EditorApplication.isPlaying)
                EditorApplication.isPlaying = true;
        }

        // ── 持久化 ───────────────────────────────────────────────

        private void LoadEntries()
        {
            var json = EditorPrefs.GetString(PrefKey, "");

            if (!string.IsNullOrEmpty(json))
            {
                JsonUtility.FromJsonOverwrite(json, this);
            }
            else
            {
                // 首次使用 — 预填默认场景
                m_entries = new List<UGUSceneEntry>
                {
                    new() { name = "Launch", path = "Assets/Scenes/Launch.scene" }
                };
                SaveEntries();
            }
        }

        private void SaveEntries()
        {
            var json = JsonUtility.ToJson(this);
            EditorPrefs.SetString(PrefKey, json);
        }
    }
}

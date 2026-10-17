using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UMiniFramework.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UMiniFramework.Editor
{
    public class UMUIWindow : EditorWindow
    {
        // ==================== 常量 ====================

        private const string SavePathKey = "UMUI_Save_Path";

        // ==================== 私有字段（运行时状态） ====================

        private List<Type> m_panelTypes = new();
        private string[] m_panelNames;

        private int m_selectIndex;

        private DefaultAsset m_saveFolder;
        private string m_savePath;

        private bool m_pathValid;

        private bool m_prefabExist;
        private string m_prefabPath;

        private bool m_addImageComponent = true;
        private bool m_addCloseButton = true;
        private bool m_addSafeArea = true;

        private bool CurrentCfgValid
        {
            get
            {
                if (m_panelTypes.Count == 0)
                    return false;

                UMUIPanelCfg cfg =
                    m_panelTypes[m_selectIndex]
                        .GetCustomAttribute<UMUIPanelCfg>();

                return cfg != null &&
                       !string.IsNullOrEmpty(cfg.PrefabPath);
            }
        }

        [MenuItem("UMini/Window/Create UI Prefab")]
        private static void ShowWindow()
        {
            var window = GetWindow<UMUIWindow>();

            window.titleContent =
                new GUIContent("Create UMOUI Panel");

            window.minSize =
                new Vector2(650, 200);

            window.Show();
        }

        // ==================== 生命周期 ====================

        private void OnEnable()
        {
            RefreshPanelTypes();

            m_savePath =
                EditorPrefs.GetString(
                    SavePathKey,
                    "Assets");

            m_saveFolder =
                AssetDatabase.LoadAssetAtPath<DefaultAsset>(
                    m_savePath);

            CheckPath();
        }

        private void OnGUI()
        {
            GUILayout.Space(10);


            DrawPanelSelect();


            GUILayout.Space(10);


            DrawFolderSelect();


            GUILayout.Space(10);


            DrawCreateButton();
        }

        // ==================== 逻辑 ====================

        private void DrawPanelSelect()
        {
            EditorGUILayout.LabelField(
                "UI Panel Class",
                EditorStyles.boldLabel);


            if (m_panelNames.Length == 0)
            {
                EditorGUILayout.HelpBox(
                    "没有找到继承 UMUIPanelBase 的类",
                    MessageType.Warning);

                return;
            }


            m_selectIndex =
                EditorGUILayout.Popup(
                    "Panel",
                    m_selectIndex,
                    m_panelNames);


            if (m_panelTypes.Count > 0)
            {
                UMUIPanelCfg cfg =
                    m_panelTypes[m_selectIndex]
                        .GetCustomAttribute<UMUIPanelCfg>();


                if (cfg != null &&
                    !string.IsNullOrEmpty(cfg.PrefabPath))
                {
                    EditorGUILayout.LabelField(
                        "PanelCfg Path",
                        cfg.PrefabPath);
                }
                else
                {
                    EditorGUILayout.HelpBox(
                        "该 Panel 缺少 UMUIPanelCfg 特性或 PrefabPath 为空",
                        MessageType.Warning);
                }
            }
        }

        private void DrawFolderSelect()
        {
            EditorGUILayout.LabelField(
                "Prefab Save Folder",
                EditorStyles.boldLabel);


            var folder =
                EditorGUILayout.ObjectField(
                        "Folder",
                        m_saveFolder,
                        typeof(DefaultAsset),
                        false)
                    as DefaultAsset;


            if (folder != m_saveFolder)
            {
                m_saveFolder = folder;

                m_savePath =
                    AssetDatabase.GetAssetPath(folder);


                EditorPrefs.SetString(
                    SavePathKey,
                    m_savePath);


                CheckPath();
            }


            if (!m_pathValid)
            {
                GUI.color = Color.red;

                EditorGUILayout.LabelField(
                    "目录不可用，请选择 Resources 目录（路径需以 Resources 结尾）");

                GUI.color = Color.white;
            }
            else
            {
                EditorGUILayout.LabelField(
                    "Path : " + m_savePath);
            }
        }

        private void DrawCreateButton()
        {
            CheckPrefabExist();

            if (m_prefabExist)
            {
                EditorGUILayout.HelpBox(
                    $"Prefab 已存在:\n{m_prefabPath}",
                    MessageType.Info);


                if (GUILayout.Button("Ping Existing Prefab"))
                {
                    var prefab =
                        AssetDatabase.LoadAssetAtPath<GameObject>(
                            m_prefabPath);


                    if (prefab != null)
                    {
                        EditorGUIUtility.PingObject(prefab);
                    }
                }
            }
            else
            {
                // 创建选项
                EditorGUILayout.Space(5);

                m_addImageComponent =
                    EditorGUILayout.Toggle(
                        "Add Image Component",
                        m_addImageComponent);

                m_addCloseButton =
                    EditorGUILayout.Toggle(
                        "Add Close Button",
                        m_addCloseButton);
                
                m_addSafeArea =
                    EditorGUILayout.Toggle(
                        "Add Safe Area",
                        m_addSafeArea);
            }

            if (m_pathValid &&
                CurrentCfgValid)
            {
                UMUIPanelCfg cfg =
                    m_panelTypes[m_selectIndex]
                        .GetCustomAttribute<UMUIPanelCfg>();

                string relativePath =
                    m_savePath.Substring(
                        m_savePath.LastIndexOf("Resources"));

                EditorGUILayout.LabelField(
                    "Panel Prefab Path",
                    $"{relativePath}/{cfg.PrefabPath}.prefab");
            }

            GUI.enabled =
                m_pathValid &&
                CurrentCfgValid &&
                !m_prefabExist;

            if (GUILayout.Button(
                "Create UI Prefab",
                GUILayout.Height(35)))
            {
                CreateUIPrefab();
            }

            GUI.enabled = true;
        }

        private void CreateUIPrefab()
        {
            Type panelType =
                m_panelTypes[m_selectIndex];

            UMUIPanelCfg cfg =
                panelType.GetCustomAttribute<UMUIPanelCfg>();

            if (cfg == null ||
                string.IsNullOrEmpty(cfg.PrefabPath))
            {
                EditorUtility.DisplayDialog(
                    "Create Failed",
                    $"{panelType.Name} 缺少 UMUIPanelCfg 特性或 PrefabPath 为空",
                    "OK");

                return;
            }

            string prefabPath =
                $"{m_savePath}/{cfg.PrefabPath}.prefab";

            if (AssetDatabase.LoadAssetAtPath<GameObject>(
                prefabPath))
            {
                EditorUtility.DisplayDialog(
                    "Create Failed",
                    $"Prefab 已存在:\n{prefabPath}",
                    "OK");

                return;
            }

            // 确保子目录存在
            string prefabDir =
                Path.GetDirectoryName(prefabPath)
                    .Replace('\\', '/');

            EnsureAssetFolderExists(prefabDir);

            GameObject go =
                new GameObject(panelType.Name);

            RectTransform rect = go.AddComponent<RectTransform>();
            rect.anchorMin = Vector2.zero;
            rect.anchorMax = Vector2.one;
            rect.pivot = new Vector2(0.5f, 0.5f);
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            go.AddComponent<CanvasRenderer>();

            // 添加ImageGroup组件
            if (m_addImageComponent)
            {
                go.AddComponent<Image>();
            }

            go.AddComponent(panelType);

            if (m_addCloseButton)
            {
                GameObject btnGo = new GameObject("BtnClose");
                btnGo.transform.SetParent(go.transform, false);

                RectTransform btnRect = btnGo.AddComponent<RectTransform>();
                btnRect.anchorMin = new Vector2(1, 1);
                btnRect.anchorMax = new Vector2(1, 1);
                btnRect.pivot = new Vector2(0.5f, 0.5f);
                btnRect.sizeDelta = new Vector2(200, 200);
                btnRect.anchoredPosition = new Vector2(-110, -110);

                btnGo.AddComponent<CanvasRenderer>();
                Image btnImg = btnGo.AddComponent<Image>();
                btnImg.color = new Color(0.8f, 0.2f, 0.2f, 1f);

                btnGo.AddComponent<Button>();
            }
            
            if (m_addSafeArea)
            {
                GameObject safeArea = new GameObject("SafeArea");
                safeArea.transform.SetParent(go.transform, false);

                RectTransform safeAreaRect = safeArea.AddComponent<RectTransform>();
                UMUIUtils.StretchFull(safeAreaRect);
                safeArea.AddComponent<UMUISafeArea>();
            }

            PrefabUtility.SaveAsPrefabAsset(
                go,
                prefabPath);

            DestroyImmediate(go);

            AssetDatabase.Refresh();

            EditorUtility.DisplayDialog(
                "Success",
                $"创建成功:\n{prefabPath}",
                "OK");
        }

        private void EnsureAssetFolderExists(string assetPath)
        {
            if (string.IsNullOrEmpty(assetPath) ||
                !assetPath.StartsWith("Assets"))
                return;


            if (AssetDatabase.IsValidFolder(assetPath))
                return;


            string parent =
                Path.GetDirectoryName(assetPath)
                    .Replace('\\', '/');

            EnsureAssetFolderExists(parent);


            string folderName =
                Path.GetFileName(assetPath);

            AssetDatabase.CreateFolder(
                parent,
                folderName);
        }

        private void RefreshPanelTypes()
        {
            m_panelTypes.Clear();


            var baseType =
                typeof(
                    UMUIPanelBase);


            foreach (var assembly in
                AppDomain.CurrentDomain
                    .GetAssemblies())
            {
                try
                {
                    var types =
                        assembly.GetTypes();


                    foreach (var type in types)
                    {
                        if (type.IsAbstract)
                            continue;


                        if (baseType.IsAssignableFrom(type))
                        {
                            m_panelTypes.Add(type);
                        }
                    }
                }
                catch
                {
                }
            }


            m_panelNames =
                m_panelTypes
                    .Select(x => x.Name)
                    .ToArray();
        }

        private void CheckPath()
        {
            m_pathValid =
                false;


            if (string.IsNullOrEmpty(m_savePath))
                return;


            if (!m_savePath.StartsWith("Assets"))
                return;


            if (!AssetDatabase.IsValidFolder(
                m_savePath))
                return;


            // PrefabPath 是 Resources 相对路径，保存目录必须是 Resources 目录
            if (!m_savePath.EndsWith("Resources"))
                return;


            m_pathValid = true;
        }

        private void CheckPrefabExist()
        {
            m_prefabExist = false;
            m_prefabPath = string.Empty;


            if (!m_pathValid)
                return;


            if (m_panelTypes.Count == 0)
                return;


            UMUIPanelCfg cfg =
                m_panelTypes[m_selectIndex]
                    .GetCustomAttribute<UMUIPanelCfg>();


            if (cfg == null ||
                string.IsNullOrEmpty(cfg.PrefabPath))
                return;


            m_prefabPath =
                $"{m_savePath}/{cfg.PrefabPath}.prefab";


            var prefab =
                AssetDatabase.LoadAssetAtPath<GameObject>(
                    m_prefabPath);


            m_prefabExist =
                prefab != null;
        }
    }
}
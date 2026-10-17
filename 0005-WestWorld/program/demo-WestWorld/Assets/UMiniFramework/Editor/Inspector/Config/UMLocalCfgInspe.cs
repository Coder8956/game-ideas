using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UMiniFramework.Runtime;
using UnityEditor;
using UnityEngine;

namespace UMiniFramework.Editor
{
    /// <summary>
    /// UMLocalCfg 自定义 Inspector
    /// 1. 通过反射读取 UMLocalCfg 的 m_localComponents 和 UMOConfig 的 m_tableDic，展示语言选项与注册组件
    /// 2. 重写 RequiresConstantRepaint，仅在 Inspector 可见且 CurtCode 变化时由 Unity 驱动重绘
    /// </summary>
    [CustomEditor(typeof(UMLocalCfg))]
    public class UMLocalCfgInspe : UnityEditor.Editor
    {
        // ==================== 私有字段（运行时状态） ====================

        private bool m_foOptions = true; // 语言选项折叠状态
        private Vector2 m_scrollPos;
        private string m_lastCode;

        // ==================== 静态只读字段 ====================

        private static readonly FieldInfo UMConfigTableDicField =
            typeof(UMOConfig).GetField("m_tableDic", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo UMLocalCfgLocalComponentsField =
            typeof(UMLocalCfg).GetField("m_localComponents", BindingFlags.NonPublic | BindingFlags.Instance);

        private const int ScrollThreshold = 10;

        // ==================== 生命周期 ====================

        private void OnEnable()
        {
            m_lastCode = ((UMLocalCfg)target)?.CurtCode;
        }

        // ==================== 逻辑 ====================

        private void PingLangAsset(string langDir, string fileName)
        {
            if (string.IsNullOrEmpty(langDir) || string.IsNullOrEmpty(fileName))
            {
                Debug.LogWarning("[UMLocalCfgInspe] 无法解析语言资源路径。");
                return;
            }

            string filePath = $"{langDir}/{fileName}";
            var asset = AssetDatabase.LoadAssetAtPath<TextAsset>(filePath);
            if (asset != null)
            {
                EditorGUIUtility.PingObject(asset);
            }
            else
            {
                Debug.LogWarning($"[UMLocalCfgInspe] 未找到语言资源：{filePath}");
            }
        }

        private UMConfigTableBase GetLangTable()
        {
            var localCfg = (UMLocalCfg)target;
            var umConfig = localCfg.GetComponentInParent<UMOConfig>();
            if (umConfig == null)
                return null;

            var tableDic = UMConfigTableDicField?.GetValue(umConfig) as Dictionary<Type, UMConfigTableBase>;
            if (tableDic == null)
                return null;

            foreach (var table in tableDic.Values)
            {
                if (table is IUMLangTable)
                    return table;
            }
            return null;
        }

        private string GetLangAssetDir(UMConfigTableBase table)
        {
            if (table == null)
                return null;

            string assetPath = table.AssetPath;
            int lastSlash = assetPath.LastIndexOf('/');
            return lastSlash >= 0 ? assetPath.Substring(0, lastSlash) : assetPath;
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 仅在 Inspector 可见时由 Unity 每帧检查；CurtCode 变化时返回 true 触发一次重绘，否则不刷新
        /// </summary>
        public override bool RequiresConstantRepaint()
        {
            var localCfg = target as UMLocalCfg;
            if (localCfg == null)
                return false;
            return localCfg.CurtCode != m_lastCode;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            UMLocalCfg localCfg = (UMLocalCfg)target;
            m_lastCode = localCfg.CurtCode;

            // Language Options
            var options = localCfg.GetOptions();
            int optionCount = options != null ? options.Count : 0;

            m_foOptions = EditorGUILayout.Foldout(m_foOptions, $"Language Options ({optionCount})");
            if (m_foOptions && optionCount > 0)
            {
                EditorGUI.indentLevel++;

                if (optionCount > ScrollThreshold)
                {
                    m_scrollPos = EditorGUILayout.BeginScrollView(m_scrollPos, GUILayout.MaxHeight(160));
                }

                UMConfigTableBase baseTable = GetLangTable();
                IUMLangTable langTable = baseTable as IUMLangTable;
                string langDir = GetLangAssetDir(baseTable);
                string currentCode = localCfg.CurtCode;

                for (int i = 0; i < optionCount; i++)
                {
                    var opt = options[i];
                    string fileName = langTable?.GetLanguageFile(i);
                    bool isCurrent = !string.IsNullOrEmpty(currentCode) && currentCode == opt.code;

                    if (isCurrent)
                    {
                        GUI.color = Color.yellow;
                    }

                    EditorGUILayout.BeginHorizontal();
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.Toggle(isCurrent, GUILayout.Width(20));
                    EditorGUILayout.TextField(opt.type);
                    EditorGUILayout.LabelField(opt.code ?? "?", GUILayout.Width(60));
                    EditorGUILayout.LabelField(fileName ?? "?", GUILayout.Width(100));
                    EditorGUI.EndDisabledGroup();
                    if (GUILayout.Button("Ping", GUILayout.Width(50)))
                    {
                        PingLangAsset(langDir, fileName);
                    }
                    EditorGUILayout.EndHorizontal();

                    if (isCurrent)
                    {
                        GUI.color = Color.white;
                    }
                }

                if (optionCount > ScrollThreshold)
                {
                    EditorGUILayout.EndScrollView();
                }

                EditorGUI.indentLevel--;
            }

            // Registered Components
            int componentCount = 0;
            if (UMLocalCfgLocalComponentsField != null)
            {
                var list = UMLocalCfgLocalComponentsField.GetValue(localCfg) as IList;
                if (list != null)
                    componentCount = list.Count;
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Registered Components:", EditorStyles.boldLabel, GUILayout.Width(130));
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.IntField(componentCount);
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
        }

    }
}

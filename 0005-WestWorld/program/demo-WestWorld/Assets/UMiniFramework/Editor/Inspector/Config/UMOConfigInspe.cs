using System;
using System.Collections.Generic;
using System.Reflection;
using UMiniFramework.Runtime;
using UnityEditor;
using UnityEngine;

namespace UMiniFramework.Editor
{
    /// <summary>
    /// UMOConfig 自定义 Inspector
    /// 1. 通过反射读取 UMOConfig 的 m_tableDic，展示已注册的非语言配置表信息
    /// 2. 重写 RequiresConstantRepaint，仅在 Inspector 可见时由 Unity 驱动实时刷新
    /// </summary>
    [CustomEditor(typeof(UMOConfig))]
    public class UMOConfigInspe : UnityEditor.Editor
    {
        // ==================== 私有字段（运行时状态） ====================

        private bool m_foConfigTables = true; // 控制折叠状态

        // ==================== 静态只读字段 ====================

        private static readonly FieldInfo UMConfigTableDicField =
            typeof(UMOConfig).GetField("m_tableDic", BindingFlags.NonPublic | BindingFlags.Instance);

        // ==================== 公开接口 ====================

        /// <summary>
        /// 仅在 Inspector 可见时由 Unity 每帧检查，返回 true 触发重绘；不可见时不调用，零开销
        /// </summary>
        public override bool RequiresConstantRepaint() => true;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var tableDic = UMConfigTableDicField != null
                ? UMConfigTableDicField.GetValue(target) as Dictionary<Type, UMConfigTableBase>
                : null;

            if (tableDic == null)
            {
                EditorGUILayout.HelpBox("m_tableDic 尚未初始化（单例可能未调用 OnInit）。", MessageType.Info);
                return;
            }

            // 统计非语言配置表数量
            int tableCount = 0;
            foreach (var v in tableDic.Values)
            {
                if (!(v is IUMLangTable))
                    tableCount++;
            }

            m_foConfigTables = EditorGUILayout.Foldout(m_foConfigTables, $"Config Tables ({tableCount})");
            if (m_foConfigTables)
            {
                // 绘制 Config Table
                EditorGUI.indentLevel++; // 增加缩进
                int tableIndex = 0;
                foreach (var kv in tableDic)
                {
                    // 跳过多语言配置表，由 UMLocalCfg Inspector 绘制
                    if (kv.Value is IUMLangTable)
                        continue;

                    EditorGUILayout.BeginVertical("helpbox");

                    // 绘制索引
                    string indexFormat = string.Format("{0:D4}", tableIndex);
                    EditorGUILayout.LabelField($"Index[{indexFormat}]", EditorStyles.boldLabel);

                    // 绘制 Table Name
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField($"Register Table: ", EditorStyles.boldLabel, GUILayout.Width(110));
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.TextField(kv.Key.Name);
                    EditorGUI.EndDisabledGroup();
                    EditorGUILayout.EndHorizontal();

                    // 绘制 Table LoadPath
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField($"Table LoadPath: ", EditorStyles.boldLabel, GUILayout.Width(120));
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.TextField(kv.Value.LoadPath);
                    EditorGUI.EndDisabledGroup();
                    EditorGUILayout.EndHorizontal();

                    // 绘制 Table AssetPath
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField($"Table AssetPath: ", EditorStyles.boldLabel, GUILayout.Width(120));
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.TextField(kv.Value.AssetPath);
                    EditorGUI.EndDisabledGroup();
                    EditorGUILayout.EndHorizontal();

                    if (GUILayout.Button("Ping Table Asset Object"))
                    {
                        string textAssetPath = string.Concat(kv.Value.AssetPath, ".json");
                        TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(textAssetPath);
                        if (textAsset != null)
                        {
                            EditorGUIUtility.PingObject(textAsset);
                        }
                        else
                        {
                            EditorUtility.DisplayDialog("提示",
                                $"无法定位配置表资源，路径：{textAssetPath}", "确定");
                        }
                    }

                    if (GUILayout.Button("Open Table Asset Object"))
                    {
                        string textAssetPath = string.Concat(kv.Value.AssetPath, ".json");
                        TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(textAssetPath);
                        if (textAsset != null)
                        {
                            AssetDatabase.OpenAsset(textAsset);
                        }
                        else
                        {
                            EditorUtility.DisplayDialog("提示",
                                $"无法打开配置表资源，路径：{textAssetPath}", "确定");
                        }
                    }

                    EditorGUILayout.EndVertical();
                    tableIndex++;
                }

                EditorGUI.indentLevel--; // 恢复缩进
            }
        }
    }
}

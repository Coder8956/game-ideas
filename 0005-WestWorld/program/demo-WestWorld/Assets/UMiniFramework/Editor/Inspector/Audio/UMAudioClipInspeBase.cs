using System.Collections.Generic;
using UMiniFramework.Runtime;
using UnityEditor;
using UnityEngine;

namespace UMiniFramework.Editor
{
    /// <summary>
    /// 音频 Inspector 基类，提供共享的剪辑列表绘制逻辑
    /// 1. DrawClips 绘制 Foldout + 滚动列表 + 每条剪辑的 helpbox 详情
    /// 2. 超过阈值时启用 ScrollView 滚动显示
    /// 3. DrawDisabledRow 提供统一的 Label + 只读 TextField 行样式
    /// </summary>
    public abstract class UMAudioClipInspeBase : UnityEditor.Editor
    {
        // ==================== 常量 ====================

        private const int ClipScrollThreshold = 15;
        private const float ClipScrollHeight = 400f;
        private const float RowLabelWidth = 70f;

        // ==================== 逻辑 ====================

        /// <summary>
        /// 绘制单条剪辑信息（helpbox 样式，每行 Label + 只读 TextField）
        /// </summary>
        private void DrawClipEntry(int index, UMACInfo aci, bool isPlaying)
        {
            EditorGUILayout.BeginVertical("helpbox");

            if (isPlaying)
            {
                var style = new GUIStyle(EditorStyles.boldLabel);
                style.normal.textColor = Color.yellow;
                EditorGUILayout.LabelField($"Index[{index:D4}]  ▶ Playing", style);
            }
            else
            {
                EditorGUILayout.LabelField($"Index[{index:D4}]", EditorStyles.boldLabel);
            }

            DrawDisabledRow("ID:", aci.ID);
            DrawDisabledRow("Path:", aci.Path);
            DrawDisabledRow("PreLoad:", aci.IsPreLoad.ToString());
            DrawDisabledRow("Clip:", aci.Clip != null ? aci.Clip.name : "<未加载>");

            EditorGUILayout.EndVertical();
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 绘制剪辑列表，超过阈值时启用滚动视图
        /// </summary>
        protected void DrawClips(Dictionary<string, UMACInfo> clipDic, ref bool foldout, ref Vector2 scrollPos)
        {
            DrawClips(clipDic, ref foldout, ref scrollPos, null);
        }

        /// <summary>
        /// 绘制剪辑列表，超过阈值时启用滚动视图；playingID 命中的条目以黄色高亮
        /// </summary>
        protected void DrawClips(Dictionary<string, UMACInfo> clipDic, ref bool foldout, ref Vector2 scrollPos, string playingID)
        {
            int count = clipDic.Count;
            foldout = EditorGUILayout.Foldout(foldout, $"Registered Clips ({count})");
            if (!foldout) return;

            EditorGUI.indentLevel++;

            // 超过阈值时启用滚动视图
            if (count > ClipScrollThreshold)
            {
                scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.MaxHeight(ClipScrollHeight));
            }

            int index = 0;
            foreach (var kv in clipDic)
            {
                bool isPlaying = playingID != null && kv.Key == playingID;
                DrawClipEntry(index, kv.Value, isPlaying);
                index++;
            }

            if (count > ClipScrollThreshold)
            {
                EditorGUILayout.EndScrollView();
            }

            EditorGUI.indentLevel--;
        }

        /// <summary>
        /// 绘制一行只读字段：Label + 禁用 TextField
        /// </summary>
        protected void DrawDisabledRow(string label, string value)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(label, EditorStyles.boldLabel, GUILayout.Width(RowLabelWidth));
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.TextField(value);
            EditorGUI.EndDisabledGroup();
            EditorGUILayout.EndHorizontal();
        }
    }
}

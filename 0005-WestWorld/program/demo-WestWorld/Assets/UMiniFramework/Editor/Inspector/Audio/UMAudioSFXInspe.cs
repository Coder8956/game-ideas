using System.Collections.Generic;
using System.Reflection;
using UMiniFramework.Runtime;
using UnityEditor;
using UnityEngine;

namespace UMiniFramework.Editor
{
    /// <summary>
    /// UMAudioSFX 自定义 Inspector
    /// 1. 通过反射读取 m_effectClipDic，展示已注册的音效剪辑数量与详情
    /// 2. 通过反射读取 AudioSource 队列信息（已创建数、空闲数、播放中数）
    /// 3. 超过 15 个时使用滚动视图显示
    /// </summary>
    [CustomEditor(typeof(UMAudioSFX))]
    public class UMAudioSFXInspe : UMAudioClipInspeBase
    {
        // ==================== 私有字段（运行时状态） ====================

        private bool m_foClips = true;   // 控制折叠状态
        private bool m_foASInfo = true;  // 控制折叠状态
        private Vector2 m_scrollPos;     // 滚动位置

        // ==================== 静态只读字段 ====================

        private static readonly FieldInfo EffectClipDicField =
            typeof(UMAudioSFX).GetField("m_effectClipDic", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo ASQueField =
            typeof(UMAudioSFX).GetField("m_asQue", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo ASPlayingListField =
            typeof(UMAudioSFX).GetField("m_asPlayingList", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo CreatedASCountField =
            typeof(UMAudioSFX).GetField("m_createdASCount", BindingFlags.NonPublic | BindingFlags.Instance);

        // ==================== 逻辑 ====================

        /// <summary>
        /// 绘制 AudioSource 信息（已创建 / 空闲 / 播放中）
        /// </summary>
        private void DrawAudioSourceInfo()
        {
            var asQue = ASQueField != null
                ? ASQueField.GetValue(target) as Queue<AudioSource>
                : null;

            var asPlayingList = ASPlayingListField != null
                ? ASPlayingListField.GetValue(target) as List<AudioSource>
                : null;

            int createdCount = CreatedASCountField != null
                ? (int)CreatedASCountField.GetValue(target)
                : 0;

            int idleCount = asQue != null ? asQue.Count : 0;
            int playingCount = asPlayingList != null ? asPlayingList.Count : 0;

            m_foASInfo = EditorGUILayout.Foldout(m_foASInfo, "AudioSource Info");
            if (!m_foASInfo) return;

            EditorGUI.indentLevel++;

            EditorGUILayout.BeginVertical("helpbox");
            DrawDisabledRow("Created:", createdCount.ToString());
            DrawDisabledRow("Idle:", idleCount.ToString());
            DrawDisabledRow("Playing:", playingCount.ToString());
            EditorGUILayout.EndVertical();

            EditorGUI.indentLevel--;
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 仅在 Inspector 可见时由 Unity 每帧检查，返回 true 触发重绘；不可见时不调用，零开销
        /// </summary>
        public override bool RequiresConstantRepaint() => true;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var clipDic = EffectClipDicField != null
                ? EffectClipDicField.GetValue(target) as Dictionary<string, UMACInfo>
                : null;

            if (clipDic == null)
            {
                EditorGUILayout.HelpBox("m_effectClipDic 尚未初始化（单例可能未调用 OnInit）。", MessageType.Info);
                return;
            }

            // ── AudioSource 信息 ──────────────────────────────────

            DrawAudioSourceInfo();

            EditorGUILayout.Space();

            // ── 注册剪辑信息 ──────────────────────────────────────

            DrawClips(clipDic, ref m_foClips, ref m_scrollPos);
        }
    }
}

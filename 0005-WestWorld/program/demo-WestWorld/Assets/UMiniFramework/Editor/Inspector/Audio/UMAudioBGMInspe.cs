using System.Collections.Generic;
using System.Reflection;
using UMiniFramework.Runtime;
using UnityEditor;
using UnityEngine;

namespace UMiniFramework.Editor
{
    /// <summary>
    /// UMAudioBGM 自定义 Inspector
    /// 1. 通过反射读取 m_BGMClipDic，展示已注册的 BGM 剪辑数量与详情
    /// 2. 超过 15 个时使用滚动视图显示
    /// </summary>
    [CustomEditor(typeof(UMAudioBGM))]
    public class UMAudioBGMInspe : UMAudioClipInspeBase
    {
        // ==================== 私有字段（运行时状态） ====================

        private bool m_foClips = true; // 控制折叠状态
        private Vector2 m_scrollPos;   // 滚动位置

        // ==================== 静态只读字段 ====================

        private static readonly FieldInfo BGMClipDicField =
            typeof(UMAudioBGM).GetField("m_BGMClipDic", BindingFlags.NonPublic | BindingFlags.Instance);

        // ==================== 逻辑 ====================

        /// <summary>
        /// 绘制当前正在播放的 BGM 的 Key 与加载路径
        /// </summary>
        private void DrawNowPlaying(UMAudioBGM bgm, Dictionary<string, UMACInfo> clipDic)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Now Playing", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            string curtID = bgm.CurtBGMID;
            string path = clipDic.TryGetValue(curtID, out UMACInfo aci) ? aci.Path : "<无>";

            DrawDisabledRow("Key:", curtID);
            DrawDisabledRow("Path:", path);

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

            var clipDic = BGMClipDicField != null
                ? BGMClipDicField.GetValue(target) as Dictionary<string, UMACInfo>
                : null;

            if (clipDic == null)
            {
                EditorGUILayout.HelpBox("m_BGMClipDic 尚未初始化（单例可能未调用 OnInit）。", MessageType.Info);
                return;
            }

            DrawNowPlaying((UMAudioBGM)target, clipDic);
            DrawClips(clipDic, ref m_foClips, ref m_scrollPos, ((UMAudioBGM)target).CurtBGMID);
        }
    }
}

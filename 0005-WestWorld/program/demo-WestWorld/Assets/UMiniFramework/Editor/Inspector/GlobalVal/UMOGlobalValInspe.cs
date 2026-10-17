using System.Collections.Generic;
using System.Reflection;
using UMiniFramework.Runtime;
using UnityEditor;
using UnityEngine;

namespace UMiniFramework.Editor
{
    /// <summary>
    /// UMOGlobalVal 自定义 Inspector
    /// 1. 通过反射读取单例 Instance 的 m_globalValDic，确保与运行时数据同步
    /// 2. 重写 RequiresConstantRepaint，仅在 Inspector 可见时由 Unity 驱动实时刷新
    /// </summary>
    [CustomEditor(typeof(UMOGlobalVal))]
    public class UMOGlobalValInspe : UnityEditor.Editor
    {
        // ==================== 私有字段（运行时状态） ====================

        private bool m_foGlobalVals = true; // 控制折叠状态

        // ==================== 静态只读字段 ====================

        private static readonly FieldInfo GlobalValDicField =
            typeof(UMOGlobalVal).GetField("m_globalValDic", BindingFlags.NonPublic | BindingFlags.Instance);

        /// <summary>
        /// 单例基类的 Instance 属性（protected static），通过反射获取运行时真正的单例实例
        /// </summary>
        private static readonly PropertyInfo InstanceProperty =
            typeof(UMOGlobalVal).BaseType
                .GetProperty("Instance", BindingFlags.NonPublic | BindingFlags.Static);

        // ==================== 公开接口 ====================

        /// <summary>
        /// 仅在 Inspector 可见时由 Unity 每帧检查，返回 true 触发重绘；不可见时不调用，零开销
        /// </summary>
        public override bool RequiresConstantRepaint() => true;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            // 优先从单例 Instance 读取运行时数据；Instance 为 null 时（EditMode 未创建单例）回退到 target
            object dataSource = InstanceProperty?.GetValue(null) ?? target;
            var globalValDic = GlobalValDicField != null
                ? GlobalValDicField.GetValue(dataSource) as Dictionary<string, object>
                : null;

            if (globalValDic == null)
            {
                EditorGUILayout.HelpBox("m_globalValDic 尚未初始化（单例可能未调用 OnInit）。", MessageType.Info);
                return;
            }

            m_foGlobalVals = EditorGUILayout.Foldout(m_foGlobalVals, $"Global Values ({globalValDic.Count})");
            if (m_foGlobalVals)
            {
                // 绘制键值对
                EditorGUI.indentLevel++; // 增加缩进
                int valIndex = 0;
                foreach (var kv in globalValDic)
                {
                    string key = kv.Key;
                    object val = kv.Value;

                    EditorGUILayout.BeginVertical("helpbox");

                    // 绘制索引
                    string indexFormat = string.Format("{0:D4}", valIndex);
                    EditorGUILayout.LabelField($"Index[{indexFormat}]", EditorStyles.boldLabel);

                    // 绘制 Key
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Key:", EditorStyles.boldLabel, GUILayout.Width(50));
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.TextField(key);
                    EditorGUI.EndDisabledGroup();
                    EditorGUILayout.EndHorizontal();

                    // 绘制 Value
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Value:", EditorStyles.boldLabel, GUILayout.Width(50));
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.TextField(val?.ToString() ?? "null");
                    EditorGUI.EndDisabledGroup();
                    EditorGUILayout.EndHorizontal();

                    // 绘制 Value Type
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField("Type:", EditorStyles.boldLabel, GUILayout.Width(50));
                    EditorGUI.BeginDisabledGroup(true);
                    string valType = val?.GetType().Name ?? "null";
                    EditorGUILayout.TextField(valType);
                    EditorGUI.EndDisabledGroup();
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.EndVertical();
                    valIndex++;
                }

                EditorGUI.indentLevel--; // 恢复缩进
            }
        }
    }
}

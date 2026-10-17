using System;
using System.Collections.Generic;
using System.Reflection;
using UMiniFramework.Runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace UMiniFramework.Editor
{
    /// <summary>
    /// UMOEvent 自定义 Inspector
    /// 1. 通过反射读取 UMOEvent 的 m_eventDic 和 UMEventListener 的 m_eventHandler，展示事件标签与侦听器信息
    /// 2. 重写 RequiresConstantRepaint，仅在 Inspector 可见时由 Unity 驱动实时刷新
    /// </summary>
    [CustomEditor(typeof(UMOEvent))]
    public class UMOEventInspe : UnityEditor.Editor
    {
        // ==================== 私有字段（运行时状态） ====================

        private bool m_foEventTags = true; // 控制折叠状态
        private Dictionary<string, bool> m_foETListeners = new Dictionary<string, bool>(); // 控制折叠状态，按 EventTag 索引
        private GUIStyle m_listenerInfoGS;

        // ==================== 静态只读字段 ====================

        private static readonly FieldInfo UMEventDicField =
            typeof(UMOEvent).GetField("m_eventDic", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo UMELEventHandlerField =
            typeof(UMEventListener).GetField("m_eventHandler", BindingFlags.NonPublic | BindingFlags.Instance);

        // ==================== 生命周期 ====================

        private void OnEnable()
        {
            m_listenerInfoGS = new GUIStyle("helpbox");
            m_listenerInfoGS.fontSize = 12;
        }

        // ==================== 公开接口 ====================

        /// <summary>
        /// 仅在 Inspector 可见时由 Unity 每帧检查，返回 true 触发重绘；不可见时不调用，零开销
        /// </summary>
        public override bool RequiresConstantRepaint() => true;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var eventDic = UMEventDicField != null
                ? UMEventDicField.GetValue(target) as Dictionary<string, List<UMEventListener>>
                : null;

            if (eventDic == null)
            {
                EditorGUILayout.HelpBox("m_eventDic 尚未初始化（单例可能未调用 OnInit）。", MessageType.Info);
                return;
            }

            m_foEventTags = EditorGUILayout.Foldout(m_foEventTags, $"Register Event Tags ({eventDic.Keys.Count})");
            if (m_foEventTags)
            {
                // 绘制 事件Tag
                EditorGUI.indentLevel++; // 增加缩进
                int tagIndex = 0;
                foreach (var kv in eventDic)
                {
                    string etag = kv.Key;
                    List<UMEventListener> listeners = kv.Value;

                    EditorGUILayout.BeginHorizontal();

                    string tagIndexFormat = string.Format("{0:D4}", tagIndex);
                    EditorGUILayout.LabelField($"Index[{tagIndexFormat}] Event Tag:", EditorStyles.boldLabel,
                        GUILayout.Width(155));

                    // 禁用编辑
                    EditorGUI.BeginDisabledGroup(true);
                    EditorGUILayout.TextArea(etag);
                    // 结束禁用组
                    EditorGUI.EndDisabledGroup();

                    EditorGUILayout.EndHorizontal();

                    // 绘制 事件Tag 下所有的侦听器
                    EditorGUI.indentLevel++; // 增加缩进
                    if (!m_foETListeners.TryGetValue(etag, out bool foListeners))
                    {
                        foListeners = true;
                        m_foETListeners[etag] = foListeners;
                    }

                    foListeners = EditorGUILayout.Foldout(foListeners, $"Listeners ({listeners.Count})");
                    m_foETListeners[etag] = foListeners;

                    if (foListeners)
                    {
                        // 禁用编辑
                        EditorGUI.BeginDisabledGroup(true);

                        for (var i = 0; i < listeners.Count; i++)
                        {
                            UMEventListener listener = listeners[i];

                            // 获取事件处理器 EventHandler 是哪个类中方法
                            string ehInfo = string.Empty;
                            UnityAction<UMEventContentBase> eh =
                                UMELEventHandlerField != null
                                    ? (UnityAction<UMEventContentBase>)UMELEventHandlerField.GetValue(listener)
                                    : null;

                            if (eh == null)
                            {
                                ehInfo = "null";
                            }
                            else
                            {
                                Type declaringType = eh.Method.DeclaringType;
                                ehInfo = string.Concat(declaringType.FullName, ".", eh.Method.Name);
                            }

                            EditorGUILayout.TextArea($"Index: {i}\n" + // 绘制 listener 索引
                                                     $"HashCode: {listener.GetHashCode()}\n" + // 绘制 listener HashCode
                                                     $"Event Tag: {listener.EventTag}\n" + // 绘制 Event Tag
                                                     $"Listen Type: {listener.ListenType.ToString()}\n" + // 绘制 Listen Type
                                                     $"Event Handler: {ehInfo}", m_listenerInfoGS); // 绘制事件处理器信息
                        }

                        // 结束禁用组
                        EditorGUI.EndDisabledGroup();
                    }

                    EditorGUI.indentLevel--; // 恢复缩进
                    tagIndex++;
                }

                EditorGUI.indentLevel--; // 恢复缩进
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UGU.Runtime;

namespace UGU.Editor
{
    /// <summary>
    /// UGUWrapperBase 及其子类的统一 PropertyDrawer
    ///
    /// Unity 无法序列化泛型类型 (如 UGUProperty&lt;int&gt;),
    /// 所以 wrapper 内部维护了可序列化的原始值字段 (m_value / m_values).
    ///
    /// 绘制规则 (参考 Unity Inspector 序列化):
    /// - UGUPropertyWrapperBase&lt;T&gt;: 直接绘制原子值 (m_value)
    /// - UGUListPropertyWrapperBase&lt;T&gt;: 按 index 绘制, 每行 index + value (m_values)
    /// - UGUDictPropertyWrapperBase&lt;TKey, T&gt;: 按 key 绘制, 每行 key + value (Dict 反射)
    /// </summary>
    [CustomPropertyDrawer(typeof(UGUWrapperBase), true)]
    public class EUGUWrapperDrawer : PropertyDrawer
    {
        private const string ValueFieldName = "m_value";
        private const string ValuesFieldName = "m_values";
        private const string DictPropertyName = "Dict";
        private const string ValuePropertyName = "Value";
        private const string ModifyMethodName = "Modify";

        private const float Spacing = 2f;

        private static readonly Dictionary<string, bool> FoldoutStates = new();

        // ── 公共入口 ──────────────────────────────────────────────

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var wrapper = GetWrapperInstance(property);
            if (wrapper == null)
            {
                EditorGUI.LabelField(position, label, new GUIContent("(未初始化)"));
                return;
            }

            var wrapperType = wrapper.GetType();

            if (IsSubclassOfRawGeneric(typeof(UGUPropertyWrapperBase<>), wrapperType))
            {
                DrawSingleValue(position, property, wrapper, label);
            }
            else if (IsSubclassOfRawGeneric(typeof(UGUListPropertyWrapperBase<>), wrapperType))
            {
                DrawList(position, property, wrapper, label);
            }
            else if (IsSubclassOfRawGeneric(typeof(UGUDictPropertyWrapperBase<,>), wrapperType))
            {
                DrawDict(position, property, wrapper, label);
            }
            else
            {
                EditorGUI.LabelField(position, label, new GUIContent("(未知 Wrapper 类型)"));
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var wrapper = GetWrapperInstance(property);
            if (wrapper == null)
                return EditorGUIUtility.singleLineHeight;

            var wrapperType = wrapper.GetType();

            if (IsSubclassOfRawGeneric(typeof(UGUPropertyWrapperBase<>), wrapperType))
                return EditorGUIUtility.singleLineHeight;

            if (IsSubclassOfRawGeneric(typeof(UGUListPropertyWrapperBase<>), wrapperType))
                return GetListHeight(property, wrapper);

            if (IsSubclassOfRawGeneric(typeof(UGUDictPropertyWrapperBase<,>), wrapperType))
                return GetDictHeight(property, wrapper);

            return EditorGUIUtility.singleLineHeight;
        }

        // ── 单值 Wrapper ──────────────────────────────────────────

        private void DrawSingleValue(Rect position, SerializedProperty property, object wrapper, GUIContent label)
        {
            var value = GetFieldValue(wrapper, ValueFieldName);
            var valueType = GetGenericArgument(wrapper, 0);

            EditorGUI.BeginProperty(position, label, property);
            using (var scope = new EditorGUI.ChangeCheckScope())
            {
                var newValue = DrawTypedValue(position, value, valueType, label);
                if (scope.changed && !Equals(newValue, value))
                {
                    Undo.RecordObject(property.serializedObject.targetObject, "Modify Value");
                    CallModify(wrapper, newValue, valueType);
                    EditorUtility.SetDirty(property.serializedObject.targetObject);
                }
            }
            EditorGUI.EndProperty();
        }

        // ── 列表 Wrapper ──────────────────────────────────────────

        private void DrawList(Rect position, SerializedProperty property, object wrapper, GUIContent label)
        {
            var list = GetFieldValue(wrapper, ValuesFieldName) as IList;

            EditorGUI.BeginProperty(position, label, property);

            float y = position.y;
            var foldoutRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);

            int count = list?.Count ?? 0;
            bool expanded = GetFoldout(property);
            expanded = EditorGUI.Foldout(foldoutRect, expanded, $"{label.text} [{count}]", true);
            SetFoldout(property, expanded);
            y += EditorGUIUtility.singleLineHeight + Spacing;

            if (!expanded || list == null || list.Count == 0)
            {
                if (expanded && (list == null || list.Count == 0))
                {
                    var rect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);
                    EditorGUI.LabelField(rect, "(空)");
                }
                EditorGUI.EndProperty();
                return;
            }

            var valueType = GetGenericArgument(wrapper, 0);

            for (int i = 0; i < list.Count; i++)
            {
                var value = list[i];
                var rowRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);

                float indexWidth = Mathf.Max(40f, position.width * 0.2f);
                var indexRect = new Rect(rowRect.x, rowRect.y, indexWidth, rowRect.height);
                var valueRect = new Rect(
                    rowRect.x + indexWidth + Spacing,
                    rowRect.y,
                    rowRect.width - indexWidth - Spacing,
                    rowRect.height);

                using (var scope = new EditorGUI.ChangeCheckScope())
                {
                    EditorGUI.LabelField(indexRect, $"[{i}]");
                    var newValue = DrawTypedValue(valueRect, value, valueType, GUIContent.none);
                    if (scope.changed && !Equals(newValue, value))
                    {
                        Undo.RecordObject(property.serializedObject.targetObject, "Modify List Value");
                        CallModify(wrapper, i, newValue, valueType);
                        EditorUtility.SetDirty(property.serializedObject.targetObject);
                    }
                }

                y += EditorGUIUtility.singleLineHeight + Spacing;
            }

            EditorGUI.EndProperty();
        }

        private float GetListHeight(SerializedProperty property, object wrapper)
        {
            float height = EditorGUIUtility.singleLineHeight + Spacing;

            if (!GetFoldout(property))
                return height;

            var list = GetFieldValue(wrapper, ValuesFieldName) as IList;
            if (list == null || list.Count == 0)
                return height + EditorGUIUtility.singleLineHeight;

            return height + list.Count * (EditorGUIUtility.singleLineHeight + Spacing);
        }

        // ── 字典 Wrapper (反射) ───────────────────────────────────

        private void DrawDict(Rect position, SerializedProperty property, object wrapper, GUIContent label)
        {
            var dict = GetPropertyValue(wrapper, DictPropertyName) as IDictionary;

            EditorGUI.BeginProperty(position, label, property);

            float y = position.y;
            var foldoutRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);

            int count = dict?.Count ?? 0;
            bool expanded = GetFoldout(property);
            expanded = EditorGUI.Foldout(foldoutRect, expanded, $"{label.text} [{count}]", true);
            SetFoldout(property, expanded);
            y += EditorGUIUtility.singleLineHeight + Spacing;

            if (!expanded || dict == null || dict.Count == 0)
            {
                if (expanded && (dict == null || dict.Count == 0))
                {
                    var rect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);
                    EditorGUI.LabelField(rect, "(空)");
                }
                EditorGUI.EndProperty();
                return;
            }

            var keyType = GetGenericArgument(wrapper, 0);
            var valueType = GetGenericArgument(wrapper, 1);

            foreach (DictionaryEntry entry in dict)
            {
                var key = entry.Key;
                var prop = entry.Value;
                var valueInfo = prop?.GetType().GetProperty(ValuePropertyName);
                var value = valueInfo?.GetValue(prop);
                var actualValueType = valueInfo?.PropertyType ?? valueType;

                var rowRect = new Rect(position.x, y, position.width, EditorGUIUtility.singleLineHeight);

                float keyWidth = Mathf.Max(80f, position.width * 0.35f);
                var keyRect = new Rect(rowRect.x, rowRect.y, keyWidth, rowRect.height);
                var valueRect = new Rect(
                    rowRect.x + keyWidth + Spacing,
                    rowRect.y,
                    rowRect.width - keyWidth - Spacing,
                    rowRect.height);

                EditorGUI.LabelField(keyRect, key?.ToString() ?? "null");

                if (valueInfo != null)
                {
                    using (var scope = new EditorGUI.ChangeCheckScope())
                    {
                        var newValue = DrawTypedValue(valueRect, value, actualValueType, GUIContent.none);
                        if (scope.changed && !Equals(newValue, value))
                        {
                            Undo.RecordObject(property.serializedObject.targetObject, "Modify Dict Value");
                            CallModify(wrapper, key, keyType, newValue, actualValueType);
                            EditorUtility.SetDirty(property.serializedObject.targetObject);
                        }
                    }
                }
                else
                {
                    EditorGUI.LabelField(valueRect, prop == null ? "(未初始化)" : "(无法读取)");
                }

                y += EditorGUIUtility.singleLineHeight + Spacing;
            }

            EditorGUI.EndProperty();
        }

        private float GetDictHeight(SerializedProperty property, object wrapper)
        {
            float height = EditorGUIUtility.singleLineHeight + Spacing;

            if (!GetFoldout(property))
                return height;

            var dict = GetPropertyValue(wrapper, DictPropertyName) as IDictionary;
            if (dict == null || dict.Count == 0)
                return height + EditorGUIUtility.singleLineHeight;

            return height + dict.Count * (EditorGUIUtility.singleLineHeight + Spacing);
        }

        // ── 类型绘制 ─────────────────────────────────────────────

        private static object DrawTypedValue(Rect rect, object value, Type type, GUIContent label)
        {
            // 整数类型
            if (type == typeof(int))
                return EditorGUI.IntField(rect, label, (int)value);
            if (type == typeof(uint))
                return (uint)EditorGUI.LongField(rect, label, (long)(uint)value);
            if (type == typeof(long))
                return EditorGUI.LongField(rect, label, (long)value);
            if (type == typeof(ulong))
            {
                var str = EditorGUI.TextField(rect, label, value?.ToString() ?? "0");
                return ulong.TryParse(str, out var result) ? result : value;
            }
            if (type == typeof(short))
                return (short)EditorGUI.IntField(rect, label, (short)value);
            if (type == typeof(ushort))
                return (ushort)EditorGUI.IntField(rect, label, (ushort)value);
            if (type == typeof(byte))
                return (byte)EditorGUI.IntField(rect, label, (byte)value);
            if (type == typeof(sbyte))
                return (sbyte)EditorGUI.IntField(rect, label, (sbyte)value);

            // 浮点类型
            if (type == typeof(float))
                return EditorGUI.FloatField(rect, label, (float)value);
            if (type == typeof(double))
                return EditorGUI.DoubleField(rect, label, (double)value);
            if (type == typeof(decimal))
            {
                var str = EditorGUI.TextField(rect, label, value?.ToString() ?? "0");
                return decimal.TryParse(str, out var result) ? result : value;
            }

            // 其他原始类型
            if (type == typeof(string))
                return EditorGUI.TextField(rect, label, (string)value ?? "");
            if (type == typeof(bool))
                return EditorGUI.Toggle(rect, label, (bool)value);
            if (type == typeof(char))
            {
                var str = EditorGUI.TextField(rect, label, value == null ? "" : ((char)value).ToString());
                return str.Length > 0 ? str[0] : '\0';
            }

            // 扩展类型 (UGUProperty<T> 当前不支持, 保留兼容)
            if (type == typeof(Vector2))
                return EditorGUI.Vector2Field(rect, label, (Vector2)value);
            if (type == typeof(Vector3))
                return EditorGUI.Vector3Field(rect, label, (Vector3)value);
            if (type == typeof(Vector4))
                return EditorGUI.Vector4Field(rect, label, (Vector4)value);
            if (type == typeof(Color))
                return EditorGUI.ColorField(rect, label, (Color)value);
            if (type.IsEnum)
                return EditorGUI.EnumPopup(rect, label, (Enum)value);

            EditorGUI.LabelField(rect, label, new GUIContent(value?.ToString() ?? "null"));
            return value;
        }

        // ── 反射工具 ──────────────────────────────────────────────

        private static bool IsSubclassOfRawGeneric(Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur) return true;
                toCheck = toCheck.BaseType;
            }
            return false;
        }

        private object GetWrapperInstance(SerializedProperty property)
        {
            var target = property.serializedObject.targetObject;
            if (target == null || fieldInfo == null) return null;

            // 直接字段 — fieldInfo 即可
            if (!property.propertyPath.Contains("."))
                return fieldInfo.GetValue(target);

            // nested property path (含 Array.data[N] 格式)
            var parts = property.propertyPath.Split('.');
            object current = target;
            foreach (var part in parts)
            {
                if (current == null) return null;

                if (part == "Array")
                    continue;

                // Unity 数组元素路径: data[N]
                if (part.StartsWith("data[") && part.EndsWith("]"))
                {
                    var indexStr = part.Substring(5, part.Length - 6);
                    if (int.TryParse(indexStr, out int index) && current is IList list)
                    {
                        current = index >= 0 && index < list.Count ? list[index] : null;
                    }
                    continue;
                }

                var fi = current.GetType().GetField(
                    part, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                current = fi?.GetValue(current);
            }
            return current;
        }

        /// <summary>
        /// 向上查找基类中的字段值
        /// </summary>
        private static object GetFieldValue(object obj, string fieldName)
        {
            if (obj == null) return null;
            var t = obj.GetType();
            while (t != null && t != typeof(object))
            {
                var fi = t.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (fi != null) return fi.GetValue(obj);
                t = t.BaseType;
            }
            return null;
        }

        /// <summary>
        /// 向上查找基类中的属性值
        /// </summary>
        private static object GetPropertyValue(object obj, string propName)
        {
            if (obj == null) return null;
            var t = obj.GetType();
            while (t != null && t != typeof(object))
            {
                var pi = t.GetProperty(propName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (pi != null) return pi.GetValue(obj);
                t = t.BaseType;
            }
            return null;
        }

        private static Type GetGenericArgument(object obj, int index)
        {
            if (obj == null) return typeof(object);
            var t = obj.GetType();
            while (t != null && t != typeof(object))
            {
                if (t.IsGenericType && t.GetGenericArguments().Length > index)
                    return t.GetGenericArguments()[index];
                t = t.BaseType;
            }
            return typeof(object);
        }

        // ── Modify 调用 ───────────────────────────────────────────

        private static void CallModify(object wrapper, object value, Type valueType)
        {
            var method = wrapper.GetType().GetMethod(ModifyMethodName, new[] { valueType });
            method?.Invoke(wrapper, new[] { value });
        }

        private static void CallModify(object wrapper, int index, object value, Type valueType)
        {
            var method = wrapper.GetType().GetMethod(ModifyMethodName, new[] { typeof(int), valueType });
            method?.Invoke(wrapper, new object[] { index, value });
        }

        private static void CallModify(object wrapper, object key, Type keyType, object value, Type valueType)
        {
            var method = wrapper.GetType().GetMethod(ModifyMethodName, new[] { keyType, valueType });
            method?.Invoke(wrapper, new[] { key, value });
        }

        // ── Foldout 状态 ─────────────────────────────────────────

        private static string GetFoldoutKey(SerializedProperty property)
        {
            var target = property.serializedObject.targetObject;
            return $"{target.GetInstanceID()}:{property.propertyPath}";
        }

        private static bool GetFoldout(SerializedProperty property)
        {
            FoldoutStates.TryGetValue(GetFoldoutKey(property), out bool state);
            return state;
        }

        private static void SetFoldout(SerializedProperty property, bool value)
        {
            FoldoutStates[GetFoldoutKey(property)] = value;
        }
    }
}

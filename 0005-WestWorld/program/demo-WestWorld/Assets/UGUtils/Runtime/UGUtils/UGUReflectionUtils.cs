using System;
using System.Reflection;

namespace UGU.Runtime
{
    /// <summary>
    /// 反射工具
    /// </summary>
    public static class UGUReflectionUtils
    {
        /// <summary>
        /// 转换对象类型(class)
        /// </summary>
        /// <param name="obj">对象</param>
        /// <typeparam name="T">目标类型</typeparam>
        /// <returns>转换失败返回 null</returns>
        public static T ConvertObjectClass<T>(object obj) where T : class
        {
            if (obj is T)
                return (T) obj;
            else
                return null;
        }

        /// <summary>
        /// 获取对象的非公共方法
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="methodName">方法名</param>
        /// <returns></returns>
        public static MethodInfo GetObjectNoPublicMethod(Type type, string methodName)
        {
            return type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
        }

        /// <summary>
        /// 获取对象的非公共字段(变量)
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="fieldName">字段名</param>
        /// <returns></returns>
        public static FieldInfo GetObjectNoPublicField(Type type, string fieldName)
        {
            return type.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        }
    }
}

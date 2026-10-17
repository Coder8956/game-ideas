using System;

namespace UMiniFramework.Runtime
{
    public static class UMConfigUtils
    {
    }

    /// <summary>
    /// 解析由 ":" 分割的字符串键值对
    /// K, V 只支持 string; bool; int; uint; float;
    /// </summary>
    /// <typeparam name="K"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class UMCfgKV<K, V>
    {
        public readonly K Key;
        public readonly V Value;

        public UMCfgKV(string content)
        {
            string[] kv = content.Split(':');
            Key = ConvertTo<K>(kv[0]);
            Value = ConvertTo<V>(kv[1]);
        }

        private static T ConvertTo<T>(string value)
        {
            Type type = typeof(T);

            if (type == typeof(string))
            {
                return (T) (object) value;
            }

            if (type == typeof(int))
                return (T) (object) int.Parse(value);

            if (type == typeof(uint))
                return (T) (object) uint.Parse(value);

            if (type == typeof(float))
                return (T) (object) float.Parse(value);

            if (type == typeof(bool))
                return (T) (object) bool.Parse(value);

            return (T) Convert.ChangeType(value, type);
        }
    }
}

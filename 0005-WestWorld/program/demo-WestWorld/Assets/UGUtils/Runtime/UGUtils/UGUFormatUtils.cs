namespace UGU.Runtime
{
    /// <summary>
    /// 格式化工具
    /// </summary>
    public static class UGUFormatUtils
    {
        /// <summary>
        /// 将浮点数格式化为百分比字符串
        /// </summary>
        /// <param name="value">要格式化的值 (如 0.4567)</param>
        /// <param name="decimalPlaces">保留小数位数</param>
        /// <returns>百分比字符串 (如 "45.67%")</returns>
        public static string ToPercent(float value, int decimalPlaces = 2)
        {
            return value.ToString("P" + decimalPlaces);
        }
    }
}

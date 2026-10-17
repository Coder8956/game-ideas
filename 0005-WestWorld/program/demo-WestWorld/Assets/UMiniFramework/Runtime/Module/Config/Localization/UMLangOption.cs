namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 语言选项，包含语言类型和语言代码
    /// </summary>
    public struct UMLangOption
    {
        /// <summary>
        /// 语言类型（如：简体中文、English）
        /// </summary>
        public string type;

        /// <summary>
        /// 语言代码（如：SC、ENG）
        /// </summary>
        public string code;

        public UMLangOption(string type, string code)
        {
            this.type = type;
            this.code = code;
        }
    }
}

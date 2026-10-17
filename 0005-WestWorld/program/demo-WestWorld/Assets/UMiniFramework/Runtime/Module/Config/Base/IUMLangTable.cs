using System.Collections.Generic;

namespace UMiniFramework.Runtime
{
    /// <summary>
    /// 多语言配置表接口，由 Config Editor Window 生成的语言配置表实现
    /// </summary>
    public interface IUMLangTable
    {
        /// <summary>
        /// 获取所有语言选项（类型 + 代码）
        /// </summary>
        List<UMLangOption> GetOptions();

        /// <summary>
        /// 通过语言类型获取语言内容 (id → text)
        /// </summary>
        Dictionary<string, string> GetContent(string langType);

        /// <summary>
        /// 通过索引获取语言对应的配置文件名
        /// </summary>
        string GetLanguageFile(int index);

        /// <summary>
        /// 通过索引获取语言代码
        /// </summary>
        string GetLanguageCode(int index);
    }
}

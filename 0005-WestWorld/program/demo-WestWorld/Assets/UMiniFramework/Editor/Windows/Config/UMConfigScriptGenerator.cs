using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace UMiniFramework.Editor
{
    internal static class UMConfigScriptGenerator
    {
        private const string ScriptTip = "// UMiniFramework config automatically generated, please do not modify it";

        public static void CreateConfigScript(
            List<UMConfigFieldInfo> fieldInfos,
            string excelPath,
            string scriptFolder,
            string dataFolder,
            List<string> tableClassList)
        {
            if (fieldInfos == null || fieldInfos.Count < 1) return;

            string excelName = Path.GetFileNameWithoutExtension(excelPath);
            string dataClassName = $"{UMConfigUtility.CapitalizeFirstWord(excelName)}Data";

            UMConfigFieldInfo idConfigField = fieldInfos.Find(ele => ele.Field.ToLower() == "id");
            if (idConfigField == null)
            {
                EditorUtility.DisplayDialog("Tip",
                    $"Failed to generate the configuration table script. There is no id field in the configuration table.\n{excelPath}",
                    "OK");
                return;
            }

            GenerateDataScript(fieldInfos, dataClassName, scriptFolder);
            GenerateTableScript(fieldInfos, excelName, dataClassName, scriptFolder, dataFolder, tableClassList);
        }

        private static void GenerateDataScript(
            List<UMConfigFieldInfo> fieldInfos,
            string dataClassName,
            string scriptFolder)
        {
            var sb = new StringBuilder();
            sb.AppendLine(ScriptTip);
            sb.AppendLine("using Newtonsoft.Json;");
            sb.AppendLine();
            sb.AppendLine($"public class {dataClassName}");
            sb.AppendLine("{");

            foreach (var cfi in fieldInfos)
            {
                if (!string.IsNullOrEmpty(cfi.Comments))
                {
                    sb.AppendLine("    /// <summary>");
                    sb.AppendLine($"    /// {cfi.Comments}");
                    sb.AppendLine("    /// </summary>");
                }

                sb.AppendLine($"    [JsonProperty] public readonly {cfi.Type.ToLower()} {cfi.Field};");
                sb.AppendLine();
            }

            sb.AppendLine("}");

            string savePath = $"{scriptFolder}/{dataClassName}.cs";
            if (File.Exists(savePath))
                File.Delete(savePath);

            File.WriteAllText(savePath, sb.ToString(), Encoding.UTF8);
        }

        private static void GenerateTableScript(
            List<UMConfigFieldInfo> fieldInfos,
            string excelName,
            string dataClassName,
            string scriptFolder,
            string dataFolder,
            List<string> tableClassList)
        {
            string tableClassName = $"{UMConfigUtility.CapitalizeFirstWord(excelName)}Table";
            tableClassList.Add(tableClassName);

            string configPath = dataFolder.Replace($"{Application.dataPath}/", "");
            string configAssetPath = $"Assets/{configPath}/{excelName}";
            string[] splitStrs = configAssetPath.Split(new[] {"Resources/"}, System.StringSplitOptions.None);
            string configLoadPath = splitStrs[splitStrs.Length - 1];

            var sb = new StringBuilder();
            sb.AppendLine(ScriptTip);
            sb.AppendLine("using UMiniFramework.Runtime;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Newtonsoft.Json;");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine();
            sb.AppendLine($"public class {tableClassName} : UMConfigTableBase");
            sb.AppendLine("{");

            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 配置文件路径");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine($"    private const string ConfigAssetPath = \"{configAssetPath}\";");
            sb.AppendLine("    public override string AssetPath { get { return ConfigAssetPath; } }");
            sb.AppendLine($"    private const string ConfigLoadPath = \"{configLoadPath}\";");
            sb.AppendLine("    public override string LoadPath { get { return ConfigLoadPath; } }");
            sb.AppendLine();

            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 包含在配置表中的数据");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine($"    public List<{dataClassName}> TableData {{ get; private set; }}");
            sb.AppendLine();

            // Find the id field (not necessarily the first column)
            UMConfigFieldInfo idField = fieldInfos.Find(ele => ele.Field.ToLower() == "id");
            string idType = idField != null ? idField.Type.ToLower() : string.Empty;

            if (idField != null)
            {
                if (idType != "string")
                    return;

                string idDicTypeString = $"Dictionary<{idType}, {dataClassName}>";

                sb.AppendLine($"    private {idDicTypeString} m_dataDicById;");
                sb.AppendLine();
                sb.AppendLine("    /// <summary>");
                sb.AppendLine("    /// 通过 Id 属性查询数据");
                sb.AppendLine("    /// </summary>");
                sb.AppendLine($"    public {dataClassName} GetDataById({idType} id)");
                sb.AppendLine("    {");
                sb.AppendLine("        if (m_dataDicById.ContainsKey(id))");
                sb.AppendLine("            return m_dataDicById[id];");
                sb.AppendLine("        else");
                sb.AppendLine($"            Debug.LogWarning($\"{tableClassName} id does not exist {{id}}\");");
                sb.AppendLine("        return null;");
                sb.AppendLine("    }");
            }

            sb.AppendLine();
            sb.AppendLine("    protected override void OnInit(string tableContent)");
            sb.AppendLine("    {");
            sb.AppendLine($"        m_dataDicById = new Dictionary<{idType}, {dataClassName}>();");
            sb.AppendLine($"        TableData = JsonConvert.DeserializeObject<List<{dataClassName}>>(tableContent);");
            sb.AppendLine("        for (var i = 0; i < TableData.Count; i++)");
            sb.AppendLine("        {");
            sb.AppendLine("            m_dataDicById.Add(TableData[i].id, TableData[i]);");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            string savePath = $"{scriptFolder}/{tableClassName}.cs";
            File.WriteAllText(savePath, sb.ToString(), Encoding.UTF8);
        }

        public static void CreateLangScript(
            DataTable table,
            string excelPath,
            string scriptFolder,
            string dataFolder,
            List<string> tableClassList)
        {
            const string LangScriptClassName = "LanguageCfg";
            tableClassList.Add(LangScriptClassName);

            string langScriptFolder = $"{scriptFolder}/lang";
            Directory.CreateDirectory(langScriptFolder);

            // Compute AssetPath and LoadPath for lang/lang_types
            string configPath = dataFolder.Replace($"{Application.dataPath}/", "");
            string configAssetPath = $"Assets/{configPath}/lang/lang_types";
            string[] splitStrs = configAssetPath.Split(new[] {"Resources/"}, System.StringSplitOptions.None);
            string configLoadPath = splitStrs[splitStrs.Length - 1];

            var sb = new StringBuilder();
            sb.AppendLine(ScriptTip);
            sb.AppendLine("using UMiniFramework.Runtime;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Newtonsoft.Json;");
            sb.AppendLine("using UnityEngine;");
            sb.AppendLine();
            sb.AppendLine($"public class {LangScriptClassName} : UMConfigTableBase, IUMLangTable");
            sb.AppendLine("{");

            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 配置文件路径");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine($"    private const string ConfigAssetPath = \"{configAssetPath}\";");
            sb.AppendLine("    public override string AssetPath { get { return ConfigAssetPath; } }");
            sb.AppendLine($"    private const string ConfigLoadPath = \"{configLoadPath}\";");
            sb.AppendLine("    public override string LoadPath { get { return ConfigLoadPath; } }");
            sb.AppendLine();

            // 3.4.1: Language types list (private)
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 语言类型列表");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    private List<string> m_langTypes;");
            sb.AppendLine();

            // LangTypeEntry for deserialization of lang_types.json
            sb.AppendLine("    private class LangTypeEntry");
            sb.AppendLine("    {");
            sb.AppendLine("        [JsonProperty(\"type\")] public string type;");
            sb.AppendLine("        [JsonProperty(\"code\")] public string code;");
            sb.AppendLine("        [JsonProperty(\"file\")] public string file;");
            sb.AppendLine("    }");
            sb.AppendLine();

            // LangEntry for deserialization of lang_{i}.json
            sb.AppendLine("    private class LangEntry");
            sb.AppendLine("    {");
            sb.AppendLine("        [JsonProperty(\"type\")] public string type;");
            sb.AppendLine("        [JsonProperty(\"code\")] public string code;");
            sb.AppendLine("        [JsonProperty(\"content\")] public Dictionary<string, string> content;");
            sb.AppendLine("    }");
            sb.AppendLine();

            // 3.4.2: Language file list (private)
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 语言文件名列表");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    private List<string> m_langFiles;");
            sb.AppendLine();

            // Language codes list (private)
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 语言代码列表");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    private List<string> m_langCodes;");
            sb.AppendLine();

            // 3.4.2: Language content dictionary (private)
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 语言内容字典，key 为语言名称，value 为该语言的 id→内容映射");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    private Dictionary<string, Dictionary<string, string>> m_langContent;");
            sb.AppendLine();

            // 3.4.3: Get content by index
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 通过索引获取语言配置");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public Dictionary<string, string> GetContent(int index)");
            sb.AppendLine("    {");
            sb.AppendLine("        if (index < 0 || index >= m_langTypes.Count)");
            sb.AppendLine("        {");
            sb.AppendLine("            Debug.LogWarning($\"Language index out of range: {index}\");");
            sb.AppendLine("            return null;");
            sb.AppendLine("        }");
            sb.AppendLine("        return m_langContent[m_langTypes[index]];");
            sb.AppendLine("    }");
            sb.AppendLine();

            // 3.4.3: Get content by name
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 通过语言名称获取语言配置");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public Dictionary<string, string> GetContent(string langName)");
            sb.AppendLine("    {");
            sb.AppendLine("        if (m_langContent.TryGetValue(langName, out var content))");
            sb.AppendLine("            return content;");
            sb.AppendLine("        Debug.LogWarning($\"Language not found: {langName}\");");
            sb.AppendLine("        return null;");
            sb.AppendLine("    }");
            sb.AppendLine();

            // Convenience: GetText by index + id
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 通过索引和 id 获取单条语言文本");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public string GetText(int langIndex, string id)");
            sb.AppendLine("    {");
            sb.AppendLine("        var content = GetContent(langIndex);");
            sb.AppendLine("        if (content != null && content.TryGetValue(id, out var text))");
            sb.AppendLine("            return text;");
            sb.AppendLine("        return null;");
            sb.AppendLine("    }");
            sb.AppendLine();

            // Convenience: GetText by name + id
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 通过语言名称和 id 获取单条语言文本");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public string GetText(string langName, string id)");
            sb.AppendLine("    {");
            sb.AppendLine("        var content = GetContent(langName);");
            sb.AppendLine("        if (content != null && content.TryGetValue(id, out var text))");
            sb.AppendLine("            return text;");
            sb.AppendLine("        return null;");
            sb.AppendLine("    }");
            sb.AppendLine();

            // 3.4.4: Get all languages
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 获取所有语言选项（类型 + 代码）");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public List<UMLangOption> GetOptions()");
            sb.AppendLine("    {");
            sb.AppendLine("        var options = new List<UMLangOption>(m_langTypes.Count);");
            sb.AppendLine("        for (int i = 0; i < m_langTypes.Count; i++)");
            sb.AppendLine("        {");
            sb.AppendLine("            options.Add(new UMLangOption(m_langTypes[i], m_langCodes[i]));");
            sb.AppendLine("        }");
            sb.AppendLine("        return options;");
            sb.AppendLine("    }");
            sb.AppendLine();

            // 3.4.4: Language count
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 语言数量");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public int LanguageCount { get { return m_langTypes.Count; } }");
            sb.AppendLine();

            // 3.4.4: Get language name by index
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 通过索引获取语言名称");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public string GetLanguageName(int index)");
            sb.AppendLine("    {");
            sb.AppendLine("        if (index < 0 || index >= m_langTypes.Count)");
            sb.AppendLine("            return null;");
            sb.AppendLine("        return m_langTypes[index];");
            sb.AppendLine("    }");
            sb.AppendLine();

            // 3.4.4: Get index by language name
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 通过语言名称获取索引");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public int GetLanguageIndex(string langName)");
            sb.AppendLine("    {");
            sb.AppendLine("        return m_langTypes.IndexOf(langName);");
            sb.AppendLine("    }");
            sb.AppendLine();

            // Get language code by index
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 通过索引获取语言代码");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public string GetLanguageCode(int index)");
            sb.AppendLine("    {");
            sb.AppendLine("        if (index < 0 || index >= m_langCodes.Count)");
            sb.AppendLine("            return null;");
            sb.AppendLine("        return m_langCodes[index];");
            sb.AppendLine("    }");
            sb.AppendLine();

            // Get language file by index
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// 通过索引获取语言对应的配置文件名");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    public string GetLanguageFile(int index)");
            sb.AppendLine("    {");
            sb.AppendLine("        if (index < 0 || index >= m_langFiles.Count)");
            sb.AppendLine("            return null;");
            sb.AppendLine("        return m_langFiles[index];");
            sb.AppendLine("    }");
            sb.AppendLine();

            // OnInit: load types then load each language file
            sb.AppendLine("    protected override void OnInit(string tableContent)");
            sb.AppendLine("    {");
            sb.AppendLine("        var langEntries = JsonConvert.DeserializeObject<List<LangTypeEntry>>(tableContent);");
            sb.AppendLine();
            sb.AppendLine("        m_langTypes = new List<string>(langEntries.Count);");
            sb.AppendLine("        m_langFiles = new List<string>(langEntries.Count);");
            sb.AppendLine("        m_langCodes = new List<string>(langEntries.Count);");
            sb.AppendLine("        m_langContent = new Dictionary<string, Dictionary<string, string>>();");
            sb.AppendLine();
            sb.AppendLine("        string basePath = ConfigLoadPath.Substring(0, ConfigLoadPath.LastIndexOf('/'));");
            sb.AppendLine("        for (int i = 0; i < langEntries.Count; i++)");
            sb.AppendLine("        {");
            sb.AppendLine("            var entry = langEntries[i];");
            sb.AppendLine("            m_langTypes.Add(entry.type);");
            sb.AppendLine("            m_langFiles.Add(entry.file);");
            sb.AppendLine();
            sb.AppendLine("            string fileName = entry.file.EndsWith(\".json\")");
            sb.AppendLine("                ? entry.file.Substring(0, entry.file.Length - 5)");
            sb.AppendLine("                : entry.file;");
            sb.AppendLine("            var asset = Resources.Load<TextAsset>($\"{basePath}/{fileName}\");");
            sb.AppendLine("            if (asset != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                var langData = JsonConvert.DeserializeObject<LangEntry>(asset.text);");
            sb.AppendLine("                m_langCodes.Add(langData.code);");
            sb.AppendLine("                m_langContent[entry.type] = langData.content;");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("            {");
            sb.AppendLine("                Debug.LogWarning($\"Language file not found: {basePath}/{entry.file}\");");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            string savePath = $"{langScriptFolder}/{LangScriptClassName}.cs";
            File.WriteAllText(savePath, sb.ToString(), Encoding.UTF8);
        }
    }
}

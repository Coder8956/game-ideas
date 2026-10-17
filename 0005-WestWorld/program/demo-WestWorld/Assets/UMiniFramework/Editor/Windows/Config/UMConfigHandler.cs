using System.Collections.Generic;
using System.Data;
using System.IO;
using ExcelDataReader;
using UnityEditor;

namespace UMiniFramework.Editor
{
    public enum UMConfigUpdateMode
    {
        /// <summary>
        /// 仅更新数据
        /// </summary>
        Data,

        /// <summary>
        /// 仅更新脚本
        /// </summary>
        Scripts,

        /// <summary>
        /// 同时更新数据和脚本
        /// </summary>
        DataAndScripts
    }

    public class UMConfigHandler
    {
        private static readonly List<string> TableClassList = new List<string>();

        public static void UpdateConfig(
            List<string> configFiles,
            string scriptFolder,
            string dataFolder,
            UMConfigUpdateMode mode,
            string langTableName = null)
        {
            bool updateData = mode == UMConfigUpdateMode.Data ||
                              mode == UMConfigUpdateMode.DataAndScripts;
            bool updateScripts = mode == UMConfigUpdateMode.Scripts ||
                                 mode == UMConfigUpdateMode.DataAndScripts;

            if (updateScripts && !UMConfigUtility.IsSafeFolder(scriptFolder))
            {
                EditorUtility.DisplayDialog(
                    "Error",
                    "Cannot clear this folder.",
                    "OK");
                return;
            }

            if (updateData && !UMConfigUtility.IsSafeFolder(dataFolder))
            {
                EditorUtility.DisplayDialog(
                    "Error",
                    "Cannot clear this folder.",
                    "OK");
                return;
            }

            string normalizedScriptFolder = scriptFolder.Replace("\\", "/");
            string normalizedDataFolder = dataFolder.Replace("\\", "/");

            if (updateScripts && !Directory.Exists(scriptFolder))
            {
                EditorUtility.DisplayDialog(
                    "Invalid Folder",
                    scriptFolder,
                    "OK");
                return;
            }

            // dataFolder is always needed (CreateConfigScript uses it for config path),
            // but only cleared when updating data
            if (!Directory.Exists(dataFolder))
            {
                EditorUtility.DisplayDialog(
                    "Invalid Folder",
                    dataFolder,
                    "OK");
                return;
            }

            // 清理旧生成文件
            if (updateScripts)
                UMConfigUtility.ClearDirectory(normalizedScriptFolder);
            if (updateData)
                UMConfigUtility.ClearDirectory(normalizedDataFolder);

            TableClassList.Clear();

            try
            {
                for (int i = 0; i < configFiles.Count; i++)
                {
                    string currentExcel = configFiles[i];

                    EditorUtility.DisplayProgressBar(
                        "UMConfigModule Create Config By Excel",
                        $"Current Excel: {currentExcel}",
                        (float) i / configFiles.Count);

                    string excelName = Path.GetFileNameWithoutExtension(currentExcel);
                    bool isLangTable = !string.IsNullOrEmpty(langTableName) &&
                                       excelName.Equals(langTableName, System.StringComparison.OrdinalIgnoreCase);

                    if (isLangTable)
                    {
                        CreateLangConfigByExcel(
                            currentExcel,
                            normalizedScriptFolder,
                            normalizedDataFolder,
                            mode);
                    }
                    else
                    {
                        CreateConfigByExcel(
                            currentExcel,
                            normalizedScriptFolder,
                            normalizedDataFolder,
                            mode);
                    }
                }
            }
            finally
            {
                EditorUtility.ClearProgressBar();
            }

            AssetDatabase.Refresh();

            string completionMsg = mode switch
            {
                UMConfigUpdateMode.Data => "Data update complete.",
                UMConfigUpdateMode.Scripts => "Scripts update complete.",
                _ => "Configuration update complete."
            };

            EditorUtility.DisplayDialog(
                "Tip",
                completionMsg,
                "OK");
        }

        public static void GetAllExcelFiles(string folderPath, List<string> configFiles)
        {
            foreach (var file in Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories))
            {
                var ext = Path.GetExtension(file);
                if ((ext == ".xlsx" || ext == ".xls") && !file.Contains("~$"))
                {
                    string validFile = file.Replace("\\", "/");
                    configFiles.Add(validFile);
                }
            }
        }

        private static void CreateConfigByExcel(
            string excel,
            string scriptFolder,
            string dataFolder,
            UMConfigUpdateMode mode)
        {
            if (excel.Contains("~$")) return;

            using (var stream = File.Open(excel, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet();
                if (result.Tables.Count == 0) return;

                DataTable table = result.Tables[0];

                DataRow commentsRow = table.Rows[0];
                DataRow fieldRow = table.Rows[1];
                DataRow typeRow = table.Rows[2];

                int validColumnCount = GetValidColumnCount(fieldRow, table.Columns.Count);

                var fieldInfos = new List<UMConfigFieldInfo>(validColumnCount);
                for (int i = 0; i < validColumnCount; i++)
                {
                    fieldInfos.Add(new UMConfigFieldInfo(
                        commentsRow[i].ToString(),
                        fieldRow[i].ToString(),
                        typeRow[i].ToString(), i));
                }

                if (mode == UMConfigUpdateMode.Data ||
                    mode == UMConfigUpdateMode.DataAndScripts)
                {
                    UMConfigJsonGenerator.CreateConfigJson(
                        fieldInfos,
                        table,
                        excel,
                        dataFolder);
                }

                if (mode == UMConfigUpdateMode.Scripts ||
                    mode == UMConfigUpdateMode.DataAndScripts)
                {
                    UMConfigScriptGenerator.CreateConfigScript(
                        fieldInfos,
                        excel,
                        scriptFolder,
                        dataFolder,
                        TableClassList);
                }
            }
        }

        private static int GetValidColumnCount(DataRow fieldRow, int totalColumns)
        {
            int count = 0;
            for (int i = 0; i < totalColumns; i++)
            {
                if (!string.IsNullOrEmpty(fieldRow[i].ToString()))
                    ++count;
                else
                    break;
            }

            return count;
        }

        private static void CreateLangConfigByExcel(
            string excel,
            string scriptFolder,
            string dataFolder,
            UMConfigUpdateMode mode)
        {
            if (excel.Contains("~$")) return;

            using (var stream = File.Open(excel, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet();
                if (result.Tables.Count == 0) return;

                DataTable table = result.Tables[0];

                if (mode == UMConfigUpdateMode.Data ||
                    mode == UMConfigUpdateMode.DataAndScripts)
                {
                    UMConfigJsonGenerator.CreateLangJson(
                        table,
                        dataFolder);
                }

                if (mode == UMConfigUpdateMode.Scripts ||
                    mode == UMConfigUpdateMode.DataAndScripts)
                {
                    UMConfigScriptGenerator.CreateLangScript(
                        table,
                        excel,
                        scriptFolder,
                        dataFolder,
                        TableClassList);
                }
            }
        }
    }
}

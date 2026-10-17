using System.IO;
using UnityEngine;

namespace UMiniFramework.Editor
{
    internal static class UMConfigUtility
    {
        public static void ClearDirectory(string path)
        {
            if (!Directory.Exists(path))
                return;

            DirectoryInfo directory = new DirectoryInfo(path);

            // 删除文件
            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            // 删除子目录
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static bool IsSafeFolder(string path)
        {
            string fullPath =
                Path.GetFullPath(path)
                    .Replace("\\", "/");

            string assetsPath =
                Path.GetFullPath(Application.dataPath)
                    .Replace("\\", "/");

            // 禁止清理 Assets 根目录
            if (fullPath == assetsPath)
                return false;

            return true;
        }

        public static string CapitalizeFirstWord(string content)
        {
            return char.ToUpper(content[0]) + content.Substring(1);
        }
    }
}

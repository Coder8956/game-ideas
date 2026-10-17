using UnityEditor;
using UnityEngine;

namespace UGU.Editor
{
    public static class EUGUDirUtils
    {
        private const string MenuTitle = "UGUtils/Open Directory";

        /// <summary>
        /// 打开场景
        /// </summary>
        [MenuItem(MenuTitle + "/PersistentData")]
        static void OpenPersistentDataPath()
        {
            // 直接打开文件夹
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }

        [MenuItem(MenuTitle + "/Assets")]
        static void OpenAssetsFolder()
        {
            EditorUtility.RevealInFinder(Application.dataPath);
        }

        [MenuItem(MenuTitle + "/Project")]
        static void OpenProjectFolder()
        {
            // 项目根目录是 Assets 的上一级
            string projectPath = System.IO.Directory.GetParent(Application.dataPath).FullName;
            EditorUtility.RevealInFinder(projectPath);
        }
    }
}

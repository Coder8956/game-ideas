using System.IO;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Editor.Install
{
    public static class Installer
    {
        private const string InstallFolder = "Packages/com.hutonggames.playmaker/Install";

        public static void InstallPlayMaker()
        {
#if PLAYMAKER_SOURCE_VERSION
            Debug.Log($"Source code version, nothing to install...");
            return;
#endif    

            var file = GetFileName(InstallFolder, "PlayMaker.unitypackage");
#if UNITY_6000_6_OR_NEWER
            UnityEditor.AssetPackage.Package.Import(file, false);
#else
            AssetDatabase.ImportPackage(file, false);
#endif
        }

        private static string GetFileName(string folder, string name) => 
            Path.GetFullPath(Application.dataPath + $"/../{folder}/{name}");
    }
}

using System.IO;
using System.Linq;
using JetBrains.Annotations;
using UnityEditor;
using UnityEditor.PackageManager;

namespace HutongGames.PlayMaker.Editor
{
    [PublicAPI]
    public static class PackageHelpers
    {
        public static bool IsPackageInstalled(string packageName)
        {
            var listRequest = Client.List(true);
            while (!listRequest.IsCompleted) { }
    
            if (listRequest.Status == StatusCode.Success)
            {
                return listRequest.Result.Any(package => package.name == packageName);
            }
    
            return false;
        }
        
        public static bool DoesPackageDirectoryExist(string packageName, string subPath = "")
        {
            string packagePath = $"Packages/{packageName}";
            if (!string.IsNullOrEmpty(subPath))
            {
                packagePath = Path.Combine(packagePath, subPath).Replace('\\', '/');
            }
            
            return AssetDatabase.IsValidFolder(packagePath);
        }

    }
}
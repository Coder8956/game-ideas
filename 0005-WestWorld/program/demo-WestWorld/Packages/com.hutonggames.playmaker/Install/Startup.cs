
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace HutongGames.PlayMaker.Editor.Install
{
    [InitializeOnLoad]
    public class Startup
    {
        private const string UnityVersionMismatchWarningSessionKey = "HutongGames.PlayMaker.Install.UnityVersionMismatchWarning";

        static Startup()
        {
            // Delayed just to be safe
            EditorApplication.delayCall += OpenInstallWindow;

            AssetDatabase.importPackageCompleted -= OnImportPackageCompleted;
            AssetDatabase.importPackageCompleted += OnImportPackageCompleted;
        }
        
        private static void OpenInstallWindow()
        {
            InstallInfo.UpdateInfo();

            if (InstallInfo.InstalledUnityVersionMismatch && !InstallInfo.InstallerPackageMatchesCurrentUnityVersion)
            {
                ShowUnityVersionMismatchWarning();
                return;
            }

            // We only auto-open once per release build
            if (InstallInfo.UpToDate) return;

            // No graphics device in batch mode
            if (Application.isBatchMode) return;
            
            InstallWindow.Open();
            InstallInfo.RecordInstallerWasOpened();
        }

        private static void ShowUnityVersionMismatchWarning()
        {
            if (SessionState.GetBool(UnityVersionMismatchWarningSessionKey, false)) return;
            SessionState.SetBool(UnityVersionMismatchWarningSessionKey, true);

            // No graphics device in batch mode
            if (Application.isBatchMode) return;

            EditorUtility.DisplayDialog(
                "Update PlayMaker",
                InstallInfo.UnityVersionMismatchMessage,
                "OK");
        }

        private static void OnImportPackageCompleted(string packageName)
        {
            if (IsPlayMakerInstallPackage(packageName) || IsPlayMakerStorePackage(packageName))
            {
                InstallInfo.RecordInstallerPackageImported();
                EditorApplication.delayCall += OpenInstallWindow;
            }

            if (!IsPlayMakerPackage(packageName)) return;

            AssetDatabase.importPackageCompleted -= OnImportPackageCompleted;
            EditorApplication.delayCall += CloseInstallWindow;
        }

        private static bool IsPlayMakerInstallPackage(string packageName) =>
            Path.GetFileNameWithoutExtension(packageName)?.IndexOf("PlayMakerInstall", StringComparison.OrdinalIgnoreCase) >= 0;

        private static bool IsPlayMakerStorePackage(string packageName) =>
            string.Equals(Path.GetFileNameWithoutExtension(packageName), "PlayMaker 2", StringComparison.OrdinalIgnoreCase);

        private static bool IsPlayMakerPackage(string packageName) =>
            string.Equals(Path.GetFileNameWithoutExtension(packageName), "PlayMaker", StringComparison.OrdinalIgnoreCase);

        private static void CloseInstallWindow()
        {
            var installWindows = Resources.FindObjectsOfTypeAll<InstallWindow>();
            foreach (var installWindow in installWindows)
            {
                installWindow.Close();
            }
        }
    }
}

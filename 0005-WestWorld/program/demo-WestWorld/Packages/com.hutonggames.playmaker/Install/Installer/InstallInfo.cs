using System.IO;
using UnityEngine;


namespace HutongGames.PlayMaker.Editor.Install
{
    /// <summary>
    /// Helper to check if PlayMaker is installed and if it needs updating.
    /// </summary>
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
    public static class InstallInfo
    {
        /// <summary>
        /// Version file written by the installer.
        /// </summary>
        private const string InstallerVersionFile = "../ProjectSettings/PlayMaker/InstallerVersion.txt";
        private const string InstallerUnityVersionFile = "../ProjectSettings/PlayMaker/InstallerUnityVersion.txt";
        private const string InstallerUnityVersionAssetFile = "../Packages/com.hutonggames.playmaker/Install/InstallerUnityVersion.txt";
        private const string InstallerPackageFile = "../Packages/com.hutonggames.playmaker/Install/PlayMaker.unitypackage";
        
        /// <summary>
        /// Version file written after PlayMaker is installed.
        /// </summary>
        private const string InstalledVersionFile = "../ProjectSettings/PlayMaker/InstalledVersion.txt";
        private const string InstalledUnityVersionFile = "../ProjectSettings/PlayMaker/InstalledUnityVersion.txt";
        
        /// <summary>
        /// The version this installer will install.
        /// </summary>
        public const string InstallerVersion = "2.0.0b88";
        
        public static bool UpToDate =>
            LastInstallerVersion == InstallerVersion &&
            IsPlayMakerInstalled() &&
            !InstalledUnityVersionMismatch &&
            !InstallerPackageImportedAfterLastOpen;
        
        public static string InstalledVersion { get; private set; }

        public static string InstalledUnityVersion { get; private set; }

        public static string InstalledVersionDisplay =>
            ShowUnityVersionInVersionLabels ? FormatVersionDisplay(InstalledVersion, InstalledUnityVersion) : InstalledVersion;

        public static string InstallerVersionDisplay =>
            ShowUnityVersionInVersionLabels ? FormatVersionDisplay(InstallerVersion, GetInstallerUnityVersion()) : InstallerVersion;

        public static string CurrentUnityVersion => GetUnityCompatibilityVersion();

        public static bool InstalledUnityVersionMismatch =>
            IsPlayMakerInstalled() &&
            !string.IsNullOrEmpty(InstalledUnityVersion) &&
            InstalledUnityVersion != CurrentUnityVersion;

        public static bool InstallerPackageImportedAfterLastOpen
        {
            get
            {
                var installerUnityVersionFile = GetVersionFilePath(InstallerUnityVersionFile);
                var installerVersionFile = GetVersionFilePath(InstallerVersionFile);
                if (File.Exists(installerUnityVersionFile) &&
                    (!File.Exists(installerVersionFile) ||
                     File.GetLastWriteTimeUtc(installerUnityVersionFile) > File.GetLastWriteTimeUtc(installerVersionFile)))
                {
                    return true;
                }

                var installerPackageFile = GetVersionFilePath(InstallerPackageFile);
                if (!File.Exists(installerPackageFile)) return false;

                var trackingFile = GetNewestTrackingFilePath();
                return string.IsNullOrEmpty(trackingFile) ||
                       File.GetLastWriteTimeUtc(installerPackageFile) > File.GetLastWriteTimeUtc(trackingFile);
            }
        }

        public static bool InstallerPackageMatchesCurrentUnityVersion
        {
            get
            {
                var installerUnityVersion = GetInstallerUnityVersion();
                return string.IsNullOrEmpty(installerUnityVersion) || installerUnityVersion == CurrentUnityVersion;
            }
        }

        public static bool InstallerBuildIsOlder => VersionParser.IsNewer(InstalledVersion, InstallerVersion);

        private static bool ShowUnityVersionInVersionLabels =>
            !string.IsNullOrEmpty(InstalledUnityVersion) &&
            (InstalledUnityVersionMismatch || GetInstallerUnityVersion() != InstalledUnityVersion);

        public static string UnityVersionMismatchMessage =>
            $"PlayMaker was installed for {InstalledUnityVersion}, but this project is now using {CurrentUnityVersion}.\n\n" +
            "Please import PlayMaker again for this Unity version. " +
            "\n\nFrom Asset Store: In Unity Package Manager, select PlayMaker 2 under Packages - Asset Store and download/re-import it." +
            "\n\nFrom Hutong Games: Import the PlayMaker unitypackage for this Unity version." +
            "\n\nAfter the package imports, run the PlayMaker installer.";

        private static string LastInstallerVersion { get; set; }

        static InstallInfo() => UpdateInfo();

        public static bool IsPlayMakerInstalled() => HasImportedPlayMaker() && !string.IsNullOrEmpty(InstalledVersion);
        
        public static void RecordInstallerWasOpened()
        {
            LastInstallerVersion = InstallerVersion;
            WriteInstallerVersionFile();
        }

        public static void RecordInstallerPackageImported()
        {
            var installerUnityVersion = GetInstallerUnityVersion();
            if (string.IsNullOrEmpty(installerUnityVersion)) return;

            var installerUnityVersionFile = GetVersionFilePath(InstallerUnityVersionFile);
            Directory.CreateDirectory(Path.GetDirectoryName(installerUnityVersionFile) ?? "");
            File.WriteAllText(installerUnityVersionFile, installerUnityVersion);
        }
        
        public static void UpdateInfo()
        {
            InstalledVersion = string.Empty;
            InstalledUnityVersion = string.Empty;
            LastInstallerVersion = string.Empty;

            var installedVersionFile = GetVersionFilePath(InstalledVersionFile);
            var installedUnityVersionFile = GetVersionFilePath(InstalledUnityVersionFile);
            var installerVersionFile = GetVersionFilePath(InstallerVersionFile);

            LastInstallerVersion = ReadVersionFile(installerVersionFile);

            if (!HasImportedPlayMaker())
            {
                DeleteVersionFile(installedVersionFile);
                DeleteVersionFile(installedUnityVersionFile);
                return;
            }

            InstalledVersion = ReadVersionFile(installedVersionFile);
            InstalledUnityVersion = GetUnityCompatibilityVersion(ReadVersionFile(installedUnityVersionFile));
        }
        
        private static void WriteInstallerVersionFile()
        {
            var installerVersionFile = GetVersionFilePath(InstallerVersionFile);
            Directory.CreateDirectory(Path.GetDirectoryName(installerVersionFile) ?? "");
            File.WriteAllText(installerVersionFile, InstallerVersion);
        }

        private static bool HasImportedPlayMaker() =>
            // We can't just check if the package exists here
            // because the importer is imported by importing the package!
            // Instead, we check if the Runtime directory exists,
            // which is only true after the installer has imported PlayMaker.
            PackageHelpers.DoesPackageDirectoryExist("com.hutonggames.playmaker", "Runtime");

        private static string GetUnityCompatibilityVersion()
        {
#if UNITY_6000_5_OR_NEWER
            return "Unity 6.5+";
#elif UNITY_6000_4_OR_NEWER
            return "Unity 6.4";
#elif UNITY_6000_0_OR_NEWER
            return "Unity 6.0-6.3";
#else
            return "Unity 2022.3";
#endif
        }

        private static string GetUnityCompatibilityVersion(string unityVersion)
        {
            if (string.IsNullOrEmpty(unityVersion)) return string.Empty;

            var version = unityVersion.Trim();
            if (version.StartsWith("Unity "))
            {
                version = version.Substring("Unity ".Length).Trim();
            }

            var parts = version.Split('.');
            if (parts.Length < 2 ||
                !int.TryParse(parts[0], out var major) ||
                !int.TryParse(parts[1], out var minor))
            {
                return unityVersion.Trim();
            }

            if (major == 6000)
            {
                if (minor >= 5) return "Unity 6.5+";
                if (minor == 4) return "Unity 6.4";
                return "Unity 6.0-6.3";
            }

            if (major == 6)
            {
                if (minor >= 5) return "Unity 6.5+";
                if (minor == 4) return "Unity 6.4";
                return "Unity 6.0-6.3";
            }

            if (major == 2022 && minor == 3)
            {
                return "Unity 2022.3";
            }

            return $"Unity {major}.{minor}";
        }

        private static string GetInstallerUnityVersion()
        {
            var assetVersion = GetUnityCompatibilityVersion(ReadVersionFile(GetVersionFilePath(InstallerUnityVersionAssetFile)));
            if (!string.IsNullOrEmpty(assetVersion)) return assetVersion;

            var recordedVersion = GetUnityCompatibilityVersion(ReadVersionFile(GetVersionFilePath(InstallerUnityVersionFile)));
            return recordedVersion;
        }

        private static string FormatVersionDisplay(string version, string unityVersion) =>
            string.IsNullOrEmpty(unityVersion) ? version : $"{version} ({unityVersion})";

        private static string GetVersionFilePath(string relativePath) =>
            Path.GetFullPath(Path.Combine(Application.dataPath, relativePath));

        private static string GetNewestTrackingFilePath()
        {
            string newestFile = null;
            var newestTime = System.DateTime.MinValue;

            foreach (var filePath in new[]
                     {
                         GetVersionFilePath(InstallerVersionFile),
                         GetVersionFilePath(InstallerUnityVersionFile),
                         GetVersionFilePath(InstalledUnityVersionFile),
                         GetVersionFilePath(InstalledVersionFile)
                     })
            {
                if (!File.Exists(filePath)) continue;

                var writeTime = File.GetLastWriteTimeUtc(filePath);
                if (writeTime <= newestTime) continue;

                newestFile = filePath;
                newestTime = writeTime;
            }

            return newestFile;
        }

        private static string ReadVersionFile(string filePath) =>
            File.Exists(filePath) ? File.ReadAllText(filePath).Trim() : string.Empty;

        private static void DeleteVersionFile(string filePath)
        {
            if (!File.Exists(filePath)) return;

            File.Delete(filePath);
        }
    }
}

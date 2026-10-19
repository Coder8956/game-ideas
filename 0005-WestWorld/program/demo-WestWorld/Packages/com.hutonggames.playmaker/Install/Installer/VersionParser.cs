using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Editor.Install
{
    /// <summary>
    /// Parses version info.
    /// </summary>
    /// <remarks>
    /// Duplicated in PlayMaker.Editor assembly.
    /// TODO: Make shared assembly for this and other common classes.
    /// </remarks>
    [PublicAPI]
    internal class VersionParser 
    {
        public enum BuildType {
            Unknown,
            Release,
            Beta,
            Patch
        }
        
        public static bool IsNewer(string version1, string version2)
        {
            if (version1 == version2) return false;
            var parser1 = new VersionParser(version1);
            var parser2 = new VersionParser(version2);
            if (parser1.GetNumericVersion() > parser2.GetNumericVersion())
                return true;
            // TODO: Account for p being newer than f and f being newer than b?
            if (parser1.GetNumericVersion() == parser2.GetNumericVersion())
                return parser1.VersionReleaseNumber > parser2.VersionReleaseNumber;
            return false;
        }
        
        public int VersionMajor { get; }
        public int VersionMinor { get; }
        public int VersionPatch { get; }
        public BuildType VersionBuildType { get; } = BuildType.Unknown;
        public int VersionReleaseNumber { get; } = -1;
        
        /// <summary>
        /// Parse a version string into its components.
        /// </summary>
        /// <remarks>
        /// NOTE: PlayMaker uses the same version format as Unity.
        /// </remarks>
        public VersionParser(string version) 
        {
            if (string.IsNullOrWhiteSpace(version))
            {
                // Leave version components at default values
                return;
            }
            
            var versionMatch = Regex.Match(version.Trim(), @"(\d+)\.(\d+)\.(\d+)([bpf])?(\d+)?");
            if (!versionMatch.Success)
            {
                // Leave version components at default values
                return;
            }

            VersionMajor = Convert.ToInt32(versionMatch.Groups[1].Value);
            VersionMinor = Convert.ToInt32(versionMatch.Groups[2].Value);
            VersionPatch = Convert.ToInt32(versionMatch.Groups[3].Value);
            if (versionMatch.Groups.Count <= 4) return;
           
            var versionBuildType = versionMatch.Groups[4].Value;
            VersionBuildType = versionBuildType switch
            {
                "f" => BuildType.Release,
                "p" => BuildType.Patch,
                "b" => BuildType.Beta,
                _ => BuildType.Unknown
            };

            if (versionMatch.Groups[5].Success)
            {
                VersionReleaseNumber = Convert.ToInt32(versionMatch.Groups[5].Value);
            }
        }
        
        public int GetNumericVersion() => VersionMajor * 100 + VersionMinor * 10 + VersionPatch;
    }
}

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Editor
{
    public static class UnityVersionCheck
    {
        public static bool IsMinimumUnityVersion(string minimumVersion)
        {
            // Get the current Unity version
            var currentVersion = Application.unityVersion;

            // Parse versions into comparable numbers
            var current = ParseUnityVersion(currentVersion);
            var minimum = ParseUnityVersion(minimumVersion);

            return current >= minimum;
        }

        public static bool IsUnityVersionInRange(string minVersion, string maxVersion)
        {
            var current = ParseUnityVersion(Application.unityVersion);
            var min = ParseUnityVersion(minVersion);
            var max = ParseUnityVersion(maxVersion);

            return current >= min && current <= max;
        }

        private static Version ParseUnityVersion(string versionString)
        {
            // Remove any 'f1', 'p1', etc. suffix
            var cleanVersion = System.Text.RegularExpressions.Regex.Replace(versionString, @"[a-zA-Z]\d*$", "");

            // Split the version string
            var parts = cleanVersion.Split('.');

            // Parse the components (major.minor.patch)
            var major = parts.Length > 0 ? int.Parse(parts[0]) : 0;
            var minor = parts.Length > 1 ? int.Parse(parts[1]) : 0;
            var patch = parts.Length > 2 ? int.Parse(parts[2]) : 0;

            return new Version(major, minor, patch);
        }
    }
}

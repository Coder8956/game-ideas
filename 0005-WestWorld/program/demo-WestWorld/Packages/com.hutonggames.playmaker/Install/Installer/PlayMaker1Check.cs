using UnityEditor;

namespace Install.Validation
{
    /// <summary>
    /// Class used to check if PlayMaker1 is present in a project.
    /// </summary>
    public static class PlayMaker1Check
    {
        // PlayMaker dll guids:
        private const string PlayMaker1Guid = "e743331561ef77147ae48cda9bcb8209";
        private const string PlayMaker1EditorGuid = "336aa50a81ce85b47b50a7b6adf85a76";

        /// <summary>
        /// Returns true if we find some evidence of PlayMaker1 in the project.
        /// </summary>
        public static bool Failed()
        {
            if (!string.IsNullOrEmpty(AssetDatabase.GUIDToAssetPath(PlayMaker1Guid))) return true;
            if (!string.IsNullOrEmpty(AssetDatabase.GUIDToAssetPath(PlayMaker1EditorGuid))) return true;
            // Other tests?
            return false;
        }
        
    }
}
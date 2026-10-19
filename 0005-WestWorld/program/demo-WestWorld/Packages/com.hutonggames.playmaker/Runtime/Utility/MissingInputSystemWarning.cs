#if ENABLE_INPUT_SYSTEM && !UNITY_INPUT_SYSTEM
using UnityEngine;

namespace HutongGames.PlayMaker.Samples
{
    /// <summary>
    /// Appears in scenes that require the Input System package.
    /// Logs a clear setup message if the package is missing.
    /// </summary>
    [DefaultExecutionOrder(-10000)]
    public sealed class MissingInputSystemWarning : MonoBehaviour
    {
        private void Awake()
        {
            Debug.LogError(
                "This PlayMaker sample requires Unity's Input System package.\n\n" +
                "The Input System backend is enabled, but the package is not installed.\n\n" +
                "Fix:\n" +
                "1) Open Window → Package Manager\n" +
                "2) Select 'Unity Registry'\n" +
                "3) Install 'Input System'\n" +
                "4) Restart Unity if prompted\n" +
                "5) Re-import the sample (very important)\n\n" +
                "Why re-import?\n" +
                "If the sample was saved while the package was missing, some actions " +
                "may have been serialized as missing types.",
                this);
        }
    }
}
#endif
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace HutongGames.PlayMaker
{
    /// <summary>
    /// Centralized helper for deciding whether input-driven actions
    /// should process input this frame.
    ///
    /// Why this exists:
    /// - In the Unity Editor, <see cref="Cursor.visible"/> and <see cref="Cursor.lockState"/>
    ///   are unreliable indicators of whether the user is actually controlling the GameView.
    ///   For example, Escape often shows the cursor without updating lock state,
    ///   and Unity reports values before the OS cursor lock is engaged.
    /// - This helper provides stable gating based on GameView focus and explicit
    ///   engagement/disengagement rules.
    ///
    /// Editor behavior:
    ///   - Optionally requires GameView focus.
    ///   - Escape can disengage input.
    ///   - Clicking inside the GameView can re-engage input.
    ///   - The caller stores editor engagement state using the <paramref name="editorEngaged"/> flag.
    ///
    /// Player behavior:
    ///   - Falls back to <see cref="Application.isFocused"/> (no editor-specific quirks).
    ///
    /// Usage:
    ///   if (!EditorInputGate.ShouldProcessInput(ref _editorEngaged)) { /* zero output */ return; }
    /// </summary>
    internal static class EditorInputGate
    {
#if UNITY_EDITOR
        private static bool IsGameViewFocused()
        {
            var window = EditorWindow.focusedWindow;
            return window != null && window.GetType().Name == "GameView";
        }
#endif

        /// <param name="editorEngaged">
        /// Editor-only: stateful flag tracking whether input is "armed".
        /// Ignored in player builds.
        /// </param>
        /// <param name="requireGameViewFocus">Only process input if GameView has focus</param>
        /// <param name="escapeDisengages">Escape disengages editor mode.</param>
        /// <param name="clickReengages">Clicking in GameView re-engages.</param>
        public static bool ShouldProcessInput(
            ref bool editorEngaged,
            bool requireGameViewFocus = true,
            bool escapeDisengages = true,
            bool clickReengages = true)
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
            {
                editorEngaged = false;
                return false;
            }

            if (requireGameViewFocus && !IsGameViewFocused())
            {
                editorEngaged = false;
                return false;
            }

            if (escapeDisengages && InputShim.GetKeyDown(KeyCode.Escape))
            {
                editorEngaged = false;
            }

            if (!editorEngaged && clickReengages && IsGameViewFocused() && InputShim.GetMouseButtonDown(0))
            {
                editorEngaged = true;
            }

            return editorEngaged;
#else
            // In builds, just require app focus.
            return Application.isFocused;
#endif
        }
    }
}
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Samples
{
    [Icon(Strings.EditorIconsPath+"PlayMakerUtilityIcon.png")]
    public class EnableCorrectInputModule : MonoBehaviour
    {
        private void Awake()
        {
            var eventSystem = GetComponent<EventSystem>();
            if (eventSystem == null) return;

            var standalone = GetComponent<StandaloneInputModule>();

#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM
            var inputSystem = GetComponent<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
#else
            // IMPORTANT: declare the variable WITHOUT the type
            // so the compiler never needs to resolve the Input System namespace.
            var inputSystem = (MonoBehaviour)null;
#endif

            // -------------------------
            // Case 1: Both modules exist AND enabled → FIX
            // -------------------------
            if (standalone != null && standalone.enabled &&
                inputSystem != null && inputSystem.enabled)
            {
#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
                // New Input System only → disable the legacy module
                standalone.enabled = false;
#else
                // Legacy or Both → disable the new module
                inputSystem.enabled = false;
#endif
            }

            // -------------------------
            // Case 2: Neither module exists/enabled → FIX
            // -------------------------
            if ((standalone == null || !standalone.enabled) &&
                (inputSystem == null || !inputSystem.enabled))
            {
#if ENABLE_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
                if (inputSystem != null) inputSystem.enabled = true;
#else
                if (standalone != null) standalone.enabled = true;
#endif
            }
        }
    }
}
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    internal static class InputActionBindingOverrideHelper
    {
        public static InputAction ResolveAction(InputActionReferenceVar inputAction)
        {
            return inputAction != null && inputAction.Value != null ? inputAction.Value.action : null;
        }

        public static int GetFirstRebindableBindingIndex(InputAction action)
        {
            if (action == null) return -1;

            for (var i = 0; i < action.bindings.Count; i++)
            {
                var binding = action.bindings[i];
                if (!binding.isComposite) return i;
            }

            return -1;
        }

        public static bool HasValidBindingIndex(InputAction action, int bindingIndex, UnityEngine.Object owner, string actionName)
        {
            if (action == null)
            {
                Debug.LogWarning($"{actionName}: No InputAction assigned.", owner);
                return false;
            }

            if (bindingIndex >= 0 && bindingIndex < action.bindings.Count) return true;

            Debug.LogWarning($"{actionName}: Binding index {bindingIndex} is out of range.", owner);
            return false;
        }

        public static InputBinding.DisplayStringOptions GetDisplayStringOptions(bool dontUseShortDisplayNames, bool ignoreBindingOverrides)
        {
            var options = default(InputBinding.DisplayStringOptions);

            if (dontUseShortDisplayNames)
            {
                options |= InputBinding.DisplayStringOptions.DontUseShortDisplayNames;
            }

            if (ignoreBindingOverrides)
            {
                options |= InputBinding.DisplayStringOptions.IgnoreBindingOverrides;
            }

            return options;
        }

        public static bool MatchesText(string value, string pattern)
        {
            return string.IsNullOrEmpty(pattern) || string.Equals(value, pattern, StringComparison.OrdinalIgnoreCase);
        }
    }
}

#endif

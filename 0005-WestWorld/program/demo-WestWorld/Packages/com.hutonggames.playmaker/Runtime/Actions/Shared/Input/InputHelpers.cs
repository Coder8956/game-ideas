// NOTE: The new Input System and legacy Input Manager can both be enabled in a project.

#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM && !ENABLE_LEGACY_INPUT_MANAGER
#define NEW_INPUT_SYSTEM_ONLY
#endif

#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

using System;
using UnityEngine;

namespace HutongGames.PlayMaker
{
    /// <summary>
    /// Helpers to deal with different input systems.
    /// </summary>
    [Obsolete("Use InputShim instead")]
    public static class InputHelpers 
    {
        [Obsolete("Use InputShim.AnyKey instead.")]
        public static bool AnyKey()
        {
#if NEW_INPUT_SYSTEM_ONLY
            return Keyboard.current.anyKey.isPressed ||
                   Mouse.current.leftButton.isPressed ||
                   Mouse.current.rightButton.isPressed ||
                   Mouse.current.middleButton.isPressed;
#else
            return Input.anyKey;
#endif
        }
        
        [Obsolete("Use InputShim.AnyKeyDown instead.")]
        public static bool AnyKeyDown()
        {
#if NEW_INPUT_SYSTEM_ONLY
            return Keyboard.current.anyKey.isPressed ||
                   Mouse.current.leftButton.isPressed ||
                   Mouse.current.rightButton.isPressed ||
                   Mouse.current.middleButton.isPressed;
#else
            return Input.anyKeyDown;
#endif
        }

        [Obsolete("Use InputShim.MouseButtonDown instead.")]
        public static bool MouseButtonDown(int button)
        {
#if NEW_INPUT_SYSTEM_ONLY
            if (button == 0) return Mouse.current.leftButton.isPressed;
            if (button == 1) return Mouse.current.rightButton.isPressed;
            if (button == 2) return Mouse.current.middleButton.isPressed;
            return false;
#else
            return Input.GetMouseButton(button);
#endif
        }

        [Obsolete("Use InputShim.GetMousePosition instead.")]
        public static Vector3 MousePosition()
        {
#if NEW_INPUT_SYSTEM_ONLY
            var pos = Mouse.current.position.ReadValue();
            return new Vector3(pos.x, pos.y, 0);
#else
            return Input.mousePosition;
#endif
        }
    }

}


// InputShim.cs
//
// Drop-in helper for PlayMaker2 input actions.
// Wraps both the old Input Manager (UnityEngine.Input) and the new
// Input System (UnityEngine.InputSystem) behind a single static API.
//
// Features:
// - Keyboard: GetKey / GetKeyDown / GetKeyUp
// - Mouse buttons: GetMouseButton / GetMouseButtonDown / GetMouseButtonUp
// - Mouse: GetMousePosition / GetMouseDelta / GetScrollDelta
// - "Any" helpers: AnyKey / AnyKeyDown / AnyButton / AnyButtonDown / AnyInput / AnyInputDown
// - Axes: GetAxis / GetAxisRaw with classic names:
//      "Horizontal", "Vertical", "Mouse X", "Mouse Y", "Mouse ScrollWheel"
//
// Backend selection:
// - Prefers new Input System if it is both enabled (Player Settings) AND installed (package present).
// - Falls back to legacy Input Manager if only ENABLE_LEGACY_INPUT_MANAGER is defined.
// - If neither is available, Backend == None and all methods return neutral values.
//
// To use in actions, call InputShim.* instead of UnityEngine.Input.*
//
// Example:
//   if (InputShim.GetKeyDown(KeyCode.Space)) { ... }
//
// If you later drop 2022.3 / legacy support, you can delete the legacy
// regions (#if PM_LEGACYINPUT) and leave the public API intact.

// -----------------------------------------------------------------------------
// Local capability defines
// -----------------------------------------------------------------------------

// Input System is usable only when BOTH are true:
// - Player Settings backend enabled: ENABLE_INPUT_SYSTEM
// - Package installed: UNITY_INPUT_SYSTEM (asmdef versionDefine)
#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM
#define PM_INPUTSYSTEM
#endif

// Legacy Input Manager usable when Player Settings backend enabled
#if ENABLE_LEGACY_INPUT_MANAGER
#define PM_LEGACYINPUT
#endif

#if PM_INPUTSYSTEM
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
#endif

using UnityEngine;

namespace HutongGames.PlayMaker
{
#if UNITY_6000_5_OR_NEWER
    [Unity.Scripting.LifecycleManagement.NoAutoStaticsCleanup]
#endif
    public static class InputShim
    {
        public enum InputBackend
        {
            Auto = 0,
            UnityInputManager = 1,
            UnityInputSystem = 2,
            None = 3
        }

        private static bool _initialized;
        private static InputBackend _backend;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetStatics()
        {
            _initialized = false;
            _backend = InputBackend.Auto;
#if PM_INPUTSYSTEM
            _horizontalSmooth = 0f;
            _verticalSmooth = 0f;
            _mouseDeltaSmooth = Vector2.zero;
#endif
        }

        // ---------------------------------------------------------------------
        // Backend selection
        // ---------------------------------------------------------------------

        public static InputBackend Backend
        {
            get
            {
                if (!_initialized)
                    Initialize();
                return _backend;
            }
        }

        /// <summary>
        /// Force initialization early if you want (optional).
        /// Otherwise it's done on first access.
        /// </summary>
        public static void Initialize()
        {
            if (_initialized) return;
            _initialized = true;

#if PM_INPUTSYSTEM
            _backend = InputBackend.UnityInputSystem;

#elif PM_LEGACYINPUT
            _backend = InputBackend.UnityInputManager;

#elif ENABLE_INPUT_SYSTEM && !UNITY_INPUT_SYSTEM
            _backend = InputBackend.None;
            Debug.LogWarning(
                "[PlayMaker2] Input System is enabled in Player Settings, but the Input System package " +
                "(com.unity.inputsystem) is not installed. Install it via Window → Package Manager, then restart Unity.");

#else
            _backend = InputBackend.None;
            Debug.LogWarning(
                "[PlayMaker2] No input backend enabled. Enable Input System or Input Manager in Player Settings.");
#endif
        }

        // ---------------------------------------------------------------------
        // Keyboard
        // ---------------------------------------------------------------------

        public static bool GetKey(KeyCode key)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetKey_InputSystem(key);
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.GetKey(key);
#endif
                default:
                    return false;
            }
        }

        public static bool GetKeyDown(KeyCode key)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetKeyDown_InputSystem(key);
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.GetKeyDown(key);
#endif
                default:
                    return false;
            }
        }

        public static bool GetKeyUp(KeyCode key)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetKeyUp_InputSystem(key);
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.GetKeyUp(key);
#endif
                default:
                    return false;
            }
        }

        // ---------------------------------------------------------------------
        // Mouse buttons
        // ---------------------------------------------------------------------

        public static bool GetMouseButton(int button)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetMouseButton_InputSystem(button);
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.GetMouseButton(button);
#endif
                default:
                    return false;
            }
        }

        public static bool GetMouseButtonDown(int button)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetMouseButtonDown_InputSystem(button);
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.GetMouseButtonDown(button);
#endif
                default:
                    return false;
            }
        }

        public static bool GetMouseButtonUp(int button)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetMouseButtonUp_InputSystem(button);
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.GetMouseButtonUp(button);
#endif
                default:
                    return false;
            }
        }

        // ---------------------------------------------------------------------
        // Mouse position / delta / scroll
        // ---------------------------------------------------------------------

        public static Vector2 GetMousePosition()
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetMousePosition_InputSystem();
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.mousePosition;
#endif
                default:
                    return Vector2.zero;
            }
        }

        /// <summary>Mouse delta since last frame.</summary>
        public static Vector2 GetMouseDelta()
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetMouseDelta_InputSystem();
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return new Vector2(
                        Input.GetAxisRaw("Mouse X"),
                        Input.GetAxisRaw("Mouse Y"));
#endif
                default:
                    return Vector2.zero;
            }
        }

        /// <summary>Scroll wheel. Y is usually the interesting axis.</summary>
        public static Vector2 GetScrollDelta()
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetScrollDelta_InputSystem();
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return new Vector2(
                        0f, Input.GetAxisRaw("Mouse ScrollWheel"));
#endif
                default:
                    return Vector2.zero;
            }
        }

        // ---------------------------------------------------------------------
        // Any Key / Button / Input
        // ---------------------------------------------------------------------

        /// <summary>True if ANY keyboard key is currently held.</summary>
        public static bool AnyKey()
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return AnyKey_InputSystem();
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.anyKey;
#endif
                default:
                    return false;
            }
        }

        /// <summary>True if ANY keyboard key was pressed this frame.</summary>
        public static bool AnyKeyDown()
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return AnyKeyDown_InputSystem();
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.anyKeyDown;
#endif
                default:
                    return false;
            }
        }

        /// <summary>True if ANY mouse or gamepad button is currently held.</summary>
        public static bool AnyButton()
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return AnyButton_InputSystem();
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return AnyMouseButton_Legacy() || AnyJoystickButton_Legacy();
#endif
                default:
                    return false;
            }
        }

        /// <summary>True if ANY mouse or gamepad button was pressed this frame.</summary>
        public static bool AnyButtonDown()
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return AnyButtonDown_InputSystem();
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return AnyMouseButtonDown_Legacy() || AnyJoystickButtonDown_Legacy();
#endif
                default:
                    return false;
            }
        }

        /// <summary>True if ANY touch is currently held.</summary>
        public static bool AnyTouch()
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return AnyTouch_InputSystem();
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return Input.touchCount > 0;
#endif
                default:
                    return false;
            }
        }

        /// <summary>True if ANY touch started this frame.</summary>
        public static bool AnyTouchDown()
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return AnyTouchDown_InputSystem();
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return AnyTouchDown_Legacy();
#endif
                default:
                    return false;
            }
        }

        /// <summary>True if ANY keyboard key OR mouse/gamepad button OR touch is currently held.</summary>
        public static bool AnyInput()
        {
            return AnyKey() || AnyButton() || AnyTouch();
        }

        /// <summary>True if ANY keyboard key OR mouse/gamepad button OR touch started this frame.</summary>
        public static bool AnyInputDown()
        {
            return AnyKeyDown() || AnyButtonDown() || AnyTouchDown();
        }

        // ---------------------------------------------------------------------
        // Axes (classic names)
        // ---------------------------------------------------------------------

        /// <summary>
        /// Get an axis value by name ("Horizontal", "Vertical", "Mouse X", "Mouse Y", "Mouse ScrollWheel").
        /// On legacy Input Manager, this forwards to Input.GetAxis/GetAxisRaw.
        /// On the Input System backend, it synthesizes these axes from devices.
        /// </summary>
        public static float GetAxis(string axisName, bool raw = false)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetAxis_InputSystem(axisName, raw);
#endif
#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return raw
                        ? Input.GetAxisRaw(axisName)
                        : Input.GetAxis(axisName);
#endif
                default:
                    return 0f;
            }
        }

        public static float GetAxisRaw(string axisName)
        {
            return GetAxis(axisName, raw: true);
        }

        /// <summary>
        /// Resets internal axis smoothing values used by the InputShim.
        /// This mimics the useful parts of Input.ResetInputAxes() for the new Input System.
        /// </summary>
        public static void ResetInputAxes()
        {
#if PM_INPUTSYSTEM
            _horizontalSmooth = 0f;
            _verticalSmooth = 0f;
            _mouseDeltaSmooth = Vector2.zero;
#endif

#if PM_LEGACYINPUT
            Input.ResetInputAxes();
#endif
        }

        // ---------------------------------------------------------------------
        // Named Buttons (Fire1, Jump, etc.)
        // ---------------------------------------------------------------------

        /// <summary>
        /// Returns true while the virtual button identified by <paramref name="name"/> is held down.
        /// For the legacy Input Manager this forwards to Input.GetButton.
        /// For the new Input System, a small set of common names are supported:
        /// "Fire1", "Fire2", "Fire3", "Jump", "Submit", "Cancel".
        /// </summary>
        public static bool GetButton(string name)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetButton_InputSystem(name);
#endif

#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return UnityEngine.Input.GetButton(name);
#endif

                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns true during the frame the virtual button identified by <paramref name="name"/> is pressed.
        /// </summary>
        public static bool GetButtonDown(string name)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetButtonDown_InputSystem(name);
#endif

#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return UnityEngine.Input.GetButtonDown(name);
#endif

                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns true during the frame the virtual button identified by <paramref name="name"/> is released.
        /// </summary>
        public static bool GetButtonUp(string name)
        {
            switch (Backend)
            {
#if PM_INPUTSYSTEM
                case InputBackend.UnityInputSystem:
                    return GetButtonUp_InputSystem(name);
#endif

#if PM_LEGACYINPUT
                case InputBackend.UnityInputManager:
                    return UnityEngine.Input.GetButtonUp(name);
#endif

                default:
                    return false;
            }
        }

        // ---------------------------------------------------------------------
        // NEW INPUT SYSTEM IMPLEMENTATIONS
        // ---------------------------------------------------------------------

#if PM_INPUTSYSTEM

        private static bool GetKey_InputSystem(KeyCode keyCode)
        {
            var keyControl = GetKeyControl(keyCode);
            return keyControl is { isPressed: true };
        }

        private static bool GetKeyDown_InputSystem(KeyCode keyCode)
        {
            var keyControl = GetKeyControl(keyCode);
            return keyControl is { wasPressedThisFrame: true };
        }

        private static bool GetKeyUp_InputSystem(KeyCode keyCode)
        {
            var keyControl = GetKeyControl(keyCode);
            return keyControl is { wasReleasedThisFrame: true };
        }

        private static bool GetMouseButton_InputSystem(int button)
        {
            var mouse = Mouse.current;
            if (mouse == null) return false;

            return button switch
            {
                0 => mouse.leftButton.isPressed,
                1 => mouse.rightButton.isPressed,
                2 => mouse.middleButton.isPressed,
                3 => mouse.forwardButton != null && mouse.forwardButton.isPressed,
                4 => mouse.backButton != null && mouse.backButton.isPressed,
                _ => false
            };
        }

        private static bool GetMouseButtonDown_InputSystem(int button)
        {
            var mouse = Mouse.current;
            if (mouse == null) return false;

            return button switch
            {
                0 => mouse.leftButton.wasPressedThisFrame,
                1 => mouse.rightButton.wasPressedThisFrame,
                2 => mouse.middleButton.wasPressedThisFrame,
                3 => mouse.forwardButton != null && mouse.forwardButton.wasPressedThisFrame,
                4 => mouse.backButton != null && mouse.backButton.wasPressedThisFrame,
                _ => false
            };
        }

        private static bool GetMouseButtonUp_InputSystem(int button)
        {
            var mouse = Mouse.current;
            if (mouse == null) return false;

            return button switch
            {
                0 => mouse.leftButton.wasReleasedThisFrame,
                1 => mouse.rightButton.wasReleasedThisFrame,
                2 => mouse.middleButton.wasReleasedThisFrame,
                3 => mouse.forwardButton != null && mouse.forwardButton.wasReleasedThisFrame,
                4 => mouse.backButton != null && mouse.backButton.wasReleasedThisFrame,
                _ => false
            };
        }

        private static Vector2 GetMousePosition_InputSystem()
        {
            var mouse = Mouse.current;
            return mouse?.position.ReadValue() ?? Vector2.zero;
        }

        private static Vector2 GetMouseDelta_InputSystem()
        {
            var mouse = Mouse.current;
            // Raw delta is in pixels per frame and much "hotter" than the old axes.
            // Scale it down to better match Input.GetAxis("Mouse X/Y").
            const float scale = 0.05f; // tweak if needed
            return (mouse?.delta.ReadValue() ?? Vector2.zero) * scale;
        }

        private static Vector2 GetScrollDelta_InputSystem()
        {
            var mouse = Mouse.current;
            return mouse?.scroll.ReadValue() ?? Vector2.zero;
        }

        // --- AnyKey / AnyButton for Input System ---

        private static bool AnyKey_InputSystem()
        {
            var keyboard = Keyboard.current;
            if (keyboard != null)
            {
                var keys = keyboard.allKeys;
                var count = keys.Count;

                for (int i = 0; i < count; i++)
                {
                    var key = keys[i];
                    if (key != null && key.isPressed)
                        return true;
                }
            }

            var mouse = Mouse.current;
            if (mouse != null)
            {
                if ((mouse.leftButton != null && mouse.leftButton.isPressed) ||
                    (mouse.rightButton != null && mouse.rightButton.isPressed) ||
                    (mouse.middleButton != null && mouse.middleButton.isPressed))
                    return true;
            }

            return false;
        }

        private static bool AnyKeyDown_InputSystem()
        {
            var keyboard = Keyboard.current;
            if (keyboard != null)
            {
                var keys = keyboard.allKeys;
                var count = keys.Count;

                for (int i = 0; i < count; i++)
                {
                    var key = keys[i];
                    if (key != null && key.wasPressedThisFrame)
                        return true;
                }
            }

            // You can also include mouse/gamepad if you treat those as "any key":
            var mouse = Mouse.current;
            if (mouse != null)
            {
                if ((mouse.leftButton != null && mouse.leftButton.wasPressedThisFrame) ||
                    (mouse.rightButton != null && mouse.rightButton.wasPressedThisFrame) ||
                    (mouse.middleButton != null && mouse.middleButton.wasPressedThisFrame))
                    return true;
            }

            // Add gamepad/etc. here if you want them to count as "any key"

            return false;
        }

        private static bool AnyButton_InputSystem()
        {
            // Mouse
            var mouse = Mouse.current;
            if (mouse != null)
            {
                if (mouse.leftButton.isPressed ||
                    mouse.rightButton.isPressed ||
                    mouse.middleButton.isPressed ||
                    (mouse.forwardButton != null && mouse.forwardButton.isPressed) ||
                    (mouse.backButton != null && mouse.backButton.isPressed))
                {
                    return true;
                }
            }

            // Gamepads
            var gamepads = Gamepad.all;
            for (int i = 0; i < gamepads.Count; i++)
            {
                var pad = gamepads[i];
                if (pad == null) continue;

                var controls = pad.allControls;
                for (int j = 0; j < controls.Count; j++)
                {
                    if (controls[j] is ButtonControl button && button.isPressed)
                        return true;
                }
            }

            return false;
        }

        private static bool AnyButtonDown_InputSystem()
        {
            // Mouse
            var mouse = Mouse.current;
            if (mouse != null)
            {
                if (mouse.leftButton.wasPressedThisFrame ||
                    mouse.rightButton.wasPressedThisFrame ||
                    mouse.middleButton.wasPressedThisFrame ||
                    (mouse.forwardButton != null && mouse.forwardButton.wasPressedThisFrame) ||
                    (mouse.backButton != null && mouse.backButton.wasPressedThisFrame))
                {
                    return true;
                }
            }

            // Gamepads
            var gamepads = Gamepad.all;
            for (int i = 0; i < gamepads.Count; i++)
            {
                var pad = gamepads[i];
                if (pad == null) continue;

                var controls = pad.allControls;
                for (int j = 0; j < controls.Count; j++)
                {
                    if (controls[j] is ButtonControl button && button.wasPressedThisFrame)
                        return true;
                }
            }

            return false;
        }

        private static bool AnyTouch_InputSystem()
        {
            var touchscreen = Touchscreen.current;
            return touchscreen != null && touchscreen.primaryTouch.press.isPressed;
        }

        private static bool AnyTouchDown_InputSystem()
        {
            var touchscreen = Touchscreen.current;
            return touchscreen != null && touchscreen.primaryTouch.press.wasPressedThisFrame;
        }

        // --- Axes for Input System backend ---

        private static float _horizontalSmooth;
        private static float _verticalSmooth;
        private static Vector2 _mouseDeltaSmooth;

        private const float AxisSensitivity = 10f; // tweak to taste
        private const float AxisGravity = 20f;     // how quickly it returns to 0

        private static float GetAxis_InputSystem(string axisName, bool raw)
        {
            switch (axisName)
            {
                case "Horizontal":
                    return GetAxis_Horizontal_InputSystem(raw);

                case "Vertical":
                    return GetAxis_Vertical_InputSystem(raw);

                case "Mouse X":
                    return GetAxis_MouseX_InputSystem(raw);

                case "Mouse Y":
                    return GetAxis_MouseY_InputSystem(raw);

                case "Mouse ScrollWheel":
                    return GetAxis_MouseScroll_InputSystem(raw);

                default:
                    // Unknown axis name for Input System backend; return 0.
                    return 0f;
            }
        }

        private static float GetAxis_Horizontal_InputSystem(bool raw)
        {
            float rawValue = GetRaw_Horizontal_InputSystem();

            if (raw)
                return rawValue;

            _horizontalSmooth = MoveAxisToward(_horizontalSmooth, rawValue);
            return _horizontalSmooth;
        }

        private static float GetAxis_Vertical_InputSystem(bool raw)
        {
            float rawValue = GetRaw_Vertical_InputSystem();

            if (raw)
                return rawValue;

            _verticalSmooth = MoveAxisToward(_verticalSmooth, rawValue);
            return _verticalSmooth;
        }

        private static float MoveAxisToward(float current, float target)
        {
            float dt = Time.unscaledDeltaTime;

            if (Mathf.Approximately(target, 0f))
            {
                // Decay towards 0 (Gravity)
                float sign = Mathf.Sign(current);
                float magnitude = Mathf.Max(0f, Mathf.Abs(current) - AxisGravity * dt);
                return magnitude * sign;
            }

            // Move towards target (Sensitivity)
            return Mathf.MoveTowards(current, target, AxisSensitivity * dt);
        }

        private static float GetRaw_Horizontal_InputSystem()
        {
            float value = 0f;

            var keyboard = Keyboard.current;
            if (keyboard != null)
            {
                if (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed)
                    value -= 1f;
                if (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed)
                    value += 1f;
            }

            var gamepad = Gamepad.current;
            if (gamepad != null)
            {
                float stick = gamepad.leftStick.x.ReadValue();
                float dpad = gamepad.dpad.x.ReadValue();
                value += stick + dpad;
            }

            return Mathf.Clamp(value, -1f, 1f);
        }

        private static float GetRaw_Vertical_InputSystem()
        {
            float value = 0f;

            var keyboard = Keyboard.current;
            if (keyboard != null)
            {
                if (keyboard.downArrowKey.isPressed || keyboard.sKey.isPressed)
                    value -= 1f;
                if (keyboard.upArrowKey.isPressed || keyboard.wKey.isPressed)
                    value += 1f;
            }

            var gamepad = Gamepad.current;
            if (gamepad != null)
            {
                float stick = gamepad.leftStick.y.ReadValue();
                float dpad = gamepad.dpad.y.ReadValue();
                value += stick + dpad;
            }

            return Mathf.Clamp(value, -1f, 1f);
        }

        private static float GetAxis_MouseX_InputSystem(bool raw)
        {
            var mouse = Mouse.current;
            if (mouse == null)
                return 0f;

            var rawDelta = mouse.delta.ReadValue().x;

            if (raw)
                return rawDelta;

            _mouseDeltaSmooth.x = Mathf.Lerp(_mouseDeltaSmooth.x, rawDelta, 0.5f);
            return _mouseDeltaSmooth.x;
        }

        private static float GetAxis_MouseY_InputSystem(bool raw)
        {
            var mouse = Mouse.current;
            if (mouse == null)
                return 0f;

            var rawDelta = mouse.delta.ReadValue().y;

            if (raw)
                return rawDelta;

            _mouseDeltaSmooth.y = Mathf.Lerp(_mouseDeltaSmooth.y, rawDelta, 0.5f);
            return _mouseDeltaSmooth.y;
        }

        private static float GetAxis_MouseScroll_InputSystem(bool raw)
        {
            var mouse = Mouse.current;
            if (mouse == null)
                return 0f;

            var scroll = mouse.scroll.ReadValue().y;
            // Legacy "Mouse ScrollWheel" is already fairly raw; treat both the same.
            return scroll;
        }

        // --- KeyCode -> Key mapping for Input System ---

        private static KeyControl GetKeyControl(KeyCode keyCode)
        {
            var keyboard = Keyboard.current;
            if (keyboard == null)
                return null;

            var key = MapKeyCodeToKey(keyCode);
            if (!key.HasValue)
                return null;

            return keyboard[key.Value];
        }

        private static Key? MapKeyCodeToKey(KeyCode code)
        {
            switch (code)
            {
                // None / fallback
                case KeyCode.None: return Key.None;

                // Basic control keys
                case KeyCode.Backspace: return Key.Backspace;
                case KeyCode.Delete: return Key.Delete;
                case KeyCode.Tab: return Key.Tab;
                case KeyCode.Return: return Key.Enter;
                case KeyCode.KeypadEnter: return Key.NumpadEnter;
                case KeyCode.Escape: return Key.Escape;
                case KeyCode.Space: return Key.Space;
                case KeyCode.Pause: return Key.Pause;

                // Arrows
                case KeyCode.UpArrow: return Key.UpArrow;
                case KeyCode.DownArrow: return Key.DownArrow;
                case KeyCode.LeftArrow: return Key.LeftArrow;
                case KeyCode.RightArrow: return Key.RightArrow;

                // Navigation / editing
                case KeyCode.Insert: return Key.Insert;
                case KeyCode.Home: return Key.Home;
                case KeyCode.End: return Key.End;
                case KeyCode.PageUp: return Key.PageUp;
                case KeyCode.PageDown: return Key.PageDown;

                // Function keys
                case KeyCode.F1: return Key.F1;
                case KeyCode.F2: return Key.F2;
                case KeyCode.F3: return Key.F3;
                case KeyCode.F4: return Key.F4;
                case KeyCode.F5: return Key.F5;
                case KeyCode.F6: return Key.F6;
                case KeyCode.F7: return Key.F7;
                case KeyCode.F8: return Key.F8;
                case KeyCode.F9: return Key.F9;
                case KeyCode.F10: return Key.F10;
                case KeyCode.F11: return Key.F11;
                case KeyCode.F12: return Key.F12;
#if UNITY_INPUT_SYSTEM_1_14_0_OR_NEWER
                case KeyCode.F13: return Key.F13;
                case KeyCode.F14: return Key.F14;
                case KeyCode.F15: return Key.F15;
                case KeyCode.F16: return Key.F16;
                case KeyCode.F17: return Key.F17;
                case KeyCode.F18: return Key.F18;
                case KeyCode.F19: return Key.F19;
                case KeyCode.F20: return Key.F20;
                case KeyCode.F21: return Key.F21;
                case KeyCode.F22: return Key.F22;
                case KeyCode.F23: return Key.F23;
                case KeyCode.F24: return Key.F24;
#endif

                // Top-row digits
                case KeyCode.Alpha0: return Key.Digit0;
                case KeyCode.Alpha1: return Key.Digit1;
                case KeyCode.Alpha2: return Key.Digit2;
                case KeyCode.Alpha3: return Key.Digit3;
                case KeyCode.Alpha4: return Key.Digit4;
                case KeyCode.Alpha5: return Key.Digit5;
                case KeyCode.Alpha6: return Key.Digit6;
                case KeyCode.Alpha7: return Key.Digit7;
                case KeyCode.Alpha8: return Key.Digit8;
                case KeyCode.Alpha9: return Key.Digit9;

                // Symbol KeyCodes -> map to physical keys
                case KeyCode.Exclaim: return Key.Digit1;
                case KeyCode.DoubleQuote: return Key.Quote;
                case KeyCode.Hash: return Key.Digit3;
                case KeyCode.Dollar: return Key.Digit4;
                case KeyCode.Percent: return Key.Digit5;
                case KeyCode.Ampersand: return Key.Digit7;
                case KeyCode.LeftParen: return Key.Digit9;
                case KeyCode.RightParen: return Key.Digit0;
                case KeyCode.Asterisk: return Key.Digit8;
                case KeyCode.Plus: return Key.Equals;
                case KeyCode.Colon: return Key.Semicolon;
                case KeyCode.Less: return Key.Comma;
                case KeyCode.Greater: return Key.Period;
                case KeyCode.Question: return Key.Slash;
                case KeyCode.At: return Key.Digit2;
                case KeyCode.Caret: return Key.Digit6;
                case KeyCode.Underscore: return Key.Minus;

                // Punctuation keys (physical)
                case KeyCode.Comma: return Key.Comma;
                case KeyCode.Minus: return Key.Minus;
                case KeyCode.Period: return Key.Period;
                case KeyCode.Slash: return Key.Slash;
                case KeyCode.Semicolon: return Key.Semicolon;
                case KeyCode.Equals: return Key.Equals;
                case KeyCode.LeftBracket: return Key.LeftBracket;
                case KeyCode.Backslash: return Key.Backslash;
                case KeyCode.RightBracket: return Key.RightBracket;
                case KeyCode.Quote: return Key.Quote;
                case KeyCode.BackQuote: return Key.Backquote;

                // Extended punctuation
                case KeyCode.LeftCurlyBracket: return Key.LeftBracket;
                case KeyCode.RightCurlyBracket: return Key.RightBracket;
                case KeyCode.Pipe: return Key.Backslash;
                case KeyCode.Tilde: return Key.Backquote;

                // Letters A–Z
                case KeyCode.A: return Key.A;
                case KeyCode.B: return Key.B;
                case KeyCode.C: return Key.C;
                case KeyCode.D: return Key.D;
                case KeyCode.E: return Key.E;
                case KeyCode.F: return Key.F;
                case KeyCode.G: return Key.G;
                case KeyCode.H: return Key.H;
                case KeyCode.I: return Key.I;
                case KeyCode.J: return Key.J;
                case KeyCode.K: return Key.K;
                case KeyCode.L: return Key.L;
                case KeyCode.M: return Key.M;
                case KeyCode.N: return Key.N;
                case KeyCode.O: return Key.O;
                case KeyCode.P: return Key.P;
                case KeyCode.Q: return Key.Q;
                case KeyCode.R: return Key.R;
                case KeyCode.S: return Key.S;
                case KeyCode.T: return Key.T;
                case KeyCode.U: return Key.U;
                case KeyCode.V: return Key.V;
                case KeyCode.W: return Key.W;
                case KeyCode.X: return Key.X;
                case KeyCode.Y: return Key.Y;
                case KeyCode.Z: return Key.Z;

                // Lock keys
                case KeyCode.CapsLock: return Key.CapsLock;
                case KeyCode.Numlock: return Key.NumLock;
                case KeyCode.ScrollLock: return Key.ScrollLock;

                // Modifiers
                case KeyCode.LeftShift: return Key.LeftShift;
                case KeyCode.RightShift: return Key.RightShift;
                case KeyCode.LeftControl: return Key.LeftCtrl;
                case KeyCode.RightControl: return Key.RightCtrl;
                case KeyCode.LeftAlt: return Key.LeftAlt;
                case KeyCode.RightAlt: return Key.RightAlt;
                case KeyCode.AltGr: return Key.AltGr;

                // Meta / Windows / Command
                case KeyCode.LeftMeta: return Key.LeftMeta;
                case KeyCode.RightMeta: return Key.RightMeta;
                case KeyCode.LeftWindows: return Key.LeftWindows;
                case KeyCode.RightWindows: return Key.RightWindows;

                // Context / Print
                case KeyCode.Menu: return Key.ContextMenu;
                case KeyCode.Print: return Key.PrintScreen;
                case KeyCode.SysReq: return Key.PrintScreen;
                case KeyCode.Break: return Key.Pause;

                // Numpad digits and operators
                case KeyCode.Keypad0: return Key.Numpad0;
                case KeyCode.Keypad1: return Key.Numpad1;
                case KeyCode.Keypad2: return Key.Numpad2;
                case KeyCode.Keypad3: return Key.Numpad3;
                case KeyCode.Keypad4: return Key.Numpad4;
                case KeyCode.Keypad5: return Key.Numpad5;
                case KeyCode.Keypad6: return Key.Numpad6;
                case KeyCode.Keypad7: return Key.Numpad7;
                case KeyCode.Keypad8: return Key.Numpad8;
                case KeyCode.Keypad9: return Key.Numpad9;
                case KeyCode.KeypadPeriod: return Key.NumpadPeriod;
                case KeyCode.KeypadDivide: return Key.NumpadDivide;
                case KeyCode.KeypadMultiply: return Key.NumpadMultiply;
                case KeyCode.KeypadMinus: return Key.NumpadMinus;
                case KeyCode.KeypadPlus: return Key.NumpadPlus;
                case KeyCode.KeypadEquals: return Key.NumpadEquals;

                default:
                    // Mouse buttons, joystick buttons etc. don't map to Key
                    return null;
            }
        }

        // -----------------------------------------------------------------
        // Named Button support for Input System backend
        // -----------------------------------------------------------------
        //
        // NOTE: We only emulate Unity's *default* button names here.
        // Custom Input Manager button names cannot be mirrored automatically
        // without using InputActions, which the shim intentionally avoids.
        //
        // Supported names:
        //  - "Fire1"  (Ctrl or Mouse0)
        //  - "Fire2"  (Alt or Mouse1)
        //  - "Fire3"  (Shift or Mouse2)
        //  - "Jump"   (Space)
        //  - "Submit" (Enter)
        //  - "Cancel" (Escape)

        private static bool GetButton_InputSystem(string name)
        {
            var keyboard = Keyboard.current;
            var mouse = Mouse.current;

            switch (name)
            {
                case "Fire1":
                    return IsPressed(keyboard?.leftCtrlKey) || IsPressed(mouse?.leftButton);

                case "Fire2":
                    return IsPressed(keyboard?.leftAltKey) || IsPressed(mouse?.rightButton);

                case "Fire3":
                    return IsPressed(keyboard?.leftShiftKey) || IsPressed(mouse?.middleButton);

                case "Jump":
                    return IsPressed(keyboard?.spaceKey);

                case "Submit":
                    return IsPressed(keyboard?.enterKey);

                case "Cancel":
                    return IsPressed(keyboard?.escapeKey);

                default:
                    return false;
            }
        }

        private static bool GetButtonDown_InputSystem(string name)
        {
            var keyboard = Keyboard.current;
            var mouse = Mouse.current;

            switch (name)
            {
                case "Fire1":
                    return WasPressed(keyboard?.leftCtrlKey) || WasPressed(mouse?.leftButton);

                case "Fire2":
                    return WasPressed(keyboard?.leftAltKey) || WasPressed(mouse?.rightButton);

                case "Fire3":
                    return WasPressed(keyboard?.leftShiftKey) || WasPressed(mouse?.middleButton);

                case "Jump":
                    return WasPressed(keyboard?.spaceKey);

                case "Submit":
                    return WasPressed(keyboard?.enterKey);

                case "Cancel":
                    return WasPressed(keyboard?.escapeKey);

                default:
                    return false;
            }
        }

        private static bool GetButtonUp_InputSystem(string name)
        {
            var keyboard = Keyboard.current;
            var mouse = Mouse.current;

            switch (name)
            {
                case "Fire1":
                    return WasReleased(keyboard?.leftCtrlKey) || WasReleased(mouse?.leftButton);

                case "Fire2":
                    return WasReleased(keyboard?.leftAltKey) || WasReleased(mouse?.rightButton);

                case "Fire3":
                    return WasReleased(keyboard?.leftShiftKey) || WasReleased(mouse?.middleButton);

                case "Jump":
                    return WasReleased(keyboard?.spaceKey);

                case "Submit":
                    return WasReleased(keyboard?.enterKey) || WasReleased(keyboard?.numpadEnterKey);

                case "Cancel":
                    return WasReleased(keyboard?.escapeKey);

                default:
                    return false;
            }
        }

        private static bool IsPressed(ButtonControl button) =>
            button is { isPressed: true };

        private static bool WasPressed(ButtonControl button) =>
            button is { wasPressedThisFrame: true };

        private static bool WasReleased(ButtonControl button) =>
            button is { wasReleasedThisFrame: true };

#endif // PM_INPUTSYSTEM

        // ---------------------------------------------------------------------
        // LEGACY INPUT MANAGER HELPERS
        // ---------------------------------------------------------------------

#if PM_LEGACYINPUT

        private const int MaxMouseButtons = 7;
        private const int MaxJoysticks = 8;
        private const int MaxButtonsPerJoystick = 20;

        private static bool AnyMouseButton_Legacy()
        {
            for (int button = 0; button < MaxMouseButtons; button++)
            {
                if (Input.GetMouseButton(button))
                    return true;
            }

            return false;
        }

        private static bool AnyMouseButtonDown_Legacy()
        {
            for (int button = 0; button < MaxMouseButtons; button++)
            {
                if (Input.GetMouseButtonDown(button))
                    return true;
            }

            return false;
        }

        private static bool AnyJoystickButton_Legacy()
        {
            for (int joystick = 1; joystick <= MaxJoysticks; joystick++)
            {
                for (int button = 0; button < MaxButtonsPerJoystick; button++)
                {
                    var keyCode = (KeyCode)((int)KeyCode.Joystick1Button0 +
                                            (joystick - 1) * MaxButtonsPerJoystick +
                                            button);

                    if (Input.GetKey(keyCode))
                        return true;
                }
            }

            return false;
        }

        private static bool AnyJoystickButtonDown_Legacy()
        {
            for (int joystick = 1; joystick <= MaxJoysticks; joystick++)
            {
                for (int button = 0; button < MaxButtonsPerJoystick; button++)
                {
                    var keyCode = (KeyCode)((int)KeyCode.Joystick1Button0 +
                                            (joystick - 1) * MaxButtonsPerJoystick +
                                            button);

                    if (Input.GetKeyDown(keyCode))
                        return true;
                }
            }

            return false;
        }

        private static bool AnyTouchDown_Legacy()
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == UnityEngine.TouchPhase.Began)
                    return true;
            }

            return false;
        }

#endif // PM_LEGACYINPUT
    }
}

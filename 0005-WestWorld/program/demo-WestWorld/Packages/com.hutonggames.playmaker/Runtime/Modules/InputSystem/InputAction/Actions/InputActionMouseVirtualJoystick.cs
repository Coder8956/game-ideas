#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Mouse)]
    [ActionDescription("Generates a virtual 2D joystick value from mouse movement. " +
                       "Supports dead zone, optional re-centering behavior, and optional UI handle visualization.")]
    [HelpURL("actions/input-system-actions/input-action-actions/mouse-virtual-joystick/")]
    public sealed class InputActionMouseVirtualJoystick : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [Header("Input")]

        [Tooltip("The InputAction that provides pointer delta (e.g., bound to <Pointer>/delta)." + Strings.InputActionEnabledNote)]
        [SerializeField]
        private InputActionReferenceVar _mouseDeltaAction;

        [Tooltip("If true, the cursor will be locked to the center of the screen while the joystick is active.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _lockCursor;

        [Header("Tuning")]

        [Tooltip("Multiplier from mouse delta (pixels) to stick movement.\nDefault: 0.002")]
        [SerializeField, DefaultValue(0.002f)]
        private FloatVar _sensitivity;

        [Tooltip("Speed that the stick re-centers towards zero when inside the recenter threshold (units per second).\n0 = no spring anywhere.\nDefault: 1.5")]
        [SerializeField, DefaultValue(1.5f)]
        private FloatVar _returnRate;

        [Tooltip("Inside this radius, automatic return-to-center activates. Outside it, the stick does not spring.\n0 = always spring (no threshold).\nDefault: 0.35")]
        [SerializeField, DefaultValue(0.35f)]
        private FloatVar _recenterThreshold;

        [Tooltip("Dead zone radius near the center in normalized stick space [0..1]. Output is zero inside this radius.\nDefault: 0.1")]
        [SerializeField, DefaultValue(0.1f)]
        private FloatVar _deadZone;

        [Tooltip("Clamp the internal stick magnitude to 1.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _clampMagnitude;

        [Header("Controls")]

        [OptionalField]
        [Tooltip("Invert the horizontal (X) axis.")]
        [SerializeField]
        private BoolVar _invertX;

        [OptionalField]
        [Tooltip("Invert the vertical (Y) axis.")]
        [SerializeField]
        private BoolVar _invertY;

        [OptionalField]
        [Tooltip("Optional: scale the final joystick output per-axis without needing a separate action.")]
        [SerializeField]
        private Vector2Var _multiplier;
        
        [Header("Output")]

        [Tooltip("Virtual joystick output in normalized [-1, 1] range.")]
        [SerializeField, WriteOnly]
        private Vector2Ref _value;

        [OptionalField]
        [Tooltip("Normalized magnitude of the virtual joystick (0..1) after dead zone, invert.")]
        [SerializeField, WriteOnly]
        private FloatRef _magnitude;

        [Header("UI (Optional)")]

        [Tooltip("UI handle to move, e.g., a uGUI Image RectTransform for the joystick. " +
                 "Its anchoredPosition MUST be (0,0) at rest; this is treated as the joystick center.")]
        [SerializeField, OptionalField]
        private RectTransformVar _uiHandle;

        [Tooltip("Maximum visual radius (in anchoredPosition units) for full stick deflection. " +
                 "0 = half of parent rect's smallest dimension.")]
        [SerializeField, OptionalField]
        private FloatVar _uiMaxRadius;

        [Tooltip("If true, rotates the UI handle so its local 'up' direction points away from the joystick center.")]
        [SerializeField, OptionalField]
        private BoolVar _rotateHandle;

        // Internal accumulated stick position in normalized space [-1,1]
        private Vector2 _stick;
        
        private CursorLockMode _previousCursorLockMode;

#if UNITY_EDITOR
        // Tracks whether the joystick is "armed" in the editor.
        [NonSerialized]
        private bool _editorInputEngaged;
#endif
        
        public override bool CanExecute()
        {
            // Ensure we have an action reference and an output variable.
            if (!CheckParameters(_mouseDeltaAction, _value))
                return false;

            var reference = _mouseDeltaAction.Value;
            if (reference == null || reference.action == null)
                return false;

            return true;
        }

        public override void OnStart()
        {
            _stick = Vector2.zero;
            _value.Value = Vector2.zero;

            if (!_magnitude.IsNone)
                _magnitude.Value = 0f;
            
#if UNITY_EDITOR
            _editorInputEngaged = true; // start engaged in editor
#endif
            
            if (_lockCursor.Value)
            {
                LogInfo("Locking cursor. Escape to unlock. Click in GameView to lock. ", true);
                _previousCursorLockMode = Cursor.lockState;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public override void OnStop()
        {
            if (_lockCursor.Value)
            {
                Cursor.lockState = _previousCursorLockMode;
            }
        }

        public override void Execute()
        {
            var reference = _mouseDeltaAction.Value;
            if (reference == null)
                return;

            var action = reference.action;
            if (action == null)
                return;
            
#if UNITY_EDITOR      
            if (!EditorInputGate.ShouldProcessInput(ref _editorInputEngaged))
            {
                ZeroJoystick();
                return;
            }
#endif
            
            // 1. Read mouse delta from input system
            var delta = action.ReadValue<Vector2>();

            var sensitivity = Mathf.Max(0f, _sensitivity.Value);
            var returnRate  = Mathf.Max(0f, _returnRate.Value);
            var deadZone    = Mathf.Clamp01(_deadZone.Value);
            var recenter    = Mathf.Clamp01(_recenterThreshold.Value);

            // 2. Accumulate mouse delta into internal stick position
            //    (Mouse movement pushes a virtual joystick)
            _stick += delta * sensitivity;

            // 3. Clamp magnitude (optional)
            var mag = _stick.magnitude;
            if (_clampMagnitude.Value && mag > 1f)
            {
                _stick = _stick.normalized;
                mag = 1f;
            }

            // 4. Apply dead zone and compute base output in normalized space
            Vector2 baseOutput;

            if (mag < deadZone)
            {
                // Inside dead zone → no output
                baseOutput = Vector2.zero;
            }
            else if (mag > 0f)
            {
                // Rescale so edge of dead zone → 0, outer edge → 1
                var scaledMag = (mag - deadZone) / (1f - deadZone);
                scaledMag = Mathf.Clamp01(scaledMag);
                baseOutput = _stick.normalized * scaledMag;
            }
            else
            {
                baseOutput = Vector2.zero;
            }

            // 5. Build final logical output: invert + multiplier
            var output = baseOutput;

            // Invert axes if requested
            if (!_invertX.IsNone && _invertX.Value)
            {
                output.x = -output.x;
            }

            if (!_invertY.IsNone && _invertY.Value)
            {
                output.y = -output.y;
            }

            // Per-axis multiplier
            if (!_multiplier.IsNone)
            {
                var m = _multiplier.Value;
                output = new Vector2(output.x * m.x, output.y * m.y);
            }

            // 6. Spring return (recenter behavior) uses the internal stick magnitude,
            //    not the post-processed output.
            //    - returnRate == 0 → no spring anywhere
            //    - recenter > 0   → spring only when stick magnitude < recenter
            //    - recenter == 0  → always spring (no threshold)
            if (returnRate > 0f)
            {
                bool applySpring;

                if (recenter > 0f)
                {
                    applySpring = mag < recenter;
                }
                else
                {
                    // No threshold defined → always spring
                    applySpring = true;
                }

                if (applySpring)
                {
                    _stick = Vector2.MoveTowards(_stick, Vector2.zero, returnRate * Time.deltaTime);
                }
            }

            // 7. Write outputs
            _value.Value = output;

            if (!_magnitude.IsNone)
            {
                // Normalized joystick magnitude (0–1), independent of invert/multiplier.
                _magnitude.Value = baseOutput.magnitude;
            }

            // 8. Optional: drive UI handle (uses baseOutput so UI range is not affected by multiplier)
            UpdateUiHandle(baseOutput);
        }

        private void UpdateUiHandle(Vector2 uiOutput)
        {
            if (_uiHandle.IsNone) return;

            var handle = _uiHandle.Value;
            if (handle == null) return;

            // Determine radius
            float radius = _uiMaxRadius.IsNone ? 0f : _uiMaxRadius.Value;
            if (radius <= 0f)
            {
                var parentRect = handle.parent as RectTransform;
                if (parentRect != null)
                {
                    radius = 0.5f * Mathf.Min(parentRect.rect.width, parentRect.rect.height);
                }
                else
                {
                    radius = 50f; // fallback
                }
            }

            // Handle is assumed to be centered at (0,0) in anchoredPosition.
            handle.anchoredPosition = uiOutput * radius;

            // Optional rotation: point handle away from center (local up along output direction)
            if (!_rotateHandle.IsNone && _rotateHandle.Value)
            {
                if (uiOutput.sqrMagnitude > 0.0001f)
                {
                    // Angle so local 'up' points along uiOutput:
                    // atan2(y, x) gives angle from +X; subtract 90 so +Y (up) aligns with the vector.
                    float angle = Mathf.Atan2(uiOutput.y, uiOutput.x) * Mathf.Rad2Deg - 90f;
                    handle.localRotation = Quaternion.Euler(0f, 0f, angle);
                }
                else
                {
                    // Near center → reset rotation
                    handle.localRotation = Quaternion.identity;
                }
            }
        }

        private void ZeroJoystick()
        {
            _stick = Vector2.zero;
            _value.Value = Vector2.zero;
            _magnitude.Value = 0f;
            UpdateUiHandle(Vector2.zero);
        }
        
        public override string GetSummary()
        {
            return "Get {_mouseDeltaAction} joystick -> {_value}" +
                   (_multiplier.IsNotDefault(new Vector2(1f, 1f)) ? " * {_multiplier}" : "");
        }
    }
}

#endif

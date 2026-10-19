#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("Disable all connected gamepads (new Input System).")]
    [HelpURL("actions/input-system-actions/input-devices/")]
    public sealed class InputSystemDisableAllGamepads : BaseAction
    {
        public override void Execute()
        {
            foreach (var pad in Gamepad.all)
                InputSystem.DisableDevice(pad);
        }

        public override string GetSummary() => "Disable all gamepads";
    }
}
#endif

#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("Disable the mouse (new Input System).")]
    [HelpURL("actions/input-system-actions/input-devices/")]
    public sealed class InputSystemDisableMouse : BaseAction
    {
        public override void Execute()
        {
            if (Mouse.current != null)
                InputSystem.DisableDevice(Mouse.current);
        }

        public override string GetSummary() => "Disable mouse";
    }
}
#endif

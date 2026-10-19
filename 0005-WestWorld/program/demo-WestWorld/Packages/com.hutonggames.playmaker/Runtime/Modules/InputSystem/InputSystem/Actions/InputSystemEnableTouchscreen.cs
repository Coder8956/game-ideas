#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("Enable the touchscreen (new Input System).")]
    [HelpURL("actions/input-system-actions/input-devices/")]
    public sealed class InputSystemEnableTouchscreen : BaseAction
    {
        public override void Execute()
        {
            if (Touchscreen.current != null)
                InputSystem.EnableDevice(Touchscreen.current);
        }

        public override string GetSummary() => "Enable touchscreen";
    }
}
#endif

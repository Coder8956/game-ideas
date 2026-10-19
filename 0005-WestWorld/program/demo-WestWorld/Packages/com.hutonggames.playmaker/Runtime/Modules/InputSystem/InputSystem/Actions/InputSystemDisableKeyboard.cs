#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("Disable the keyboard (new Input System).")]
    [HelpURL("actions/input-system-actions/input-devices/")]
    public sealed class InputSystemDisableKeyboard : BaseAction
    {
        public override void Execute()
        {
            if (Keyboard.current != null)
                InputSystem.DisableDevice(Keyboard.current);
        }
        
        public override string GetSummary() => "Disable keyboard";
    }
}
#endif

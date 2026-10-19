#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("Enable the keyboard (new Input System).")]
    [HelpURL("actions/input-system-actions/input-devices/")]
    public sealed class InputSystemEnableKeyboard : BaseAction
    {
        public override void Execute()
        {
            if (Keyboard.current != null)
                InputSystem.EnableDevice(Keyboard.current);
        }
        
        public override string GetSummary() => "Enable keyboard";
    }
}
#endif

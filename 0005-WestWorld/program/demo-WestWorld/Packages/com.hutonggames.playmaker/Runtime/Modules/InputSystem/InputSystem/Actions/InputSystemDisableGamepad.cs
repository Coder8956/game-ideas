#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("Disable a gamepad by index (0 = first gamepad).")]
    [HelpURL("actions/input-system-actions/input-devices/")]
    public sealed class InputSystemDisableGamepad : BaseAction
    {
        [SerializeField, DefaultValue(0)]
        private IntegerVar _gamepadIndex;

        public override bool CanExecute() => CheckParameters(_gamepadIndex);

        public override void Execute()
        {
            var all = Gamepad.all;
            if (all.Count == 0) return;

            var index = Mathf.Clamp(_gamepadIndex.Value, 0, all.Count - 1);
            InputSystem.DisableDevice(all[index]);
        }

        public override string GetSummary() => "Disable Gamepad[{_gamepadIndex}]";
    }
}
#endif

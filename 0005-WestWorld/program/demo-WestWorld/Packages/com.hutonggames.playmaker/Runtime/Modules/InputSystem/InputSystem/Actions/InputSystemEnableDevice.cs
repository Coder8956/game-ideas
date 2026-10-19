#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("(Re-)enable the given device.")]
    [HelpURL(HelpUrls.InputSystem + "#UnityEngine_InputSystem_InputSystem_EnableDevice_UnityEngine_InputSystem_InputDevice_")]
    public class InputSystemEnableDevice : BaseAction
    {
        [Tooltip("The device to enable")]
        [SerializeField]
        private InputDeviceRef _inputDevice;

        public override bool CanExecute() => _inputDevice.IsAssigned;
        
        public override void Execute()
        {
            if (_inputDevice.Value == null) return;
            
            InputSystem.EnableDevice(_inputDevice.Value);
        }
    }
}

#endif
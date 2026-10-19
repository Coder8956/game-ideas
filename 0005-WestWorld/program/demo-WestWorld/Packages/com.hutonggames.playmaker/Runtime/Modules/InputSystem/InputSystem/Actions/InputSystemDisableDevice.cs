#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("Disable the given device, i.e. \"mute\" it.")]
    [HelpURL(HelpUrls.InputSystem + "#UnityEngine_InputSystem_InputSystem_DisableDevice_UnityEngine_InputSystem_InputDevice_System_Boolean_")]
    public class InputSystemDisableDevice : BaseAction
    {
        [Tooltip("The device to disable.")]
        [SerializeField]
        private InputDeviceRef _inputDevice;

        [Tooltip("If true, no DisableDeviceCommand will be sent for the device. " +
                 "This means that the backend sending input events will not be notified " +
                 "about the device being disabled and will thus keep sending events. " +
                 "This can be useful when input is being rerouted from one device to another. " +
                 "For example, TouchSimulation uses this to disable the Mouse while redirecting " +
                 "its events to input on a Touchscreen.")]
        [SerializeField]
        private BoolVar _keepSendingEvents;
        
        public override bool CanExecute() => _inputDevice.IsAssigned && _keepSendingEvents.HasValue();
        
        public override void Execute()
        {
            if (_inputDevice.Value == null) return;
            
            InputSystem.DisableDevice(_inputDevice.Value, _keepSendingEvents.Value);
        }
    }
}

#endif
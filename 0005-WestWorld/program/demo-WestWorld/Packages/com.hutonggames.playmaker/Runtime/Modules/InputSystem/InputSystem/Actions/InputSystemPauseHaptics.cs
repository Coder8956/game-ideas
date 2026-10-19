#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("Pause haptic effect playback on all devices.")]
    [HelpURL(HelpUrls.InputSystem + "#UnityEngine_InputSystem_InputSystem_PauseHaptics")]
    public class InputSystemPauseHaptics : BaseAction
    {
        public override void Execute() => InputSystem.PauseHaptics();
    }
}

#endif
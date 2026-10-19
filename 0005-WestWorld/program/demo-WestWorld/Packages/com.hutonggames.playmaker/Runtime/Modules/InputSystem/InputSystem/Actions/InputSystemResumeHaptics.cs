#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.Settings)]
    [ActionDescription("Resume haptic effect playback on all devices.")]
    [HelpURL(HelpUrls.InputSystem + "#UnityEngine_InputSystem_InputSystem_ResumeHaptics")]
    public class InputSystemResumeHaptics : BaseAction
    {
        public override void Execute() => InputSystem.ResumeHaptics();
    }
}

#endif
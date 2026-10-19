#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputActionAsset)]
    [ActionDescription("Enable all Input Action Maps and Actions in an Input Action Asset.")]
    [Tooltip("Enable all action maps inside the Input Action Asset.")]
    [HelpURL("actions/input-system-actions/input-action-actions/")]
    public sealed class InputActionAssetEnable : BaseAction
    {
        [Tooltip("The Input Action Asset to enable.")]
        [SerializeField]
        private InputActionAssetVar _inputActionAsset;

        public override bool CanExecute() => CheckParameters(_inputActionAsset);

        public override void OnStart()
        {
            var asset = _inputActionAsset.Value;
            if (asset == null)
            {
                Debug.LogWarning("InputActionAssetEnable: No asset assigned.", Owner);
                return;
            }

            asset.Enable();
        }

        public override string GetSummary() => "Enable {_inputActionAsset} InputActions";
    }
}

#endif
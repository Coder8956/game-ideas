#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputActionAsset)]
    [ActionDescription("Disable all Input Action Maps and Actions in an Input Action Asset.")]
    [Tooltip("Disable all action maps inside the Input Action Asset.")]
    [HelpURL("actions/input-system-actions/input-action-actions/")]
    public sealed class InputActionAssetDisable : BaseAction
    {
        [Tooltip("The Input Action Asset to disable.")]
        [SerializeField]
        private InputActionAssetVar _inputActionAsset;

        public override bool CanExecute() => CheckParameters(_inputActionAsset);

        public override void OnStart()
        {
            var asset = _inputActionAsset.Value;
            if (asset == null)
            {
                Debug.LogWarning("InputActionAssetDisable: No asset assigned.", Owner);
                return;
            }

            asset.Disable();
        }

        public override string GetSummary() => "Disable {_inputActionAsset}";
    }
}

#endif
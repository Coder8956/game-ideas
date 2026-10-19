#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputActionAsset)]
    [ActionDescription("Remove all binding overrides from an InputActionAsset.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionAssetRemoveAllBindingOverrides : BaseAction
    {
        [Tooltip("The InputActionAsset to modify.")]
        [SerializeField]
        private InputActionAssetVar _inputActionAsset;

        public override bool CanExecute() => CheckParameters(_inputActionAsset);

        public override void Execute() => _inputActionAsset.Value.RemoveAllBindingOverrides();

        public override string GetSummary() => "Remove all binding overrides from {_inputActionAsset}";
    }
}

#endif

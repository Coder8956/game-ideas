#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputActionAsset)]
    [ActionDescription("Save all binding overrides on an InputActionAsset as JSON.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionAssetSaveBindingOverridesAsJson : BaseAction
    {
        [Tooltip("The InputActionAsset to save.")]
        [SerializeField]
        private InputActionAssetVar _inputActionAsset;

        [Tooltip("Store the binding override JSON.")]
        [SerializeField, WriteOnly]
        private StringRef _json;

        public override bool CanExecute() => CheckParameters(_inputActionAsset, _json);

        public override void Execute() => _json.Value = _inputActionAsset.Value.SaveBindingOverridesAsJson();

        public override string GetSummary() => "Save {_inputActionAsset} binding overrides -> {_json}";
    }
}

#endif

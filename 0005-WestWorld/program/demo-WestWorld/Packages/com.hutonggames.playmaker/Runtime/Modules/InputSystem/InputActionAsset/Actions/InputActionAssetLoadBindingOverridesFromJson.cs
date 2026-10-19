#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputActionAsset)]
    [ActionDescription("Load binding overrides from JSON onto an InputActionAsset.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionAssetLoadBindingOverridesFromJson : BaseAction
    {
        [Tooltip("The InputActionAsset to load onto.")]
        [SerializeField]
        private InputActionAssetVar _inputActionAsset;

        [Tooltip("Binding override JSON produced by SaveBindingOverridesAsJson.")]
        [SerializeField]
        private StringVar _json;

        [Tooltip("Remove existing binding overrides before loading the JSON.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _removeExisting;

        public override bool CanExecute() => CheckParameters(_inputActionAsset, _json);

        public override void Execute()
        {
            if (string.IsNullOrEmpty(_json.Value))
            {
                return;
            }

            _inputActionAsset.Value.LoadBindingOverridesFromJson(_json.Value, _removeExisting.Value);
        }

        public override string GetSummary() => "Load binding overrides onto {_inputActionAsset}";
    }
}

#endif

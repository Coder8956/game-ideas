#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions.InputActionMap
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputActionMap)]
    [ActionDescription("Load binding overrides from JSON onto an InputActionMap.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionMapLoadBindingOverridesFromJson : BaseAction
    {
        [Tooltip("The InputActionMap to load onto.")]
        [SerializeField]
        private InputActionMapRef _inputActionMap;

        [Tooltip("Binding override JSON produced by SaveBindingOverridesAsJson.")]
        [SerializeField]
        private StringVar _json;

        [Tooltip("Remove existing binding overrides before loading the JSON.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _removeExisting;

        public override bool CanExecute() => CheckParameters(_inputActionMap, _json);

        public override void Execute()
        {
            if (string.IsNullOrEmpty(_json.Value))
            {
                return;
            }

            _inputActionMap.Value.LoadBindingOverridesFromJson(_json.Value, _removeExisting.Value);
        }

        public override string GetSummary() => "Load binding overrides onto {_inputActionMap}";
    }
}

#endif

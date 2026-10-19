#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions.InputActionMap
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputActionMap)]
    [ActionDescription("Save all binding overrides on an InputActionMap as JSON.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionMapSaveBindingOverridesAsJson : BaseAction
    {
        [Tooltip("The InputActionMap to save.")]
        [SerializeField]
        private InputActionMapRef _inputActionMap;

        [Tooltip("Store the binding override JSON.")]
        [SerializeField, WriteOnly]
        private StringRef _json;

        public override bool CanExecute() => CheckParameters(_inputActionMap, _json);

        public override void Execute() => _json.Value = _inputActionMap.Value.SaveBindingOverridesAsJson();

        public override string GetSummary() => "Save {_inputActionMap} binding overrides -> {_json}";
    }
}

#endif

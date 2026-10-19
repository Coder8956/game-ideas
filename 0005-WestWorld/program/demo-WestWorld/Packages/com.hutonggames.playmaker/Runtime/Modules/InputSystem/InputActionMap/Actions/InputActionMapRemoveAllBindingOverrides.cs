#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions.InputActionMap
{
    [Serializable]
    [ActionCategory(Category.InputSystem.InputActionMap)]
    [ActionDescription("Remove all binding overrides from an InputActionMap.")]
    [HelpURL(HelpUrls.InputSystemRoot + ".InputActionRebindingExtensions.html")]
    public sealed class InputActionMapRemoveAllBindingOverrides : BaseAction
    {
        [Tooltip("The InputActionMap to modify.")]
        [SerializeField]
        private InputActionMapRef _inputActionMap;

        public override bool CanExecute() => CheckParameters(_inputActionMap);

        public override void Execute() => _inputActionMap.Value.RemoveAllBindingOverrides();

        public override string GetSummary() => "Remove all binding overrides from {_inputActionMap}";
    }
}

#endif

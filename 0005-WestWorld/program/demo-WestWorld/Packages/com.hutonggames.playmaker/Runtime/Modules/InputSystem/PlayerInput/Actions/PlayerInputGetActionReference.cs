#if ENABLE_INPUT_SYSTEM && UNITY_INPUT_SYSTEM

using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.InputSystem.PlayerInput)]
    [ActionDescription("Get an InputActionReference for an action in the PlayerInput actions asset.")]
    [HelpURL(HelpUrls.PlayerInput + "#UnityEngine_InputSystem_PlayerInput_actions")]
    public sealed class PlayerInputGetActionReference : BaseAction
    {
        [Tooltip("The PlayerInput.")]
        [SerializeField]
        private PlayerInputVar _playerInput;

        [Tooltip("The name of the action to get.")]
        [SerializeField]
        private StringVar _actionName;

        [Tooltip("Store the result.")]
        [SerializeField, WriteOnly]
        private InputActionReferenceRef _result;

        public override bool CanExecute() => CheckParameters(_playerInput, _actionName, _result);

        public override void Execute()
        {
            var playerInput = _playerInput.Value;
            var action = playerInput != null && playerInput.actions != null ? playerInput.actions[_actionName.Value] : null;

            _result.Value = action != null ? InputActionReference.Create(action) : null;
        }

        public override string GetSummary() => "Get {_playerInput} {_actionName} action reference -> {_result}";
    }
}

#endif

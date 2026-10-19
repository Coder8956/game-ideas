using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Input)]
    [ActionDescription("Checks an ordered list of named input buttons and returns the first matching activation id. " +
                       "Use the activation id as a generic label to map inputs to gameplay commands, UI actions, " +
                       "interactables, or any other system that needs an input-to-id lookup.")]
    public sealed class InputGetButtonActivation : BaseAction
    {
        [Serializable]
        public sealed class ActivationBinding
        {
            public ActivationBinding()
            {
                _buttonName = new StringVar();
                _buttonName.Reset("Fire1");
                _activationId = new StringVar();
                _activationId.Reset("Use");
            }

            [Tooltip("Named input button to query, such as Fire1, Submit, or Jump.")]
            [SerializeField]
            private StringVar _buttonName;

            [Tooltip("Activation id to return when this button matches, such as Use or AltUse. This can be any id your game uses to route input to a command, mode, UI action, interactable, or other system.")]
            [SerializeField]
            private StringVar _activationId;

            public string ButtonName => _buttonName?.Value ?? string.Empty;
            public string ActivationId => _activationId?.Value ?? string.Empty;
        }

        public enum ButtonState
        {
            PressedThisFrame,
            Held,
            ReleasedThisFrame
        }

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [Tooltip("Ordered list of button-to-activation mappings. The first matching button wins, letting you translate multiple named inputs into the ids used by other systems.")]
        [SerializeField, NoFoldout]
        private List<ActivationBinding> _bindings;

        [Tooltip("Which button state to detect.")]
        [SerializeField, DefaultValue(ButtonState.PressedThisFrame)]
        private ButtonState _buttonState = ButtonState.PressedThisFrame;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("True when any configured button matches the selected button state.")]
        [SerializeField, WriteOnly]
        private BoolRef _pressed;

        [OptionalField]
        [Tooltip("Activation id from the first matching binding, " +
                 "ready to pass into any system that uses ids to decide what input should do. E.g., Interactables")]
        [SerializeField, WriteOnly]
        private StringRef _activationId;

        [OptionalField]
        [Tooltip("Button name from the first matching binding.")]
        [SerializeField, WriteOnly]
        private StringRef _buttonName;

        public override void Reset()
        {
            _bindings = new List<ActivationBinding> { new() };
        }
        
        public override void Execute()
        {
            var matchIndex = FindMatchingBinding(_bindings, IsButtonMatch);
            if (matchIndex < 0)
            {
                ClearOutputs();
                return;
            }

            var binding = _bindings[matchIndex];

            if (_pressed is { IsAssigned: true }) _pressed.Value = true;
            if (_activationId is { IsAssigned: true }) _activationId.Value = binding.ActivationId;
            if (_buttonName is { IsAssigned: true }) _buttonName.Value = binding.ButtonName;
        }

        public override string GetSummary() =>
            "Get button activation {_pressed:output} {_activationId:output}";

        private void ClearOutputs()
        {
            if (_pressed is { IsAssigned: true }) _pressed.Value = false;
            if (_activationId is { IsAssigned: true }) _activationId.Value = string.Empty;
            if (_buttonName is { IsAssigned: true }) _buttonName.Value = string.Empty;
        }

        private bool IsButtonMatch(string buttonName)
        {
            return _buttonState switch
            {
                ButtonState.Held => InputShim.GetButton(buttonName),
                ButtonState.ReleasedThisFrame => InputShim.GetButtonUp(buttonName),
                _ => InputShim.GetButtonDown(buttonName)
            };
        }

        private static int FindMatchingBinding(IReadOnlyList<ActivationBinding> bindings, Func<string, bool> isButtonMatch)
        {
            if (bindings == null || isButtonMatch == null)
            {
                return -1;
            }

            for (var i = 0; i < bindings.Count; i++)
            {
                var binding = bindings[i];
                if (binding == null || string.IsNullOrEmpty(binding.ButtonName))
                {
                    continue;
                }

                if (isButtonMatch(binding.ButtonName))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}

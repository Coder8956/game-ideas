using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Input)]
    [ActionDescription("Checks an ordered list of keys and returns the first matching activation id." +
                       "Use the activation id as a generic label to map inputs to gameplay commands, UI actions, " +
                       "interactables, or any other system that needs an input-to-id lookup.")]
    public sealed class InputGetKeyActivation : BaseAction
    {
        [Serializable]
        public sealed class ActivationBinding
        {
            public ActivationBinding()
            {
                _key = new KeyCodeVar();
                _key.Reset(KeyCode.Space);
                _activationId = new StringVar();
                _activationId.Reset("Use");
            }

            [Tooltip("Key to query.")]
            [SerializeField]
            private KeyCodeVar _key;

            [Tooltip("Activation id to return when this key matches, such as Use or AltUse.")]
            [SerializeField]
            private StringVar _activationId;

            public KeyCode Key => _key != null ? _key.Value : KeyCode.None;
            public string ActivationId => _activationId?.Value ?? string.Empty;
        }

        public enum KeyState
        {
            PressedThisFrame,
            Held,
            ReleasedThisFrame
        }

        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

        [Tooltip("Ordered list of key-to-activation mappings. The first matching key wins.")]
        [SerializeField, NoFoldout]
        private List<ActivationBinding> _bindings;

        [Tooltip("Which key state to detect.")]
        [SerializeField, DefaultValue(KeyState.PressedThisFrame)]
        private KeyState _keyState = KeyState.PressedThisFrame;

        [ActionHeader("Outputs")]

        [OptionalField]
        [Tooltip("True when any configured key matches the selected key state.")]
        [SerializeField, WriteOnly]
        private BoolRef _pressed;

        [OptionalField]
        [Tooltip("Activation id from the first matching binding, " +
                 "ready to pass into any system that uses ids to decide what input should do. E.g., Interactables")]
        [SerializeField, WriteOnly]
        private StringRef _activationId;

        [OptionalField]
        [Tooltip("Key from the first matching binding.")]
        [SerializeField, WriteOnly]
        private KeyCodeRef _key;

        public override void Reset()
        {
            _bindings = new List<ActivationBinding> { new() };
        }
        
        public override void Execute()
        {
            var matchIndex = FindMatchingBinding(_bindings, IsKeyMatch);
            if (matchIndex < 0)
            {
                ClearOutputs();
                return;
            }

            var binding = _bindings[matchIndex];

            if (_pressed is { IsAssigned: true }) _pressed.Value = true;
            if (_activationId is { IsAssigned: true }) _activationId.Value = binding.ActivationId;
            if (_key is { IsAssigned: true }) _key.Value = binding.Key;
        }

        public override string GetSummary() =>
            "Get key activation {_pressed:output} {_activationId:output}";

        private void ClearOutputs()
        {
            if (_pressed is { IsAssigned: true }) _pressed.Value = false;
            if (_activationId is { IsAssigned: true }) _activationId.Value = string.Empty;
            if (_key is { IsAssigned: true }) _key.Value = KeyCode.None;
        }

        private bool IsKeyMatch(KeyCode key)
        {
            return _keyState switch
            {
                KeyState.Held => InputShim.GetKey(key),
                KeyState.ReleasedThisFrame => InputShim.GetKeyUp(key),
                _ => InputShim.GetKeyDown(key)
            };
        }

        private static int FindMatchingBinding(IReadOnlyList<ActivationBinding> bindings, Func<KeyCode, bool> isKeyMatch)
        {
            if (bindings == null || isKeyMatch == null)
            {
                return -1;
            }

            for (var i = 0; i < bindings.Count; i++)
            {
                var binding = bindings[i];
                if (binding == null || binding.Key == KeyCode.None)
                {
                    continue;
                }

                if (isKeyMatch(binding.Key))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}

using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Animator)]
    [ActionDescription("Gets the current transition information on a specified Animator layer. Only valid during a transition.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Animator.GetAnimatorTransitionInfo.html")]
    public sealed class AnimatorGetCurrentTransitionInfo : BaseAction
    {
        [Tooltip("The Animator.")]
        [SerializeField]
        private AnimatorVar _animator;

        [Tooltip("The layer index.")]
        [SerializeField]
        private IntegerVar _layerIndex;

        [ActionHeader("Results")]

        [Tooltip("Store the layer name for the layer index.")]
        [SerializeField, WriteOnly, OptionalField]
        private StringRef _layerName;

        [Tooltip("Store the unique name hash of the transition.")]
        [SerializeField, WriteOnly, OptionalField]
        private IntegerRef _nameHash;

        [Tooltip("Store the user-specified name hash of the transition.")]
        [SerializeField, WriteOnly, OptionalField]
        private IntegerRef _userNameHash;

        [Tooltip("Store the normalized time of the transition.")]
        [SerializeField, WriteOnly, OptionalField]
        private FloatRef _normalizedTime;

        public override bool CanExecute()
        {
            return CheckParameters(_animator, _layerIndex);
        }

        public override void Execute()
        {
            var animator = _animator.Value;
            var layerIndex = _layerIndex.Value;
            var info = animator.GetAnimatorTransitionInfo(layerIndex);

            if (_layerName != null && _layerName.IsAssigned)
                _layerName.Value = animator.GetLayerName(layerIndex);

            if (_nameHash != null && _nameHash.IsAssigned)
                _nameHash.Value = info.nameHash;

            if (_userNameHash != null && _userNameHash.IsAssigned)
                _userNameHash.Value = info.userNameHash;

            if (_normalizedTime != null && _normalizedTime.IsAssigned)
                _normalizedTime.Value = info.normalizedTime;
        }

        public override string GetSummary()
        {
            return "Get {_animator} current transition info -> {_layerName:output} {_nameHash:output} {_userNameHash:output} {_normalizedTime:output} ({_layerIndex})";
        }
    }
}

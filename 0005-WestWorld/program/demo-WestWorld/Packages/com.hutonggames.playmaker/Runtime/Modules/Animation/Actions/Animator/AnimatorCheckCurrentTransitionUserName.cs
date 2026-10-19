using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Animator)]
    [ActionDescription("Checks the active Animator transition user-specified name on a specified layer.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AnimatorTransitionInfo.IsUserName.html")]
    public sealed class AnimatorCheckCurrentTransitionUserName : BaseTrueFalseAction
    {
        [Tooltip("The Animator.")]
        [SerializeField]
        private AnimatorVar _animator;

        [Tooltip("The layer index.")]
        [SerializeField]
        private IntegerVar _layerIndex;

        [Tooltip("The user-specified transition name to check.")]
        [SerializeField]
        private StringVar _transitionUserName;

        public override bool CanExecute()
        {
            return CheckParameters(_animator, _layerIndex, _transitionUserName);
        }

        protected override bool Test()
        {
            var info = _animator.Value.GetAnimatorTransitionInfo(_layerIndex.Value);
            return info.IsUserName(_transitionUserName.Value);
        }

        protected override string TrueSummary => "{_animator} current transition user name is {_transitionUserName} ({_layerIndex})";
        protected override string FalseSummary => "{_animator} current transition user name is not {_transitionUserName} ({_layerIndex})";
    }
}

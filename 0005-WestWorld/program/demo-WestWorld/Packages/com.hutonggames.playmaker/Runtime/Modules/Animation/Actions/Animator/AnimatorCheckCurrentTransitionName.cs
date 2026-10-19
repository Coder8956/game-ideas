using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Animator)]
    [ActionDescription("Checks the active Animator transition name on a specified layer. Format is 'CURRENT_STATE -> NEXT_STATE'.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/AnimatorTransitionInfo.IsName.html")]
    public sealed class AnimatorCheckCurrentTransitionName : BaseTrueFalseAction
    {
        [Tooltip("The Animator.")]
        [SerializeField]
        private AnimatorVar _animator;

        [Tooltip("The layer index.")]
        [SerializeField]
        private IntegerVar _layerIndex;

        [Tooltip("The transition name to check. Format is 'CURRENT_STATE -> NEXT_STATE'.")]
        [SerializeField]
        private StringVar _transitionName;

        public override bool CanExecute()
        {
            return CheckParameters(_animator, _layerIndex, _transitionName);
        }

        protected override bool Test()
        {
            var info = _animator.Value.GetAnimatorTransitionInfo(_layerIndex.Value);
            return info.IsName(_transitionName.Value);
        }

        protected override string TrueSummary => "{_animator} current transition is {_transitionName} ({_layerIndex})";
        protected override string FalseSummary => "{_animator} current transition is not {_transitionName} ({_layerIndex})";
    }
}

using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.AnimatedList)]
    [ActionDescription("Remove an item from an AnimatedList by index.")]
    [HelpURL("guides/ui-widgets/lists/animated-list/")]
    public class AnimatedListRemoveItemAtIndex : BaseAction
    {
        public override bool CanFinish => true;

        [SerializeField]
        [Tooltip("AnimatedList to modify.")]
        private AnimatedListVar _animatedList;

        [SerializeField]
        [Tooltip("Index of the item to remove.")]
        private IntegerVar _index;

        [ActionHeader("Animation")]
        [SerializeField]
        [Tooltip("If false, uses the list's default remove animation. If true, uses the custom settings below.")]
        [DefaultValue(false)]
        private BoolVar _overrideDefaultAnimation;

        private bool HideAnimationSettings =>
            _overrideDefaultAnimation.IsConstantValue && !_overrideDefaultAnimation.Value;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Animation duration in seconds (when overriding list defaults).")]
        [DefaultValue(0.25f)]
        private FloatVar _duration;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Ease curve (when overriding list defaults).")]
        private AnimationCurveVar _ease;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Fade item visuals while animating (when overriding list defaults).")]
        [DefaultValue(true)]
        private BoolVar _fade;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Use unscaled realtime (when overriding list defaults).")]
        [DefaultValue(true)]
        [FormerlySerializedAs("_useUnscaledTime")]
        private BoolVar _useRealtime;

        public override bool CanExecute() => CheckParameters(_animatedList, _index);

        public override void Execute()
        {
            var list = _animatedList.Value;
            if (list == null)
            {
                Finish();
                return;
            }

            if (_overrideDefaultAnimation.Value)
            {
                list.RemoveItemAt(_index.Value, BuildAnimationSettings());
            }
            else
            {
                list.RemoveItemAt(_index.Value);
            }

            Finish();
        }

        public override string GetSummary()
        {
            return "Remove item at {_index} from {_animatedList}";
        }

        private AnimatedList.ItemAnimationSettings BuildAnimationSettings()
        {
            var anim = AnimatedList.ItemAnimationSettings.Default;

            anim.Timing.Duration = Mathf.Max(0f, _duration.Value);
            anim.Timing.Ease = _ease?.Value;
            anim.Fade = _fade.Value;
            anim.Timing.UseUnscaledTime = _useRealtime.Value;

            return anim;
        }
    }
}

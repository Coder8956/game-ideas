using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.AnimatedList)]
    [ActionDescription("Clear all items from an AnimatedList.")]
    [HelpURL("guides/ui-widgets/lists/animated-list/")]
    public class AnimatedListClear : BaseAction
    {
        public override bool CanFinish => true;

        [SerializeField]
        [Tooltip("AnimatedList to modify.")]
        private AnimatedListVar _animatedList;

        [SerializeField]
        [Tooltip("If true, removes items with animation. If false, clears instantly.")]
        [DefaultValue(true)]
        private BoolVar _animate;

        [ActionHeader("Animation")]
        [SerializeField]
        [Tooltip("If false, uses the list's default remove animation. If true, uses the custom settings below.")]
        [DefaultValue(false)]
        private BoolVar _overrideDefaultAnimation;

        private bool HideAnimationSettings =>
            _overrideDefaultAnimation.IsConstantValue && (!_overrideDefaultAnimation.Value || !_animate.Value);

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

        public override bool CanExecute() => CheckParameters(_animatedList);

        public override void Execute()
        {
            var list = _animatedList.Value;
            if (list == null)
            {
                Finish();
                return;
            }

            var content = list.Content;
            if (content == null)
            {
                Finish();
                return;
            }

            if (!_animate.Value)
            {
                // Instant: destroy all host children under content.
                // (Assumes your runtime design uses hosts as direct children.)
                for (int i = content.childCount - 1; i >= 0; i--)
                {
                    var child = content.GetChild(i);
                    if (child != null)
                    {
                        UnityEngine.Object.Destroy(child.gameObject);
                    }
                }

                Finish();
                return;
            }

            var anim = _overrideDefaultAnimation.Value ? BuildAnimationSettings() : default;

            // Animate: remove end->start so indices stay valid.
            for (int i = content.childCount - 1; i >= 0; i--)
            {
                if (_overrideDefaultAnimation.Value)
                {
                    list.RemoveItemAt(i, anim);
                }
                else
                {
                    list.RemoveItemAt(i);
                }
            }

            Finish();
        }

        public override string GetSummary()
        {
            return "Clear {_animatedList}" +
                   (_animate.IsNotDefault() ? " ({_animate:option})" : "");
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

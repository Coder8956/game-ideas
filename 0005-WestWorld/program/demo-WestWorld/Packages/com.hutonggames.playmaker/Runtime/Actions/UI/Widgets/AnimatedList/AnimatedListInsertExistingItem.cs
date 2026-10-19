using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.AnimatedList)]
    [ActionDescription("Insert an existing item instance into an AnimatedListWidget (adopts it into the list and animates it in).")]
    [HelpURL("guides/ui-widgets/lists/animated-list/")]
    public class AnimatedListInsertExistingItem : BaseAction
    {
        [SerializeField]
        [Tooltip("AnimatedListWidget to modify.")]
        private AnimatedListVar _animatedList;

        [SerializeField]
        [Tooltip("Existing item instance to add to the list.")]
        private GameObjectVar _item;
        
        [SerializeField]
        [Tooltip("Index to insert at.")]
        private IntegerVar _atIndex;

        [ActionHeader("Animation")]
        [SerializeField]
        [Tooltip("If false, uses the widget's DefaultInsertAnimation. If true, uses the custom settings below.")]
        [DefaultValue(false)]
        private BoolVar _overrideDefaultAnimation;

        private bool HideAnimationSettings =>
            _overrideDefaultAnimation.IsConstantValue && !_overrideDefaultAnimation.Value;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Animation duration in seconds (when overriding widget defaults).")]
        [DefaultValue(0.25f)]
        private FloatVar _duration;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Ease curve (when overriding widget defaults).")]
        private AnimationCurveVar _ease;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Fade the item while animating (when overriding widget defaults).")]
        [DefaultValue(true)]
        private BoolVar _fade;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Use unscaled realtime (when overriding widget defaults).")]
        [DefaultValue(true)]
        [FormerlySerializedAs("_useUnscaledTime")]
        private BoolVar _useRealtime;

        public override bool CanExecute() => CheckParameters(_animatedList, _item);

        public override void Execute()
        {
            var animatedList = _animatedList.Value;
            var itemGo = _item.Value;

            if (animatedList == null || itemGo == null)
                return;

            var settings = _overrideDefaultAnimation.Value
                ? BuildAnimationSettings()
                : animatedList.DefaultInsertAnimation;

            animatedList.InsertExistingItem(_atIndex.Value, itemGo, settings);
        }

        public override string GetSummary()
        {
            return "Insert existing {_item} into {_animatedList} at {_atIndex}";
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

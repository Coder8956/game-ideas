using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.AnimatedList)]
    [ActionDescription("Add an item into an AnimatedListWidget. Optionally stores the created item.")]
    [HelpURL("guides/ui-widgets/lists/animated-list/")]
    public class AnimatedListAddItem : BaseAction
    {
        public override bool CanFinish => true;
        
        [SerializeField]
        [Tooltip("AnimatedListWidget to modify.")]
        private AnimatedListVar _animatedList;

        [SerializeField]
        [Tooltip("Optional prefab override. If not set, the widget's ItemPrefab is used.")]
        [OptionalField]
        private GameObjectVar _prefabOverride;

        [ActionHeader("Animation")]
        [SerializeField]
        [Tooltip("If false, uses the widget's DefaultAnimation settings. If true, uses the custom settings below.")]
        [DefaultValue(false)]
        private BoolVar _overrideDefaultAnimation;
        
        private bool HideAnimationSettings => 
            _overrideDefaultAnimation.IsConstantValue && !_overrideDefaultAnimation.Value;
        
        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Animation duration in seconds (when not using widget defaults).")]
        [DefaultValue(0.25f)]
        private FloatVar _duration;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Ease curve (when not using widget defaults).")]
        private AnimationCurveVar _ease;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Fade the item in (when not using widget defaults).")]
        [DefaultValue(true)]
        private BoolVar _fade;

        [HideIf(nameof(HideAnimationSettings))]
        [SerializeField]
        [Tooltip("Use unscaled realtime (when not using widget defaults).")]
        [DefaultValue(true)]
        [FormerlySerializedAs("_useUnscaledTime")]
        private BoolVar _useRealtime;

        [ActionHeader("Result")]
        [SerializeField]
        [Tooltip("Store the created item GameObject.")]
        [OptionalField]
        [WriteOnly]
        private GameObjectRef _storeItem;

        public override bool CanExecute() => CheckParameters(_animatedList);

        public override void Execute()
        {
            var animatedList = _animatedList.Value;
            if (animatedList == null) return;
            
            var prefab = _prefabOverride?.Value;
            var settings = _overrideDefaultAnimation.Value 
                ?  BuildAnimationSettings() 
                : animatedList.DefaultInsertAnimation;
            var created = animatedList.AddItem(prefab, settings);
            if (_storeItem.IsAssigned)
            {
                _storeItem.Value = created;
            }
        }

        public override string GetSummary()
        {
            return "Add " +
                   (_prefabOverride.IsDefault(null) ? " item" : " {_prefabOverride}") +
                   " to {_animatedList} {_storeItem:output}";
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

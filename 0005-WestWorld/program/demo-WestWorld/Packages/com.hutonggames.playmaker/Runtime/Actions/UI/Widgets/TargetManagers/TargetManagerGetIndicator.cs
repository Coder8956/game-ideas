using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TargetManager)]
    [ConvertibleGroup("TargetManager")]
    [Tooltip("Get the spawned indicator prefab associated with a target in an TargetManager component.")]
    [HelpURL("guides/ui-widgets/target-managers/target-indicator/")]
    public sealed class TargetManagerGetIndicator : BaseAction
    {
        [Tooltip("The TargetManager component.")]
        [SerializeField]
        private BaseTargetManagerVar _manager;

        [Tooltip("World-space target Transform used when adding the indicator.")]
        [SerializeField]
        private TransformVar _target;

        [Tooltip("Store the indicator GameObject.")]
        [SerializeField, OptionalField, WriteOnly]
        private GameObjectRef _indicator;

        [Tooltip("Store the RectTransform of the indicator.")]
        [SerializeField, OptionalField, WriteOnly]
        private RectTransformRef _rectTransform;

        public override bool CanExecute() => CheckParameters(_manager, _target);

        public override void Execute()
        {
            var mgr = _manager.Value;
            if (mgr == null) return;

            var target = _target.Value;
            if (target == null) return;

            GameObject indicatorGo = null;
            RectTransform rect = null;

            // Prefer direct API if both methods exist
            rect        = mgr.GetIndicatorRect(target);
            indicatorGo = rect != null ? rect.gameObject : mgr.GetIndicatorGameObject(target);

            if (_indicator.IsAssigned)
            {
                _indicator.Value = indicatorGo;
            }

            if (_rectTransform.IsAssigned)
            {
                _rectTransform.Value = rect;
            }
        }

        public override string GetSummary() => "Get {_target} indicator from {_manager}";
    }
}
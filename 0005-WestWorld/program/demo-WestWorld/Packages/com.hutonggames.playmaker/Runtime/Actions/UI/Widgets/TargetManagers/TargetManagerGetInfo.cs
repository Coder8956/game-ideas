using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TargetManager)]
    [ConvertibleGroup("TargetManager")]
    [Tooltip("Gets information from a TargetManager component " +
             "(OffscreenIndicator, Minimap, OnscreenTarget, etc.).")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class TargetManagerGetInfo : BaseAction
    {
        [Tooltip("The TargetManager component.")]
        [SerializeField]
        private BaseTargetManagerVar _manager;

        [ActionTarget, WriteOnly]
        [Tooltip("Store the Camera used by this manager.")]
        [SerializeField, OptionalField]
        private CameraRef _camera;

        [ActionTarget, WriteOnly]
        [Tooltip("Store the UI root where indicator prefabs are spawned.")]
        [SerializeField, OptionalField]
        private RectTransformRef _iconRoot;

        [ActionTarget, WriteOnly]
        [Tooltip("Store the number of active target entries.")]
        [SerializeField, OptionalField]
        private IntegerRef _targetCount;

        public override bool CanExecute() => CheckParameters(_manager);

        public override void Execute()
        {
            var mgr = _manager.Value;
            if (mgr == null) return;

            if (_camera.IsAssigned)
                _camera.Value = mgr.TargetCamera;

            if (_iconRoot.IsAssigned)
                _iconRoot.Value = mgr.IndicatorPanel;

            if (_targetCount.IsAssigned)
                _targetCount.Value = mgr.EntryCount; // Added below
        }

        public override string GetSummary()
        {
            return $"Get BaseTargetManager info from {_manager}";
        }
    }
}
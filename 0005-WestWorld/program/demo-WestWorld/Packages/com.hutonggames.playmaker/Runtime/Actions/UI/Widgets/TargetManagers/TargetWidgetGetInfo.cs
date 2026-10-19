using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TargetWidget)]
    [Tooltip("Gets information from a TargetObject component spawned by a UI widget manager " +
             "(OffscreenIndicator, TargetIndicator, Minimap, etc.). " +
             "Useful for customizing indicator UI based on its target and manager.")]
    [MovedFrom(true, null, null, "TargetObjectGetInfo")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class TargetWidgetGetInfo : BaseAction
    {
        [Tooltip("The TargetObject component associated with a spawned UI indicator.")]
        [SerializeField]
        private TargetWidgetVar _targetObject;
        
        [Tooltip("Store the world-space target Transform.")]
        [SerializeField, OptionalField, WriteOnly]
        private TransformRef _target;
        
        [Tooltip("Store the style ID for this indicator.")]
        [SerializeField, OptionalField, WriteOnly]
        private IntegerRef _styleId;
        
        [Tooltip("Store the manager component that controls this indicator (e.g., OffscreenIndicator, TargetIndicator).")]
        [SerializeField, OptionalField, WriteOnly]
        private ComponentRef _manager;

        // --- Manager shortcuts ---
        
        [ActionHeader("Manager")]
        
        [Tooltip("Store the Camera used by the manager, if it is a BaseTargetManager.")]
        [SerializeField, OptionalField, WriteOnly]
        private CameraRef _camera;
        
        [Tooltip("Store the UI root (IconRoot) used by the manager, if it is a BaseTargetManager.")]
        [SerializeField, OptionalField, WriteOnly]
        private RectTransformRef _iconRoot;

        public override bool CanExecute() => CheckParameters(_targetObject);

        public override void Execute()
        {
            var to = _targetObject.Value;
            if (to == null)
                return;

            // Basic info
            if (_target.IsAssigned)
                _target.Value = to.Target;

            if (_styleId.IsAssigned)
                _styleId.Value = to.StyleId;

            var manager = to.Manager;

            if (_manager.IsAssigned)
                _manager.Value = manager;

            // Manager shortcuts (only if manager is a BaseTargetManager)
            if (manager is BaseTargetManager baseManager)
            {
                if (_camera.IsAssigned)
                    _camera.Value = baseManager.TargetCamera;

                if (_iconRoot.IsAssigned)
                    _iconRoot.Value = baseManager.IndicatorPanel;
            }
        }
        public override string GetSummary() => 
            "Get {_targetObject} target info {_target:output} {_styleId:output} {_manager:output} {_camera:output} {_iconRoot:output}";
    }
}
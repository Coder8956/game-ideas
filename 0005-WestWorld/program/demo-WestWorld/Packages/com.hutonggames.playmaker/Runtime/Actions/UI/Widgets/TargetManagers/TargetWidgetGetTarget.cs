using System;
using HutongGames.PlayMaker.UI;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.TargetWidget)]
    [Tooltip("Gets the Target from a TargetObject component spawned by a UI widget manager " +
             "(OffscreenIndicator, TargetIndicator, Minimap, etc.). " +
             "Useful for customizing indicator UI based on its target and manager. " +
             "Use TargetObjectGetInfo to get more information from the TargetObject component.")]
    [MovedFrom(true, null, null, "TargetObjectGetTarget")]
    [HelpURL("guides/ui-widgets/target-managers")]
    public sealed class TargetWidgetGetTarget : BaseAction
    {
        [Tooltip("The TargetObject component associated with a spawned UI indicator.")]
        [SerializeField]
        private TargetWidgetVar _targetObject;
        
        [Tooltip("Store the world-space target Transform.")]
        [SerializeField, WriteOnly]
        private TransformRef _target;

        public override bool CanExecute() => CheckParameters(_targetObject, _target);

        public override void Execute()
        {
            var to = _targetObject.Value;
            if (to == null)
                return;
            
            if (_target.IsAssigned)
                _target.Value = to.Target;
        }
        public override string GetSummary() => "Get {_targetObject} target -> {_target}";
    }
}
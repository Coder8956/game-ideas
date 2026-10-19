using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [HasSceneGUI]
    [Serializable, PublicAPI]
    [ActionCategory(Category.Tween)]
    [ConvertibleGroup(ConvertibleGroup.Tween)]
    [ActionDescription("Tween a GameObject's Scale." +
                       "\n\nNOTE: Start and End Scales are set when the tween starts.")]
    public class TweenScale : GameObjectTweenAction
    {
        [DisplayName("From")]
        [Tooltip("Start scale for the Tween.")]
        [SerializeReference]
        [DefaultValue(typeof(CurrentScaleBlock))]
        public BaseScaleBlock StartScale;
        
        [DisplayName("To")]
        [Tooltip("End scale of the Tween.")]
        [SerializeReference]
        [DefaultValue(typeof(LocalScaleBlock))]
        public BaseScaleBlock EndScale;

        [NonSerialized] private Vector3 _startScale;
        [NonSerialized] private Vector3 _endScale;

        public override void OnStart()
        {
            base.OnStart();

            _startScale = StartScale?.GetScale() ?? TargetTransform.localScale;
            _endScale = EndScale.GetScale();

            // We measure distance as the largest difference between any scale axis.
            var scaleDiff = _endScale - _startScale;
            Distance = Mathf.Max(Mathf.Abs(scaleDiff.x), Mathf.Abs(scaleDiff.y), Mathf.Abs(scaleDiff.z));
        }
        
        public override bool CanExecute() => base.CanExecute() && StartScale.IsValid && EndScale.IsValid;

        public override void Execute()
        {
            base.Execute();

            GameObject.Value.transform.localScale = Vector3.Lerp(_startScale, _endScale, Easing.Evaluate(Progress));
        }
        
        public override string GetSummary() => 
            "Tween {GameObject} Scale from {StartScale} to {EndScale}" + base.GetSummary();
    }
}
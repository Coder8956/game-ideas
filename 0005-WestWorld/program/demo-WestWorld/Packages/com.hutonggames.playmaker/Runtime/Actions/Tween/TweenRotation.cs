using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [HasSceneGUI]
    [Serializable, PublicAPI]
    [ActionCategory(Category.Tween)]
    [ConvertibleGroup(ConvertibleGroup.Tween)]
    [ActionDescription("Tween a GameObject's Rotation." +
                       "\n\nNOTE: Start and End Rotations are set when the tween starts.")]
    public class TweenRotation : GameObjectTweenAction
    {
        [DisplayName("From")]
        [Tooltip("Start rotation for the Tween.")]
        [SerializeReference]
        [DefaultValue(typeof(CurrentRotationBlock))]
        public BaseRotationBlock StartRotation;
        
        [DisplayName("To")]
        [Tooltip("End rotation of the Tween.")]
        [SerializeReference]
        [DefaultValue(typeof(RotationBlock))]
        public BaseRotationBlock EndRotation;

        [NonSerialized] private Quaternion _startRotation;
        [NonSerialized] private Quaternion _endRotation;

        public override void OnStart()
        {
            base.OnStart();

            _startRotation = StartRotation?.GetRotation() ?? TargetTransform.rotation;
            _endRotation = EndRotation?.GetRotation() ?? TargetTransform.rotation;

            // Measure distance between StartRotation and EndRotation for speed based tweens.
            // This needs testing...
            Distance = Quaternion.Angle(_startRotation, _endRotation);
        }
        
        public override bool CanExecute() => base.CanExecute() && StartRotation.IsValid && EndRotation.IsValid;

        public override void Execute()
        {
            base.Execute();

            GameObject.Value.transform.rotation = Quaternion.Slerp(_startRotation, _endRotation, Easing.Evaluate(Progress));
        }
        
        public override string GetSummary() => 
            "Tween {GameObject} Rotation from {StartRotation} to {EndRotation}" + base.GetSummary();
    }
}
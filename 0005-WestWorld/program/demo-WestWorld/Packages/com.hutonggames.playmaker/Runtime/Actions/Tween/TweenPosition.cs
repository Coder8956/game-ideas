
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Modular Tween Position action.
    /// </summary>
    /// <remarks>
    /// Note: We use SerializeReference even when we don't need
    /// polymorphism to allow for null values.
    /// TODO: Profile this.
    /// </remarks>
    [HasSceneGUI]
    [Serializable, PublicAPI]
    [ActionCategory(Category.Tween)]
    [ConvertibleGroup(ConvertibleGroup.Tween)]
    [ActionDescription("Tween a GameObject's Position." +
                       "\n\nNOTE: Start and End Positions are set when the tween starts.")]
    public class TweenPosition : GameObjectTweenAction
    {
        [DisplayName("From")]
        [Tooltip("Start position for the Tween.")]
        [SerializeReference]
        [DefaultValue(typeof(CurrentPositionBlock))]
        public BasePositionBlock StartPosition;
        
        [DisplayName("To")]
        [Tooltip("End position of the Tween.")]
        [SerializeReference]
        [DefaultValue(typeof(WorldPositionBlock))]
        public BasePositionBlock EndPosition;

        [NonSerialized] private Vector3 _startPosition;
        [NonSerialized] private Vector3 _endPosition;

        public Vector3 GetStartPosition() => StartPosition?.GetWorldPosition() ?? TargetTransform.position;

        public Vector3 GetEndPosition() => EndPosition?.GetWorldPosition() ?? TargetTransform.position;

        public override void OnStart()
        {
            base.OnStart();
            
            _startPosition = GetStartPosition();
            _endPosition = GetEndPosition();

            Distance = Vector3.Distance(_startPosition, _endPosition);
        }

        public override bool CanExecute() => base.CanExecute() && StartPosition.IsValid && EndPosition.IsValid;

        public override void Execute()
        {
            base.Execute();

            GameObject.Value.transform.position = Vector3.Lerp(_startPosition, _endPosition, Easing.Evaluate(Progress));
        }
        
        public override string GetSummary() => 
            "Tween {GameObject} position from {StartPosition} to {EndPosition}" + base.GetSummary();
    }
}


using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [HasSceneGUI]
    [ActionCategory(Category.PhysicsQueries)]
    [ActionDescription("Casts a ray against all colliders in the Scene. " +
                       "Use configurable action blocks to set up the ray.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Raycast.html")]
    [MovedFrom(true, null, null, "PhysicsRayCast__Options")]
    public class PhysicsRaycast__Options : BaseAction
    {
        [DisplayName("From")]
        [Tooltip("Start point of the RayCast.")]
        [SerializeReference]
        [DefaultValue(typeof(CurrentPositionBlock))]
        private BasePositionBlock _start;
        
        [DisplayName("Direction")]
        [Tooltip("Direction of the RayCast.")]
        [SerializeReference]
        [DefaultValue(typeof(VectorDirectionBlock))]
        private BaseDirectionBlock _direction;
        
        [DefaultValue("~MathfInfinity")]
        [Tooltip("The maximum distance the RayCast can travel. Set to -1 for infinity.")]
        [SerializeField]
        private FloatVar _maxDistance;

        [OptionalField]
        [Tooltip("Filter the objects hit by the RayCast.")]
        [SerializeReference]
        private RaycastFilterBlock _filters;

        [OptionalField]
        [DisplayName("Debug")]
        [Tooltip("Debug the RayCast.")]
        [SerializeReference]
        private DebugRayBlock _debugRay;

        [OptionalField, WriteOnly]
        [Tooltip("Store hit information from the raycast.")]
        [SerializeField]
        private RaycastHitRef _storeResult;

        [OptionalField, WriteOnly]
        [Tooltip("Store whether the raycast hit something.")]
        [SerializeField]
        private BoolRef _didHit;
        
        [OptionalField]
        [Tooltip("Event to send if the ray hits something.")]
        public EventRef HitEvent;

        [OptionalField]
        [Tooltip("Event to send if the ray doesn't hit something.")]
        public EventRef NotHitEvent;
        
        public Vector3 StartPosition => _start?.GetWorldPosition() ?? TargetTransform.position;
        
        public Vector3 EndPosition
        {
            get
            {
                if (_direction == null) return StartPosition;
                _direction.SetStartPosition(StartPosition);
                return StartPosition + _direction.GetDirection();
            }
        }

        public DebugRayBlock DebugRay => _debugRay;
        
        public override void Execute()
        {
            if (_start.IsInvalid || _direction.IsInvalid) return;
            
            var layerMask = _filters?.LayerMask.Value ?? Physics.DefaultRaycastLayers;
            var useTriggers = _filters?.UseTriggers ?? QueryTriggerInteraction.UseGlobal;

            bool didHit;
            var startPosition = _start.GetWorldPosition();
            var direction = _direction.GetDirection();
            var maxDistance = _maxDistance.Value;
            
            if (_storeResult.HasValue())
            {
                didHit = Physics.Raycast(startPosition, direction, out var raycastHitInfo, maxDistance, layerMask, useTriggers);
                _storeResult.Value = raycastHitInfo;
            }
            else
            {
                didHit = Physics.Raycast(startPosition, direction, maxDistance, layerMask, useTriggers);
            }

            _debugRay?.DrawRay(startPosition, direction);

            if (_didHit.HasValue())
            {
                _didHit.Value = didHit;
            }

            SendEvent(didHit ? HitEvent : NotHitEvent);
        }
        
        public override string GetSummary() => "RayCast from: {_start} dir: {_direction} dist: {_maxDistance} filters: {_filters} {_storeResult:output} {_didHit:output}";
    }
}

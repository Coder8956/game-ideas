using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.PhysicsQueries)]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Raycast.html")]
    public abstract class BasePhysicsRaycast : BaseAction
    {
        public abstract Vector3 StartPosition { get; set; }
        public abstract Vector3 DirectionVector { get; set; }
        public abstract Vector3 EndPosition { get; set; }
        public virtual Quaternion TargetGizmoRotation => Quaternion.identity;
        
        [DefaultValue("~MathfInfinity")]
        [Tooltip("The maximum distance the RayCast can travel. Set to -1 for infinity.")]
        [SerializeField]
        public FloatVar MaxDistance;
        
        [ActionHeader("Filters")]
        
        [Tooltip("A Layer mask that is used to selectively ignore colliders when casting a ray.")]
        [DefaultValue("Physics.DefaultRaycastLayers")]
        [SerializeField]
        protected LayerMaskVar LayerMask;

        [Tooltip("Specifies whether this query should hit Triggers.")]
        [DefaultValue(QueryTriggerInteraction.UseGlobal)]
        [SerializeField]
        protected QueryTriggerInteraction HitTriggers;

        [Tooltip("Should the raycast be blocked by UI.")]
        [SerializeField, DefaultValue(true)]
        protected BoolVar BlockedByUI;

        [ActionHeader("Result")]
        
        [OptionalField]
        [Tooltip("Event to send if the ray hits something.")]
        [SerializeField]
        protected EventRef HitEvent;

        [OptionalField]
        [Tooltip("Event to send if the ray doesn't hit something.")]
        [SerializeField]
        protected EventRef NotHitEvent;
        
        [OptionalField, WriteOnly]
        [Tooltip("Store whether the raycast hit something.")]
        [SerializeField]
        protected BoolRef DidHit;
        
        [OptionalField, WriteOnly]
        [Tooltip("Store hit GameObject from the raycast.")]
        [SerializeField]
        protected GameObjectRef StoreHitObject;

        [OptionalField, WriteOnly]
        [Tooltip("Store hit information from the raycast.")]
        [SerializeField]
        protected RaycastHitRef StoreHitInfo;

        [OptionalField, WriteOnly]
        [Tooltip("Store the Ray used for the raycast (origin + direction in world space).")]
        [SerializeField]
        protected RayRef StoreRay;
        
        [OptionalField]
        [DisplayName("Debug")]
        [Tooltip("Debug the RayCast.")]
        [SerializeReference]
        public DebugRayBlock DebugRay;
        
        public override bool CanExecute() => CheckParameters(LayerMask, HitTriggers );

        public override void Execute()
        {
            var origin    = StartPosition;
            var direction = DirectionVector;

            // Store the ray first so helpers (like AimPoint) always know what was used,
            // even if UI blocks the actual physics cast.
            if (StoreRay.IsAssigned)
            {
                var dir = direction;
                if (dir.sqrMagnitude < 1e-6f)
                {
                    dir = Vector3.forward;
                }
                else
                {
                    dir.Normalize(); // Physics internally normalizes; keep Ray consistent.
                }

                StoreRay.Value = new Ray(origin, dir);
            }

            bool didHit;

            if (BlockedByUI.Value && IsOverUI())
            {
                didHit = false;
            }
            else
            {
                if (StoreHitInfo.HasValue() || StoreHitObject.HasValue())
                {
                    didHit = Physics.Raycast(origin, direction, out var raycastHitInfo, MaxDistance.Value, LayerMask.Value, HitTriggers);
                    if (StoreHitInfo.HasValue())
                    {
                        StoreHitInfo.Value = raycastHitInfo;
                    }

                    if (StoreHitObject.HasValue())
                    {
                        StoreHitObject.Value = raycastHitInfo.collider ? raycastHitInfo.collider.gameObject : null;
                    }
                }
                else
                {
                    didHit = Physics.Raycast(origin, direction, MaxDistance.Value, LayerMask.Value, HitTriggers);
                }
            }
            
            DebugRay?.DrawRay(origin,  direction * Mathf.Min(MaxDistance.Value, 50000));

            if (DidHit.HasValue())
            {
                DidHit.Value = didHit;
            }

            SendEvent(didHit ? HitEvent : NotHitEvent);
        }
        
        protected virtual bool IsOverUI() => EventSystem.current && EventSystem.current.IsPointerOverGameObject();

        public override string GetSummary()
        {
            return (!float.IsInfinity(MaxDistance.Value) ? "Dist {MaxDistance} " : "") +
                   (LayerMask.Value != Physics.DefaultRaycastLayers ? "Mask {LayerMask} " : "") +
                   (HitTriggers != QueryTriggerInteraction.UseGlobal ? "Triggers {HitTriggers} " : "") +
                   (HitEvent.IsSet ? "Hit {HitEvent} " : "") +
                   (NotHitEvent.IsSet ? "Not Hit {NotHitEvent} " : "") + 
                   "{StoreHitInfo:output} {StoreHitObject:output} {DidHit:output} {StoreRay:output}";
        }
    }
}

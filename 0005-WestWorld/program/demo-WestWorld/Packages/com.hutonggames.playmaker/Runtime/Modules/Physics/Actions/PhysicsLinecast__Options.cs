
using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Modular LineCast action.
    /// Proof of concept for ActionBlocks workflow.
    /// </summary>
    /// <remarks>
    /// Note: We use SerializeReference even when we don't need
    /// polymorphism to allow for null values.
    /// TODO: Profile this.
    /// </remarks>
    [HasSceneGUI]
    [Serializable, PublicAPI]
    [ActionCategory(Category.PhysicsQueries)]
    [MovedFrom(true, null, null, "PhysicsLineCast")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Physics.Linecast.html")]
    public class PhysicsLinecast__Options : BaseAction
    {
        [SerializeReference]
        [DisplayName("From")]
        [Tooltip("Start point of the LineCast.")]
        public BasePositionBlock StartPosition;
        
        [SerializeReference]
        [DisplayName("To")]
        [Tooltip("End point of the LineCast.")]
        public BasePositionBlock EndPosition;

        [OptionalField]
        [SerializeReference]
        [Tooltip("Filter the objects hit by the LineCast.")]
        public RaycastFilterBlock Filters;

        [OptionalField]
        [DisplayName("Debug")]
        [SerializeReference]
        [Tooltip("Debug the LineCast.")]
        public DebugRayBlock DebugRay;
        
        [OptionalField]
        [SerializeReference]
        [Tooltip("Get information about the LineCast.")]
        public List<RaycastHitBlock> HitInfo;

        [OptionalField]
        [SerializeReference]
        [Tooltip("Send events based on the results of the LineCast.")]
        public RaycastHitEventsBlock Events;

        public override void Execute()
        {
            if (StartPosition.IsInvalid || EndPosition.IsInvalid) return;
            
            var layerMask = Filters?.LayerMask.Value ?? Physics.DefaultRaycastLayers;
            var useTriggers = Filters?.UseTriggers ?? QueryTriggerInteraction.UseGlobal;

            bool didHit;
            var startPosition = StartPosition.GetWorldPosition();
            var endPosition = EndPosition.GetWorldPosition();
            
            if (HitInfo.Count > 0)
            {
                didHit = Physics.Linecast(startPosition, endPosition, out var hitInfo, layerMask, useTriggers);
                
                // NOTE: we do this whether we hit a collider or not
                // so that hit info also reflects NOT hitting anything.
                // Otherwise the value would be stuck with info from the last hit.
                
                foreach (var getHitInfo in HitInfo)
                {
                    getHitInfo.GetInfo(hitInfo);
                }
            }
            else
            {
                didHit = Physics.Linecast(startPosition, endPosition, layerMask, useTriggers);
            }

            if (DebugRay != null)
            {
                Debug.DrawLine(startPosition, endPosition, DebugRay.RayColor.Value, DebugRay.Duration.Value);
            }

            if (didHit && Events != null)
            {
                SendEvent(Events.HitEvent);
            }

        }
        
        public override string GetSummary() => "LineCast from: {StartPosition} dir: {EndPosition} {Filters}";
    }
}

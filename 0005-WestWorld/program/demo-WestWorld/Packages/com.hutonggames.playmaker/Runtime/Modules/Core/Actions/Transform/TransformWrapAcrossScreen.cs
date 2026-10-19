using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    
    [Serializable, PublicAPI]
    [ActionCategory(Category.GameplayMovementTransform)]
    [ActionDescription("Wrap a transform position across screen edges. " +
                       "E.g. A transform moving off screen left, wraps to screen right.")]
    [HelpURL("actions/transform-actions/transform-clamp-actions/")]
    public class TransformWrapAcrossScreen : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform to wrap.")]
        public TransformVar Transform;

        [DefaultValue("~MainCamera")]
        [Tooltip("The camera viewport used.")]
        public CameraVar Camera;

        [DefaultValue(true)]
        [Tooltip("Wrap the position of the Transform if it moves off the left side of the screen.")]
        public BoolVar WrapLeft;
        
        [DefaultValue(true)]
        [Tooltip("Wrap the position of the Transform if it moves off the right side of the screen.")]
        public BoolVar WrapRight;
        
        [DefaultValue(true)]
        [Tooltip("Wrap the position of the Transform if it moves off the top of the screen.")]
        public BoolVar WrapTop;
        
        [DefaultValue(true)]
        [Tooltip("Wrap the position of the Transform if it moves off the bottom of the screen.")]
        public BoolVar WrapBottom;


        public override bool CanExecute()
        {
            return CheckParameters(Transform, Camera, WrapLeft, WrapRight, WrapTop, WrapBottom);
        }
        
        public override void Execute()
        {
            var camera = Camera.Value;
            if (camera == null) return;
            
            var transform = Transform.Value;
            if (transform == null) return;
            
            var screenPos = camera.WorldToViewportPoint(transform.position);
            var wrapped = false; // only do expensive operations if we wrapped
            
            if (WrapLeft.Value && screenPos.x < 0 ||
                WrapRight.Value && screenPos.x >= 1)
            {
                screenPos.x = Wrap01(screenPos.x);
                wrapped = true;
            }

            if (WrapTop.Value && screenPos.y >= 1 ||
                WrapBottom.Value && screenPos.y < 0)
            {
                screenPos.y = Wrap01(screenPos.y);
                wrapped = true;
            }

            if (wrapped)
            {
                // get z distance from camera to transform new screen position back into world position
                screenPos.z = camera.transform.InverseTransformPoint(transform.position).z;
                transform.position = camera.ViewportToWorldPoint(screenPos);
            }
        }
        
        private static float Wrap01(float x) => Wrap(x, 0, 1);

        private static float Wrap(float x, float xMin, float xMax)
        {
            if (x < xMin)
            {
                x = xMax - (xMin - x) % (xMax - xMin);
            }
            else
            {
                x = xMin + (x - xMin) % (xMax - xMin);
            }

            return x;
        }

        public override string GetSummary() => $"Wrap {{Transform}} across screen edges ({GetEdgesSummary()})";

        private IEnumerable<BoolVar> GetEdges()
        {
            yield return WrapLeft;
            yield return WrapRight;
            yield return WrapTop;
            yield return WrapBottom;
        }

        private string GetEdgeSummary(string name, string varName, BoolVar edgeVar)
        {
            return edgeVar.IsConstantValue ? edgeVar.Value ? $"{name}, " : "" 
                : $"{name}: {varName}";
        }
        
        private string GetEdgesSummary()
        {
            if (GetEdges().All(x => x.IsConstantValue && x.Value))
            {
                return "All";
            }
            
            var edges = "";
            if (WrapLeft.Value) edges += GetEdgeSummary("Left", "WrapLeft", WrapLeft);
            if (WrapRight.Value) edges += GetEdgeSummary("Right", "WrapRight", WrapRight);
            if (WrapTop.Value) edges += GetEdgeSummary("Top", "WrapTop", WrapTop);
            if (WrapBottom.Value) edges += GetEdgeSummary("Bottom", "WrapBottom", WrapBottom);
            return edges.TrimEnd(' ', ',');
        }
    }
}
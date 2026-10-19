using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Position Offscreen 2D")]
    [Tooltip("Generate a random 2D world position outside a camera's view, with optional padding.")]
    public class RandomPositionOffscreenGeneratorBlock2D : SpawnPositionGeneratorBlock2D
    {
        [Tooltip("The Camera to sample against. Uses MainCamera if not specified.")]
        public CameraVar Camera;

        [Tooltip("How to define the sampling plane.")]
        public OffscreenPlacementMode PlacementMode;

        [DefaultValue(10f)]
        [Tooltip("Z value of the sampling plane. In CameraDepth mode this is depth from the camera origin. In WorldZ mode this is the world-space Z coordinate.")]
        public FloatVar ZPlane;

        [DefaultValue(0f)]
        [Tooltip("Extra world-space padding beyond the viewport edges, measured on the sampling plane.")]
        public FloatVar Padding;

        public override bool IsValid => true;

        public override bool CanExecute() => Action.CheckParameters(ZPlane, Padding);

        public override void Generate(FindValidRandomPosition2D action)
        {
            var camera = Camera == null || Camera.Value.IsUnityNull() ? UnityEngine.Camera.main : Camera.Value;
            var point = OffscreenPositionUtility.GetRandomOffscreenWorldPoint(
                camera,
                PlacementMode,
                ZPlane.Value,
                Padding.Value);

            action.CandidatePosition = new Vector2(point.x, point.y);
        }

        public override string GetSummary() => "Random offscreen position 2D";
    }
}

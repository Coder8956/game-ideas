using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomPosition)]
    [ActionDescription("Get a random world point outside a camera's view at a given z depth, with optional padding to keep spawned objects offscreen.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ViewportToWorldPoint.html")]
    public class RandomGetPointOffscreen : BaseAction
    {
        [Tooltip("The Camera to sample against. Uses MainCamera if not specified.")]
        [SerializeField, DefaultValue("~MainCamera"), OptionalField]
        private CameraVar _camera;

        [Tooltip("How to define the sampling plane.")]
        [SerializeField, DefaultValue(OffscreenPlacementMode.CameraDepth)]
        private OffscreenPlacementMode _placementMode;

        [Tooltip("Z value of the sampling plane. In CameraDepth mode this is depth from the camera origin. In WorldZ mode this is the world-space Z coordinate.")]
        [SerializeField, DefaultValue(10f)]
        private FloatVar _zPlane;

        [Tooltip("Extra world-space padding beyond the viewport edges, measured on the sampling plane at the given z depth.")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _padding;

        [Tooltip("Store the random world point in a Vector3 variable.")]
        [SerializeField, WriteOnly, DefaultName("RandomPoint")]
        private Vector3Ref _storeResult;

        public override bool CanExecute() => CheckParameters(_zPlane, _padding, _storeResult);

        public override void Execute()
        {
            var camera = _camera == null || _camera.Value.IsUnityNull() ? Camera.main : _camera.Value;
            if (camera == null)
            {
                return;
            }
            _storeResult.Value = OffscreenPositionUtility.GetRandomOffscreenWorldPoint(
                camera,
                _placementMode,
                _zPlane.Value,
                _padding.Value);
        }

        public override string GetSummary()
        {
            return "Get random point offscreen {_storeResult:output}";
            //return $"Get random point offscreen at {_placementMode} {{_zPlane}} -> {{_storeResult}}";
        }
    }
}

using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.Camera)]
    [ConvertibleGroup("ScreenToWorldPoint")]
    // ReSharper disable once InconsistentNaming
    [System.Serializable]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html")]
    public class CameraScreenToWorldPoint__Vector3 : BaseAction
    {
        [DefaultValue("~MainCamera")]
        [Tooltip("Camera used to convert the screen point to a world point.")]
        public CameraVar Camera;
        
        [Tooltip("A screen space position, including Z depth.")]
        public Vector3Var ScreenPoint;
        
        [Tooltip("Does the screen point use normalized coordinates (0-1).")]
        public BoolVar NormalizedCoordinates;

        [WriteOnly]
        [Tooltip("The world space point created by converting the screen space point at the provided distance z from the camera plane.")]
        public Vector3Ref WorldPoint;

        public override bool CanExecute()
        {
            return CheckParameters(Camera, ScreenPoint, NormalizedCoordinates) && WorldPoint.IsAssigned;
        }

        public override string GetSummary() => Camera.Value == UnityEngine.Camera.main
            ? "Convert screen point {ScreenPoint} to world point {WorldPoint}"
            : "Convert {Camera} screen point {ScreenPoint} to world point {WorldPoint}";
        
        public override void Execute()
        {
            var screenPos = ScreenPoint.Value;
            if (NormalizedCoordinates.Value)
            {
                screenPos.x *= Screen.width;
                screenPos.y *= Screen.height;
            }
            WorldPoint.Value = Camera.Value.ScreenToWorldPoint(screenPos);
        }
    }
}

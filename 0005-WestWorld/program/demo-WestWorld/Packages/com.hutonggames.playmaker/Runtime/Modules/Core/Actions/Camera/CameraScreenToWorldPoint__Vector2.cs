using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.Camera)]
    [ConvertibleGroup("CameraScreenToWorldPoint")]
    // ReSharper disable once InconsistentNaming
    [System.Serializable]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html")]
    public class CameraScreenToWorldPoint__Vector2 : BaseAction
    {
        [DefaultValue("~MainCamera")]
        [Tooltip("Camera used to convert the screen point to a world point.")]
        public CameraVar Camera;
        
        [Tooltip("A screen space position.")]
        public Vector2Var ScreenPoint;
        
        [DefaultValue(1f)]
        [Tooltip("Z position for depth (for example, a camera clipping plane).")]
        public FloatVar ZDepth;
        
        [Tooltip("Does the screen point use normalized coordinates (0-1).")]
        public BoolVar NormalizedCoordinates;

        [WriteOnly]
        [Tooltip("The world space point created by converting the screen space point at the provided distance z from the camera plane.")]
        public Vector3Ref WorldPoint;

        public override bool CanExecute()
        {
            return CheckParameters(Camera, ScreenPoint, ZDepth, NormalizedCoordinates) && WorldPoint.IsAssigned;
        }
        
        public override void Execute()
        {
            var screenPos = new Vector3(ScreenPoint.Value.x, ScreenPoint.Value.y, ZDepth.Value);
            if (NormalizedCoordinates.Value)
            {
                screenPos.x *= Screen.width;
                screenPos.y *= Screen.height;
            }
            WorldPoint.Value = Camera.Value.ScreenToWorldPoint(screenPos);
        }

        public override string GetSummary() => "Convert screen point {ScreenPoint} to world point {WorldPoint}";
    }
}

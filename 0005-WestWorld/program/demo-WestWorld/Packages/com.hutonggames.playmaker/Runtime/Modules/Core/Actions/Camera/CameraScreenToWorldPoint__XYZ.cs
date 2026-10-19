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
    public class CameraScreenToWorldPoint__XYZ : BaseAction
    {
        [DefaultValue("~MainCamera")]
        [Tooltip("Camera used to convert the screen point to a world point.")]
        public CameraVar Camera;
        
        [Tooltip("X coordinate in screen space.")]
        public FloatVar ScreenX;
        
        [Tooltip("Y coordinate in screen space.")]
        public FloatVar ScreenY;
        
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
            return CheckParameters(ScreenX, ScreenY, ZDepth, NormalizedCoordinates, WorldPoint);
        }
        
        public override void Execute()
        {
            if (!Camera.HasValue())             
            {
                LogRuntimeError("Could not find a MainCamera!");
                return;
            }
            
            var screenPos = new Vector3(ScreenX.Value, ScreenY.Value, ZDepth.Value);
            if (NormalizedCoordinates.Value)
            {
                screenPos.x *= Screen.width;
                screenPos.y *= Screen.height;
            }
            WorldPoint.Value = Camera.Value.ScreenToWorldPoint(screenPos);
        }

        public override string GetSummary() => "Convert screen point ({ScreenX}, {ScreenY}, {ZDepth}) to world point {WorldPoint}";
    }
}


using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	/*
    TODO: Do we need special support for HDRP and URP?
    
    #if _HDRP
        cam.GetComponent<HDRPAdaptiveCameraData>().backgroundColor = color;
    #else
        cam.backgroundColor = color;
    #endif
    			
    */
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The color with which the screen will be cleared.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-backgroundColor.html")]
	public sealed class CameraSetBackgroundColor : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Background Color")]
		[SerializeField]
		private ColorVar _setBackgroundColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setBackgroundColor);
		}
		
		public override void Execute()
		{
			_camera.Value.backgroundColor = _setBackgroundColor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} background color to {_setBackgroundColor}";
		}
	}
}

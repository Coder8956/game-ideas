
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Image)]
	[ActionDescription("See:ICanvasRaycastFilter.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Image.html")]
	public sealed class ImageIsRaycastLocationValid : BaseAction
	{
		
		[Tooltip("The Image.")]
		[SerializeField]
		private ImageVar _image;
		
		[Tooltip("Screen Point.")]
		[SerializeField]
		private Vector2Var _screenPoint;
		
		[Tooltip("Event Camera.")]
		[SerializeField]
		private CameraVar _eventCamera;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_image, _screenPoint, _eventCamera, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Image.IsRaycastLocationValid(UnityEngine.Vector2, UnityEngine.Camera);
			_result.Value = _image.Value.IsRaycastLocationValid(_screenPoint.Value, _eventCamera.Value);
		}
		
		public override string GetSummary()
		{
			return "Check {_image} raycast location {_screenPoint} {_eventCamera} -> {_result}";
		}
	}
}

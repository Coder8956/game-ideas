
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Set the camera rect to match an aspect ratio, either Letterboxing or Pillarboxing the view.")]
	[MovedFrom(true, null, null, "CameraSetRectAspect")]
	public sealed class CameraSetRectToAspectRatio : BaseAction
	{
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("The aspect ratio to match.")]
		[SerializeField]
		private Vector2Var _aspectRatio;

		public override void Reset()
		{
			_aspectRatio = new Vector2Var { Value = new Vector2(16, 9) };
		}
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _aspectRatio);
		}
		
		public override void Execute()
		{
			var camera = _camera.Value;
			var aspectRatio = _aspectRatio.Value;
			var targetAspectRatio = aspectRatio.x / aspectRatio.y;
			var currentAspectRatio = (float)Screen.width / Screen.height;
			var scaleHeight = currentAspectRatio / targetAspectRatio;

			if (scaleHeight < 1.0f)
			{
				// Letterboxing
				var rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
				camera.rect = rect;
			}
			else
			{
				// Pillarboxing
				var scaleWidth = 1.0f / scaleHeight;
				var rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
				camera.rect = rect;
			}
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} aspect ratio to {_aspectRatio}";
		}
	}
}


using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Get the view projection matrix used on the last frame.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-previousViewProjectionMatrix.html" +
		"")]
	public sealed class CameraGetPreviousViewProjectionMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Previous View Projection Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getPreviousViewProjectionMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getPreviousViewProjectionMatrix);
		}
		
		public override void Execute()
		{
			_getPreviousViewProjectionMatrix.Value = _camera.Value.previousViewProjectionMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} previous view projection matrix -> {_getPreviousViewProjectionMatrix}";
		}
	}
}

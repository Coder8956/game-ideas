
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Render the camera manually.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.Render.html")]
	public sealed class CameraRender : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.Render();
			_camera.Value.Render();
		}
		
		public override string GetSummary()
		{
			return "Render {_camera}";
		}
	}
}

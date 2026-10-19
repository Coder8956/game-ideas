
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Remove all command buffers set on this camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.RemoveAllCommandBuffers.html")]
	public sealed class CameraRemoveAllCommandBuffers : BaseAction
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
			//UnityEngine.Camera.RemoveAllCommandBuffers();
			_camera.Value.RemoveAllCommandBuffers();
		}
		
		public override string GetSummary()
		{
			return "Remove all command buffers from {_camera}";
		}
	}
}

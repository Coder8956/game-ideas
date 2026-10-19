
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Remove command buffers from execution at a specified place.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.RemoveCommandBuffers.html")]
	public sealed class CameraRemoveCommandBuffers : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("When to execute the command buffer during rendering.")]
		[SerializeField]
		private CameraEvent _evt;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _evt);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.RemoveCommandBuffers(UnityEngine.Rendering.CameraEvent);
			_camera.Value.RemoveCommandBuffers(_evt);
		}
		
		public override string GetSummary()
		{
			return "Remove {_camera} command buffers {_evt}";
		}
	}
}

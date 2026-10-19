
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Number of command buffers set up on this camera (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-commandBufferCount.html")]
	public sealed class CameraGetCommandBufferCount : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Command Buffer Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getCommandBufferCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getCommandBufferCount);
		}
		
		public override void Execute()
		{
			_getCommandBufferCount.Value = _camera.Value.commandBufferCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} command buffer count -> {_getCommandBufferCount}";
		}
	}
}

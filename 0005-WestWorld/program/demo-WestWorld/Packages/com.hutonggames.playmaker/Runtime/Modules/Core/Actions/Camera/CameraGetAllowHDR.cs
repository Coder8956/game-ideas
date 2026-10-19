
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("High dynamic range rendering.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-allowHDR.html")]
	public sealed class CameraGetAllowHDR : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Allow HDR")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAllowHDR;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getAllowHDR);
		}
		
		public override void Execute()
		{
			_getAllowHDR.Value = _camera.Value.allowHDR;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} allow HDR -> {_getAllowHDR}";
		}
	}
}


using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("MSAA rendering.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-allowMSAA.html")]
	public sealed class CameraGetAllowMSAA : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Allow MSAA")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAllowMSAA;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getAllowMSAA);
		}
		
		public override void Execute()
		{
			_getAllowMSAA.Value = _camera.Value.allowMSAA;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} allow MSAA -> {_getAllowMSAA}";
		}
	}
}

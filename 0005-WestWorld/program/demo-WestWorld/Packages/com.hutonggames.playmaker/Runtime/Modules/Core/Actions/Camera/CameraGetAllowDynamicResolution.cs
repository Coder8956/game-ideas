
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Dynamic Resolution Scaling.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-allowDynamicResolution.html")]
	public sealed class CameraGetAllowDynamicResolution : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Allow Dynamic Resolution")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAllowDynamicResolution;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getAllowDynamicResolution);
		}
		
		public override void Execute()
		{
			_getAllowDynamicResolution.Value = _camera.Value.allowDynamicResolution;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} allow dynamic resolution -> {_getAllowDynamicResolution}";
		}
	}
}

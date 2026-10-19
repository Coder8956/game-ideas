
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Whether or not the Camera will use occlusion culling during rendering.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-useOcclusionCulling.html")]
	public sealed class CameraGetUseOcclusionCulling : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Use Occlusion Culling")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseOcclusionCulling;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getUseOcclusionCulling);
		}
		
		public override void Execute()
		{
			_getUseOcclusionCulling.Value = _camera.Value.useOcclusionCulling;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} use occlusion culling -> {_getUseOcclusionCulling}";
		}
	}
}

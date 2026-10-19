
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
	public sealed class CameraSetUseOcclusionCulling : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Use Occlusion Culling")]
		[SerializeField]
		private BoolVar _setUseOcclusionCulling;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setUseOcclusionCulling);
		}
		
		public override void Execute()
		{
			_camera.Value.useOcclusionCulling = _setUseOcclusionCulling.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} use occlusion culling to {_setUseOcclusionCulling}";
		}
	}
}

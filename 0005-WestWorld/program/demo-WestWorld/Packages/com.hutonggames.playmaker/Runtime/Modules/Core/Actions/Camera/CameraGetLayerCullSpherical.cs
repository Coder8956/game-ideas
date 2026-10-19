
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("How to perform per-layer culling for a Camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-layerCullSpherical.html")]
	public sealed class CameraGetLayerCullSpherical : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Layer Cull Spherical")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getLayerCullSpherical;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getLayerCullSpherical);
		}
		
		public override void Execute()
		{
			_getLayerCullSpherical.Value = _camera.Value.layerCullSpherical;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} layer cull spherical -> {_getLayerCullSpherical}";
		}
	}
}

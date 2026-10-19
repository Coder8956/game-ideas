
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
	public sealed class CameraSetLayerCullSpherical : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Layer Cull Spherical")]
		[SerializeField]
		private BoolVar _setLayerCullSpherical;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setLayerCullSpherical);
		}
		
		public override void Execute()
		{
			_camera.Value.layerCullSpherical = _setLayerCullSpherical.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} layer cull spherical to {_setLayerCullSpherical}";
		}
	}
}

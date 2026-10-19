
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Per-layer culling distances.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-layerCullDistances.html")]
	public sealed class CameraGetLayerCullDistances : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Layer Cull Distances")]
		[SerializeField]
		[WriteOnly]
		private FloatListRef _getLayerCullDistances;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getLayerCullDistances);
		}
		
		public override void Execute()
		{
			_getLayerCullDistances.Values = _camera.Value.layerCullDistances;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} layer cull distances -> {_getLayerCullDistances}";
		}
	}
}

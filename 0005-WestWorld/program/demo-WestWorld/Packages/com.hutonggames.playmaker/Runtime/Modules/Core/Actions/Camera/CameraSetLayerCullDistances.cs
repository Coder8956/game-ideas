
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
	public sealed class CameraSetLayerCullDistances : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Layer Cull Distances")]
		[SerializeField]
		private FloatListVar _setLayerCullDistances;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setLayerCullDistances);
		}
		
		public override void Execute()
		{
			_camera.Value.layerCullDistances = _setLayerCullDistances.Values;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} layer cull distances to {_setLayerCullDistances}";
		}
	}
}


using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The camera anamorphism. To use this property, enable UsePhysicalProperties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-anamorphism.html")]
	public sealed class CameraGetAnamorphism : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Anamorphism")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAnamorphism;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getAnamorphism);
		}
		
		public override void Execute()
		{
			_getAnamorphism.Value = _camera.Value.anamorphism;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} anamorphism -> {_getAnamorphism}";
		}
	}
}

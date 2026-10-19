
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
	public sealed class CameraSetAnamorphism : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Anamorphism")]
		[SerializeField]
		private FloatVar _setAnamorphism;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setAnamorphism);
		}
		
		public override void Execute()
		{
			_camera.Value.anamorphism = _setAnamorphism.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} anamorphism to {_setAnamorphism}";
		}
	}
}

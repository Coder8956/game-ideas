
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The focus distance of the lens. To use this property, enable UsePhysicalPropertie" +
		"s.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-focusDistance.html")]
	public sealed class CameraSetFocusDistance : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Focus Distance")]
		[SerializeField]
		private FloatVar _setFocusDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setFocusDistance);
		}
		
		public override void Execute()
		{
			_camera.Value.focusDistance = _setFocusDistance.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} focus distance to {_setFocusDistance}";
		}
	}
}


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
	public sealed class CameraGetFocusDistance : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Focus Distance")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFocusDistance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getFocusDistance);
		}
		
		public override void Execute()
		{
			_getFocusDistance.Value = _camera.Value.focusDistance;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} focus distance -> {_getFocusDistance}";
		}
	}
}

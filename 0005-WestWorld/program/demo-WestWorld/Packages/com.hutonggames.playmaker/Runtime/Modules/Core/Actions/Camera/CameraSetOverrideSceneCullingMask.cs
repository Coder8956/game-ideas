
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Sets the culling mask used to determine which objects from which Scenes to draw. " +
		"See EditorSceneManager.SetSceneCullingMask.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-overrideSceneCullingMask.html")]
	public sealed class CameraSetOverrideSceneCullingMask : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Override Scene Culling Mask")]
		[SerializeField]
		private ULongVar _setOverrideSceneCullingMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setOverrideSceneCullingMask);
		}
		
		public override void Execute()
		{
			_camera.Value.overrideSceneCullingMask = _setOverrideSceneCullingMask.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} override scene culling mask to {_setOverrideSceneCullingMask}";
		}
	}
}

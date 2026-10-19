
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
	public sealed class CameraGetOverrideSceneCullingMask : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Override Scene Culling Mask")]
		[SerializeField]
		[WriteOnly]
		private ULongRef _getOverrideSceneCullingMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getOverrideSceneCullingMask);
		}
		
		public override void Execute()
		{
			_getOverrideSceneCullingMask.Value = _camera.Value.overrideSceneCullingMask;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} override scene culling mask -> {_getOverrideSceneCullingMask}";
		}
	}
}

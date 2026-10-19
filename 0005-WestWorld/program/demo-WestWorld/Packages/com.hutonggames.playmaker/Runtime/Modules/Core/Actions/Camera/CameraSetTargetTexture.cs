
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Destination render texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-targetTexture.html")]
	public sealed class CameraSetTargetTexture : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Target Texture")]
		[SerializeField, CanBeNullOrEmpty]
		private RenderTextureVar _setTargetTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera);
		}
		
		public override void Execute()
		{
			_camera.Value.targetTexture = _setTargetTexture.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} target texture to {_setTargetTexture}";
		}
	}
}

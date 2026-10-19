
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Render the camera with shader replacement.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.RenderWithShader.html")]
	public sealed class CameraRenderWithShader : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Shader.")]
		[SerializeField]
		private ShaderVar _shader;
		
		[Tooltip("Replacement Tag.")]
		[SerializeField]
		private StringVar _replacementTag;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _shader, _replacementTag);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.RenderWithShader(UnityEngine.Shader, System.String);
			_camera.Value.RenderWithShader(_shader.Value, _replacementTag.Value);
		}
		
		public override string GetSummary()
		{
			return "Render {_camera} with shader {_shader} {_replacementTag}";
		}
	}
}


using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Make the camera render with shader replacement.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.SetReplacementShader.html")]
	public sealed class CameraSetReplacementShader : BaseAction
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
			//UnityEngine.Camera.SetReplacementShader(UnityEngine.Shader, System.String);
			_camera.Value.SetReplacementShader(_shader.Value, _replacementTag.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} replacement shader {_shader} {_replacementTag}";
		}
	}
}

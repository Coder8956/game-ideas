
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("The current threshold for Sprite Renderer tiling.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-adaptiveModeThreshold.htm" +
		"l")]
	public sealed class SpriteRendererGetAdaptiveModeThreshold : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Adaptive Mode Threshold")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAdaptiveModeThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getAdaptiveModeThreshold);
		}
		
		public override void Execute()
		{
			_getAdaptiveModeThreshold.Value = _spriteRenderer.Value.adaptiveModeThreshold;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Adaptive Mode Threshold -> {_getAdaptiveModeThreshold}";
		}
	}
}


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
	public sealed class SpriteRendererSetAdaptiveModeThreshold : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Adaptive Mode Threshold")]
		[SerializeField]
		private FloatVar _setAdaptiveModeThreshold;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _setAdaptiveModeThreshold);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.adaptiveModeThreshold = _setAdaptiveModeThreshold.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Adaptive Mode Threshold to {_setAdaptiveModeThreshold}";
		}
	}
}

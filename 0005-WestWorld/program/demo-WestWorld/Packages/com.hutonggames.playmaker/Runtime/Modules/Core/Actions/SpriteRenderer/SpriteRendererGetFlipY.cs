
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Flips the sprite on the Y axis.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-flipY.html")]
	public sealed class SpriteRendererGetFlipY : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Flip Y")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getFlipY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getFlipY);
		}
		
		public override void Execute()
		{
			_getFlipY.Value = _spriteRenderer.Value.flipY;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Flip Y -> {_getFlipY}";
		}
	}
}

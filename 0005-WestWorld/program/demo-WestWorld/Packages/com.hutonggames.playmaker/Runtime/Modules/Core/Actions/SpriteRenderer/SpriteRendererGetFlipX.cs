
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Flips the sprite on the X axis.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-flipX.html")]
	public sealed class SpriteRendererGetFlipX : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Flip X")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getFlipX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getFlipX);
		}
		
		public override void Execute()
		{
			_getFlipX.Value = _spriteRenderer.Value.flipX;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Flip X -> {_getFlipX}";
		}
	}
}

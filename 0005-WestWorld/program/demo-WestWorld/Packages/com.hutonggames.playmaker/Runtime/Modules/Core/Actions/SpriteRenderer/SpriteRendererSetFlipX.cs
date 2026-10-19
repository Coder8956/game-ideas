
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
	public sealed class SpriteRendererSetFlipX : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Flip X")]
		[SerializeField]
		private BoolVar _setFlipX;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _setFlipX);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.flipX = _setFlipX.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Flip X to {_setFlipX}";
		}
	}
}

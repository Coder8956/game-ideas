
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
	public sealed class SpriteRendererSetFlipY : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Flip Y")]
		[SerializeField]
		private BoolVar _setFlipY;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _setFlipY);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.flipY = _setFlipY.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Flip Y to {_setFlipY}";
		}
	}
}

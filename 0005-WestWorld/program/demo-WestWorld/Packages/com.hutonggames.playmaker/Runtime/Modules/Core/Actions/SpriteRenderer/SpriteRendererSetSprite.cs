
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("The Sprite to render.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-sprite.html")]
	public sealed class SpriteRendererSetSprite : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Sprite")]
		[SerializeField, CanBeNullOrEmpty]
		private SpriteVar _setSprite;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.sprite = _setSprite.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Sprite to {_setSprite}";
		}
	}
}

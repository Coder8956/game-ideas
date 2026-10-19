
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("The Sprite to render.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-sprite.html")]
	public sealed class SpriteRendererGetSprite : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Sprite")]
		[SerializeField]
		[WriteOnly]
		private SpriteRef _getSprite;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getSprite);
		}
		
		public override void Execute()
		{
			_getSprite.Value = _spriteRenderer.Value.sprite;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Sprite -> {_getSprite}";
		}
	}
}

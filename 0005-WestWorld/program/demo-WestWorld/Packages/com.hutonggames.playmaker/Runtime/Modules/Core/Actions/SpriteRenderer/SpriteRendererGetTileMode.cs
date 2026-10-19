
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("The current tile mode of the Sprite Renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-tileMode.html")]
	public sealed class SpriteRendererGetTileMode : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Tile Mode")]
		[SerializeField]
		[WriteOnly]
		private SpriteTileModeRef _getTileMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getTileMode);
		}
		
		public override void Execute()
		{
			_getTileMode.Value = _spriteRenderer.Value.tileMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Tile Mode -> {_getTileMode}";
		}
	}
}

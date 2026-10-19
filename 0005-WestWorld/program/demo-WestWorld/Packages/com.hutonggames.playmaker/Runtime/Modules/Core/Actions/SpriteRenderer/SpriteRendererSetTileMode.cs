
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("The current tile mode of the Sprite Renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-tileMode.html")]
	public sealed class SpriteRendererSetTileMode : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Tile Mode")]
		[SerializeField]
		private SpriteTileModeVar _setTileMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _setTileMode);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.tileMode = _setTileMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Tile Mode to {_setTileMode}";
		}
	}
}

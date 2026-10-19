
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Determines the position of the Sprite used for sorting the SpriteRenderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-spriteSortPoint.html")]
	public sealed class SpriteRendererGetSpriteSortPoint : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Get SpriteRenderer Sprite Sort Point")]
		[SerializeField]
		[WriteOnly]
		private SpriteSortPointRef _getSpriteSortPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _getSpriteSortPoint);
		}
		
		public override void Execute()
		{
			_getSpriteSortPoint.Value = _spriteRenderer.Value.spriteSortPoint;
		}
		
		public override string GetSummary()
		{
			return "Get {_spriteRenderer} Sprite Sort Point -> {_getSpriteSortPoint}";
		}
	}
}

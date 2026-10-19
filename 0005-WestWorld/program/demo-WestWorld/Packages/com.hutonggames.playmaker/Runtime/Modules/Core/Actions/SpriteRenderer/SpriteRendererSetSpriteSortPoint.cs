
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Determines the position of the Sprite used for sorting the SpriteRenderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-spriteSortPoint.html")]
	public sealed class SpriteRendererSetSpriteSortPoint : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("Set SpriteRenderer Sprite Sort Point")]
		[SerializeField]
		private SpriteSortPointVar _setSpriteSortPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_spriteRenderer, _setSpriteSortPoint);
		}
		
		public override void Execute()
		{
			_spriteRenderer.Value.spriteSortPoint = _setSpriteSortPoint.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_spriteRenderer} Sprite Sort Point to {_setSpriteSortPoint}";
		}
	}
}


using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Flips the sprite on the X axis to face the opposite direction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-flipX.html")]
	public sealed class SpriteRendererFlipX : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		public override bool CanExecute() => CheckParameters(_spriteRenderer);

		public override void Execute()
		{
			_spriteRenderer.Value.flipX = !_spriteRenderer.Value.flipX;
		}

		public override string GetSummary() => "Flip {_spriteRenderer} X";
	}
}

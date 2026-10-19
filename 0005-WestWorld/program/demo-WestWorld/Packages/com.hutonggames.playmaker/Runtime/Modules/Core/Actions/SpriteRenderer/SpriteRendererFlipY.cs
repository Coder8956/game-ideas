
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.SpriteRenderer)]
	[ActionDescription("Flips the sprite on the Y axis to face the opposite direction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/SpriteRenderer-flipY.html")]
	public sealed class SpriteRendererFlipY : BaseAction
	{
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		public override bool CanExecute() => CheckParameters(_spriteRenderer);

		public override void Execute()
		{
			_spriteRenderer.Value.flipY = !_spriteRenderer.Value.flipY;
		}

		public override string GetSummary() => "Flip {_spriteRenderer} Y";
	}
}


using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingSpriteRenderer)]
	[ActionDescription("Flips the sprite on the Y axis based on a direction vector. ")]
	[HelpURL("actions/sprite-actions/sprite-flip-actions/")]
	public sealed class SpriteRendererFlipYToFaceDirection : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("The direction vector.")]
		[SerializeField]
		private Vector2Ref _direction;

		[Tooltip("Invert the direction test. Use this if your default sprite is facing down instead of up.")]
		[SerializeField]
		private BoolVar _invert;
		
		public override bool CanExecute() => CheckParameters(_spriteRenderer, _direction, _invert);

		public override void Execute()
		{
			if (Mathf.Approximately(_direction.Value.y, 0)) return;
			_spriteRenderer.Value.flipY = _invert.Value ? _direction.Value.y > 0 : _direction.Value.y < 0;
		}

		public override string GetSummary() => "Flip {_spriteRenderer} Y to face {_direction}";
	}
}

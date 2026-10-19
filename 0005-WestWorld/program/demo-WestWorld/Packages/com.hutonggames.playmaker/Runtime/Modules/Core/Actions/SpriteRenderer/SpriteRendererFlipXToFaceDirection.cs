
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingSpriteRenderer)]
	[ActionDescription("Flips the sprite on the X axis to face a direction vector.")]
	[HelpURL("actions/sprite-actions/sprite-flip-actions/")]
	public sealed class SpriteRendererFlipXToFaceDirection : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("The direction vector.")]
		[SerializeField]
		private Vector2Ref _direction;

		[Tooltip("Invert the direction test. Use this if your default sprite is facing left instead of right.")]
		[SerializeField]
		private BoolVar _invert;
		
		public override bool CanExecute() => CheckParameters(_spriteRenderer, _direction, _invert);

		public override void Execute()
		{
			if (Mathf.Approximately(_direction.Value.x, 0)) return;
			_spriteRenderer.Value.flipX = _invert.Value ? _direction.Value.x > 0 : _direction.Value.x < 0;
		}

		public override string GetSummary() => "Flip {_spriteRenderer} X to face {_direction}";
	}
}

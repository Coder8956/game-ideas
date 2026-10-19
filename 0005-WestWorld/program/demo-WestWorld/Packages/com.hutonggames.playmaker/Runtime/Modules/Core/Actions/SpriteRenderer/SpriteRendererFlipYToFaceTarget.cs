
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingSpriteRenderer)]
	[ActionDescription("Flips the sprite on the Y axis to face a target. ")]
	[HelpURL("actions/sprite-actions/sprite-flip-actions/")]
	public sealed class SpriteRendererFlipYToFaceTarget : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The SpriteRenderer")]
		[SerializeField]
		private SpriteRendererVar _spriteRenderer;
		
		[Tooltip("The target.")]
		[SerializeField]
		private TransformVar _target;

		[Tooltip("Invert the direction test. Use this if your default sprite is facing down instead of up.")]
		[SerializeField]
		private BoolVar _invert;
		
		public override bool CanStart() => CheckParameters(_spriteRenderer, _target, _invert);

		public override bool CanExecute() => CheckParameters(_spriteRenderer, _invert);

		public override void Execute()
		{
			var target = _target.Value;
			if (target == null)
			{
				Finish();
				return;
			}

			var spriteRenderer = _spriteRenderer.Value;
			var direction = target.position - spriteRenderer.transform.position;
			if (Mathf.Approximately(direction.y, 0)) return;
			spriteRenderer.flipY = _invert.Value ? direction.y > 0 : direction.y < 0;
		}

		public override string GetSummary() => "Flip {_spriteRenderer} Y to face {_target}";
	}
}

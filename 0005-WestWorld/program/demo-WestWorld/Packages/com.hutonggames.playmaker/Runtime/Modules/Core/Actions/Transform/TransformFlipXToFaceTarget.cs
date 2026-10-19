
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingTransform)]
	[ActionDescription("Set X axis scale to 1 or -1 to face a target. " +
	                   "\n\nIf the x position of the target is to the left, x scale will be -1, otherwise 1. " +
	                   "This is a convenient way to flip sprites to face a target. " +
	                   "\n\nSimilar to SpriteRendererFlipXToFaceTarget but scales the whole GameObject hierarchy, " +
	                   "e.g., attach points and sensors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformFlipXToFaceTarget : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The Transform to scale.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("The target.")]
		[SerializeField]
		private TransformRef _target;

		[Tooltip("Invert the direction test. For example, use this if your default sprite is facing left instead of right.")]
		[SerializeField]
		private BoolVar _invert;
		
		public override bool CanStart() => CheckParameters(_transform, _target, _invert);

		public override bool CanExecute() => CheckParameters(_transform, _invert);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			
			var target = _target.Value;
			if (target == null)
			{
				Finish();
				return;
			}

			var direction = target.position - transform.position;
			if (Mathf.Approximately(direction.x, 0)) return;
			var scale = transform.localScale;
			scale.x = direction.x > 0 ? 1 : -1;
			scale.x *= _invert.Value ? -1 : 1;
			transform.localScale = scale;
		}

		public override string GetSummary() => "Flip {_transform} X to face {_target}";
	}
}

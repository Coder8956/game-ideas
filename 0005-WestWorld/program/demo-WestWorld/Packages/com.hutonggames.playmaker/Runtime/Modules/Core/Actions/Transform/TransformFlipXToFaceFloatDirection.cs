
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingTransform)]
	[ActionDescription("Set X axis scale to 1 or -1 to match the sign of a float value. " +
	                   "This is a convenient way to flip sprites to face a movement direction." +
	                   "\n\nSimilar to SpriteRendererFlipXToFaceFloatDirection but scales the whole GameObject hierarchy, " +
	                   "e.g., attach points and sensors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformFlipXToFaceFloatDirection : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The Transform to scale.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("The direction.")]
		[SerializeField]
		private FloatRef _direction;

		[Tooltip("Invert the direction test. For example, use this if your default sprite is facing left instead of right.")]
		[SerializeField]
		private BoolVar _invert;
		
		public override bool CanExecute() => CheckParameters(_transform, _direction, _invert);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			if (Mathf.Approximately(_direction.Value, 0)) return;
			var scale = transform.localScale;
			scale.x = _direction.Value > 0 ? 1 : -1;
			scale.x *= _invert.Value ? -1 : 1;
			transform.localScale = scale;
		}

		public override string GetSummary() => "Flip {_transform} X to face {_direction}";
	}
}


using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayTargetingTransform)]
	[ActionDescription("Set Y axis scale to 1 or -1 to match a direction vector. " +
	                   "\n\nIf the y value of the direction vector is negative, y scale will be -1, otherwise 1. " +
	                   "This is a convenient way to flip sprites to face a movement direction." +
	                   "\n\nSimilar to SpriteRendererFlipYToFaceDirection but scales the whole GameObject hierarchy, " +
	                   "e.g., attach points and sensors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformFlipYToFaceDirection : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
		
		[Tooltip("The Transform to scale.")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("The direction vector.")]
		[SerializeField]
		private Vector2Ref _direction;

		[Tooltip("Invert the direction test. For example, use this if your default sprite is facing down instead of up.")]
		[SerializeField]
		private BoolVar _invert;
		
		public override bool CanExecute() => CheckParameters(_transform, _direction, _invert);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;

			if (Mathf.Approximately(_direction.Value.y, 0)) return;
			var scale = transform.localScale;
			scale.y = _direction.Value.y > 0 ? 1 : -1;
			scale.y *= _invert.Value ? -1 : 1;
			transform.localScale = scale;
		}

		public override string GetSummary() => "Flip {_transform} Y to face {_direction}";
	}
}

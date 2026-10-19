
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Invert the X axis scale of the transform. " +
	                   "This is a convenient way to flip sprites to face the opposite direction." +
	                   "\n\nSimilar to SpriteRendererFlipX but scales the whole GameObject hierarchy, " +
	                   "e.g., attach points and sensors.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformFlipX : BaseAction
	{

		[Tooltip("The Transform to scale.")]
		[SerializeField]
		private TransformVar _transform;
		
		public override bool CanExecute() => CheckParameters(_transform);

		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;
			var scale = transform.localScale;
			scale.x = -scale.x;
			transform.localScale = scale;
		}

		public override string GetSummary() => "Flip {_transform} X";
	}
}

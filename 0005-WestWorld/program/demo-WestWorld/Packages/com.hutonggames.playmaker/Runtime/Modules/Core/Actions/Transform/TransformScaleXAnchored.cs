
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the X scale of a transform, anchoring its position to the left or right. " +
	                   "Useful for meters, e.g., a health bar." +
	                   "\n\nNOTE: The transform needs a Renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformScaleXAnchored : BaseAction
	{
		public enum Anchor
		{
			Left,
			Right
		}
		
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set the local X Scale")]
		[SerializeField]
		private FloatVar _scaleX;
		
		[Tooltip("Anchor position to the left or right.")]
		[SerializeField]
		private Anchor _anchor;
		
		public override bool CanExecute() => CheckParameters(_transform, _scaleX);
		
		private Renderer _cachedRenderer;
		private Transform _cachedTransform;

		private void UpdateCachedRenderer()
		{
			if (_cachedTransform != _transform.Value)
			{
				_cachedRenderer = _transform.Value.GetComponent<Renderer>();
				_cachedTransform = _transform.Value;
			}
		}
		
		public override void Execute()
		{
			var transform = _transform.Value;
			if (transform == null) return;

			UpdateCachedRenderer();
			if (_cachedRenderer == null) return;

			// Get current anchor point in world space
			var bounds = _cachedRenderer.bounds;
			var worldAnchorX = _anchor == Anchor.Left ? bounds.min.x : bounds.max.x;

			// Apply new scale
			var localScale = transform.localScale;
			localScale.x = _scaleX.Value;
			transform.localScale = localScale;

			// Get new bounds and calculate offset needed
			var newBounds = _cachedRenderer.bounds;
			var newWorldAnchorX = _anchor == Anchor.Left ? newBounds.min.x : newBounds.max.x;

			// Adjust position to maintain anchor point
			var worldOffset = worldAnchorX - newWorldAnchorX;
			transform.position = new Vector3(transform.position.x + worldOffset, transform.position.y,
				transform.position.z);
		}
		
		public override string GetSummary()
		{
			return "{_transform} scale X {_scaleX} anchor {_anchor}";
		}
	}
}

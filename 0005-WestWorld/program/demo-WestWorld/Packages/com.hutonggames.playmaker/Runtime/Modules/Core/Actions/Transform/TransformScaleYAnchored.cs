using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.Transform)]
	[ActionDescription("Set the Y scale of a transform, anchoring its position to the top or bottom. " +
	                   "Useful for meters, e.g., a power bar." +
	                   "\n\nNOTE: The transform needs a Renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
	public sealed class TransformScaleYAnchored : BaseAction
	{
		public enum Anchor
		{
			Top,
			Bottom
		}
		
		[OwnerDefaultValue]
		[Tooltip("The Transform")]
		[SerializeField]
		private TransformVar _transform;
		
		[Tooltip("Set the local Y Scale")]
		[SerializeField]
		private FloatVar _scaleY;
		
		[Tooltip("Anchor position to the top or bottom.")]
		[SerializeField]
		private Anchor _anchor;
		
		public override bool CanExecute() => CheckParameters(_transform, _scaleY);
		
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
			var worldAnchorY = _anchor == Anchor.Top ? bounds.max.y : bounds.min.y;

			// Apply new scale
			var localScale = transform.localScale;
			localScale.y = _scaleY.Value;
			transform.localScale = localScale;

			// Get new bounds and calculate offset needed
			var newBounds = _cachedRenderer.bounds;
			var newWorldAnchorY = _anchor == Anchor.Top ? newBounds.max.y : newBounds.min.y;

			// Adjust position to maintain anchor point
			var worldOffset = worldAnchorY - newWorldAnchorY;
			transform.position = new Vector3(transform.position.x, transform.position.y + worldOffset,
				transform.position.z);
		}
		
		public override string GetSummary()
		{
			return "{_transform} scale Y {_scaleY} anchor {_anchor}";
		}
	}
}

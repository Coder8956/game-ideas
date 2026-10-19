using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.Rigidbody)]
	[ActionDescription("Applies an explosion force to all rigidbodies within a blast radius.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.AddExplosionForce.html")]
	public sealed class RigidbodyExplosion : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate;

		[Tooltip("The centre of the sphere within which the explosion has its effect.")]
		[SerializeField]
		private Vector3Var _explosionPosition;

		[Tooltip("The force of the explosion (which may be modified by distance).")]
		[SerializeField]
		private FloatVar _explosionForce;

		[Tooltip("The radius of the sphere within which the explosion has its effect.")]
		[SerializeField]
		private FloatVar _explosionRadius;

		[Tooltip("Adjustment to the apparent position of the explosion to make it seem to lift objects.")]
		[SerializeField]
		private FloatVar _upwardsModifier;

		[Tooltip("The method used to apply the force to its targets.")]
		[SerializeField]
		private ForceModeVar _forceMode;

		[Tooltip("Only colliders on these layers will be affected.")]
		[SerializeField]
		private LayerMaskVar _layerMask;

		[Tooltip("Include trigger colliders in the explosion.")]
		[SerializeField]
		private BoolVar _includeTriggers;

		public override bool CanExecute()
		{
			return CheckParameters(
				_explosionPosition,
				_explosionForce,
				_explosionRadius,
				_layerMask);
		}

		public override void Execute()
		{
			var radius = _explosionRadius.Value;
			if (radius <= 0f) return;

			var queryTriggers = _includeTriggers.Value
				? QueryTriggerInteraction.Collide
				: QueryTriggerInteraction.Ignore;

			var colliders = Physics.OverlapSphere(
				_explosionPosition.Value,
				radius,
				_layerMask.Value,
				queryTriggers);

			if (colliders == null || colliders.Length == 0) return;

			var force = _explosionForce.Value;
			var position = _explosionPosition.Value;
			var upwards = _upwardsModifier.Value;
			var mode = _forceMode.Value;

			for (int i = 0; i < colliders.Length; i++)
			{
				var rb = colliders[i].attachedRigidbody;
				if (rb == null) continue;

				rb.AddExplosionForce(force, position, radius, upwards, mode);
			}
		}

		public override string GetSummary()
		{
			return "Apply explosion {_explosionForce} at {_explosionPosition} radius {_explosionRadius}";
		}
	}
}

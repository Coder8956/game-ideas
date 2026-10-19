
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyAddForce")]
	[ActionDescription("Applies a force to a rigidbody that simulates explosion effects.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.AddExplosionForce.html")]
	public sealed class RigidbodyAddExplosionForce : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdateEveryFrame;

		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("The force of the explosion (which may be modified by distance).")]
		[SerializeField]
		private FloatVar _explosionForce;
		
		[Tooltip("The centre of the sphere within which the explosion has its effect.")]
		[SerializeField]
		private Vector3Var _explosionPosition;
		
		[Tooltip("The radius of the sphere within which the explosion has its effect.")]
		[SerializeField]
		private FloatVar _explosionRadius;

		[Tooltip("Adjustment to the apparent position of the explosion to make it seem to lift objects.")]
		[SerializeField]
		private FloatVar _upwardsModifier;
		
		[Tooltip("The method used to apply the force to its targets.")]
		[SerializeField]
		private ForceModeVar _forceMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _explosionForce, _explosionPosition, _explosionRadius);
		}
		
		public override void Execute()
		{
			var rigidbody = _rigidbody.Value;
			if (rigidbody == null) return;
			
			rigidbody.AddExplosionForce(
				_explosionForce.Value, 
				_explosionPosition.Value, 
				_explosionRadius.Value, 
				_upwardsModifier.Value,
				_forceMode.Value);
		}
		
		public override string GetSummary()
		{
			return "Add explosion force {_explosionForce} to {_rigidbody} at {_explosionPosition} radius {_explosionRadius}";
		}
	}
}

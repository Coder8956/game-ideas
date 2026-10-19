
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.GameplayMovementRigidbody)]
	[ConvertibleGroup("RigidbodySetVelocity")]
	[ActionDescription("Manually set the Rigidbody speed in world units per second, preserving the current movement direction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
	public sealed class RigidbodySetSpeed : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set the speed in world units per second.")]
		[SerializeField]
		private FloatVar _speed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _speed);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			var currentVelocity = _rigidbody.Value.linearVelocity;
			if (currentVelocity.magnitude == 0) return;
			_rigidbody.Value.linearVelocity = currentVelocity.normalized * _speed.Value;
#else
			var currentVelocity = _rigidbody.Value.velocity;
			if (currentVelocity.magnitude == 0) return;
			_rigidbody.Value.velocity = currentVelocity.normalized * _speed.Value;
#endif

		}
		
		public override string GetSummary() => "Clamp {_rigidbody} speed to {_speed}";
	}
}


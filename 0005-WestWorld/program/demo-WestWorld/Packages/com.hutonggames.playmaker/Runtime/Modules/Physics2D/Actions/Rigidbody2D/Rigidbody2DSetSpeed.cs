using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[Serializable]
	[ActionCategory(Category.GameplayMovementRigidbody2D)]
	[ConvertibleGroup("Rigidbody2DSetVelocity")]
	[ActionDescription("Manually set the Rigidbody2D speed in world units per second, preserving the current movement direction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearVelocity.html")]
	public sealed class Rigidbody2DSetSpeed : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set the speed in world units per second.")]
		[SerializeField]
		private FloatVar _speed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _speed);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			var currentVelocity = _rigidbody2D.Value.linearVelocity;
			if (currentVelocity.magnitude == 0) return;
			_rigidbody2D.Value.linearVelocity = currentVelocity.normalized * _speed.Value;
#else
			var currentVelocity = _rigidbody2D.Value.velocity;
			if (currentVelocity.magnitude == 0) return;
			_rigidbody2D.Value.velocity = currentVelocity.normalized * _speed.Value;
#endif

		}
		
		public override string GetSummary() => "Set {_rigidbody2D} speed to {_speed}";
	}
}


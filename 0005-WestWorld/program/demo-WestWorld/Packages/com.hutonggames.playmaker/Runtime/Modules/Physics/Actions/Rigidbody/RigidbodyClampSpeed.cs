
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[Serializable]
	[ActionCategory(Category.GameplayMovementRigidbody)]
	[ConvertibleGroup("RigidbodySetVelocity")]
	[ActionDescription("Manually clamp the velocity of the Rigidbody to a max speed in world units per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody-linearVelocity.html")]
	public sealed class RigidbodyClampSpeed : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Set the maximum speed in world units per second.")]
		[SerializeField]
		private FloatVar _maxSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _maxSpeed);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_rigidbody.Value.linearVelocity = Vector3.ClampMagnitude(_rigidbody.Value.linearVelocity, _maxSpeed.Value);
#else
			_rigidbody.Value.velocity = Vector3.ClampMagnitude(_rigidbody.Value.velocity, _maxSpeed.Value);
#endif
		}
		
		public override string GetSummary() => "Clamp {_rigidbody} speed to {_maxSpeed}";
	}
}


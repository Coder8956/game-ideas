/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.GameplayMovementRigidbody2D)]
	[ConvertibleGroup("Rigidbody2DSetVelocity")]
	[ActionDescription("Set the rigidbody velocity if the input magnitude is not zero." +
	                   "\n\nThis is useful when you want to keep the existing velocity when there is no input.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html")]
	public sealed class Rigidbody2DSetVelocityIfInputNotZero : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody;
		
		[Tooltip("Set Rigidbody2D Velocity")]
		[SerializeField]
		private Vector3Var _input;

		[Tooltip("A magnitude less than this is considered 'zero'")]
		[SerializeField]
		private FloatVar _threshold;
		
		public override bool CanExecute() => CheckParameters(_rigidbody, _input, _threshold);

		public override void Execute()
		{
			if (_input.Value.magnitude < _threshold.Value) return;
#if UNITY_6000_0_OR_NEWER
			_rigidbody.Value.linearVelocity = _input.Value;
#else
			_rigidbody.Value.velocity = _input.Value;
#endif
		}
		
		public override string GetSummary() => "Set {_rigidbody} velocity to {_input} if input > {_threshold}";
	}
}
*/

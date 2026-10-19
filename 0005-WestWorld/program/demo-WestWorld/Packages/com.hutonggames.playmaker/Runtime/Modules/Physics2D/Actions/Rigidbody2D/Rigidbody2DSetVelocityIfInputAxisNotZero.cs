/*
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[PublicAPI]
	[ActionCategory(Category.GameplayMovementRigidbody2D)]
	[ConvertibleGroup("Rigidbody2DSetVelocity")]
	[ActionDescription("Set the rigidbody velocity on any axis where the input magnitude is not zero." +
	                   "\n\nThis is useful when you want to keep the existing velocity when there is no input.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html")]
	public sealed class Rigidbody2DSetVelocityIfInputAxisNotZero : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody;
		
		[Tooltip("Set Rigidbody2D Velocity")]
		[SerializeField]
		private Vector2Var _input;

		[Tooltip("A magnitude less than this is considered 'zero'")]
		[SerializeField]
		private FloatVar _threshold;
		
		[Tooltip("The space to set the velocity relative to.")]
		[SerializeField]
		private SpaceVar _relativeTo;
		
		public override bool CanExecute() => CheckParameters(_rigidbody, _input, _threshold);

		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			var velocity = _rigidbody.Value.linearVelocity;
#else
			var velocity = _rigidbody.Value.velocity;
#endif
			
			if (Mathf.Abs(_input.Value.x) > _threshold.Value)
			{
				velocity.x = _input.Value.x;
			}
			if (Mathf.Abs(_input.Value.y) > _threshold.Value)
			{
				velocity.y = _input.Value.y;
			}
			
#if UNITY_6000_0_OR_NEWER
			_rigidbody.Value.linearVelocity = velocity;
#else
			_rigidbody.Value.velocity = velocity;
#endif
		}
		
		public override string GetSummary() => "Set {_rigidbody} velocity to {_input} on axes where input > {_threshold}";
	}
}
*/

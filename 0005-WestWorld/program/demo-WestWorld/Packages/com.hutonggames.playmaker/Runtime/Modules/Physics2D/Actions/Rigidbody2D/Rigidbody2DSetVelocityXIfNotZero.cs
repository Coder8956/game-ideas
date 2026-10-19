
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ConvertibleGroup("Rigidbody2DSetVelocity")]
	[ActionDescription("Set the X velocity of the Rigidbody if the input is not zero. Use this to keep velocity if there is no input.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearVelocity.html")]
	public sealed class Rigidbody2DSetVelocityXIfNotZero : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Velocity in X")]
		[SerializeField]
		private FloatRef _setVelocityX;
		
		[Tooltip("A magnitude less than this is considered 'zero'")]
		[SerializeField]
		private FloatVar _threshold;
		
		public override bool CanExecute() => CheckParameters(_rigidbody2D, _setVelocityX, _threshold);

		public override void Execute()
		{
			if (_setVelocityX.Value <= _threshold.Value) return;
			
#if UNITY_6000_0_OR_NEWER
			var velocity = _rigidbody2D.Value.linearVelocity;
			velocity.x = _setVelocityX.Value;
			_rigidbody2D.Value.linearVelocity = velocity;
#else
			var velocity = _rigidbody2D.Value.velocity;
			velocity.x = _setVelocityX.Value;
			_rigidbody2D.Value.velocity = velocity;
#endif
		}
		
		public override string GetSummary() => "Set {_rigidbody2D} x velocity to {_setVelocityX} if not zero";
	}
}


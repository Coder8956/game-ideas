
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{


	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.GameplayMovementRigidbody2D)]
	[ConvertibleGroup("Rigidbody2DSetVelocity")]
	[ActionDescription("Manually clamp the Rigidbody2D velocity to a max speed in world units per second.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-linearVelocity.html")]
	public sealed class Rigidbody2DClampSpeed : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.FixedUpdate | UpdateMode.EveryFrame;
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set the maximum speed in world units per second.")]
		[SerializeField]
		private FloatVar _maxSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _maxSpeed);
		}
		
		public override void Execute()
		{
#if UNITY_6000_0_OR_NEWER
			_rigidbody2D.Value.linearVelocity = Vector2.ClampMagnitude(_rigidbody2D.Value.linearVelocity, _maxSpeed.Value);
#else
			_rigidbody2D.Value.velocity = Vector2.ClampMagnitude(_rigidbody2D.Value.velocity, _maxSpeed.Value);
#endif
		}
		
		public override string GetSummary() => "Clamp {_rigidbody2D} speed to {_maxSpeed}";
	}
}


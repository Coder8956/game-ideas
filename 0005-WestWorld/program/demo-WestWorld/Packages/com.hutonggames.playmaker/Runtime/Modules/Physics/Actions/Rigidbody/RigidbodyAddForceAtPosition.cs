
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyAddForce")]
	[ActionDescription("Applies force at position. As a result this will apply a torque and force on the " +
		"object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.AddForceAtPosition.html")]
	public sealed class RigidbodyAddForceAtPosition : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Force vector in world coordinates.")]
		[SerializeField]
		private Vector3Var _force;
		
		[Tooltip("Position in world coordinates.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Multiply the force by this value.")]      
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier = new (){Value = 1};

		[Tooltip("Invert the direction of the force.")]      
		[SerializeField]
		private BoolVar _invertDirection;
		
		[Tooltip("Mode.")]
		[SerializeField]
		private ForceModeVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _force, _position, _mode, _multiplier, _invertDirection);
		}
		
		public override void Execute()
		{
			var rigidbody = _rigidbody.Value;
			if (rigidbody == null) return;
			
			var force = _force.Value * _multiplier.Value;
			if (_invertDirection.Value) force = -force;
			rigidbody.AddForceAtPosition(force, _position.Value, _mode.Value);
		}
		
		public override string GetSummary() => "Add force {_force} to {_rigidbody} at {_position}"
		                                       + (!Mathf.Approximately(_multiplier.Value, 1) ? " * {_multiplier}" : "")
		                                       + " ({_mode})";
	}
}

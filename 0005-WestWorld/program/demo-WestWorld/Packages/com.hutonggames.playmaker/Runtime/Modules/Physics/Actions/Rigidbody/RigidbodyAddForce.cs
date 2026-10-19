
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyAddForce")]
	[ActionDescription("Adds a force to the Rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.AddForce.html")]
	public sealed class RigidbodyAddForce : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Force vector in world coordinates.")]
		[SerializeField]
		private Vector3Var _force;
		
		[Tooltip("Multiply the force by this value.")]      
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier = new (){Value = 1};

		[Tooltip("Invert the direction of the force.")]      
		[SerializeField]
		private BoolVar _invertDirection;
		
		[Tooltip("Type of force to apply.")]
		[SerializeField]
		private ForceModeVar _mode;
		
		public override bool CanExecute() => CheckParameters(_rigidbody, _force, _mode, _multiplier, _invertDirection);

		public override void Execute()
		{			
			var rigidbody = _rigidbody.Value;
			if (rigidbody == null) return;
			
			var force = _force.Value * _multiplier.Value;
			if (_invertDirection.Value) force = -force;
			rigidbody.AddForce(force, _mode.Value);
		}
		
		public override string GetSummary() => "Add force {_force} to {_rigidbody}" 
		                                       + (!Mathf.Approximately(_multiplier.Value, 1) ? " * {_multiplier}" : "")
		                                       + " ({_mode})";
	}
}

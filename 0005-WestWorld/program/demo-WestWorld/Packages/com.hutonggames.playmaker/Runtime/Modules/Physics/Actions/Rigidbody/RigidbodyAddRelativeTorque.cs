
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyAddTorque")]
	[ActionDescription("Adds a torque to the rigidbody relative to its coordinate system.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.AddRelativeTorque.html")]
	public sealed class RigidbodyAddRelativeTorque : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Torque vector in local coordinates.")]
		[SerializeField]
		private Vector3Var _torque;
		
		[Tooltip("Multiply the torque by this value.")]      
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier = new (){Value = 1};
		
		[Tooltip("Type of force to apply.")]
		[SerializeField]
		private ForceModeVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _torque, _mode, _multiplier);
		}
		
		public override void Execute()
		{
			var rigidbody = _rigidbody.Value;
			if (rigidbody == null) return;
			
			var torque = _torque.Value * _multiplier.Value;
			rigidbody.AddRelativeTorque(torque, _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Add relative torque {_torque} to {_rigidbody}"
			       + (!Mathf.Approximately(_multiplier.Value, 1) ? " * {_multiplier}" : "")
			       + " ({_mode})";
		}
	}
}

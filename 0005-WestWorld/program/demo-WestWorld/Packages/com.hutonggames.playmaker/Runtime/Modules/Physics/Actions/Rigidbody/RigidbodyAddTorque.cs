
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyAddTorque")]
	[ActionDescription("Adds a torque to the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.AddTorque.html")]
	public sealed class RigidbodyAddTorque : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Torque vector in world coordinates.")]
		[SerializeField]
		private Vector3Var _torque;
		
		[Tooltip("Multiply the torque by this value.")]      
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier = new (){Value = 1};
		
		[Tooltip("The type of torque to apply.")]
		[SerializeField]
		private ForceModeVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _torque, _mode);
		}
		
		public override void Execute()
		{
			var rigidbody = _rigidbody.Value;
			if (rigidbody == null) return;
			
			var torque = _torque.Value * _multiplier.Value;
			rigidbody.AddTorque(torque, _mode.Value);
		}
		
		public override string GetSummary() =>
			"{_rigidbody} add torque {_torque}"
			+ (!Mathf.Approximately(_multiplier.Value, 1) ? " * {_multiplier}" : "")
			+ " ({_mode})";
	}
}

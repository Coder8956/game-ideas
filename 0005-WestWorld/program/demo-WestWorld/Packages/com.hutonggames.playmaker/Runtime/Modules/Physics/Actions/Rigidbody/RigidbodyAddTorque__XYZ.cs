
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyAddTorque")]
	[ActionDescription("Adds a torque to the rigidbody.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.AddTorque.html")]
	public sealed class RigidbodyAddTorque__XYZ : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Size of torque along the world x-axis.")]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Size of torque along the world y-axis.")]
		[SerializeField]
		private FloatVar _y;
		
		[Tooltip("Size of torque along the world z-axis.")]
		[SerializeField]
		private FloatVar _z;
		
		[Tooltip("The type of torque to apply.")]
		[SerializeField]
		private ForceModeVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody, _x, _y, _z, _mode);
		}
		
		public override void Execute()
		{
			var rigidbody = _rigidbody.Value;
			if (rigidbody == null) return;
			
			rigidbody.AddTorque(_x.Value, _y.Value, _z.Value, _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Add torque ({_x}, {_y}, {_z}) to {_rigidbody} as {_mode}";
		}
	}
}

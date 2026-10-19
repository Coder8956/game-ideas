
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody)]
	[ConvertibleGroup("RigidbodyAddForce")]
	[ActionDescription("Adds a force to the rigidbody relative to its coordinate system.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody.AddRelativeForce.html")]
	public sealed class RigidbodyAddRelativeForce__XYZ : BaseAction
	{
		
		[Tooltip("The Rigidbody.")]
		[SerializeField]
		private RigidbodyVar _rigidbody;
		
		[Tooltip("Size of force along the local x-axis.")]
		[SerializeField]
		private FloatVar _x;
		
		[Tooltip("Size of force along the local y-axis.")]
		[SerializeField]
		private FloatVar _y;
		
		[Tooltip("Size of force along the local z-axis.")]
		[SerializeField]
		private FloatVar _z;
		
		[Tooltip("Type of force to apply.")]
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

			rigidbody.AddRelativeForce(_x.Value, _y.Value, _z.Value, _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Add relative force ({_x}, {_y}, {_z}) to {_rigidbody} as {_mode}";
		}
	}
}

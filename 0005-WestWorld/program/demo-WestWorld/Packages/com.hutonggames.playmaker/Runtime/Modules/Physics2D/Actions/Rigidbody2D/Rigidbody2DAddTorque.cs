
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("Apply a torque at the rigidbody\'s centre of mass.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D.AddTorque.html")]
	public sealed class Rigidbody2DAddTorque : BaseAction
	{
		
		[Tooltip("The Rigidbody2D.")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Torque to apply.")]
		[SerializeField]
		private FloatVar _torque;
		
		[Tooltip("The force mode to use.")]
		[SerializeField]
		private ForceMode2DVar _mode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _torque, _mode);
		}
		
		public override void Execute()
		{
			//UnityEngine.Rigidbody2D.AddTorque(System.Single, UnityEngine.ForceMode2D);
			_rigidbody2D.Value.AddTorque(_torque.Value, _mode.Value);
		}
		
		public override string GetSummary()
		{
			return "Add torque {_torque} to {_rigidbody2D} as {_mode}";
		}
	}
}

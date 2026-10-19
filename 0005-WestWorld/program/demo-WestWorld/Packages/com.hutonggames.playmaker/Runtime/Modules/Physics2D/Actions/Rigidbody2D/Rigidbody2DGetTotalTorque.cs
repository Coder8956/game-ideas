
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The total amount of torque that has been explicitly applied to this Rigidbody2D s" +
		"ince the last physics simulation step.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-totalTorque.html")]
	public sealed class Rigidbody2DGetTotalTorque : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Total Torque")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTotalTorque;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getTotalTorque);
		}
		
		public override void Execute()
		{
			_getTotalTorque.Value = _rigidbody2D.Value.totalTorque;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} total torque -> {_getTotalTorque}";
		}
	}
}

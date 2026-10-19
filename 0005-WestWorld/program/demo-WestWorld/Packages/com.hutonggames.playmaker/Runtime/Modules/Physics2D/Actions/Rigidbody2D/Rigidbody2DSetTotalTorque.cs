
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
	public sealed class Rigidbody2DSetTotalTorque : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Total Torque")]
		[SerializeField]
		private FloatVar _setTotalTorque;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setTotalTorque);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.totalTorque = _setTotalTorque.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} total torque to {_setTotalTorque}";
		}
	}
}

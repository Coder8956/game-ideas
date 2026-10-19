
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce2D)]
	[ActionDescription("The torque applied to the rigidbody each physics update.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce2D-torque.html")]
	public sealed class ConstantForce2DSetTorque : BaseAction
	{
		
		[Tooltip("The ConstantForce2D")]
		[SerializeField]
		private ConstantForce2DVar _constantForce2D;
		
		[Tooltip("Set ConstantForce2D Torque")]
		[SerializeField]
		private FloatVar _setTorque;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce2D, _setTorque);
		}
		
		public override void Execute()
		{
			_constantForce2D.Value.torque = _setTorque.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_constantForce2D} Torque to {_setTorque}";
		}
	}
}

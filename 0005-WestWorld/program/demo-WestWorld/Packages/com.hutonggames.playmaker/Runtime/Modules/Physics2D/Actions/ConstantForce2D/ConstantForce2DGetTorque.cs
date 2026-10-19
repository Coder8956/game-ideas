
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
	public sealed class ConstantForce2DGetTorque : BaseAction
	{
		
		[Tooltip("The ConstantForce2D")]
		[SerializeField]
		private ConstantForce2DVar _constantForce2D;
		
		[Tooltip("Get ConstantForce2D Torque")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTorque;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce2D, _getTorque);
		}
		
		public override void Execute()
		{
			_getTorque.Value = _constantForce2D.Value.torque;
		}
		
		public override string GetSummary()
		{
			return "Get {_constantForce2D} torque -> {_getTorque}";
		}
	}
}

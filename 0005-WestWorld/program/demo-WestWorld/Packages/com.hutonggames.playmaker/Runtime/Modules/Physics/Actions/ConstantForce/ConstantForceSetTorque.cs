
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce)]
	[ActionDescription("The torque applied to the rigidbody every frame.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce-torque.html")]
	public sealed class ConstantForceSetTorque : BaseAction
	{
		
		[Tooltip("The ConstantForce")]
		[SerializeField]
		private ConstantForceVar _constantForce;
		
		[Tooltip("Set ConstantForce Torque")]
		[SerializeField]
		private Vector3Var _setTorque;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce, _setTorque);
		}
		
		public override void Execute()
		{
			_constantForce.Value.torque = _setTorque.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_constantForce} Torque to {_setTorque}";
		}
	}
}

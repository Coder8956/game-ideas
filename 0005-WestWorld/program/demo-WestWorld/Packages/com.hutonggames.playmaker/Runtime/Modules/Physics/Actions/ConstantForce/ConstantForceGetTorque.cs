
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce)]
	[ActionDescription("The torque applied to the rigidbody every frame.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce-torque.html")]
	public sealed class ConstantForceGetTorque : BaseAction
	{
		
		[Tooltip("The ConstantForce")]
		[SerializeField]
		private ConstantForceVar _constantForce;
		
		[Tooltip("Get ConstantForce Torque")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getTorque;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce, _getTorque);
		}
		
		public override void Execute()
		{
			_getTorque.Value = _constantForce.Value.torque;
		}
		
		public override string GetSummary()
		{
			return "Get {_constantForce} torque -> {_getTorque}";
		}
	}
}

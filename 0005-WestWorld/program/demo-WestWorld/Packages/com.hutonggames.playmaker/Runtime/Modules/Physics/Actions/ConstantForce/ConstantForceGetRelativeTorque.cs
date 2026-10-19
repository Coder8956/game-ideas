
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce)]
	[ActionDescription("The torque - relative to the rigid bodies coordinate system - applied every frame" +
		".")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce-relativeTorque.html")]
	public sealed class ConstantForceGetRelativeTorque : BaseAction
	{
		
		[Tooltip("The ConstantForce")]
		[SerializeField]
		private ConstantForceVar _constantForce;
		
		[Tooltip("Get ConstantForce Relative Torque")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getRelativeTorque;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce, _getRelativeTorque);
		}
		
		public override void Execute()
		{
			_getRelativeTorque.Value = _constantForce.Value.relativeTorque;
		}
		
		public override string GetSummary()
		{
			return "Get {_constantForce} relativeTorque -> {_getRelativeTorque}";
		}
	}
}


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
	public sealed class ConstantForceSetRelativeTorque : BaseAction
	{
		
		[Tooltip("The ConstantForce")]
		[SerializeField]
		private ConstantForceVar _constantForce;
		
		[Tooltip("Set ConstantForce Relative Torque")]
		[SerializeField]
		private Vector3Var _setRelativeTorque;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce, _setRelativeTorque);
		}
		
		public override void Execute()
		{
			_constantForce.Value.relativeTorque = _setRelativeTorque.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_constantForce} Relative Torque to {_setRelativeTorque}";
		}
	}
}

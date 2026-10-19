
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce)]
	[ActionDescription("The force applied to the rigidbody every frame.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce-force.html")]
	public sealed class ConstantForceSetForce : BaseAction
	{
		
		[Tooltip("The ConstantForce")]
		[SerializeField]
		private ConstantForceVar _constantForce;
		
		[Tooltip("Set ConstantForce Force")]
		[SerializeField]
		private Vector3Var _setForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce, _setForce);
		}
		
		public override void Execute()
		{
			_constantForce.Value.force = _setForce.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_constantForce} Force to {_setForce}";
		}
	}
}

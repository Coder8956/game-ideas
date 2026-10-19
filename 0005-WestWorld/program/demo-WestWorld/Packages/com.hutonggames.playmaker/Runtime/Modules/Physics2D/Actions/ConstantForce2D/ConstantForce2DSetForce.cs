
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce2D)]
	[ActionDescription("The linear force applied to the rigidbody each physics update.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce2D-force.html")]
	public sealed class ConstantForce2DSetForce : BaseAction
	{
		
		[Tooltip("The ConstantForce2D")]
		[SerializeField]
		private ConstantForce2DVar _constantForce2D;
		
		[Tooltip("Set ConstantForce2D Force")]
		[SerializeField]
		private Vector2Var _setForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce2D, _setForce);
		}
		
		public override void Execute()
		{
			_constantForce2D.Value.force = _setForce.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_constantForce2D} Force to {_setForce}";
		}
	}
}

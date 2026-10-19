
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce2D)]
	[ActionDescription("The linear force, relative to the rigid-body coordinate system, applied each phys" +
		"ics update.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce2D-relativeForce.html")]
	public sealed class ConstantForce2DSetRelativeForce : BaseAction
	{
		
		[Tooltip("The ConstantForce2D")]
		[SerializeField]
		private ConstantForce2DVar _constantForce2D;
		
		[Tooltip("Set ConstantForce2D Relative Force")]
		[SerializeField]
		private Vector2Var _setRelativeForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce2D, _setRelativeForce);
		}
		
		public override void Execute()
		{
			_constantForce2D.Value.relativeForce = _setRelativeForce.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_constantForce2D} Relative Force to {_setRelativeForce}";
		}
	}
}

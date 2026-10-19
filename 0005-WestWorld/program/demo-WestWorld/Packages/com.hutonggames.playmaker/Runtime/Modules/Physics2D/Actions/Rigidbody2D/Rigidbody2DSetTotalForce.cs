
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Rigidbody2D)]
	[ActionDescription("The total amount of force that has been explicitly applied to this Rigidbody2D si" +
		"nce the last physics simulation step.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Rigidbody2D-totalForce.html")]
	public sealed class Rigidbody2DSetTotalForce : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Set Rigidbody2D Total Force")]
		[SerializeField]
		private Vector2Var _setTotalForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _setTotalForce);
		}
		
		public override void Execute()
		{
			_rigidbody2D.Value.totalForce = _setTotalForce.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_rigidbody2D} total force to {_setTotalForce}";
		}
	}
}

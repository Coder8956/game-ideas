
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
	public sealed class Rigidbody2DGetTotalForce : BaseAction
	{
		
		[Tooltip("The Rigidbody2D")]
		[SerializeField]
		private Rigidbody2DVar _rigidbody2D;
		
		[Tooltip("Get Rigidbody2D Total Force")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getTotalForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_rigidbody2D, _getTotalForce);
		}
		
		public override void Execute()
		{
			_getTotalForce.Value = _rigidbody2D.Value.totalForce;
		}
		
		public override string GetSummary()
		{
			return "Get {_rigidbody2D} total force -> {_getTotalForce}";
		}
	}
}


using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.ConstantForce2D)]
	[ActionDescription("The linear force applied to the rigidbody each physics update.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/ConstantForce2D-force.html")]
	public sealed class ConstantForce2DGetForce : BaseAction
	{
		
		[Tooltip("The ConstantForce2D")]
		[SerializeField]
		private ConstantForce2DVar _constantForce2D;
		
		[Tooltip("Get ConstantForce2D Force")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce2D, _getForce);
		}
		
		public override void Execute()
		{
			_getForce.Value = _constantForce2D.Value.force;
		}
		
		public override string GetSummary()
		{
			return "Get {_constantForce2D} force -> {_getForce}";
		}
	}
}


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
	public sealed class ConstantForce2DGetRelativeForce : BaseAction
	{
		
		[Tooltip("The ConstantForce2D")]
		[SerializeField]
		private ConstantForce2DVar _constantForce2D;
		
		[Tooltip("Get ConstantForce2D Relative Force")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getRelativeForce;
		
		public override bool CanExecute()
		{
			return CheckParameters(_constantForce2D, _getRelativeForce);
		}
		
		public override void Execute()
		{
			_getRelativeForce.Value = _constantForce2D.Value.relativeForce;
		}
		
		public override string GetSummary()
		{
			return "Get {_constantForce2D} relativeForce -> {_getRelativeForce}";
		}
	}
}

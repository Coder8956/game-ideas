
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Expand the bounds by increasing its size by amount along each side.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.Expand.html")]
	public sealed class BoundsExpandVector3 : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField]
		private BoundsRef _bounds;
		
		[Tooltip("Amount.")]
		[SerializeField]
		private Vector3Var _amount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _amount);
		}
		
		public override void Execute()
		{
			//UnityEngine.Bounds.Expand(UnityEngine.Vector3);
			_bounds.Value.Expand(_amount.Value);
		}
		
		public override string GetSummary()
		{
			return "Expand {_bounds} by {_amount} ";
		}
	}
}


using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Bounds)]
	[ActionDescription("Expand the bounds by increasing its size by amount along each side.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Bounds.Expand.html")]
	public sealed class BoundsExpand : BaseAction
	{
		
		[Tooltip("The Bounds.")]
		[SerializeField, WriteOnly]
		private BoundsRef _bounds;
		
		[Tooltip("Amount.")]
		[SerializeField]
		private FloatVar _amount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_bounds, _amount);
		}
		
		public override void Execute()
		{
			//UnityEngine.Bounds.Expand(System.Single);
			_bounds.Value.Expand(_amount.Value);
		}
		
		public override string GetSummary()
		{
			return "Expand {_bounds} by {_amount} ";
		}
	}
}

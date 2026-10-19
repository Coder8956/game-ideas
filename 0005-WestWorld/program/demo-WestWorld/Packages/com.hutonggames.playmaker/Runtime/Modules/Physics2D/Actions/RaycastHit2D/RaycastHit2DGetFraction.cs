
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.RaycastHit2D)]
	[ActionDescription("Fraction of the distance along the ray that the hit occurred.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/RaycastHit2D-fraction.html")]
	public sealed class RaycastHit2DGetFraction : BaseAction
	{
		
		[Tooltip("The RaycastHit2D")]
		[SerializeField]
		private RaycastHit2DRef _raycastHit2D;
		
		[Tooltip("Get RaycastHit2D Fraction")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFraction;
		
		public override bool CanExecute()
		{
			return CheckParameters(_raycastHit2D, _getFraction);
		}
		
		public override void Execute()
		{
			_getFraction.Value = _raycastHit2D.Value.fraction;
		}
		
		public override string GetSummary()
		{
			return "Get {_raycastHit2D} fraction -> {_getFraction}";
		}
	}
}


using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription(@"Set this to true to use the adjacentEndPoint to form the collision normal that is used to calculate the collision response when a collision occurs at the Edge Collider's end point. Set this to false to not use the adjacentEndPoint, and the collision normal becomes the direction of motion of the collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D-useAdjacentEndPoint.html")]
	public sealed class EdgeCollider2DSetUseAdjacentEndPoint : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Set EdgeCollider2D Use Adjacent End Point")]
		[SerializeField]
		private BoolVar _setUseAdjacentEndPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _setUseAdjacentEndPoint);
		}
		
		public override void Execute()
		{
			_edgeCollider2D.Value.useAdjacentEndPoint = _setUseAdjacentEndPoint.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_edgeCollider2D} Use Adjacent End Point to {_setUseAdjacentEndPoint}";
		}
	}
}

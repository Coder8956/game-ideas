
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription(@"Set this to true to use the adjacentStartPoint to form the collision normal that is used to calculate the collision response when a collision occurs at the Edge Collider's start point. Set this to false to not use the adjacentStartPoint, and the collision normal becomes the direction of motion of the collision.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D-useAdjacentStartPoint.htm" +
		"l")]
	public sealed class EdgeCollider2DGetUseAdjacentStartPoint : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Get EdgeCollider2D Use Adjacent Start Point")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseAdjacentStartPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _getUseAdjacentStartPoint);
		}
		
		public override void Execute()
		{
			_getUseAdjacentStartPoint.Value = _edgeCollider2D.Value.useAdjacentStartPoint;
		}
		
		public override string GetSummary()
		{
			return "Get {_edgeCollider2D} useAdjacentStartPoint -> {_getUseAdjacentStartPoint}";
		}
	}
}

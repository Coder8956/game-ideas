
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription("Defines the position of a virtual point adjacent to the start point of the EdgeCo" +
		"llider2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D-adjacentStartPoint.html")]
	public sealed class EdgeCollider2DGetAdjacentStartPoint : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Get EdgeCollider2D Adjacent Start Point")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getAdjacentStartPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _getAdjacentStartPoint);
		}
		
		public override void Execute()
		{
			_getAdjacentStartPoint.Value = _edgeCollider2D.Value.adjacentStartPoint;
		}
		
		public override string GetSummary()
		{
			return "Get {_edgeCollider2D} adjacentStartPoint -> {_getAdjacentStartPoint}";
		}
	}
}

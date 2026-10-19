
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription("Defines the position of a virtual point adjacent to the end point of the EdgeColl" +
		"ider2D.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D-adjacentEndPoint.html")]
	public sealed class EdgeCollider2DGetAdjacentEndPoint : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Get EdgeCollider2D Adjacent End Point")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getAdjacentEndPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _getAdjacentEndPoint);
		}
		
		public override void Execute()
		{
			_getAdjacentEndPoint.Value = _edgeCollider2D.Value.adjacentEndPoint;
		}
		
		public override string GetSummary()
		{
			return "Get {_edgeCollider2D} adjacentEndPoint -> {_getAdjacentEndPoint}";
		}
	}
}

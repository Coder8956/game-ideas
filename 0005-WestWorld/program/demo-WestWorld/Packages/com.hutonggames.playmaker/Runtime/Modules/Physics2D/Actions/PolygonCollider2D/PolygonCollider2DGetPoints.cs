
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PolygonCollider2D)]
	[ActionDescription("Corner points that define the collider\'s shape in local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PolygonCollider2D-points.html")]
	public sealed class PolygonCollider2DGetPoints : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("Get PolygonCollider2D Points")]
		[SerializeField]
		[WriteOnly]
		private Vector2ListRef _getPoints;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _getPoints);
		}
		
		public override void Execute()
		{
			_getPoints.Values = _polygonCollider2D.Value.points;
		}
		
		public override string GetSummary()
		{
			return "Get {_polygonCollider2D} points -> {_getPoints}";
		}
	}
}


using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PolygonCollider2D)]
	[ActionDescription("Corner points that define the collider\'s shape in local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PolygonCollider2D-points.html")]
	public sealed class PolygonCollider2DSetPoints : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("Set PolygonCollider2D Points")]
		[SerializeField]
		private Vector2ListVar _setPoints;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _setPoints);
		}
		
		public override void Execute()
		{
			_polygonCollider2D.Value.points = _setPoints.Values;
		}
		
		public override string GetSummary()
		{
			return "Set {_polygonCollider2D} Points to {_setPoints}";
		}
	}
}

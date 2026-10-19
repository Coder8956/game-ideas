
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription("Get the points defining multiple continuous edges.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D-points.html")]
	public sealed class EdgeCollider2DGetPoints : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Get EdgeCollider2D Points")]
		[SerializeField]
		[WriteOnly]
		private Vector2ListRef _getPoints;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _getPoints);
		}
		
		public override void Execute()
		{
			_getPoints.Values = _edgeCollider2D.Value.points;
		}
		
		public override string GetSummary()
		{
			return "Get {_edgeCollider2D} points -> {_getPoints}";
		}
	}
}

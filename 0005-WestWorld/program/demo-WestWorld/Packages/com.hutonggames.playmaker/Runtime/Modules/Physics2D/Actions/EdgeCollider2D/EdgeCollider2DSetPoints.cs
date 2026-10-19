
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription("Set the points defining multiple continuous edges.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D-points.html")]
	public sealed class EdgeCollider2DSetPoints : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Set EdgeCollider2D Points")]
		[SerializeField]
		private Vector2ListVar _setPoints;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _setPoints);
		}
		
		public override void Execute()
		{
			_edgeCollider2D.Value.points = _setPoints.Values;
		}
		
		public override string GetSummary()
		{
			return "Set {_edgeCollider2D} Points to {_setPoints}";
		}
	}
}

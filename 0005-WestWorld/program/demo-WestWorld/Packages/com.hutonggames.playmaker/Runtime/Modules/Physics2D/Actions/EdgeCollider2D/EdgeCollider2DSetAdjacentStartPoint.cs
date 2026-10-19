
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
	public sealed class EdgeCollider2DSetAdjacentStartPoint : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Set EdgeCollider2D Adjacent Start Point")]
		[SerializeField]
		private Vector2Var _setAdjacentStartPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _setAdjacentStartPoint);
		}
		
		public override void Execute()
		{
			_edgeCollider2D.Value.adjacentStartPoint = _setAdjacentStartPoint.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_edgeCollider2D} Adjacent Start Point to {_setAdjacentStartPoint}";
		}
	}
}

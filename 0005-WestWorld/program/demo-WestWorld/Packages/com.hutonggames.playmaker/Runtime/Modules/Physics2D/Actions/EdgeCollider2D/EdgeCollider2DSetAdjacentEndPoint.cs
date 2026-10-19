
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
	public sealed class EdgeCollider2DSetAdjacentEndPoint : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Set EdgeCollider2D Adjacent End Point")]
		[SerializeField]
		private Vector2Var _setAdjacentEndPoint;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _setAdjacentEndPoint);
		}
		
		public override void Execute()
		{
			_edgeCollider2D.Value.adjacentEndPoint = _setAdjacentEndPoint.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_edgeCollider2D} Adjacent End Point to {_setAdjacentEndPoint}";
		}
	}
}

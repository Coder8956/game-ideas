
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription("Gets the number of edges.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D-edgeCount.html")]
	public sealed class EdgeCollider2DGetEdgeCount : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Get EdgeCollider2D Edge Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getEdgeCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _getEdgeCount);
		}
		
		public override void Execute()
		{
			_getEdgeCount.Value = _edgeCollider2D.Value.edgeCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_edgeCollider2D} edgeCount -> {_getEdgeCount}";
		}
	}
}

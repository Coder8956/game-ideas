
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PolygonCollider2D)]
	[ActionDescription("The number of paths in the polygon.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PolygonCollider2D-pathCount.html")]
	public sealed class PolygonCollider2DGetPathCount : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("Get PolygonCollider2D Path Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPathCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _getPathCount);
		}
		
		public override void Execute()
		{
			_getPathCount.Value = _polygonCollider2D.Value.pathCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_polygonCollider2D} pathCount -> {_getPathCount}";
		}
	}
}

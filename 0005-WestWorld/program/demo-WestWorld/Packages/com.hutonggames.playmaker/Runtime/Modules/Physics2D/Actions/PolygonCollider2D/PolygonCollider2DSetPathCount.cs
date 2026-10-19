
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
	public sealed class PolygonCollider2DSetPathCount : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("Set PolygonCollider2D Path Count")]
		[SerializeField]
		private IntegerVar _setPathCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _setPathCount);
		}
		
		public override void Execute()
		{
			_polygonCollider2D.Value.pathCount = _setPathCount.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_polygonCollider2D} Path Count to {_setPathCount}";
		}
	}
}

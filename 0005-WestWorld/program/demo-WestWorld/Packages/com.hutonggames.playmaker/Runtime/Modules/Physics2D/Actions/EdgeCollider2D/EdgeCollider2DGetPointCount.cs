
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription("Gets the number of points.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D-pointCount.html")]
	public sealed class EdgeCollider2DGetPointCount : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("Get EdgeCollider2D Point Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPointCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _getPointCount);
		}
		
		public override void Execute()
		{
			_getPointCount.Value = _edgeCollider2D.Value.pointCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_edgeCollider2D} pointCount -> {_getPointCount}";
		}
	}
}

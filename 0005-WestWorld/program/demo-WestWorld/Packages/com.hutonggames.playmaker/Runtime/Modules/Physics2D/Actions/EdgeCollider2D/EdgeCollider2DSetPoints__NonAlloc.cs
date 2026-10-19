
using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.EdgeCollider2D)]
	[ActionDescription("Sets all the points that define a set of continuous edges.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/EdgeCollider2D.SetPoints.html")]
	public sealed class EdgeCollider2DSetPoints__NonAlloc : BaseAction
	{
		
		[Tooltip("The EdgeCollider2D.")]
		[SerializeField]
		private EdgeCollider2DVar _edgeCollider2D;
		
		[Tooltip("A list of Vector2 used to set the points. This list must contain at least two points.")]
		[SerializeField]
		private Vector2ListVar _points;
		
		[Tooltip("Store the number of points in Integer variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _pointCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_edgeCollider2D, _points, _pointCount);
		}
		
		public override void Execute()
		{
			//UnityEngine.EdgeCollider2D.SetPoints(System.Collections.Generic.List`1[[UnityEngine.Vector2, UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null]]);
			_pointCount.Value = _edgeCollider2D.Value.SetPoints(_points.Value);
		}
		
		public override string GetSummary()
		{
			return "Set Points {_edgeCollider2D} -> {_points} -> {_pointCount}";
		}
	}
}

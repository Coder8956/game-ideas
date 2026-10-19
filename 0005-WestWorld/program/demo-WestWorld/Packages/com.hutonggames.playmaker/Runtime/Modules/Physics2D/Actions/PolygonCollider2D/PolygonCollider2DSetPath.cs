
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PolygonCollider2D)]
	[ActionDescription("Define a path by its constituent points.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PolygonCollider2D.SetPath.html")]
	public sealed class PolygonCollider2DSetPath : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D.")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("Index of the path to set.")]
		[SerializeField]
		private IntegerVar _index;
		
		[Tooltip("An ordered array of the vertices (points) that define the path.")]
		[SerializeField]
		private Vector2ListVar _points;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _index, _points);
		}
		
		public override void Execute()
		{
			//UnityEngine.PolygonCollider2D.SetPath(System.Int32, UnityEngine.Vector2[]);
			_polygonCollider2D.Value.SetPath(_index.Value, _points.Values);
		}
		
		public override string GetSummary()
		{
			return "Set Path {_polygonCollider2D} {_index} {_points} ";
		}
	}
}


using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PolygonCollider2D)]
	[ActionDescription("Gets a path from the Collider by its index.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PolygonCollider2D.GetPath.html")]
	public sealed class PolygonCollider2DGetPath : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D.")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("The index of the path to retrieve.")]
		[SerializeField]
		private IntegerVar _index;
		
		[Tooltip("Store the result in Vector2 List variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2ListRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _index, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.PolygonCollider2D.GetPath(System.Int32);
			_result.Values = _polygonCollider2D.Value.GetPath(_index.Value);
		}
		
		public override string GetSummary()
		{
			return "Get Path {_polygonCollider2D} {_index} -> {_result}";
		}
	}
}

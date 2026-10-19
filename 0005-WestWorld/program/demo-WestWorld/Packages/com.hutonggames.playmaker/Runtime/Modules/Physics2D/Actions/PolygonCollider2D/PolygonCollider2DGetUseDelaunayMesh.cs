
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.PolygonCollider2D)]
	[ActionDescription("When the value is true, the Collider uses an additional Delaunay triangulation st" +
		"ep to produce the Collider mesh. When the value is false, this additional step d" +
		"oes not occur.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/PolygonCollider2D-useDelaunayMesh.html")]
	public sealed class PolygonCollider2DGetUseDelaunayMesh : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("Get PolygonCollider2D Use Delaunay Mesh")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseDelaunayMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _getUseDelaunayMesh);
		}
		
		public override void Execute()
		{
			_getUseDelaunayMesh.Value = _polygonCollider2D.Value.useDelaunayMesh;
		}
		
		public override string GetSummary()
		{
			return "Get {_polygonCollider2D} useDelaunayMesh -> {_getUseDelaunayMesh}";
		}
	}
}

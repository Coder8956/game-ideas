
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
	public sealed class PolygonCollider2DSetUseDelaunayMesh : BaseAction
	{
		
		[Tooltip("The PolygonCollider2D")]
		[SerializeField]
		private PolygonCollider2DVar _polygonCollider2D;
		
		[Tooltip("Set PolygonCollider2D Use Delaunay Mesh")]
		[SerializeField]
		private BoolVar _setUseDelaunayMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_polygonCollider2D, _setUseDelaunayMesh);
		}
		
		public override void Execute()
		{
			_polygonCollider2D.Value.useDelaunayMesh = _setUseDelaunayMesh.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_polygonCollider2D} Use Delaunay Mesh to {_setUseDelaunayMesh}";
		}
	}
}

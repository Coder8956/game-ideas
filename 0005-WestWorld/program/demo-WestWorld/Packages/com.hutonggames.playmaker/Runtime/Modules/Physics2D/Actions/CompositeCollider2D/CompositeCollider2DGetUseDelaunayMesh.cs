
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CompositeCollider2D)]
	[ActionDescription("When the value is true, the Collider uses an additional Delaunay triangulation st" +
		"ep to produce the Collider mesh. When the value is false, this additional step d" +
		"oes not occur.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CompositeCollider2D-useDelaunayMesh.html" +
		"")]
	public sealed class CompositeCollider2DGetUseDelaunayMesh : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Get CompositeCollider2D Use Delaunay Mesh")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseDelaunayMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _getUseDelaunayMesh);
		}
		
		public override void Execute()
		{
			_getUseDelaunayMesh.Value = _compositeCollider2D.Value.useDelaunayMesh;
		}
		
		public override string GetSummary()
		{
			return "Get {_compositeCollider2D} useDelaunayMesh -> {_getUseDelaunayMesh}";
		}
	}
}

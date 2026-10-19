
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
	public sealed class CompositeCollider2DSetUseDelaunayMesh : BaseAction
	{
		
		[Tooltip("The CompositeCollider2D")]
		[SerializeField]
		private CompositeCollider2DVar _compositeCollider2D;
		
		[Tooltip("Set CompositeCollider2D Use Delaunay Mesh")]
		[SerializeField]
		private BoolVar _setUseDelaunayMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_compositeCollider2D, _setUseDelaunayMesh);
		}
		
		public override void Execute()
		{
			_compositeCollider2D.Value.useDelaunayMesh = _setUseDelaunayMesh.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_compositeCollider2D} Use Delaunay Mesh to {_setUseDelaunayMesh}";
		}
	}
}

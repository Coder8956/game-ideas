
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MeshCollider)]
	[ActionDescription("Use a convex collider from the mesh.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MeshCollider-convex.html")]
	public sealed class MeshColliderGetConvex : BaseAction
	{
		
		[Tooltip("The MeshCollider")]
		[SerializeField]
		private MeshColliderVar _meshCollider;
		
		[Tooltip("Get MeshCollider Convex")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getConvex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_meshCollider, _getConvex);
		}
		
		public override void Execute()
		{
			_getConvex.Value = _meshCollider.Value.convex;
		}
		
		public override string GetSummary()
		{
			return "Get {_meshCollider} convex -> {_getConvex}";
		}
	}
}


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
	public sealed class MeshColliderSetConvex : BaseAction
	{
		
		[Tooltip("The MeshCollider")]
		[SerializeField]
		private MeshColliderVar _meshCollider;
		
		[Tooltip("Set MeshCollider Convex")]
		[SerializeField]
		private BoolVar _setConvex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_meshCollider, _setConvex);
		}
		
		public override void Execute()
		{
			_meshCollider.Value.convex = _setConvex.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_meshCollider} Convex to {_setConvex}";
		}
	}
}

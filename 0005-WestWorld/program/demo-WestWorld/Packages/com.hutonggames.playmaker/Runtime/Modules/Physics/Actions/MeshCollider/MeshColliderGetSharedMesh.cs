
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MeshCollider)]
	[ActionDescription("The mesh object used for collision detection.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MeshCollider-sharedMesh.html")]
	public sealed class MeshColliderGetSharedMesh : BaseAction
	{
		
		[Tooltip("The MeshCollider")]
		[SerializeField]
		private MeshColliderVar _meshCollider;
		
		[Tooltip("Get MeshCollider Shared Mesh")]
		[SerializeField]
		[WriteOnly]
		private MeshRef _getSharedMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_meshCollider, _getSharedMesh);
		}
		
		public override void Execute()
		{
			_getSharedMesh.Value = _meshCollider.Value.sharedMesh;
		}
		
		public override string GetSummary()
		{
			return "Get {_meshCollider} sharedMesh -> {_getSharedMesh}";
		}
	}
}

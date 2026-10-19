
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.MeshCollider)]
	[ActionDescription("The mesh object used for collision detection.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/MeshCollider-sharedMesh.html")]
	public sealed class MeshColliderSetSharedMesh : BaseAction
	{
		
		[Tooltip("The MeshCollider")]
		[SerializeField]
		private MeshColliderVar _meshCollider;
		
		[Tooltip("Set MeshCollider Shared Mesh")]
		[SerializeField, CanBeNullOrEmpty]
		private MeshVar _setSharedMesh;
		
		public override bool CanExecute()
		{
			return CheckParameters(_meshCollider);
		}
		
		public override void Execute()
		{
			_meshCollider.Value.sharedMesh = _setSharedMesh.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_meshCollider} Shared Mesh to {_setSharedMesh}";
		}
	}
}

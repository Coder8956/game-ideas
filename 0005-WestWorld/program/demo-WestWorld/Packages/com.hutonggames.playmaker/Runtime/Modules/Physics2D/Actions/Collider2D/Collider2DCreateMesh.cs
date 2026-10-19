
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Collider2D)]
	[ActionDescription("Creates a planar Mesh that is identical to the area defined by the Collider2D geo" +
		"metry.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Collider2D.CreateMesh.html")]
	public sealed class Collider2DCreateMesh : BaseAction
	{
		
		[Tooltip("The Collider2D.")]
		[SerializeField]
		private Collider2DVar _collider2D;
		
		[Tooltip("Should the mesh be transformed by the position of the attached Rigidbody2D?")]
		[SerializeField]
		private BoolVar _useBodyPosition;
		
		[Tooltip("Should the mesh be transformed by the rotation of the attached Rigidbody2D?")]
		[SerializeField]
		private BoolVar _useBodyRotation;
		
		[Tooltip("Store the result in Mesh variable.")]
		[SerializeField]
		[WriteOnly]
		private MeshRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_collider2D, _useBodyPosition, _useBodyRotation, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Collider2D.CreateMesh(System.Boolean, System.Boolean);
			_result.Value = _collider2D.Value.CreateMesh(_useBodyPosition.Value, _useBodyRotation.Value);
		}
		
		public override string GetSummary()
		{
			return "Create mesh from {_collider2D} {_useBodyPosition} {_useBodyRotation} -> {_result}";
		}
	}
}

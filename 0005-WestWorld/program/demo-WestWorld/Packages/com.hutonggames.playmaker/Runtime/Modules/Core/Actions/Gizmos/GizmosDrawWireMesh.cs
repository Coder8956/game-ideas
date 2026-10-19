
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Gizmos)]
	[ActionDescription("Draws a wireframe mesh.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Gizmos.DrawWireMesh.html")]
	public sealed class GizmosDrawWireMesh : BaseAction
	{
		
		[Tooltip("The Mesh to draw as a gizmo.")]
		[SerializeField]
		private MeshVar _mesh;
		
		[Tooltip("Submesh to draw (default is -1, which draws whole mesh).")]
		[SerializeField, DefaultValue(-1)]
		private IntegerVar _submeshIndex;
		
		[Tooltip("Position.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Rotation.")]
		[SerializeField]
		private QuaternionVar _rotation;
		
		[Tooltip("Scale.")]
		[SerializeField, DefaultValue("Vector3.one")]
		private Vector3Var _scale;
		
		public override bool CanExecute() => CheckParameters(_mesh, _submeshIndex, _position, _rotation, _scale);

#if UNITY_EDITOR
		
		public override bool HasGizmos => true;
		
		public override void OnDrawGizmosSelected()
		{
			Gizmos.DrawWireMesh(_mesh.Value, _submeshIndex.Value, _position.Value, _rotation.Value, _scale.Value);
		}
#endif
		
		public override string GetSummary() =>
			"Draw Wire Mesh: {_mesh}  Pos: {_position} " +
			(_rotation.Value != Quaternion.identity ? "Rot: {_rotation} " :"") +
			(_scale.Value != Vector3.one ? "Scale: {_scale} " : "") +
			(_submeshIndex.Value != -1 ? "Submesh: {_submeshIndex} " : "");
	}
}

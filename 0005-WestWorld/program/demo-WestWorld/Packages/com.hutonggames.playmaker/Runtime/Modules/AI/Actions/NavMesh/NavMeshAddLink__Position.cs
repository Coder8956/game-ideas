
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Adds a link to the NavMesh. The link is described by the NavMeshLinkData struct.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.AddLink.html")]
	public sealed class NavMeshAddLink__Position : BaseAction
	{
		
		[Tooltip("Object that describes the properties of the link.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshLinkDataRef _link;
		
		[Tooltip("Translate the link to this position.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Rotate the link to this orientation.")]
		[SerializeField]
		private QuaternionVar _rotation;
		
		[Tooltip("Object that identifies the added link.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshLinkInstanceRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_link, _position, _rotation, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.AddLink(UnityEngine.AI.NavMeshLinkData, UnityEngine.Vector3, UnityEngine.Quaternion);
			_result.Value = NavMesh.AddLink(_link.Value, _position.Value, _rotation.Value);
		}
		
		public override string GetSummary()
		{
			return "Add NavMesh link {_link} at {_position} {_rotation} -> {_result}";
		}
	}
}

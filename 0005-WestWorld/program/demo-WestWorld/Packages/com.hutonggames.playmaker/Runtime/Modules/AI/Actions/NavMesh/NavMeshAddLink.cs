
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Adds a link to the NavMesh. The link is described by the NavMeshLinkData struct.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.AddLink.html")]
	public sealed class NavMeshAddLink : BaseAction
	{
		
		[Tooltip("Object that describes the properties of the link.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshLinkDataRef _link;
		
		[Tooltip("Object that identifies the added link.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshLinkInstanceRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_link, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.AddLink(UnityEngine.AI.NavMeshLinkData);
			_result.Value = NavMesh.AddLink(_link.Value);
		}
		
		public override string GetSummary()
		{
			return "Add NavMesh link {_link} -> {_result}";
		}
	}
}

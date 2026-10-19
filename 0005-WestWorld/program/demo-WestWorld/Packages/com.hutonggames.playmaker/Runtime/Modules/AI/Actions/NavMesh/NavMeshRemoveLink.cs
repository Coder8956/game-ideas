
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Removes a link from the NavMesh.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.RemoveLink.html")]
	public sealed class NavMeshRemoveLink : BaseAction
	{
		
		[Tooltip("The instance of a link to remove.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshLinkInstanceRef _handle;
		
		public override bool CanExecute()
		{
			return CheckParameters(_handle);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.RemoveLink(UnityEngine.AI.NavMeshLinkInstance);
			NavMesh.RemoveLink(_handle.Value);
		}
		
		public override string GetSummary()
		{
			return "Remove NavMesh link {_handle}";
		}
	}
}

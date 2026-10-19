#if UNITY_6000_0_OR_NEWER
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Associates an object with the instance of a link.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.SetLinkOwner.html")]
	public sealed class NavMeshSetLinkOwner : BaseAction
	{
		
		[Tooltip("Handle.")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkInstanceRef _handle;
		
		[Tooltip("Owner.")]
		[SerializeField]
		private HutongGames.PlayMaker.ObjectVar _owner;
		
		public override bool CanExecute()
		{
			return CheckParameters(_handle, _owner);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.SetLinkOwner(UnityEngine.AI.NavMeshLinkInstance, UnityEngine.Object);
			UnityEngine.AI.NavMesh.SetLinkOwner(_handle.Value, _owner.Value);
		}
		
		public override string GetSummary()
		{
			return "Set NavMesh link {_handle} owner to {_owner}";
		}
	}
}
#endif

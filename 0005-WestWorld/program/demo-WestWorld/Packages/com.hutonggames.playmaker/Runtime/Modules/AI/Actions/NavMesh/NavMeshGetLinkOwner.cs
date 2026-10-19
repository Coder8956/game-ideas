#if UNITY_6000_0_OR_NEWER
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Gets the object, if any, that is associated with the link instance.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.GetLinkOwner.html")]
	public sealed class NavMeshGetLinkOwner : BaseAction
	{
		
		[Tooltip("Handle.")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkInstanceRef _handle;
		
		[Tooltip("Store the result in Object variable.")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.ObjectRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_handle, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.GetLinkOwner(UnityEngine.AI.NavMeshLinkInstance);
			_result.Value = UnityEngine.AI.NavMesh.GetLinkOwner(_handle.Value);
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh link owner {_handle} -> {_result}";
		}
	}
}
#endif

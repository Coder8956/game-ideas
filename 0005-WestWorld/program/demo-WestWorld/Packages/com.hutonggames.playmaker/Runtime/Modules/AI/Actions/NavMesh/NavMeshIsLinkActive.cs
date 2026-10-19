#if UNITY_6000_0_OR_NEWER
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Determines whether the instance of the link can be used to calculate paths, and if NavMesh agents can move over it.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.IsLinkActive.html")]
	public sealed class NavMeshIsLinkActive : BaseAction
	{
		
		[Tooltip("Handle.")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkInstanceRef _handle;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.BoolRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_handle, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.IsLinkActive(UnityEngine.AI.NavMeshLinkInstance);
			_result.Value = UnityEngine.AI.NavMesh.IsLinkActive(_handle.Value);
		}
		
		public override string GetSummary()
		{
			return "Check NavMesh link {_handle} is active -> {_result}";
		}
	}
}
#endif

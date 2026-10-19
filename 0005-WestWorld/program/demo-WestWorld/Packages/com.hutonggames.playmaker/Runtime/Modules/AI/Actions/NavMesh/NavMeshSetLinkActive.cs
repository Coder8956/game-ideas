#if UNITY_6000_0_OR_NEWER
using System;
using UnityEngine;
using UnityEngine.AI;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Activates or deactivates the link instance. An active link instance can be traversed by agents and used to plan paths, but a deactivated link cannot.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.SetLinkActive.html")]
	public sealed class NavMeshSetLinkActive : BaseAction
	{
		
		[Tooltip("Handle.")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Actions.AI.NavMeshLinkInstanceRef _handle;
		
		[Tooltip("Value.")]
		[SerializeField]
		private HutongGames.PlayMaker.BoolVar _value;
		
		public override bool CanExecute()
		{
			return CheckParameters(_handle, _value);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.SetLinkActive(UnityEngine.AI.NavMeshLinkInstance, System.Boolean);
			UnityEngine.AI.NavMesh.SetLinkActive(_handle.Value, _value.Value);
		}
		
		public override string GetSummary()
		{
			return "Set NavMesh link {_handle} active to {_value}";
		}
	}
}
#endif

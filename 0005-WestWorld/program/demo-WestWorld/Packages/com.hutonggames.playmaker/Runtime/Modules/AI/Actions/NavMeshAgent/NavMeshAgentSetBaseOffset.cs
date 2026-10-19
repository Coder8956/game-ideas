
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("The relative vertical displacement of the owning GameObject.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent-baseOffset.html")]
	public sealed class NavMeshAgentSetBaseOffset : BaseAction
	{
		
		[Tooltip("The NavMeshAgent")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Set NavMeshAgent Base Offset")]
		[SerializeField]
		private FloatVar _setBaseOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _setBaseOffset);
		}
		
		public override void Execute()
		{
			_navMeshAgent.Value.baseOffset = _setBaseOffset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} base offset to {_setBaseOffset}";
		}
	}
}

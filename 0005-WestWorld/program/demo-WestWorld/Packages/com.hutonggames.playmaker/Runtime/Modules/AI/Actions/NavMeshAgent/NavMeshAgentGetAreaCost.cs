
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Gets the cost for path calculation when crossing area of a particular type.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.GetAreaCost.html")]
	public sealed class NavMeshAgentGetAreaCost : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Area Index.")]
		[SerializeField]
		private IntegerVar _areaIndex;
		
		[Tooltip("Current cost for specified area index.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _areaIndex, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.GetAreaCost(System.Int32);
			_result.Value = _navMeshAgent.Value.GetAreaCost(_areaIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshAgent} area cost {_areaIndex} -> {_result}";
		}
	}
}

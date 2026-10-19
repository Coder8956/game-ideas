
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshAgent)]
	[ActionDescription("Sets the cost for traversing over areas of the area type.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshAgent.SetAreaCost.html")]
	public sealed class NavMeshAgentSetAreaCost : BaseAction
	{
		
		[Tooltip("The NavMeshAgent.")]
		[SerializeField]
		private NavMeshAgentVar _navMeshAgent;
		
		[Tooltip("Area cost.")]
		[SerializeField]
		private IntegerVar _areaIndex;
		
		[Tooltip("New cost for the specified area index.")]
		[SerializeField]
		private FloatVar _areaCost;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshAgent, _areaIndex, _areaCost);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshAgent.SetAreaCost(System.Int32, System.Single);
			_navMeshAgent.Value.SetAreaCost(_areaIndex.Value, _areaCost.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshAgent} area cost {_areaIndex} to {_areaCost}";
		}
	}
}

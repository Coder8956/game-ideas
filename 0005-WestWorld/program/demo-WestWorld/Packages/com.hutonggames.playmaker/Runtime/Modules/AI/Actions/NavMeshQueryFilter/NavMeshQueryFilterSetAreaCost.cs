
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshQueryFilter)]
	[ActionDescription("Sets the pathfinding cost multiplier for this filter for a given area type.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshQueryFilter.SetAreaCost.html")]
	public sealed class NavMeshQueryFilterSetAreaCost : BaseAction
	{
		
		[Tooltip("The NavMeshQueryFilter.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshQueryFilterRef _navMeshQueryFilter;
		
		[Tooltip("The area index to set the cost for.")]
		[SerializeField]
		private HutongGames.PlayMaker.IntegerVar _areaIndex;
		
		[Tooltip("The cost for the supplied area index.")]
		[SerializeField]
		private HutongGames.PlayMaker.FloatVar _cost;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshQueryFilter, _areaIndex, _cost);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshQueryFilter.SetAreaCost(System.Int32, System.Single);
			_navMeshQueryFilter.Value.SetAreaCost(_areaIndex.Value, _cost.Value);
		}
		
		public override string GetSummary()
		{
			return "{_navMeshQueryFilter} set area cost {_areaIndex} {_cost} ";
		}
	}
}

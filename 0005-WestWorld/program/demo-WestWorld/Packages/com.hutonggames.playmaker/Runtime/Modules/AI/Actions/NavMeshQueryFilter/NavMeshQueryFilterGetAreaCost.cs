
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshQueryFilter)]
	[ActionDescription("Returns the area cost multiplier for the given area type for this filter.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshQueryFilter.GetAreaCost.html")]
	public sealed class NavMeshQueryFilterGetAreaCost : BaseAction
	{
		
		[Tooltip("The NavMeshQueryFilter.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshQueryFilterRef _navMeshQueryFilter;
		
		[Tooltip("Index to retreive the cost for.")]
		[SerializeField]
		private HutongGames.PlayMaker.IntegerVar _areaIndex;
		
		[Tooltip("The cost multiplier for the supplied area index.")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshQueryFilter, _areaIndex, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshQueryFilter.GetAreaCost(System.Int32);
			_result.Value = _navMeshQueryFilter.Value.GetAreaCost(_areaIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "{_navMeshQueryFilter} get area cost {_areaIndex} -> {_result}";
		}
	}
}

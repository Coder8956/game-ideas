
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshQueryFilter)]
	[ActionDescription("A bitmask representing the traversable area types.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshQueryFilter-areaMask.html")]
	public sealed class NavMeshQueryFilterGetAreaMask : BaseAction
	{
		
		[Tooltip("The NavMeshQueryFilter")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshQueryFilterRef _navMeshQueryFilter;
		
		[Tooltip("Get NavMeshQueryFilter Area Mask")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.IntegerRef _getAreaMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshQueryFilter, _getAreaMask);
		}
		
		public override void Execute()
		{
			this._getAreaMask.Value = this._navMeshQueryFilter.Value.areaMask;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshQueryFilter} Area Mask -> {_getAreaMask}";
		}
	}
}

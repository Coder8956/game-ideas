
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshQueryFilter)]
	[ActionDescription("A bitmask representing the traversable area types.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshQueryFilter-areaMask.html")]
	public sealed class NavMeshQueryFilterSetAreaMask : BaseAction
	{
		
		[Tooltip("The NavMeshQueryFilter")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshQueryFilterRef _navMeshQueryFilter;
		
		[Tooltip("Set NavMeshQueryFilter Area Mask")]
		[SerializeField]
		private HutongGames.PlayMaker.IntegerVar _setAreaMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshQueryFilter, _setAreaMask);
		}
		
		public override void Execute()
		{
			var value = this._navMeshQueryFilter.Value;
			value.areaMask = this._setAreaMask.Value;
			this._navMeshQueryFilter.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshQueryFilter} Area Mask to {_setAreaMask}";
		}
	}
}

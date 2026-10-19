/*
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Mask specifying NavMesh area at point of hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-mask.html")]
	public sealed class NavMeshHitSetMask : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Set NavMeshHit Mask")]
		[SerializeField]
		private HutongGames.PlayMaker.IntegerVar _setMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _setMask);
		}
		
		public override void Execute()
		{
			var value = this._navMeshHit.Value;
			value.mask = this._setMask.Value;
			this._navMeshHit.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshHit} Mask to {_setMask}";
		}
	}
}
*/
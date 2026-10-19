/*
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Flag set when hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-hit.html")]
	public sealed class NavMeshHitSetHit : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Set NavMeshHit Hit")]
		[SerializeField]
		private HutongGames.PlayMaker.BoolVar _setHit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _setHit);
		}
		
		public override void Execute()
		{
			var value = this._navMeshHit.Value;
			value.hit = this._setHit.Value;
			this._navMeshHit.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshHit} Hit to {_setHit}";
		}
	}
}
*/
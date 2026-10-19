/*
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Normal at the point of hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-normal.html")]
	public sealed class NavMeshHitSetNormal : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Set NavMeshHit Normal")]
		[SerializeField]
		private HutongGames.PlayMaker.Vector3Var _setNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _setNormal);
		}
		
		public override void Execute()
		{
			var value = this._navMeshHit.Value;
			value.normal = this._setNormal.Value;
			this._navMeshHit.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshHit} Normal to {_setNormal}";
		}
	}
}
*/
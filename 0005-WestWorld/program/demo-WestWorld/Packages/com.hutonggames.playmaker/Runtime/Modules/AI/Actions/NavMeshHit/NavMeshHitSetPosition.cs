/*
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Position of hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-position.html")]
	public sealed class NavMeshHitSetPosition : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Set NavMeshHit Position")]
		[SerializeField]
		private HutongGames.PlayMaker.Vector3Var _setPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _setPosition);
		}
		
		public override void Execute()
		{
			var value = this._navMeshHit.Value;
			value.position = this._setPosition.Value;
			this._navMeshHit.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshHit} Position to {_setPosition}";
		}
	}
}
*/
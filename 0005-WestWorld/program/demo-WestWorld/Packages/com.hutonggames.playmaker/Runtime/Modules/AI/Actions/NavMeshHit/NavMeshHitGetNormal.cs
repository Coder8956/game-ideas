
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshHit)]
	[ActionDescription("Normal at the point of hit.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshHit-normal.html")]
	public sealed class NavMeshHitGetNormal : BaseAction
	{
		
		[Tooltip("The NavMeshHit")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshHitRef _navMeshHit;
		
		[Tooltip("Get NavMeshHit Normal")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Vector3Ref _getNormal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshHit, _getNormal);
		}
		
		public override void Execute()
		{
			this._getNormal.Value = this._navMeshHit.Value.normal;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshHit} Normal -> {_getNormal}";
		}
	}
}

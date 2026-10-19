
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshDataInstance)]
	[ActionDescription("Get the owning Object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshDataInstance-owner.html")]
	public sealed class NavMeshDataInstanceGetOwner : BaseAction
	{
		
		[Tooltip("The NavMeshDataInstance")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshDataInstanceRef _navMeshDataInstance;
		
		[Tooltip("Get NavMeshDataInstance Owner")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.ObjectRef _getOwner;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshDataInstance, _getOwner);
		}
		
		public override void Execute()
		{
			this._getOwner.Value = this._navMeshDataInstance.Value.owner;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshDataInstance} Owner -> {_getOwner}";
		}
	}
}

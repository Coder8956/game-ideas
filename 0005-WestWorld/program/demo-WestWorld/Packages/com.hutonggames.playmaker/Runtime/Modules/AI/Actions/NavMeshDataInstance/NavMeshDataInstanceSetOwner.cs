
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshDataInstance)]
	[ActionDescription("Set the owning Object.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshDataInstance-owner.html")]
	public sealed class NavMeshDataInstanceSetOwner : BaseAction
	{
		
		[Tooltip("The NavMeshDataInstance")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshDataInstanceRef _navMeshDataInstance;
		
		[Tooltip("Set NavMeshDataInstance Owner")]
		[SerializeField]
		private HutongGames.PlayMaker.ObjectVar _setOwner;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshDataInstance, _setOwner);
		}
		
		public override void Execute()
		{
			var value = this._navMeshDataInstance.Value;
			value.owner = this._setOwner.Value;
			this._navMeshDataInstance.Value = value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshDataInstance} Owner to {_setOwner}";
		}
	}
}

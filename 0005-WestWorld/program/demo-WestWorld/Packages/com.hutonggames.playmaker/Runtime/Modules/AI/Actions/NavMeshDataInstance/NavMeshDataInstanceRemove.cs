
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshDataInstance)]
	[ActionDescription("Removes this instance from the NavMesh system.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshDataInstance.Remove.html")]
	public sealed class NavMeshDataInstanceRemove : BaseAction
	{
		
		[Tooltip("The NavMeshDataInstance.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshDataInstanceRef _navMeshDataInstance;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshDataInstance);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMeshDataInstance.Remove();
			_navMeshDataInstance.Value.Remove();
		}
		
		public override string GetSummary()
		{
			return "{_navMeshDataInstance} remove ";
		}
	}
}

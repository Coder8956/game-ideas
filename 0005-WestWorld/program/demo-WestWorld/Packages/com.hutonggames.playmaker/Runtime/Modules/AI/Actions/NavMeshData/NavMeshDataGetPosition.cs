
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshData)]
	[ActionDescription("Gets the world space position of the NavMesh data.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshData-position.html")]
	public sealed class NavMeshDataGetPosition : BaseAction
	{
		
		[Tooltip("The NavMeshData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshDataVar _navMeshData;
		
		[Tooltip("Get NavMeshData Position")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.Vector3Ref _getPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshData, _getPosition);
		}
		
		public override void Execute()
		{
			this._getPosition.Value = this._navMeshData.Value.position;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshData} Position -> {_getPosition}";
		}
	}
}

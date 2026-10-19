
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshData)]
	[ActionDescription("Sets the world space position of the NavMesh data.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshData-position.html")]
	public sealed class NavMeshDataSetPosition : BaseAction
	{
		
		[Tooltip("The NavMeshData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshDataVar _navMeshData;
		
		[Tooltip("Set NavMeshData Position")]
		[SerializeField]
		private HutongGames.PlayMaker.Vector3Var _setPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshData, _setPosition);
		}
		
		public override void Execute()
		{
			this._navMeshData.Value.position = this._setPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshData} Position to {_setPosition}";
		}
	}
}

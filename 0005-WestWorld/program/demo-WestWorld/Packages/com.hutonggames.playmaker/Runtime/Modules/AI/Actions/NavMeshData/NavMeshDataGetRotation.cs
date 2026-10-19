
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshData)]
	[ActionDescription("Gets the orientation of the NavMesh data.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshData-rotation.html")]
	public sealed class NavMeshDataGetRotation : BaseAction
	{
		
		[Tooltip("The NavMeshData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshDataVar _navMeshData;
		
		[Tooltip("Get NavMeshData Rotation")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.QuaternionRef _getRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshData, _getRotation);
		}
		
		public override void Execute()
		{
			this._getRotation.Value = this._navMeshData.Value.rotation;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshData} Rotation -> {_getRotation}";
		}
	}
}

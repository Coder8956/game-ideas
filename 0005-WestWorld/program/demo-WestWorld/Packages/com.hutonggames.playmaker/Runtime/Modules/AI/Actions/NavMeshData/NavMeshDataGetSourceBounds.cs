
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshData)]
	[ActionDescription("Returns the bounding volume of the input geometry used to build this NavMesh (Rea" +
		"d Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshData-sourceBounds.html")]
	public sealed class NavMeshDataGetSourceBounds : BaseAction
	{
		
		[Tooltip("The NavMeshData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshDataVar _navMeshData;
		
		[Tooltip("Get NavMeshData Source Bounds")]
		[SerializeField]
		[WriteOnly]
		private HutongGames.PlayMaker.BoundsRef _getSourceBounds;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshData, _getSourceBounds);
		}
		
		public override void Execute()
		{
			this._getSourceBounds.Value = this._navMeshData.Value.sourceBounds;
		}
		
		public override string GetSummary()
		{
			return "Get {_navMeshData} Source Bounds -> {_getSourceBounds}";
		}
	}
}

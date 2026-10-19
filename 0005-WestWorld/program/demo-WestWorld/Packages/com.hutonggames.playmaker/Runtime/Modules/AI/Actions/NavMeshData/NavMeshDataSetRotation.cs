
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMeshData)]
	[ActionDescription("Sets the orientation of the NavMesh data.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMeshData-rotation.html")]
	public sealed class NavMeshDataSetRotation : BaseAction
	{
		
		[Tooltip("The NavMeshData")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.AI.NavMeshDataVar _navMeshData;
		
		[Tooltip("Set NavMeshData Rotation")]
		[SerializeField]
		private HutongGames.PlayMaker.QuaternionRef _setRotation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_navMeshData, _setRotation);
		}
		
		public override void Execute()
		{
			this._navMeshData.Value.rotation = this._setRotation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_navMeshData} Rotation to {_setRotation}";
		}
	}
}

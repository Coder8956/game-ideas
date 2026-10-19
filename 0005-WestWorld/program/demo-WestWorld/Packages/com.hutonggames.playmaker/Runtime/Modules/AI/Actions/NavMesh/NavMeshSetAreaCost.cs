
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Sets the cost for finding path over geometry of the area type on all agents.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.SetAreaCost.html")]
	public sealed class NavMeshSetAreaCost : BaseAction
	{
		
		[Tooltip("Index of the area to set.")]
		[SerializeField]
		private IntegerVar _areaIndex;
		
		[Tooltip("New cost.")]
		[SerializeField]
		private FloatVar _cost;
		
		public override bool CanExecute()
		{
			return CheckParameters(_areaIndex, _cost);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.SetAreaCost(System.Int32, System.Single);
			UnityEngine.AI.NavMesh.SetAreaCost(_areaIndex.Value, _cost.Value);
		}
		
		public override string GetSummary()
		{
			return "Set NavMesh area cost {_areaIndex} to {_cost}";
		}
	}
}

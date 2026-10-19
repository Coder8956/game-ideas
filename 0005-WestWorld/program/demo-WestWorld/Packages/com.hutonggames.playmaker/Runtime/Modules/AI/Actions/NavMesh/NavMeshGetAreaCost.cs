
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Gets the cost for path finding over geometry of the area type.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.GetAreaCost.html")]
	public sealed class NavMeshGetAreaCost : BaseAction
	{
		
		[Tooltip("Index of the area to get.")]
		[SerializeField]
		private IntegerVar _areaIndex;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_areaIndex, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.GetAreaCost(System.Int32);
			_result.Value = UnityEngine.AI.NavMesh.GetAreaCost(_areaIndex.Value);
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh area cost {_areaIndex} -> {_result}";
		}
	}
}

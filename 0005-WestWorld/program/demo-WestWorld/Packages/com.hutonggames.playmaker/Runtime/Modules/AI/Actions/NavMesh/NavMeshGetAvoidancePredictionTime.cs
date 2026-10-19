
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Describes how far in the future the agents predict collisions for avoidance.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh-avoidancePredictionTime.html")]
	public sealed class NavMeshGetAvoidancePredictionTime : BaseAction
	{
		
		[Tooltip("Get NavMesh Avoidance Prediction Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAvoidancePredictionTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAvoidancePredictionTime);
		}
		
		public override void Execute()
		{
			_getAvoidancePredictionTime.Value = UnityEngine.AI.NavMesh.avoidancePredictionTime;
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh avoidance prediction time -> {_getAvoidancePredictionTime}";
		}
	}
}


using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Describes how far in the future the agents predict collisions for avoidance.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh-avoidancePredictionTime.html")]
	public sealed class NavMeshSetAvoidancePredictionTime : BaseAction
	{
		
		[Tooltip("Set NavMesh Avoidance Prediction Time")]
		[SerializeField, DefaultValue(2f)]
		private FloatVar _setAvoidancePredictionTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setAvoidancePredictionTime);
		}
		
		public override void Execute()
		{
			UnityEngine.AI.NavMesh.avoidancePredictionTime = _setAvoidancePredictionTime.Value;
		}
		
		public override string GetSummary()
		{
			return "Set NavMesh avoidance prediction time to {_setAvoidancePredictionTime}";
		}
	}
}

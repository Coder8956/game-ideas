
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.AI
{
	
	
	[Serializable]
	[ActionCategory(Category.AI.NavMesh)]
	[ActionDescription("Returns an existing entry of NavMesh build settings.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AI.NavMesh.GetSettingsByID.html")]
	public sealed class NavMeshGetSettingsByID : BaseAction
	{
		
		[Tooltip("The ID to look for.")]
		[SerializeField]
		private IntegerVar _agentTypeID;
		
		[Tooltip("The settings found.")]
		[SerializeField]
		[WriteOnly]
		private NavMeshBuildSettingsRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_agentTypeID, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.AI.NavMesh.GetSettingsByID(System.Int32);
			_result.Value = UnityEngine.AI.NavMesh.GetSettingsByID(_agentTypeID.Value);
		}
		
		public override string GetSummary()
		{
			return "Get NavMesh settings by ID {_agentTypeID} -> {_result}";
		}
	}
}
